using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Flyoobe.ToolHub
{
    public partial class ToolHubControlView : UserControl, IView
    {
        private List<ToolHubDefinition> _allTools = new List<ToolHubDefinition>();

        public string ViewTitle => "Setup Extensions";

        public ToolHubControlView()
        {
            InitializeComponent();
            LoadTools();
        }

        private void LoadTools()
        {
            _allTools.Clear();

            // Define the scripts directory relative to the executable path
            string scriptDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");

            // If the directory does not exist, create it
            if (!Directory.Exists(scriptDirectory))
            {
                Directory.CreateDirectory(scriptDirectory);
                return;
            }

            // Get all .ps1 files in the folder
            string[] scriptFiles = Directory.GetFiles(scriptDirectory, "*.ps1");

            // Loop through each script and create a tool item
            foreach (var scriptPath in scriptFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(scriptPath); // Use file name as title
                string icon = PickIconForScript(fileName);                      // Choose an icon based on the name

                // Get description + options from script metadata
                var meta = ReadMetadataFromScript(scriptPath);

                var tool = new ToolHubDefinition(fileName, meta.description, icon, scriptPath);
                tool.Options.AddRange(meta.options);
                tool.UseConsole = meta.useConsole;

                var control = new ToolHubItemControl(tool);
                flowLayoutPanelTools.Controls.Add(control);

                _allTools.Add(tool); // Save original list
            }

            DisplayFilteredTools("");
        }

        private (string description, List<string> options, bool useConsole) ReadMetadataFromScript(string scriptPath)
        {
            string description = "No description available.";
            var options = new List<string>();
            bool useConsole = false;

            try
            {
                // Only scan the first lines for metadata.
                // Extensions put their headers (# Description, # Host, # Options) at the top,
                // so we dont waste time parsing a huge script body
                var lines = File.ReadLines(scriptPath).Take(10);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (line.StartsWith("# Options:", StringComparison.OrdinalIgnoreCase))
                    {
                        // Parse dropdown options
                        options = line.Substring(10)
                             .Split(';')
                             .Select(x => x.Trim())
                             .Where(x => !string.IsNullOrEmpty(x)) // ignore empty entries
                             .ToList();
                    }
                    // Parse host
                    else if (line.StartsWith("# Host:", StringComparison.OrdinalIgnoreCase))
                    {
                        var raw = line.Substring(7).Trim().ToLowerInvariant();
                        if (raw == "console")
                            useConsole = true;
                    }
                    else if (line.StartsWith("#"))
                    {
                        // Use the first regular comment as description (if none yet)
                        if (description == "No description available.")
                            description = line.TrimStart('#').Trim();
                    }
                }
            }
            catch
            {
                // Ignore errors and keep defaults
            }

            return (description, options, useConsole);
        }

        private string PickIconForScript(string name)
        {
            name = name.ToLower();

            // Basic keyword-based icon picking using Segoe MDL2 Assets
            if (name.Contains("debloat")) return "\uE74D";      // Trash icon (cleanup)
            if (name.Contains("network")) return "\uE701";      // Network icon (network tools)
            if (name.Contains("explorer")) return "\uE8B7";     // File Explorer icon (file management)
            if (name.Contains("update")) return "\uE895";       // Update icon (system updates)
            if (name.Contains("context")) return "\uE8A5";      // Menu icon (context menu tweaks)

            // Additional general categories
            if (name.Contains("backup")) return "\uE8C7";       // Save icon (backup tools)
            if (name.Contains("security")) return "\uE72E";     // Shield icon (security tools)
            if (name.Contains("performance")) return "\uE7B8";  // Speedometer icon (performance)
            if (name.Contains("privacy")) return "\uF552";      // Privacy icon (privacy settings)
            if (name.Contains("app")) return "\uED35";          // App icon (application management)
            if (name.Contains("setup")) return "\uE8FB";        // Install icon (installers)

            // Default icon for uncategorized tools
            return "\uE7C5"; // Wrench icon (default tool)
        }

        private void DisplayFilteredTools(string filter)
        {
            flowLayoutPanelTools.SuspendLayout();
            flowLayoutPanelTools.Controls.Clear();

            // Apply case-insensitive search filter
            foreach (var tool in _allTools)
            {
                if (string.IsNullOrWhiteSpace(filter) ||
                    tool.Title.ToLower().Contains(filter.ToLower()) ||
                    tool.Description.ToLower().Contains(filter.ToLower()))
                {
                    var control = new ToolHubItemControl(tool);
                    flowLayoutPanelTools.Controls.Add(control);
                }
            }

            flowLayoutPanelTools.ResumeLayout();
        }

        public void RefreshView()
        {
            textSearch.Clear();
            flowLayoutPanelTools.Controls.Clear();
            LoadTools();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            var keyword = textSearch.Text.Trim();
            DisplayFilteredTools(keyword);
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Clear();
        }

    }
}