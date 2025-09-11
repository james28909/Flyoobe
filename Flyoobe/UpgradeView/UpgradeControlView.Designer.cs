namespace Flyoobe
{
    partial class UpgradeControlView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDragDrop = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTiles = new System.Windows.Forms.FlowLayoutPanel();
            this.dropdownOptions = new System.Windows.Forms.ComboBox();
            this.btnExperience = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.chkAdvancedMode = new System.Windows.Forms.CheckBox();
            this.panelDragDrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDragDrop
            // 
            this.panelDragDrop.AllowDrop = true;
            this.panelDragDrop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelDragDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.panelDragDrop.Controls.Add(this.flowLayoutPanelTiles);
            this.panelDragDrop.Controls.Add(this.dropdownOptions);
            this.panelDragDrop.Controls.Add(this.btnExperience);
            this.panelDragDrop.Controls.Add(this.statusLabel);
            this.panelDragDrop.Location = new System.Drawing.Point(71, 46);
            this.panelDragDrop.Name = "panelDragDrop";
            this.panelDragDrop.Size = new System.Drawing.Size(697, 362);
            this.panelDragDrop.TabIndex = 1;
            this.panelDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDragDrop_DragDrop);
            this.panelDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDragDrop_DragEnter);
            this.panelDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDragDrop_Paint);
            // 
            // flowLayoutPanelTiles
            // 
            this.flowLayoutPanelTiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelTiles.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelTiles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTiles.Location = new System.Drawing.Point(21, 96);
            this.flowLayoutPanelTiles.Name = "flowLayoutPanelTiles";
            this.flowLayoutPanelTiles.Size = new System.Drawing.Size(651, 173);
            this.flowLayoutPanelTiles.TabIndex = 3;
            // 
            // dropdownOptions
            // 
            this.dropdownOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.dropdownOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dropdownOptions.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownOptions.ForeColor = System.Drawing.Color.Black;
            this.dropdownOptions.FormattingEnabled = true;
            this.dropdownOptions.Location = new System.Drawing.Point(55, 304);
            this.dropdownOptions.Name = "dropdownOptions";
            this.dropdownOptions.Size = new System.Drawing.Size(601, 28);
            this.dropdownOptions.TabIndex = 507;
            this.dropdownOptions.SelectedIndexChanged += new System.EventHandler(this.dropdownOptions_SelectedIndexChanged);
            // 
            // btnExperience
            // 
            this.btnExperience.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExperience.AutoEllipsis = true;
            this.btnExperience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(220)))));
            this.btnExperience.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExperience.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExperience.FlatAppearance.BorderSize = 0;
            this.btnExperience.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnExperience.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold);
            this.btnExperience.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnExperience.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExperience.Location = new System.Drawing.Point(21, 286);
            this.btnExperience.Name = "btnExperience";
            this.btnExperience.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnExperience.Size = new System.Drawing.Size(651, 60);
            this.btnExperience.TabIndex = 506;
            this.btnExperience.TabStop = false;
            this.btnExperience.UseCompatibleTextRendering = true;
            this.btnExperience.UseVisualStyleBackColor = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(21, 3);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(651, 90);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Drag && drop your Windows 11 ISO to upgrade unsupported PCs.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusLabel.UseCompatibleTextRendering = true;
            // 
            // chkAdvancedMode
            // 
            this.chkAdvancedMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAdvancedMode.AutoSize = true;
            this.chkAdvancedMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAdvancedMode.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdvancedMode.ForeColor = System.Drawing.Color.Black;
            this.chkAdvancedMode.Location = new System.Drawing.Point(225, 434);
            this.chkAdvancedMode.Name = "chkAdvancedMode";
            this.chkAdvancedMode.Size = new System.Drawing.Size(400, 20);
            this.chkAdvancedMode.TabIndex = 2;
            this.chkAdvancedMode.Text = "Enable advanced upgrade mode (bypass compatibility and driver checks)";
            this.chkAdvancedMode.UseCompatibleTextRendering = true;
            this.chkAdvancedMode.UseVisualStyleBackColor = true;
            this.chkAdvancedMode.CheckedChanged += new System.EventHandler(this.chkAdvancedMode_CheckedChanged);
            // 
            // UpgradeControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.chkAdvancedMode);
            this.Controls.Add(this.panelDragDrop);
            this.Name = "UpgradeControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.panelDragDrop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDragDrop;
        private System.Windows.Forms.ComboBox dropdownOptions;
        private System.Windows.Forms.Button btnExperience;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox chkAdvancedMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTiles;
    }
}
