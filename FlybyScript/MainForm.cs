using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Views;

namespace Flyby11
{
    public partial class MainForm : Form
    {
        private readonly IsoHandler _isoHandler;
        private readonly FAQHandler _faqHandler;

        public MainForm()
        {
            InitializeComponent();
            _isoHandler = new IsoHandler(UpdateStatusLabel);
            _faqHandler = new FAQHandler(panelFAQ, UpdateStatusLabel);
            _faqHandler.InitializeFAQ();

            UpdateStatusLabel("Drag and drop the Windows 11 ISO to patch it and install on unsupported hardware (Inplace Upgrade).");
        }

        private void panelDragDrop_Paint(object sender, PaintEventArgs e)
        {
            var borderColor = Color.DodgerBlue;
            var borderThickness = 6;

            // Draw a dotted border
            var dashPattern = new float[] { 4, 2 }; // Dots and gaps
            using (var pen = new Pen(borderColor, borderThickness))
            {
                pen.DashPattern = dashPattern;
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

                var rect = new Rectangle(
                    borderThickness / 2,
                    borderThickness / 2,
                    panelDragDrop.Width - borderThickness,
                    panelDragDrop.Height - borderThickness
                );

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, rect);
            }

            using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0))) // Transparent shadow
            {
                var shadowRect = new Rectangle(6, 6, panelDragDrop.Width, panelDragDrop.Height);
                e.Graphics.FillRectangle(shadowBrush, shadowRect);
            }
        }

        private void panelDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the file is an ISO
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]).Equals(".iso", StringComparison.OrdinalIgnoreCase))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private async void panelDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            // Get the dropped file path
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                string isoPath = files[0]; // Full path to the ISO file
                await _isoHandler.HandleIso(isoPath); // Mount the ISO and start the setup process
            }
        }

        // Update the status label
        private void UpdateStatusLabel(string message)
        {
            statusLabel.Text = message;
            statusLabel.Refresh(); // Ensure the label updates in real-time
        }

        private void linkAppDev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/builtbybel/Flyby11");
        }

        private void linkCompPatch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the USB drive containing your Windows 11 installation files. " +
                    "This feature adds a compatibility patch to bypass certain system requirements. " +
                    "Compatible with drives prepared by any tool, including Rufus. Ensure the drive is ready!";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    var driveInfo = new DriveInfo(Path.GetPathRoot(selectedPath));

                    if (driveInfo.DriveType == DriveType.Removable && driveInfo.IsReady)
                    {
                        if (MessageBox.Show("This will apply compatibility bypass settings on the selected USB drive. Continue?",
                            "Apply Bypass Patch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                _isoHandler.CreateUnattendXml(selectedPath);
                                MessageBox.Show("Bypass patch applied successfully!", "Apply Bypass Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UpdateStatusLabel("Bypass patch applied successfully!");
                            }
                            catch (Exception ex)
                            {
                                UpdateStatusLabel($"Failed to apply bypass patch: {ex.Message}");
                            }
                        }
                        else
                        {
                            UpdateStatusLabel("Bypass patch canceled by user.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected path is not a removable drive. Please select a USB drive.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateStatusLabel("User attempted to select a non-removable drive.");
                    }
                }
                else
                {
                    UpdateStatusLabel("No USB drive selected for patching.");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CanIUpgradeView canIUpgradeView = new CanIUpgradeView();
            SwitchView.SetView(canIUpgradeView, panelContainer);
        }

   
    }
}