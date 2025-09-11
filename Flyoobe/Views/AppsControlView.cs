using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Management.Deployment;

namespace Flyoobe
{
    public partial class AppsControlView : UserControl, IView
    {
        public string ViewTitle => "Manage Installed Apps";

        private Dictionary<string, string> _appDirectory = new Dictionary<string, string>();
        private string currentSearchTerm = string.Empty;

        private string activePatternFile = "Flyoobe_Profile_Full.txt";

        public AppsControlView()
        {
            InitializeComponent();
        }

        private void AppControlView_Load(object sender, EventArgs e)
        {
            InitializeProfileDropdown();
            RefreshView();

            assetViewInfo.Text = "\uE773";
        }
        private void InitializeProfileDropdown()
        {
            profileDropdown.Items.Clear();
            profileDropdown.Items.Add("Full Microsoft Experience – everything included");
            profileDropdown.Items.Add("Balanced – essentials plus Store (recommended)");
            profileDropdown.Items.Add("Minimal Windows – only essentials, zero bloat");
            profileDropdown.Items.Add("Community (from GitHub)");

            profileDropdown.SelectedIndex = 1; // Default to Balanced
            profileDropdown.SelectedIndexChanged += async (s, e) => await ApplyProfileChange();
        }

        /// <summary>
        /// Called when profile dropdown is changed.
        /// Updates label + sets correct pattern file + reloads app list.
        /// </summary>
        private async Task ApplyProfileChange()
        {
            string baseText = "Select the apps you want to uninstall. Use the dropdown to pick a cleanup profile. ";

            switch (profileDropdown.SelectedIndex)
            {
                case 0: // Full
                    lblStatus.Text = baseText + "Currently showing: Full Microsoft Experience.";
                    activePatternFile = "Flyoobe_Profile_Full.txt";
                    await LoadAndDisplayApps();
                    break;

                case 1: // Balanced
                    lblStatus.Text = baseText + "Currently showing: Balanced profile.";
                    activePatternFile = "Flyoobe_Profile_Balanced.txt";
                    await LoadAndDisplayApps();
                    break;

                case 2: // Minimal
                    lblStatus.Text = baseText + "Currently showing: Minimal Windows profile.";
                    activePatternFile = "Flyoobe_Profile_Minimal.txt";
                    await LoadAndDisplayApps();
                    break;

                case 3: // Community
                    await LoadCommunityProfileAsync();
                    break;
            }
        }

        /// <summary>
        /// Downloads and applies the community profile from GitHub.
        /// Always overwrites the local copy.
        /// </summary>
        private async Task LoadCommunityProfileAsync()
        {
            string url = "https://raw.githubusercontent.com/builtbybel/Flyoobe/main/assets/Flyoobe_Profile_Community.txt";
            string appDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app");
            string localPath = Path.Combine(appDir, "Flyoobe_Profile_Community.txt");

            try
            {
                var result = MessageBox.Show(
                    "A Community Cleanup Profile is available online.\n\n" +
                    "This profile contains the most commonly removed apps, curated by the community.\n\n" +
                    "Do you want to download and apply it now?",
                    "Community Profile",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Directory.CreateDirectory(appDir);
                    using (var client = new System.Net.WebClient())
                    {
                        await client.DownloadFileTaskAsync(new Uri(url), localPath);
                    }

                    activePatternFile = Path.GetFileName(localPath);

                    lblStatus.Text = "Community Profile active – showing most commonly removed apps.";
                    await LoadAndDisplayApps();
                }
                else
                {
                    lblStatus.Text = "Community Profile was not applied.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "⚠️ Failed to load the Community Profile.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // Loads all installed apps and displays matches in the checked list
        private async Task LoadAndDisplayApps()
        {
            checkedListBoxApps.Items.Clear();

            var (bloatware, whitelist, scanAll) = LoadNativeAppPatterns();
            await LoadInstalledAppsAsync();

            foreach (var app in _appDirectory)
            {
                string appNameLower = app.Key.ToLower();

                // Skip whitelisted apps
                if (whitelist.Any(w => appNameLower.Contains(w)))
                    continue;

                // Apply search filter
                if (!string.IsNullOrEmpty(currentSearchTerm) &&
                    !appNameLower.Contains(currentSearchTerm))
                    continue;

                // Show all apps if wildcard is enabled, or match by pattern
                if (scanAll || bloatware.Any(b => appNameLower.Contains(b)))
                {
                    checkedListBoxApps.Items.Add(app.Key, false);
                }
            }
        }

        // Loads installed UWP apps into the internal dictionary
        private async Task LoadInstalledAppsAsync()
        {
            _appDirectory.Clear();
            var pm = new PackageManager();

            var packages = await Task.Run(() =>
                pm.FindPackagesForUserWithPackageTypes(string.Empty, PackageTypes.Main));

            foreach (var p in packages)
            {
                string name = p.Id.Name;
                string fullName = p.Id.FullName;

                if (!_appDirectory.ContainsKey(name))
                {
                    _appDirectory[name] = fullName;
                }
            }
        }

        // Loads bloatware patterns and whitelist from text file
        private (string[] bloatware, string[] whitelist, bool scanAll) LoadNativeAppPatterns()
        {
            var bloatware = new List<string>();
            var whitelist = new List<string>();
            bool scanAll = false;

            string pathToUse = GetActivePatternFilePath(activePatternFile);

            if (string.IsNullOrEmpty(pathToUse) || !File.Exists(pathToUse))
                return (Array.Empty<string>(), Array.Empty<string>(), false);

            foreach (var rawLine in File.ReadLines(pathToUse))
            {
                string line = rawLine.Split('#')[0].Trim();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line == "*" || line == "*.*")
                {
                    scanAll = true;
                    continue;
                }

                if (line.StartsWith("!"))
                    whitelist.Add(line.Substring(1).Trim().ToLowerInvariant());
                else
                    bloatware.Add(line.ToLowerInvariant());
            }

            return (bloatware.ToArray(), whitelist.ToArray(), scanAll);
        }
        /// <summary>
        /// Gets the path to the selected profile pattern file inside /app directory.
        /// </summary>
        private string GetActivePatternFilePath(string fileName, bool ensureExists = false)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string appDir = Path.Combine(baseDir, "app");
            string profilePath = Path.Combine(appDir, fileName);

            if (ensureExists && !File.Exists(profilePath))
            {
                Directory.CreateDirectory(appDir); // make sure folder exists
                File.WriteAllText(profilePath, "# Add your app detection patterns here\n");
            }

            return profilePath;
        }

        private async void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting cleanup...";
            progressBar.Visible = true;

            var toRemove = new List<string>();

            // Get selected app full names from checked list
            foreach (var item in checkedListBoxApps.CheckedItems)
            {
                string appName = item.ToString();
                if (_appDirectory.TryGetValue(appName, out var fullName))
                {
                    toRemove.Add(fullName);
                }
            }

            if (toRemove.Count == 0)
            {
                MessageBox.Show("Please select at least one app.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            progressBar.Minimum = 0;
            progressBar.Maximum = toRemove.Count;
            progressBar.Value = 0;

            int count = 0;

            foreach (var fullName in toRemove)
            {
                string name = _appDirectory.FirstOrDefault(x => x.Value == fullName).Key;

                lblStatus.Text = $"Removing {name}...";
                bool success = await UninstallAppAsync(fullName);

                count++;
                progressBar.Value = count;

                if (!success)
                {
                    lblStatus.Text = $"Failed to remove {name}";
                    Logger.Log($"Uninstalling {name} ({fullName}) - Success: {success}", LogLevel.Warning);
                }
                else
                {
                    lblStatus.Text = $"Removed {name}";
                    Logger.Log($"Successfully uninstalled {name} ({fullName})", LogLevel.Info);
                }

                await Task.Delay(200); // pause to visualize progress
            }

            MessageBox.Show("Uninstallation completed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh app list after cleanup
            await LoadAndDisplayApps();
            progressBar.Value = 0;
            progressBar.Visible = false;
            lblStatus.Text = "Cleanup finished.";
        }

        // Uninstalls a UWP app using its full package name
        private async Task<bool> UninstallAppAsync(string fullName)
        {
            try
            {
                var pm = new PackageManager();
                var operation = pm.RemovePackageAsync(fullName);

                var resetEvent = new ManualResetEvent(false);
                operation.Completed = (o, s) => resetEvent.Set();

                await Task.Run(() => resetEvent.WaitOne());

                return operation.Status == AsyncStatus.Completed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uninstalling:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Use the currently active profile file
                string filePath = GetActivePatternFilePath(activePatternFile, ensureExists: true);
                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening profile file: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            currentSearchTerm = textSearch.Text.Trim().ToLower();
            _ = LoadAndDisplayApps(); // Re-run with filter
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Clear();
        }

        public async void RefreshView()
        {
            currentSearchTerm = string.Empty;
            checkedListBoxApps.Items.Clear();

            await ApplyProfileChange(); // reload with current profile
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAll = checkSelectAll.Checked;

            for (int i = 0; i < checkedListBoxApps.Items.Count; i++)
            {
                checkedListBoxApps.SetItemChecked(i, checkAll);
            }
        }
    }
}