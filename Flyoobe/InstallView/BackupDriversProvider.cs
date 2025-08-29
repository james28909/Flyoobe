using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Flyoobe
{
    // Native provider that exports all installed drivers to C:\DriversBackup using:
    //   pnputil.exe /export-driver * C:\DriversBackup

    public sealed class BackupDriversProvider : IInstallProvider
    {
        public string Id => "drivers-backup";
        public string DisplayName => "Backup installed drivers (exports to C:\\DriversBackup)";
        public string HomepageUrl => null;
        public string DirectDownloadUrl => null;
        public string[] ExactExeNames => new[] { "pnputil.exe" };
        public string[] WildcardExePatterns => Array.Empty<string>();
        public bool TypicallyNeedsIso => false;
        public bool IsExternalTool => false;

        public string Hint =>
            "Exports all currently installed device drivers (INF + binaries) to C:\\DriversBackup. " +
            "After a clean install, point Device Manager to this folder to restore drivers even without internet.";

        public string ShowOptionsAndBuildArgs(IWin32Window owner, LastSelections last)
        {
            const string target = @"C:\DriversBackup";

            if (!ToolHelpers.Confirm(owner,
                "Export all installed drivers to:\r\n\r\n" + target +
                "\r\n\r\nThis runs 'pnputil /export-driver *' with administrative rights."))
                return null;

            try
            {
                Directory.CreateDirectory(target);
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner,
                    "Could not create target folder:\r\n" + target + "\r\n\r\n" + ex.Message,
                    "Folder error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                // Start pnputil as elevated process
                var psi = new ProcessStartInfo
                {
                    FileName = "pnputil.exe",
                    Arguments = "/export-driver * \"" + target + "\"",
                    UseShellExecute = true,
                    Verb = "runas", // force elevation
                    CreateNoWindow = true
                };

                using (var proc = Process.Start(psi))
                {
                    if (proc == null)
                    {
                        MessageBox.Show(owner, "Could not start pnputil.exe", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    proc.WaitForExit();
                }

                // Now export is complete > count drivers
                int infCount = 0;
                try
                {
                    infCount = Directory.GetFiles(target, "*.inf", SearchOption.AllDirectories).Length;
                }
                catch { /* ignore */ }

                MessageBox.Show(owner,
                    "Driver export completed.\r\n\r\n" +
                    $"Target: {target}\r\n" +
                    $"Exported driver packages: {infCount}\r\n\r\n" +
                    "Tip: After reinstall, in Device Manager choose 'Update driver' → 'Browse my computer' " +
                    "and select this folder to restore drivers.",
                    "Export complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner,
                    "Failed to run pnputil:\r\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; 
        }
    }
}
