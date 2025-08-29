namespace Flyoobe
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkAppVersion = new System.Windows.Forms.LinkLabel();
            this.chkDonated = new System.Windows.Forms.CheckBox();
            this.btnDonate = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.linkAppVersion);
            this.panel1.Controls.Add(this.chkDonated);
            this.panel1.Controls.Add(this.btnDonate);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.lblCopyright);
            this.panel1.Controls.Add(this.btnGitHub);
            this.panel1.Location = new System.Drawing.Point(13, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 274);
            this.panel1.TabIndex = 322;
            // 
            // linkAppVersion
            // 
            this.linkAppVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAppVersion.AutoEllipsis = true;
            this.linkAppVersion.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11.75F, System.Drawing.FontStyle.Bold);
            this.linkAppVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAppVersion.LinkColor = System.Drawing.Color.Black;
            this.linkAppVersion.Location = new System.Drawing.Point(3, 75);
            this.linkAppVersion.Name = "linkAppVersion";
            this.linkAppVersion.Size = new System.Drawing.Size(405, 46);
            this.linkAppVersion.TabIndex = 334;
            this.linkAppVersion.TabStop = true;
            this.linkAppVersion.Text = "Version";
            this.linkAppVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkAppVersion.UseCompatibleTextRendering = true;
            this.linkAppVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAppVersion_LinkClicked);
            // 
            // chkDonated
            // 
            this.chkDonated.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkDonated.AutoSize = true;
            this.chkDonated.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDonated.ForeColor = System.Drawing.Color.Black;
            this.chkDonated.Location = new System.Drawing.Point(14, 255);
            this.chkDonated.Name = "chkDonated";
            this.chkDonated.Size = new System.Drawing.Size(141, 19);
            this.chkDonated.TabIndex = 333;
            this.chkDonated.Text = "I have already donated";
            this.chkDonated.UseVisualStyleBackColor = true;
            this.chkDonated.CheckedChanged += new System.EventHandler(this.chkDonated_CheckedChanged);
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDonate.AutoEllipsis = true;
            this.btnDonate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(26)))));
            this.btnDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDonate.FlatAppearance.BorderSize = 0;
            this.btnDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnDonate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDonate.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold);
            this.btnDonate.ForeColor = System.Drawing.Color.White;
            this.btnDonate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonate.Location = new System.Drawing.Point(12, 214);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(388, 38);
            this.btnDonate.TabIndex = 331;
            this.btnDonate.TabStop = false;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseCompatibleTextRendering = true;
            this.btnDonate.UseVisualStyleBackColor = false;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 20.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(3, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(405, 38);
            this.lblHeader.TabIndex = 330;
            this.lblHeader.Text = "Flyoobe";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(3, 127);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(405, 21);
            this.lblCopyright.TabIndex = 319;
            this.lblCopyright.Text = "A Belim app creation (C) 2025";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright.UseCompatibleTextRendering = true;
            // 
            // btnGitHub
            // 
            this.btnGitHub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGitHub.AutoEllipsis = true;
            this.btnGitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(26)))));
            this.btnGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGitHub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGitHub.FlatAppearance.BorderSize = 0;
            this.btnGitHub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnGitHub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGitHub.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold);
            this.btnGitHub.ForeColor = System.Drawing.Color.White;
            this.btnGitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGitHub.Location = new System.Drawing.Point(12, 170);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(388, 38);
            this.btnGitHub.TabIndex = 317;
            this.btnGitHub.TabStop = false;
            this.btnGitHub.Text = "GitHub";
            this.btnGitHub.UseCompatibleTextRendering = true;
            this.btnGitHub.UseVisualStyleBackColor = false;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(387, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 29);
            this.btnClose.TabIndex = 332;
            this.btnClose.Text = "...";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(436, 349);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "AboutForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.CheckBox chkDonated;
        private System.Windows.Forms.LinkLabel linkAppVersion;
    }
}