using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class UpgradeControlView : UserControl, IView
    {
        public string ViewTitle => "Upgrading Assistant";
        private readonly IsoHandler _isoHandler;

        public UpgradeControlView()
        {
            InitializeComponent();
            _isoHandler = new IsoHandler(UpdateStatusLabel);
            InitializeOptions();
            InitializeTileOptions();
        }

        private void UpdateStatusLabel(string message)
        {
            statusLabel.Text = message;
            statusLabel.Refresh();
        }

        /// <summary>
        /// Handles the selection change in the dropdown options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeOptions()
        {
            dropdownOptions.Items.Add("Select an option"); // Index 0
            dropdownOptions.Items.Add("Select ISO from local computer"); // Index 1
            dropdownOptions.Items.Add("Apply Compatibility Patch (Advanced)"); // Index 2
            dropdownOptions.Items.Add("Keep Windows 10 secure until 2026 (Enroll in ESU)"); // Index 3

            dropdownOptions.SelectedIndex = 0; // Default to "Select an option"
        }

        private async void dropdownOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            int selectedIndex = combo.SelectedIndex;

            // Pick ISO from local disk (compatibility check is now in HandleIsoInput)
            if (selectedIndex == 1)
            {
                await HandleIsoInput(sender, null);
                return;
            }

            // Handle actions based on selection
            switch (selectedIndex)
            {
                case 2:
                    _isoHandler.HandleCompatibilityPatch();
                    break;

                case 3:
                   await EsuEnrollmentHandler.HandleEnrollInESU();
                    break;
            }
        }

        /// <summary>
        /// Handle the download of ISO files from various sources.
        /// </summary>
        private void InitializeTileOptions()
        {
            flowLayoutPanelTiles.Controls.Clear();

            var options = new[]
            {
        Tuple.Create("Download ISO from Microsoft Website", "Official Microsoft ISO download", 1),
        Tuple.Create("Download ISO via Media Creation Tool", "Beginner-friendly download", 2),
        Tuple.Create("Download ISO using Fido", "Recommended automated script", 3)
    };

            for (int i = 0; i < options.Length; i++)
            {
                var option = options[i];
                var tile = CreateTile(option.Item1, option.Item2, option.Item3);
                flowLayoutPanelTiles.Controls.Add(tile);
            }
        }
        private Control CreateTile(string title, string description, int optionIndex)
        {
            // Calculate DPI scale factor relative to standard 96 DPI
            float dpiScale = this.CreateGraphics().DpiX / 96f;

            // Base + hover colors for the tile
            var normalColor = Color.FromArgb(245, 240, 230);
            var hoverColor = Color.FromArgb(240, 230, 220);

            // Accent color per tile (magenta, blue, green)
            Color accent = Color.FromArgb(96, 158, 234); // default blue
            if (optionIndex == 1)
                accent = Color.FromArgb(208, 59, 255);   // Magenta
            else if (optionIndex == 2)
                accent = Color.FromArgb(96, 158, 234);   // Blue
            else if (optionIndex == 3)
                accent = Color.FromArgb(52, 199, 89);    // Green

            // Main tile panel
            var tile = new Panel
            {
                Width = (int)(200 * dpiScale),
                Height = (int)(140 * dpiScale),
                Margin = new Padding((int)(8 * dpiScale)),
                Padding = new Padding((int)(10 * dpiScale)),
                BackColor = normalColor,
                Cursor = Cursors.Hand,
            };

            // Event handlers to apply hover color on mouse enter and revert on leave
            EventHandler applyHover = (s, e) =>
            {
                tile.BackColor = hoverColor;
                tile.Invalidate(); // redraw to update
            };
            EventHandler removeHover = (s, e) =>
            {
                tile.BackColor = normalColor;
                tile.Invalidate();
            };

            // Paint tile with rounded corners, subtle shadow and colored top stripe
            tile.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, tile.Width - 1, tile.Height - 1);
                var shadowRect = rect; shadowRect.Offset(3, 3);

                var path = RoundedRect(rect, 12);
                var shadowPath = RoundedRect(shadowRect, 12);

                using (var shadow = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                    g.FillPath(shadow, shadowPath);

                using (var brush = new SolidBrush(tile.BackColor))
                    g.FillPath(brush, path);

                // Draw colored top stripe (Copilot style)
                int stripeHeight = (int)(2 * dpiScale);   // thin stripe
                using (var stripeBrush = new SolidBrush(accent))
                {
                    g.SetClip(new Rectangle(rect.X, rect.Y, rect.Width, stripeHeight));
                    g.FillPath(stripeBrush, path);
                    g.ResetClip();
                }

                // Set the region to the rounded rectangle for hit testing
                tile.Region = new Region(path);

                path.Dispose();
                shadowPath.Dispose();
            };

            // Title label (top)
            var titleLabel = new Label
            {
                Text = title,
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 10.5f * dpiScale, FontStyle.Regular),
                Height = (int)(40 * dpiScale),
                ForeColor = Color.FromArgb(80, 60, 40),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            titleLabel.MouseEnter += applyHover;
            titleLabel.MouseLeave += removeHover;

            // Description label (fill)
            var descLabel = new Label
            {
                Text = description,
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 8f * dpiScale),
                ForeColor = Color.FromArgb(100, 80, 60),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 10, 0, 0) // spacing from title
            };
            descLabel.MouseEnter += applyHover;
            descLabel.MouseLeave += removeHover;

            // One-click handler for all parts
            EventHandler clickHandler = (s, e) => TileClicked(optionIndex);
            tile.Click += clickHandler;
            titleLabel.Click += clickHandler;
            descLabel.Click += clickHandler;

            // Compose tile
            tile.Controls.Add(descLabel);
            tile.Controls.Add(titleLabel);

            return tile;
        }


        private void TileClicked(int optionIndex)
        {
            switch (optionIndex)
            {
                case 1:
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://www.microsoft.com/software-download/windows11",
                        UseShellExecute = true
                    });
                    break;

                case 2:
                    _isoHandler.HandleMediaCreationToolDownload();
                    break;

                case 3:
                    _isoHandler.DownloadAndRunFidoScript("https://raw.githubusercontent.com/pbatard/Fido/refs/heads/master/Fido.ps1");
                    break;
            }
        }

        /// <summary>
        /// Processes the ISO input, either from drag-and-drop or file selection.
        /// Also performs a CPU compatibility check (SSE4.2 / POPCNT) before proceeding.
        /// </summary>
        private async Task HandleIsoInput(object sender, EventArgs e)
        {
            string isoPath = null;
            bool experimentalEnabled = chkAdvancedMode.Checked;

            // Check if an ISO file was dragged and dropped
            if (e is DragEventArgs dragEvent && dragEvent.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])dragEvent.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]).Equals(".iso", StringComparison.OrdinalIgnoreCase))
                {
                    isoPath = files[0];
                }
            }

            // If no ISO was provided via drag-and-drop, show a file picker dialog
            if (isoPath == null)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "ISO Files (*.iso)|*.iso";
                    openFileDialog.Title = "Select an ISO File";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        isoPath = openFileDialog.FileName;
                    }
                }
            }

            // If a valid ISO file was selected or dropped, continue
            if (!string.IsNullOrEmpty(isoPath) && File.Exists(isoPath))
            {
                // === Compatibility Check ===
                // Before processing the ISO, verify CPU compatibility using SSE4.2 / POPCNT
                bool isCompatible;
                try
                {
                    isCompatible = CpuChecker.HasPopcnt();
                }
                catch (DllNotFoundException)
                {
                    MessageBox.Show(
                        "Required module 'Flyby11.dll' is missing.\n\n" +
                        "Because of this, your system's CPU compatibility (SSE4.2 / POPCNT) cannot be verified.\n" +
                        "You can still proceed, but upgrade issues may occur on unsupported hardware.",
                        "Compatibility Check Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // CPU is not compatible
                if (!isCompatible)
                {
                    var result = MessageBox.Show(
                        "⚠️ Your CPU does not support SSE4.2 and POPCNT — required for Windows 11 upgrade bypass.\n\n" +
                        "You can still proceed, but the upgrade may fail. Continue anyway?",
                        "Incompatible CPU",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                        return;
                }
                else
                {
                    UpdateStatusLabel("✅ Thinking...");
                    await Task.Delay(1000);
                    UpdateStatusLabel("✅ CPU check passed.");
                    await Task.Delay(2000);
                }
                // === ISO Processing ===
                // If all checks passed, hand over the ISO to the handler for further processing
                await _isoHandler.HandleIso(isoPath, experimentalEnabled);
            }
        }

        private async void panelDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            await HandleIsoInput(sender, e);
        }

        private void panelDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            // file is an ISO?
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                e.Effect = (files.Length == 1 && Path.GetExtension(files[0]).Equals(".iso", StringComparison.OrdinalIgnoreCase))
                    ? DragDropEffects.Copy
                    : DragDropEffects.None;
            }
        }

        // Helper method to create a rounded rectangle path
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);                       // Top-left corner
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);              // Top-right corner
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);       // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);              // Bottom-left corner
            path.CloseFigure();
            return path;
        }

        private void chkAdvancedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdvancedMode.Checked)
            {
                var result = MessageBox.Show(
                    "You are enabling an advanced setup mode. This option adds extra setup parameters that may improve compatibility on unsupported hardware. " +
                    "\r\nSuccess may vary depending on your system and drivers.\n\nDo you want to continue?",
                    "Advanced Mode Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    chkAdvancedMode.Checked = false;
                }
            }
        }

        public void RefreshView()
        {
            UpdateStatusLabel("Select an option to begin.");
        }

        private void panelDragDrop_Paint(object sender, PaintEventArgs e)
        {
            // Create gray dashed pen
            using (Pen dashPen = new Pen(Color.FromArgb(100, Color.Gray), 2))
            {
                dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                dashPen.DashPattern = new float[] { 4, 12 }; // short dash, big gap
                dashPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                Rectangle rect = panelDragDrop.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(dashPen, rect);
            }
        }
    }
}

public static class CpuChecker
{
    [DllImport("Flyby11.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool HasPopcnt();
}