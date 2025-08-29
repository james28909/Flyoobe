using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class MainForm : Form
    {
        private ViewNavigator _navigator;
        private AboutForm aboutForm;
        private int _notificationCount = 0;

        public MainForm()
        {
            InitializeComponent();
            Logger.OnNotificationLogged += Logger_OnNotificationLogged;       // Subscribe to log events
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeButtons();

            _navigator = new ViewNavigator(panelHost, treeNavigation, title =>
            {
                // lblHeader.Text = title;
                linkSubHeader.Text = $"Running - {title} - {Program.GetAppVersion()}";
            });

            // Register views
            _navigator.RegisterView("Home", () => new HomeControlView(_navigator));
            _navigator.RegisterView("Upgrade", () => new UpgradeControlView());
            _navigator.RegisterView("Install only", () => new InstallControlView());
            _navigator.RegisterView("Device", () => new DeviceControlView());
            _navigator.RegisterView("Personalization", () => new PersonalizationControlView());
            _navigator.RegisterView("Browser", () => new DefaultsControlView());
            _navigator.RegisterView("Network", () => new NetworkControlView());
            _navigator.RegisterView("Account", () => new AccountControlView());
            _navigator.RegisterView("Apps", () => new AppsControlView());
            _navigator.RegisterView("Experience", () => new ExperienceControlView());
            _navigator.RegisterView("Installer", () => new InstallerControlView());
            _navigator.RegisterView("Updates", () => new UpdatesControlView());
            _navigator.RegisterView("Extensions", () => new ToolHub.ToolHubControlView());

            // Load OOBE navigation with system status
            _navigator.LoadDefaultNavigation();

            // Show initial view
            _navigator.ShowView("Home");
        }

        private void InitializeButtons()
        {
            CopilotHelper.SetupCopilotButton(btnAskCopilot, 20);

            btnAbout.Text = "\uE946";
            btnRefresh.Text = "\uE72C";
            btnToolSpot.Text = "\uE721";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (aboutForm == null || aboutForm.IsDisposed)
            {
                aboutForm = new AboutForm();
                aboutForm.StartPosition = FormStartPosition.Manual;
                aboutForm.Owner = this;
                aboutForm.Show();
            }
            PositionAboutForm();
        }

        private void PositionAboutForm()
        {
            if (aboutForm != null && !aboutForm.IsDisposed)
            {
                int x = this.Left + (this.Width - aboutForm.Width) / 2;
                int y = this.Top + (this.Height - aboutForm.Height) / 2;
                aboutForm.Location = new Point(x, y);
            }
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            PositionAboutForm();
        }

        private void btnAskCopilot_Click(object sender, EventArgs e)
        {
            CopilotHelper.LaunchCopilot();
        }

        /// <summary>
        /// Handles log notifications (Warnings/Errors).
        /// Increments the notification counter and updates the notification button text.
        /// </summary>
        private void Logger_OnNotificationLogged(string message, LogLevel level)
        {
            _notificationCount++;
            UpdateNotificationButton();
        }

        /// <summary>
        /// Updates the notification button text based on the current notification count.
        /// Ensures thread-safe UI updates.
        /// </summary>
        private void UpdateNotificationButton()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateNotificationButton));
                return;
            }

            if (_notificationCount > 0)
            {
                btnNotification.Text = $"Notifications ({_notificationCount})";
                btnNotification.ForeColor = Color.Blue;
            }
            else
            {
                btnNotification.Text = "No new notifications";
                btnNotification.ForeColor = Color.Black;
            }

            btnNotification.Visible = true;
        }

        /// <summary>
        /// Opens the LogForm to display the complete log.
        /// Resets the notification count afterwards.
        /// </summary>
        private void btnNotification_Click(object sender, EventArgs e)
        {
            new LogForm(Logger.GetLog()).ShowDialog(this);

            // Reset notification count after viewing log
            _notificationCount = 0;
            UpdateNotificationButton();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DonationHelper.HasDonated())
            {
                DonationHelper.ShowDonationPrompt();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // If the current view implements IView, trigger its RefreshView method
            if (_navigator.CurrentView is IView view)
            {
                view.RefreshView();
                btnNotification.Visible = false; // Hide notification button after refresh
            }
        }

        private void btnToolSpot_Click(object sender, EventArgs e)
        {
            // Path: <AppBase>\app\Foobe.Toolspot.exe
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app", "spot.exe");

            if (!File.Exists(exePath))
            {
                MessageBox.Show("Toolspot not found:\n" + exePath, "Flyoobe",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Make MainForm dim (semi-transparent)
                this.Opacity = 0.85;

                var proc = new Process();
                proc.StartInfo.FileName = exePath;
                proc.EnableRaisingEvents = true;
                proc.Exited += (s, ev) =>
                {
                    // Restore opacity on UI thread
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke((Action)(() => this.Opacity = 1.0));
                    }
                };

                proc.Start();
            }
            catch (Exception ex)
            {
                this.Opacity = 1.0; // safety reset
                MessageBox.Show("Could not start Toolspot:\n" + ex.Message, "Flyoobe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _navigator.ShowView("Home");
        }
    }
}