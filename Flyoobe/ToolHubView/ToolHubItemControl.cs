using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe.ToolHub
{
    public partial class ToolHubItemControl : UserControl
    {
        private readonly ToolHubDefinition _tool;

        public ToolHubItemControl(ToolHubDefinition tool)
        {
            InitializeComponent();
            _tool = tool;

            labelTitle.Text = _tool.Title;
            labelDescription.Text = _tool.Description;
            labelIcon.Text = _tool.Icon;
            progressBar.Visible = false;
            labelStatus.Text = string.Empty;

            // Show ComboBox only if options exist
            if (_tool.Options != null && _tool.Options.Count > 0)
            {
                comboOptions.Visible = true;
                comboOptions.Items.Clear();
                comboOptions.Items.AddRange(_tool.Options.ToArray());
                comboOptions.SelectedIndex = 0;
            }
            else
            {
                comboOptions.Visible = false;
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_tool.ScriptPath))
            {
                MessageBox.Show("Script not found: " + _tool.ScriptPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRun.Enabled = false;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            labelStatus.Text = "Running...";

            try
            {
                string arg = null;
                bool useConsole = _tool.UseConsole; // default from script header

                if (comboOptions != null && comboOptions.SelectedItem != null)
                {
                    arg = comboOptions.SelectedItem.ToString();

                    // Per-option override via suffix (console) = to show console window
                    // (silent) = hide 
                    if (arg.EndsWith(" (console)", StringComparison.Ordinal))
                    {
                        useConsole = true;
                        arg = arg.Substring(0, arg.Length - " (console)".Length).Trim();
                    }
                    else if (arg.EndsWith(" (silent)", StringComparison.Ordinal))
                    {
                        useConsole = false;
                        arg = arg.Substring(0, arg.Length - " (silent)".Length).Trim();
                    }
                }

                var output = await RunScriptAsync(_tool.ScriptPath, arg, useConsole);

                labelStatus.Text = useConsole ? "Opened in console." : "Done.";

                Logger.Log(output, LogLevel.Info);
            }
            catch (Exception ex)
            {
                labelStatus.Text = "Error: " + ex.Message;
            }
            finally
            {
                progressBar.Visible = false;
                btnRun.Enabled = true;
            }
        }


        private Task<string> RunScriptAsync(string scriptPath, string optionArg, bool useConsole)
        {
            return Task.Run(() =>
            {
                var arg = string.IsNullOrWhiteSpace(optionArg) ? "" : $" \"{optionArg}\"";

                if (useConsole)
                {
                    // Launch external PowerShell window and keep it open
                    var psi = new ProcessStartInfo("powershell.exe",
                        $"-NoExit -NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"{arg}")
                    {
                        UseShellExecute = true,
                        CreateNoWindow = false
                    };
                    Process.Start(psi);
                    return "Launched in external console.";
                }
                else
                {
                    // Run inside app and capture output
                    var psi = new ProcessStartInfo("powershell.exe",
                        $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"{arg}")
                    {
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var p = new Process { StartInfo = psi };
                    var sb = new StringBuilder();

                    p.OutputDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                            sb.AppendLine(e.Data);
                    };
                    p.ErrorDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                            sb.AppendLine("ERROR: " + e.Data);
                    };

                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    p.WaitForExit();

                    return sb.ToString();
                }
            });
        }
    }
}