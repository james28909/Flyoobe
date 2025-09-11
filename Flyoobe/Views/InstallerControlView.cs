using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class InstallerControlView : UserControl, IView
    {
        public string ViewTitle => "Install Essential Apps";
        private bool autoAcceptAgreements = false;

        private List<string> allApps;

        public InstallerControlView()
        {
            InitializeComponent();
            assetViewInfo.Text = "\uE71D";
            InitializeAppList();
        }

        private void InitializeAppList()
        {
            allApps = new List<string>
            {
                "7zip.7zip",
                "RARLab.WinRAR",
                "Giorgiotani.Peazip",

                "Spotify.Spotify",
                "VideoLAN.VLC",
                "Audacity.Audacity",

                "Git.Git",
                "GitHub.GitHubDesktop",
                "Fork.Fork",

                "Notepad++.Notepad++",
                "Obsidian.Obsidian",
                "Microsoft.VisualStudio.2022.Community.Preview",
                "Microsoft.VisualStudioCode",
                "Discord.Discord",
                "SlackTechnologies.Slack",
                "Telegram.TelegramDesktop",
                "Signal.Signal",
                "Microsoft.Teams",
                "Zoom.Zoom",

                "Dropbox.Dropbox",
                "Google.Drive",

                "BleachBit.BleachBit",
                "Microsoft.PowerToys",
                "StartIsBack.StartAllBack",

                "Adobe.AdobeAcrobatReaderDC",
                "Foxit.FoxitReader",

                "KeePass.KeePass",
                "Bitwarden.Bitwarden",
                "LastPass.LastPass",

                "GIMP.GIMP",
                "IrfanSkiljan.IrfanView",
                "Inkscape.Inkscape",
                "KDE.Krita",
                "dotPDNLLC.paintdotnet"

            };


            RefreshAppList(allApps);
        }

        private void RefreshAppList(IEnumerable<string> apps)
        {
            checkedListBoxApps.Items.Clear();
            foreach (var app in apps)
            {
                checkedListBoxApps.Items.Add(app);
            }
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {

            if (checkedListBoxApps.CheckedItems.Count == 0)
            {
                lblStatus.Text = "No apps selected.";
                return;
            }

            var result = MessageBox.Show(
    "Some apps may require license agreement acceptance. Do you want to automatically accept all agreements?",
    "Confirm License Agreements",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);
            autoAcceptAgreements = result == DialogResult.Yes;

            btnInstall.Enabled = false;
            textSearch.Enabled = false;
            checkedListBoxApps.Enabled = false;

            progressBar.Visible = true;
            progressBar.Maximum = checkedListBoxApps.CheckedItems.Count;
            progressBar.Value = 0;

            lblStatus.Text = $"Installing {checkedListBoxApps.CheckedItems.Count} apps...";

            foreach (var item in checkedListBoxApps.CheckedItems)
            {
                string appId = item.ToString();
                lblStatus.Text = $"Installing {appId}...";
                Logger.Log($"Installing {appId}...", LogLevel.Info);
                await Task.Run(() => InstallApp(appId));


                progressBar.Invoke((Action)(() =>
                {
                    progressBar.PerformStep();
                }));
            }

            lblStatus.Text = "Installation of selected apps completed.";

            btnInstall.Enabled = true;
            textSearch.Enabled = true;
            checkedListBoxApps.Enabled = true;
            progressBar.Visible = false;
        }

        private void InstallApp(string appId)
        {
            string extraArgs = autoAcceptAgreements
                ? "--accept-package-agreements --accept-source-agreements"
                : "";

      
            ProcessStartInfo psi = new ProcessStartInfo("powershell",
                $"-Command \"winget install --id {appId} -e --silent {extraArgs}\"")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Alternate!
            //winget install --id {appId} -e --silent --accept-package-agreements --accept-source-agreements

            using (Process process = new Process { StartInfo = psi, EnableRaisingEvents = true })
            {
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        UpdateStatusSafe(e.Data);
                       // Logger.Log(e.Data, LogLevel.Warning);
                    }
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        UpdateStatusSafe("[Error] " + e.Data);
                        Logger.Log(e.Data, LogLevel.Error);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
            }
        }


        private void UpdateStatusSafe(string message)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke((Action)(() => lblStatus.Text = message));
            }
            else
            {
                lblStatus.Text = message;
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string query = textSearch.Text.Trim().ToLower();
            var filteredApps = allApps.Where(app => app.ToLower().Contains(query));
            RefreshAppList(filteredApps);
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Clear();
        }

        public void RefreshView()

        {
            textSearch.Clear();

            foreach (int index in checkedListBoxApps.CheckedIndices)
            {
                checkedListBoxApps.SetItemChecked(index, false);
            }
            lblStatus.Text = "Ready.";
        }
    }
}