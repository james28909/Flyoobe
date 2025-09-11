namespace Flyoobe
{
    partial class MainForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.navPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.linkSubHeader = new System.Windows.Forms.LinkLabel();
            this.btnNotification = new System.Windows.Forms.Button();
            this.panelHost = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExtensions = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnAskCopilot = new System.Windows.Forms.Button();
            this.contextDropDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripExtensions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddExtensionUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddExtensionLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExtensionGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExtensionSource = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControls.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.contextDropDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.AutoScroll = true;
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.panelControls.Controls.Add(this.btnNext);
            this.panelControls.Controls.Add(this.navPanel);
            this.panelControls.Controls.Add(this.linkSubHeader);
            this.panelControls.Controls.Add(this.btnNotification);
            this.panelControls.Controls.Add(this.panelHost);
            this.panelControls.Controls.Add(this.btnRefresh);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(883, 503);
            this.panelControls.TabIndex = 3;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe MDL2 Assets", 25.25F);
            this.btnNext.ForeColor = System.Drawing.Color.Gray;
            this.btnNext.Location = new System.Drawing.Point(835, 429);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(45, 57);
            this.btnNext.TabIndex = 340;
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // navPanel
            // 
            this.navPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navPanel.AutoScroll = true;
            this.navPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.navPanel.Font = new System.Drawing.Font("Segoe UI Variable Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navPanel.Location = new System.Drawing.Point(0, 429);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(834, 75);
            this.navPanel.TabIndex = 339;
            this.navPanel.WrapContents = false;
            // 
            // linkSubHeader
            // 
            this.linkSubHeader.ActiveLinkColor = System.Drawing.Color.Magenta;
            this.linkSubHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkSubHeader.AutoEllipsis = true;
            this.linkSubHeader.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.5F);
            this.linkSubHeader.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkSubHeader.LinkColor = System.Drawing.Color.Black;
            this.linkSubHeader.Location = new System.Drawing.Point(12, 4);
            this.linkSubHeader.Name = "linkSubHeader";
            this.linkSubHeader.Size = new System.Drawing.Size(677, 16);
            this.linkSubHeader.TabIndex = 334;
            this.linkSubHeader.TabStop = true;
            this.linkSubHeader.Text = "...";
            // 
            // btnNotification
            // 
            this.btnNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotification.AutoEllipsis = true;
            this.btnNotification.FlatAppearance.BorderSize = 0;
            this.btnNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotification.Location = new System.Drawing.Point(729, 0);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(123, 22);
            this.btnNotification.TabIndex = 337;
            this.btnNotification.Text = "Notifications";
            this.btnNotification.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotification.UseVisualStyleBackColor = true;
            this.btnNotification.Visible = false;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // panelHost
            // 
            this.panelHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHost.Location = new System.Drawing.Point(7, 29);
            this.panelHost.Name = "panelHost";
            this.panelHost.Size = new System.Drawing.Size(873, 400);
            this.panelHost.TabIndex = 333;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(222)))), ((int)(((byte)(246)))));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(858, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 23);
            this.btnRefresh.TabIndex = 332;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "...";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExtensions
            // 
            this.btnExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtensions.AutoSize = true;
            this.btnExtensions.BackColor = System.Drawing.Color.Transparent;
            this.btnExtensions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.btnExtensions.FlatAppearance.BorderSize = 0;
            this.btnExtensions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnExtensions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtensions.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnExtensions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExtensions.Location = new System.Drawing.Point(913, 1);
            this.btnExtensions.Name = "btnExtensions";
            this.btnExtensions.Size = new System.Drawing.Size(29, 27);
            this.btnExtensions.TabIndex = 338;
            this.btnExtensions.TabStop = false;
            this.btnExtensions.Text = "...";
            this.btnExtensions.UseVisualStyleBackColor = false;
            this.btnExtensions.Click += new System.EventHandler(this.btnExtensions_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.panelContainer.Controls.Add(this.panelControls);
            this.panelContainer.Location = new System.Drawing.Point(23, 32);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(883, 503);
            this.panelContainer.TabIndex = 15;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Display", 27.75F);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.lblHeader.Location = new System.Drawing.Point(38, 2);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(696, 32);
            this.lblHeader.TabIndex = 333;
            this.lblHeader.Text = "Flyoobe";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.AutoSize = true;
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.25F);
            this.btnAbout.ForeColor = System.Drawing.Color.Black;
            this.btnAbout.Location = new System.Drawing.Point(912, 517);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(30, 29);
            this.btnAbout.TabIndex = 336;
            this.btnAbout.Text = "...";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnAskCopilot
            // 
            this.btnAskCopilot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAskCopilot.AutoSize = true;
            this.btnAskCopilot.BackColor = System.Drawing.Color.Transparent;
            this.btnAskCopilot.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAskCopilot.FlatAppearance.BorderSize = 0;
            this.btnAskCopilot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnAskCopilot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnAskCopilot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAskCopilot.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.25F);
            this.btnAskCopilot.ForeColor = System.Drawing.Color.Black;
            this.btnAskCopilot.Location = new System.Drawing.Point(912, 477);
            this.btnAskCopilot.Name = "btnAskCopilot";
            this.btnAskCopilot.Size = new System.Drawing.Size(30, 29);
            this.btnAskCopilot.TabIndex = 335;
            this.btnAskCopilot.UseVisualStyleBackColor = false;
            this.btnAskCopilot.Click += new System.EventHandler(this.btnAskCopilot_Click);
            // 
            // contextDropDown
            // 
            this.contextDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.contextDropDown.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 10.5F);
            this.contextDropDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExtensions,
            this.toolStripAddExtensionUrl,
            this.toolStripAddExtensionLocal,
            this.toolStripExtensionGuide,
            this.toolStripSeparator1,
            this.toolStripExtensionSource});
            this.contextDropDown.Name = "contextDropDown";
            this.contextDropDown.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextDropDown.Size = new System.Drawing.Size(200, 176);
            // 
            // toolStripExtensions
            // 
            this.toolStripExtensions.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripExtensions.Name = "toolStripExtensions";
            this.toolStripExtensions.Size = new System.Drawing.Size(199, 24);
            this.toolStripExtensions.Text = "Manage extensions";
            this.toolStripExtensions.Click += new System.EventHandler(this.toolStripExtensions_Click);
            // 
            // toolStripAddExtensionUrl
            // 
            this.toolStripAddExtensionUrl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripAddExtensionUrl.Name = "toolStripAddExtensionUrl";
            this.toolStripAddExtensionUrl.Size = new System.Drawing.Size(199, 24);
            this.toolStripAddExtensionUrl.Text = "Install from Url...";
            this.toolStripAddExtensionUrl.Click += new System.EventHandler(this.toolStripAddExtensionUrl_Click);
            // 
            // toolStripAddExtensionLocal
            // 
            this.toolStripAddExtensionLocal.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripAddExtensionLocal.Name = "toolStripAddExtensionLocal";
            this.toolStripAddExtensionLocal.Size = new System.Drawing.Size(199, 24);
            this.toolStripAddExtensionLocal.Text = "Import from file...";
            this.toolStripAddExtensionLocal.Click += new System.EventHandler(this.toolStripAddExtensionLocal_Click);
            // 
            // toolStripExtensionGuide
            // 
            this.toolStripExtensionGuide.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripExtensionGuide.Name = "toolStripExtensionGuide";
            this.toolStripExtensionGuide.Size = new System.Drawing.Size(199, 24);
            this.toolStripExtensionGuide.Text = "Write an extension";
            this.toolStripExtensionGuide.Click += new System.EventHandler(this.toolStripExtensionGuide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripExtensionSource
            // 
            this.toolStripExtensionSource.Margin = new System.Windows.Forms.Padding(0, 5, 0, 2);
            this.toolStripExtensionSource.Name = "toolStripExtensionSource";
            this.toolStripExtensionSource.Size = new System.Drawing.Size(199, 24);
            this.toolStripExtensionSource.Text = "Extension folder...";
            this.toolStripExtensionSource.Click += new System.EventHandler(this.toolStripExtensionSource_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(945, 565);
            this.Controls.Add(this.btnExtensions);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnAskCopilot);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.lblHeader);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flyoobe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.contextDropDown.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnAskCopilot;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.Panel panelHost;
        private System.Windows.Forms.LinkLabel linkSubHeader;
        private System.Windows.Forms.FlowLayoutPanel navPanel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ContextMenuStrip contextDropDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddExtensionUrl;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddExtensionLocal;
        private System.Windows.Forms.ToolStripMenuItem toolStripExtensionGuide;
        private System.Windows.Forms.ToolStripMenuItem toolStripExtensionSource;
        private System.Windows.Forms.Button btnExtensions;
        private System.Windows.Forms.ToolStripMenuItem toolStripExtensions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

