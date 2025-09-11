namespace Flyoobe
{
    partial class DeviceControlView
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
            this.components = new System.ComponentModel.Container();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.assetViewInfo = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.textComputername = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnJoinDomain = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbLanguage.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.ForeColor = System.Drawing.Color.Black;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(28, 114);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(421, 29);
            this.cmbLanguage.TabIndex = 9;
            this.cmbLanguage.TabStop = false;
            // 
            // assetViewInfo
            // 
            this.assetViewInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.assetViewInfo.AutoSize = true;
            this.assetViewInfo.Font = new System.Drawing.Font("Segoe MDL2 Assets", 80.75F);
            this.assetViewInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(205)))), ((int)(((byte)(250)))));
            this.assetViewInfo.Location = new System.Drawing.Point(101, 126);
            this.assetViewInfo.Name = "assetViewInfo";
            this.assetViewInfo.Size = new System.Drawing.Size(114, 108);
            this.assetViewInfo.TabIndex = 16;
            this.assetViewInfo.Text = "...";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(135)))));
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.Black;
            this.btnApply.Location = new System.Drawing.Point(341, 165);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(108, 31);
            this.btnApply.TabIndex = 19;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "Apply";
            this.btnApply.UseCompatibleTextRendering = true;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // textUsername
            // 
            this.textUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUsername.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.ForeColor = System.Drawing.Color.Black;
            this.textUsername.Location = new System.Drawing.Point(28, 30);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(421, 25);
            this.textUsername.TabIndex = 20;
            this.textUsername.TabStop = false;
            this.textUsername.Text = "Name";
            this.toolTip.SetToolTip(this.textUsername, "Set or rename User");
            // 
            // lblHeader
            // 
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(835, 31);
            this.lblHeader.TabIndex = 21;
            this.lblHeader.Text = "Tell us who you are and how you want your system to speak to you";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // textComputername
            // 
            this.textComputername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textComputername.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textComputername.ForeColor = System.Drawing.Color.Black;
            this.textComputername.Location = new System.Drawing.Point(28, 72);
            this.textComputername.Name = "textComputername";
            this.textComputername.Size = new System.Drawing.Size(421, 25);
            this.textComputername.TabIndex = 22;
            this.textComputername.TabStop = false;
            this.textComputername.Text = "Computer Name";
            this.toolTip.SetToolTip(this.textComputername, "Set or rename Computer");
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.btnJoinDomain);
            this.panel1.Controls.Add(this.textComputername);
            this.panel1.Controls.Add(this.cmbLanguage);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.textUsername);
            this.panel1.Location = new System.Drawing.Point(321, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 287);
            this.panel1.TabIndex = 23;
            // 
            // btnJoinDomain
            // 
            this.btnJoinDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJoinDomain.AutoSize = true;
            this.btnJoinDomain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJoinDomain.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnJoinDomain.FlatAppearance.BorderSize = 0;
            this.btnJoinDomain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJoinDomain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJoinDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinDomain.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinDomain.ForeColor = System.Drawing.Color.Black;
            this.btnJoinDomain.Location = new System.Drawing.Point(29, 245);
            this.btnJoinDomain.Name = "btnJoinDomain";
            this.btnJoinDomain.Size = new System.Drawing.Size(93, 29);
            this.btnJoinDomain.TabIndex = 23;
            this.btnJoinDomain.Text = "Join Domain";
            this.btnJoinDomain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJoinDomain.UseVisualStyleBackColor = true;
            this.btnJoinDomain.Click += new System.EventHandler(this.btnJoinDomain_Click);
            // 
            // DeviceControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.assetViewInfo);
            this.Name = "DeviceControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label assetViewInfo;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox textComputername;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnJoinDomain;
    }
}
