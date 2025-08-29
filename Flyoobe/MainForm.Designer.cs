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
            this.panelControls = new System.Windows.Forms.Panel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.linkSubHeader = new System.Windows.Forms.LinkLabel();
            this.btnNotification = new System.Windows.Forms.Button();
            this.panelHost = new System.Windows.Forms.Panel();
            this.treeNavigation = new System.Windows.Forms.TreeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnToolSpot = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnAskCopilot = new System.Windows.Forms.Button();
            this.panelControls.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.AutoScroll = true;
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.panelControls.Controls.Add(this.linkHome);
            this.panelControls.Controls.Add(this.linkSubHeader);
            this.panelControls.Controls.Add(this.btnNotification);
            this.panelControls.Controls.Add(this.panelHost);
            this.panelControls.Controls.Add(this.treeNavigation);
            this.panelControls.Controls.Add(this.btnRefresh);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(883, 503);
            this.panelControls.TabIndex = 3;
            // 
            // linkHome
            // 
            this.linkHome.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.linkHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkHome.AutoSize = true;
            this.linkHome.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11.5F, System.Drawing.FontStyle.Bold);
            this.linkHome.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkHome.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.linkHome.Location = new System.Drawing.Point(695, 35);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(48, 26);
            this.linkHome.TabIndex = 338;
            this.linkHome.TabStop = true;
            this.linkHome.Text = "Setup";
            this.linkHome.UseCompatibleTextRendering = true;
            this.linkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHome_LinkClicked);
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
            this.btnNotification.Location = new System.Drawing.Point(748, 34);
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
            this.panelHost.Location = new System.Drawing.Point(7, 22);
            this.panelHost.Name = "panelHost";
            this.panelHost.Size = new System.Drawing.Size(682, 468);
            this.panelHost.TabIndex = 333;
            // 
            // treeNavigation
            // 
            this.treeNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.treeNavigation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeNavigation.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeNavigation.HideSelection = false;
            this.treeNavigation.HotTracking = true;
            this.treeNavigation.Location = new System.Drawing.Point(695, 75);
            this.treeNavigation.Name = "treeNavigation";
            this.treeNavigation.Scrollable = false;
            this.treeNavigation.ShowLines = false;
            this.treeNavigation.ShowNodeToolTips = true;
            this.treeNavigation.ShowPlusMinus = false;
            this.treeNavigation.ShowRootLines = false;
            this.treeNavigation.Size = new System.Drawing.Size(186, 416);
            this.treeNavigation.TabIndex = 3;
            this.treeNavigation.TabStop = false;
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
            // btnToolSpot
            // 
            this.btnToolSpot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToolSpot.AutoSize = true;
            this.btnToolSpot.BackColor = System.Drawing.Color.Transparent;
            this.btnToolSpot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.btnToolSpot.FlatAppearance.BorderSize = 0;
            this.btnToolSpot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnToolSpot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnToolSpot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSpot.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.25F);
            this.btnToolSpot.ForeColor = System.Drawing.Color.Black;
            this.btnToolSpot.Location = new System.Drawing.Point(916, 1);
            this.btnToolSpot.Name = "btnToolSpot";
            this.btnToolSpot.Size = new System.Drawing.Size(26, 25);
            this.btnToolSpot.TabIndex = 338;
            this.btnToolSpot.TabStop = false;
            this.btnToolSpot.Text = "...";
            this.btnToolSpot.UseVisualStyleBackColor = false;
            this.btnToolSpot.Click += new System.EventHandler(this.btnToolSpot_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(945, 565);
            this.Controls.Add(this.btnToolSpot);
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
        private System.Windows.Forms.TreeView treeNavigation;
        private System.Windows.Forms.Panel panelHost;
        private System.Windows.Forms.LinkLabel linkSubHeader;
        private System.Windows.Forms.Button btnToolSpot;
        private System.Windows.Forms.LinkLabel linkHome;
    }
}

