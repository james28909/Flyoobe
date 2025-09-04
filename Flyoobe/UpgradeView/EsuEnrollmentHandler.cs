
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

public class EsuEnrollmentHandler
{
    /// <summary>
    /// Keep Windows 10 secure until 2026 (Enroll in ESU) using abbodi1406's ConsumerESU scripts.
    /// Downloads from GitHub if missing and executes.
    /// </summary>
    /// 
    public static async Task HandleEnrollInESU()
    {
        string repoBase = "https://raw.githubusercontent.com/abbodi1406/ConsumerESU/master/";
        string cmdFile = "Consumer_ESU_Enrollment_run.cmd";
        string psFile = "Consumer_ESU_Enrollment.ps1";

        string appDir = AppDomain.CurrentDomain.BaseDirectory;
        string cmdPath = Path.Combine(appDir, cmdFile);
        string psPath = Path.Combine(appDir, psFile);

        // Ensure scripts exist (download if missing)
        if (!File.Exists(cmdPath) || !File.Exists(psPath))
        {
            var confirm = MessageBox.Show(
                "The ESU enrollment scripts are missing.\n\n" +
                "They will be downloaded directly from GitHub (abbodi1406/ConsumerESU).\n\n" +
                "Do you want to continue?",
                "Download Scripts",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (var wc = new WebClient())
            {
                try
                {
                    if (!File.Exists(cmdPath))
                        await wc.DownloadFileTaskAsync(new Uri(repoBase + cmdFile), cmdPath);
                    if (!File.Exists(psPath))
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

        // Show parameter selection dialog
        string esuArgs = "";
        using (var dlg = new EsuParamDialog())
        {
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            esuArgs = dlg.SelectedParam;
            if (dlg.AddProceed) esuArgs += " -Proceed";
        }

        // Confirm and run
        var result = MessageBox.Show(
            "This will launch the Consumer ESU Enrollment Tool with parameters:\n\n" +
            esuArgs + "\n\nContinue?",
            "Enroll in ESU",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

        if (result != DialogResult.Yes) return;

        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c \"" + cmdPath + "\" " + esuArgs,
                WorkingDirectory = appDir,
                UseShellExecute = true,
                Verb = "runas" // run as admin
            };
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to run ESU enrollment script:\n" + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Dialog form to select ESU enrollment parameter (no-designer)
    /// </summary>
    private class EsuParamDialog : Form
    {
        private ComboBox combo;
        private CheckBox chkProceed;
        private Button btnOk;
        private Button btnCancel;
        private LinkLabel link;

        public string SelectedParam { get; private set; }
        public bool AddProceed { get; private set; }

        public EsuParamDialog()
        {
            Text = "Select ESU Enrollment Parameter";
            Width = 550;
            Height = 250;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;

            combo = new ComboBox
            {
                Left = 20,
                Top = 20,
                Width = 500,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo.Items.AddRange(new object[]
            {
                "-Online   : Only enroll using Microsoft user account token (exit if failed)",
                "-Store    : Only enroll using Microsoft store account token (exit if failed)",
                "-Local    : Only enroll using Local user account token (exit if failed)",
                "-License  : Force acquire Consumer ESU License regardless or without enrollment",
                "-Remove   : Remove Consumer ESU License if exists"
            });
            combo.SelectedIndex = 0;

            chkProceed = new CheckBox
            {
                Left = 20,
                Top = 60,
                Text = "Add -Proceed (force running enrollment even if already enrolled)",
                AutoSize = true
            };

            btnOk = new Button
            {
                Text = "OK",
                Left = 340,
                Width = 80,
                Top = 150,
                DialogResult = DialogResult.OK
            };
            btnCancel = new Button
            {
                Text = "Cancel",
                Left = 430,
                Width = 80,
                Top = 150,
                DialogResult = DialogResult.Cancel
            };

            link = new LinkLabel
            {
                Left = 20,
                Top = 100,
                AutoSize = true,
                Text = "Help && Credits: https://github.com/abbodi1406/ConsumerESU"
            };
            link.LinkClicked += (s, e) =>
            {
                try { Process.Start(new ProcessStartInfo { FileName = "https://github.com/abbodi1406/ConsumerESU", UseShellExecute = true }); }
                catch { }
            };

            Controls.Add(combo);
            Controls.Add(chkProceed);
            Controls.Add(link);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);

            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                // Extract only the switch (first word, e.g. "-Online")
                SelectedParam = combo.SelectedItem.ToString().Split(' ')[0];
                AddProceed = chkProceed.Checked;
            }
            base.OnClosing(e);
        }
    }
}

