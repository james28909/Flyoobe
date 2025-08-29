using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            linkAppVersion.Text = $"You have Flyoobe version {Program.GetAppVersion()}\n" +
                "(Fetching updates...)";

            btnClose.Text = "\uEF2C";
            ApplyRoundedCorners();
            chkDonated.Checked = DonationHelper.HasDonated();
        }

        private async void AboutForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            // Call update check when form loads
            await CheckForUpdateAsync();
        }

        private void ApplyRoundedCorners()
        {
            int radius = 60; // Corner radius
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // top-left
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // top-right
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // bottom-right
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // bottom-left
            path.CloseFigure();

            this.Region = new Region(path); // Apply the rounded shape
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedCorners(); // Reapply on resize
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = 45;
            int borderWidth = 1;

            // Adjust drawing rectangle
            var rect = new Rectangle(borderWidth / 2, borderWidth / 2, Width - borderWidth, Height - borderWidth);
            radius = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2); // Clamp radius

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawPath(new Pen(Color.Gray, borderWidth), path); // Draw border

            this.Region = new Region(path); // apply rounded region
        }

        private void btnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/Flyby11");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG",
                UseShellExecute = true
            });
        }

        private void chkDonated_CheckedChanged(object sender, EventArgs e)
        {
            DonationHelper.SetDonationStatus(chkDonated.Checked);
        }

        private Version NormalizeVersionString(string version)
        {
            // Split by dot
            var parts = version.Split('.');
            // Add missing zeros to have at least 3 parts
            while (parts.Length < 3)
            {
                version += ".0";
                parts = version.Split('.');
            }
            return Version.Parse(version);
        }

        private async Task CheckForUpdateAsync()
        {
            const string githubApiUrl = "https://api.github.com/repos/builtbybel/Flyby11/releases/latest";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("FlyoobeUpdateChecker");

                    var response = await client.GetAsync(githubApiUrl);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    const string tagKey = "\"tag_name\":\"";
                    int index = json.IndexOf(tagKey);
                    if (index < 0)
                    {
                        UpdateLabel($"Flyoobe v{Program.GetAppVersion()}");
                        return;
                    }

                    int start = index + tagKey.Length;
                    int end = json.IndexOf("\"", start);
                    if (end <= start)
                    {
                        UpdateLabel($"Flyoobe version {Program.GetAppVersion()}");
                        return;
                    }

                    string latestTag = json.Substring(start, end - start);

                    if (latestTag.StartsWith("v"))
                        latestTag = latestTag.Substring(1);

                    string currentVersionString = Program.GetAppVersion();

                    Version latestVersion = NormalizeVersionString(latestTag);
                    Version currentVersion = NormalizeVersionString(currentVersionString);

                    if (latestVersion > currentVersion)
                    {
                        UpdateLabel($"Update available: v{latestVersion}", clickable: true);
                    }
                    else if (latestVersion == currentVersion)
                    {
                        UpdateLabel($"Flyoobe version {currentVersion} (up-to-date)");
                    }
                    else
                    {
                        // User has a dev or newer version
                        UpdateLabel($"Flyoobe version {currentVersion} (dev version?)");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLabel($"Update check failed: {ex.Message}");
            }
        }

        // Helper method to update label safely on UI thread
        private void UpdateLabel(string text, bool clickable = false)
        {
            // Update label text
            linkAppVersion.Text = text;

            // If clickable, show bold & underline and make cursor a hand
            if (clickable)
            {
                linkAppVersion.Font = new Font(linkAppVersion.Font, FontStyle.Bold | FontStyle.Underline);
                linkAppVersion.Enabled = true;
                linkAppVersion.Cursor = Cursors.Hand;
            }
            else
            {
                // Otherwise normal font and default cursor
                linkAppVersion.Font = new Font(linkAppVersion.Font, FontStyle.Regular);
                linkAppVersion.Enabled = false;
                linkAppVersion.Cursor = Cursors.Default;
            }
        }


        private void linkAppVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/builtbybel/Flyby11/releases/latest",
                UseShellExecute = true
            });
        }

      
    }
}