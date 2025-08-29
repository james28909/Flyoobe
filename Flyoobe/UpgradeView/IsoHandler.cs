using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Flyoobe
{
    public class IsoHandler
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly Action<string> _updateStatus;

        public IsoHandler(Action<string> updateStatus)
        {
            _updateStatus = updateStatus;
        }

        public async Task HandleIso(string isoPath, bool experimentalEnabled)
        {
            try
            {
                // Block Win10 ISOs
                string isoFileName = Path.GetFileName(isoPath);
                if (Regex.IsMatch(isoFileName, @"(?i)(win10|windows\s*10)"))
                {
                    _updateStatus("Error: Windows 10 ISOs are not supported.");
                    MessageBox.Show("Windows 10 ISOs are not supported. Please use a Windows 11 ISO.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _updateStatus("Mounting the ISO...");

                // Ensure the ISO path is properly quoted
                string quotedIsoPath = $"\"{isoPath}\"";

                // Pass the quoted path to ExecutePowerShellCommand
                string driveLetter = await MountIsoAndGetDriveLetter(isoPath);
                if (string.IsNullOrEmpty(driveLetter))
                {
                    HandleException(new InvalidOperationException("ISO mounting returned no drive letter."),
                                    "Failed to mount the ISO. Please try again.");
                    return;
                }

                _updateStatus("ISO mounted successfully! Let's get this Windows 11 ready!");

                string setupPath = Path.Combine(driveLetter, "sources", "setupprep.exe");
                if (System.IO.File.Exists(setupPath))
                {
                    await RunSetupWithAdminRights(setupPath, experimentalEnabled);
                }
                else
                {
                    HandleException(new FileNotFoundException($"Setup file not found in {driveLetter}."),
                                    "The setup file could not be found on the mounted ISO.");
                }
            }
            catch (Exception ex)
            {
                _updateStatus($"Oops! Something went wrong: {ex.Message}");
                HandleException(ex, "An error occurred during ISO processing.");
            }
        }

        private async Task<string> MountIsoAndGetDriveLetter(string isoPath)
        {
            try
            {
                _updateStatus("Mounting ISO...");

                string script = $@"
try {{
    $iso = Mount-DiskImage -ImagePath '{isoPath}' -PassThru -ErrorAction Stop
    $volumes = Get-Volume -DiskImage $iso -ErrorAction Stop

    # get drive letter, but only if one exists
    $driveLetter = ($volumes | Where-Object {{ $_.DriveLetter }} | Select-Object -First 1).DriveLetter

    if (-not $driveLetter) {{
        throw 'iso mounted but no drive letter was assigned.'
    }}

    # return the drive letter (e.g. 'D:')
    $driveLetter
}} catch {{
    Write-Error $_.Exception.Message
    exit 1 # indicate an error
}}
";

                using (var process = new Process())
                {
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();

                    await process.WaitForExitAsync();

                    if (process.ExitCode != 0 || !string.IsNullOrWhiteSpace(error))
                    {
                        _updateStatus($"PowerShell error during mount: {error.Trim()}");
                        Logger.Log($"PowerShell error during mount: {error.Trim()}", LogLevel.Error);
                        MessageBox.Show($"PowerShell error during mount: {error.Trim()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    string driveLetter = output.Trim();
                    if (!string.IsNullOrWhiteSpace(driveLetter))
                    {
                        // Ensure the drive letter format is correct (e.g., "D:")
                        if (!driveLetter.EndsWith(":") && driveLetter.Length == 1)
                        {
                            driveLetter += ":";
                        }
                        _updateStatus($"ISO mounted successfully at {driveLetter}\\");
                        return $"{driveLetter}\\";
                    }
                    else
                    {
                        _updateStatus("Failed to retrieve drive letter after mounting ISO. Output was empty.");

                        Logger.Log("Failed to retrieve drive letter after mounting ISO. Output was empty.", LogLevel.Error);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _updateStatus("Exception during mounting: " + ex.Message);
                HandleException(ex, "An error occurred while mounting the ISO.");
                return null;
            }
        }

        private async Task RunSetupWithAdminRights(string setupPath, bool experimentalEnabled)
        {
            try
            {
                _updateStatus("Starting the setup process with elevated privileges...");

                // Default argument
                string arguments = "/Product Server";

                // If experimental mode is enabled, append additional setup parameters
                if (experimentalEnabled)
                {
                    arguments += " /Compat IgnoreWarning /MigrateDrivers All";
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Start-Process '{setupPath}' -ArgumentList '{arguments}' -Verb runas\"",
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = false
                };

                _updateStatus("Almost there! We're getting the setup ready...");

                using (var process = Process.Start(startInfo))
                {
                    if (process != null)
                    {
                        await process.WaitForExitAsync();
                    }
                }
                // Final status message
                string finalStatus = "You're ready to install Windows 11 on unsupported hardware! Ignore the 'Windows Server' prompt; you're all set!";

                if (experimentalEnabled)
                {
                    finalStatus += " (Advanced mode enabled: Compatibility checks bypassed)";
                }

                _updateStatus(finalStatus);

                MessageBox.Show("Windows 11 installation can now proceed. Please follow the instructions in the setup window.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _updateStatus($"Error: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create unattend.xml file in the sources\$OEM$\$$\Panther directory
        /// </summary>
        /// <param name="usbDrive">The USB drive where the unattend.xml will be created.</param>
        public void CreateUnattendXml(string usbDrive)
        {
            string unattendDir = Path.Combine(usbDrive, "sources", "$OEM$", "$$", "Panther");
            Directory.CreateDirectory(unattendDir); // Create the directory if it doesn't exist

            string unattendPath = Path.Combine(unattendDir, "unattend.xml");

            // Check if the file already exists
            if (!System.IO.File.Exists(unattendPath))
            {
                // Create the unattend.xml content
                string xmlContent = @"<unattend xmlns='urn:schemas-microsoft-com:unattend'>
<settings pass='disabled'>
<component xmlns:wcm='http://schemas.microsoft.com/WMIConfig/2002/State' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' name='Microsoft-Windows-Setup' processorArchitecture='amd64' language='neutral' publicKeyToken='31bf3856ad364e35' versionScope='nonSxS'>
<UserData>
<ProductKey>
<Key/>
</ProductKey>
</UserData>
<RunSynchronous>
<RunSynchronousCommand wcm:action='add'>
<Order>1</Order>
<Path>reg add HKLM\SYSTEM\Setup\LabConfig /v BypassTPMCheck /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
<RunSynchronousCommand wcm:action='add'>
<Order>2</Order>
<Path>reg add HKLM\SYSTEM\Setup\LabConfig /v BypassSecureBootCheck /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
<RunSynchronousCommand wcm:action='add'>
<Order>3</Order>
<Path>reg add HKLM\SYSTEM\Setup\LabConfig /v BypassRAMCheck /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
</RunSynchronous>
</component>
</settings>
<settings pass='specialize'>
<component xmlns:wcm='http://schemas.microsoft.com/WMIConfig/2002/State' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' name='Microsoft-Windows-Deployment' processorArchitecture='amd64' language='neutral' publicKeyToken='31bf3856ad364e35' versionScope='nonSxS'>
<RunSynchronous>
<RunSynchronousCommand wcm:action='add'>
<Order>1</Order>
<Path>reg add HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE /v BypassNRO /t REG_DWORD /d 1 /f</Path>
</RunSynchronousCommand>
</RunSynchronous>
</component>
</settings>
</unattend>";

                System.IO.File.WriteAllText(unattendPath, xmlContent);
                _updateStatus("Created unattend.xml in the sources\\$OEM$\\$$\\Panther directory.");
            }
            else
            {
                _updateStatus("unattend.xml already exists in the sources\\$OEM$\\$$\\Panther directory.");

                // Display a message box to inform the user
                MessageBox.Show("The patch has already been applied. The 'unattend.xml' file already exists in the specified directory.",
                                "Patch Already Applied",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the event for the compatibility patch.
        /// </summary>
        public void HandleCompatibilityPatch()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                /* Select the USB drive containing your Windows 11 installation files. " +
                "This feature adds a compatibility patch to bypass certain system requirements. " +
                "Compatible with drives prepared by any tool, including Rufus. Ensure the drive is ready! */

                folderDialog.Description = "Select the USB drive containing your Windows 11 installation files.\n" +
                    "This feature adds a compatibility patch to bypass certain system requirements.\n" +
                    "Compatible with drives prepared by any tool, including Rufus. Ensure the drive is ready!";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    var driveInfo = new DriveInfo(Path.GetPathRoot(selectedPath));

                    if (driveInfo.DriveType == DriveType.Removable && driveInfo.IsReady)
                    {
                        if (MessageBox.Show("This will apply compatibility bypass settings on the selected USB drive. Continue ?",
                            "Apply Bypass Patch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                CreateUnattendXml(selectedPath);
                                MessageBox.Show("Bypass patch applied successfully!", "Apply Bypass Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Logger.Log("Bypass patch applied successfully!");
                            }
                            catch (Exception ex)
                            {
                                Logger.Log($"{"Failed to apply bypass patch:"} {ex.Message}", LogLevel.Error);
                            }
                        }
                        else
                        {
                            Logger.Log("Bypass patch canceled by user.", LogLevel.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected path is not a removable drive. Please select a USB drive.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Logger.Log("User attempted to select a non-removable drive.", LogLevel.Error);
                    }
                }
                else
                {
                    Logger.Log("No USB drive selected for patching.", LogLevel.Error);
                }
            }
        }

        /// <summary>
        /// Handles the process of downloading the Media Creation Tool and optionally running it.
        /// </summary>
        public void HandleMediaCreationToolDownload()
        {
            var infoResult = MessageBox.Show(
                "With the Media Creation Tool, you can upgrade your PC or create an ISO.\n\nIn the 'Choose which media to use' step, select 'ISO file'.\n\nWould you like to watch a tutorial first?",
                "Media Creation Tool",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (infoResult == DialogResult.Yes)
            {
                Process.Start("https://www.youtube.com/watch?v=dNl1FHajW9w");
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Save Media Creation Tool";
                saveDialog.Filter = "Executable|*.exe";
                saveDialog.FileName = "MediaCreationTool.exe";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile("https://go.microsoft.com/fwlink/?linkid=2156295", saveDialog.FileName);
                            MessageBox.Show("Tool downloaded successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            var run = MessageBox.Show("Do you want to run it now?", "Run Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (run == DialogResult.Yes)
                            {
                                Process.Start(saveDialog.FileName);
                            }

                            _updateStatus("Media Creation Tool downloaded and optionally launched.");
                        }
                        catch (Exception ex)
                        {
                            _updateStatus("Failed to download Media Creation Tool: " + ex.Message);
                            MessageBox.Show("Download failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Logger.Log($"Failed to download Media Creation Tool: {ex.Message}", LogLevel.Error);
                        }
                    }
                }
                else
                {
                    _updateStatus("Media Creation Tool download canceled.");
                }
            }
        }

        /// <summary>
        /// Downloads and launches the Fido PowerShell script for advanced ISO selection.
        /// </summary>
        public void DownloadAndRunFidoScript(string scriptUrl)
        {
            string tempScript = Path.Combine(Path.GetTempPath(), "Fido.ps1");

            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(scriptUrl, tempScript);
                    _updateStatus("Fido script downloaded successfully. Launching PowerShell...");

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-ExecutionPolicy Bypass -File \"{tempScript}\"",
                        Verb = "runas",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    _updateStatus("Error downloading or running Fido script: " + ex.Message);
                    Logger.Log($"Error downloading or running Fido script: {ex.Message}", LogLevel.Error);
                }
            }
        }

        /// <summary>
        /// Keep Windows 10 secure until 2026 (Enroll in ESU) using abbodi1406's ConsumerESU scripts.
        /// Downloads from GitHub if missing and executes.
        /// </summary>
        public async void HandleEnrollInESU()
        {
            string repoBase = "https://raw.githubusercontent.com/abbodi1406/ConsumerESU/master/";
            string cmdFile = "Consumer_ESU_Enrollment_run.cmd";
            string psFile = "Consumer_ESU_Enrollment.ps1";

            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string cmdPath = Path.Combine(appDir, cmdFile);
            string psPath = Path.Combine(appDir, psFile);

            // Check if scripts exist, otherwise download
            if (!System.IO.File.Exists(cmdPath) || !System.IO.File.Exists(psPath))
            {
                var confirm = MessageBox.Show(
                    "The ESU enrollment scripts are missing.\n\n" +
                    "They will now be downloaded directly from GitHub (abbodi1406/ConsumerESU).\n\n" +
                    "Do you want to continue?",
                    "Download Scripts",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                using (var wc = new System.Net.WebClient())
                {
                    try
                    {
                        if (!System.IO.File.Exists(cmdPath))
                            await wc.DownloadFileTaskAsync(new Uri(repoBase + cmdFile), cmdPath);

                        if (!System.IO.File.Exists(psPath))
                            await wc.DownloadFileTaskAsync(new Uri(repoBase + psFile), psPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to download ESU scripts:\n" + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            var result = MessageBox.Show(
                "📦 This will now launch the Consumer ESU Enrollment Tool by abbodi1406.\n\n" +
                "✔ Extends Windows 10 support until October 2026\n" +
                "✔ Requires Windows 10 22H2 with KB5039299+ (19045.4598+)\n" +
                "✔ Requires Microsoft Account + Internet access\n\n" +
                "Do you want to continue?",
                "Enroll in ESU",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result != DialogResult.Yes)
                return;

            // Start the .cmd (which internally calls the PowerShell)
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = cmdPath,
                    Verb = "runas",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run ESU enrollment script:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle unexpected exceptions by logging the error, updating the status, and optionally launching Copilot for help.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="userContext"></param>
        private void HandleException(Exception ex, string userContext = "An unexpected error occurred.")
        {
            string fullMessage = $"{userContext}\n\n{ex.Message}\n\nThe error has been copied to your clipboard.";

            // Clipboard sicher setzen über STA-Thread
            Thread clipboardThread = new Thread(() => Clipboard.SetText(ex.ToString()));
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.Start();
            clipboardThread.Join();

            _updateStatus(userContext);
            Logger.Log($"{userContext}: {ex}", LogLevel.Error);

            var result = MessageBox.Show(
                fullMessage + "\n\nWould you like to ask Copilot for help?",
                "Something Went Wrong",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                CopilotHelper.LaunchCopilot();
            }
        }
    }

    public static class ProcessExtensions
    {
        public static async Task WaitForExitAsync(this Process process)
        {
            var tcs = new TaskCompletionSource<bool>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(true);
            await tcs.Task;
        }
    }
}