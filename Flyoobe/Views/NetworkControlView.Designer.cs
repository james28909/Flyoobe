namespace Flyoobe
{
    partial class NetworkControlView
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.listBoxNetworks = new System.Windows.Forms.CheckedListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.radioWifi = new System.Windows.Forms.RadioButton();
            this.assetViewInfo = new System.Windows.Forms.Label();
            this.radioEthernet = new System.Windows.Forms.RadioButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(368, 348);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 31);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseCompatibleTextRendering = true;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(206)))), ((int)(((byte)(249)))));
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.btnConnect.FlatAppearance.BorderSize = 2;
            this.btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.Location = new System.Drawing.Point(547, 348);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 31);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseCompatibleTextRendering = true;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // listBoxNetworks
            // 
            this.listBoxNetworks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNetworks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.listBoxNetworks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxNetworks.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.25F, System.Drawing.FontStyle.Bold);
            this.listBoxNetworks.ForeColor = System.Drawing.Color.Black;
            this.listBoxNetworks.FormattingEnabled = true;
            this.listBoxNetworks.Location = new System.Drawing.Point(341, 119);
            this.listBoxNetworks.Name = "listBoxNetworks";
            this.listBoxNetworks.Size = new System.Drawing.Size(366, 154);
            this.listBoxNetworks.TabIndex = 16;
            this.listBoxNetworks.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.lblStatus.Location = new System.Drawing.Point(337, 284);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(34, 20);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Idle";
            // 
            // radioWifi
            // 
            this.radioWifi.AutoSize = true;
            this.radioWifi.Checked = true;
            this.radioWifi.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.75F, System.Drawing.FontStyle.Bold);
            this.radioWifi.ForeColor = System.Drawing.Color.Black;
            this.radioWifi.Location = new System.Drawing.Point(341, 72);
            this.radioWifi.Name = "radioWifi";
            this.radioWifi.Size = new System.Drawing.Size(92, 27);
            this.radioWifi.TabIndex = 18;
            this.radioWifi.TabStop = true;
            this.radioWifi.Text = "Use Wi-Fi";
            this.radioWifi.UseCompatibleTextRendering = true;
            this.radioWifi.UseVisualStyleBackColor = true;
            // 
            // assetViewInfo
            // 
            this.assetViewInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.assetViewInfo.AutoSize = true;
            this.assetViewInfo.Font = new System.Drawing.Font("Segoe MDL2 Assets", 60.75F);
            this.assetViewInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(205)))), ((int)(((byte)(250)))));
            this.assetViewInfo.Location = new System.Drawing.Point(101, 172);
            this.assetViewInfo.Name = "assetViewInfo";
            this.assetViewInfo.Size = new System.Drawing.Size(86, 81);
            this.assetViewInfo.TabIndex = 19;
            this.assetViewInfo.Text = "...";
            // 
            // radioEthernet
            // 
            this.radioEthernet.AutoSize = true;
            this.radioEthernet.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11.75F, System.Drawing.FontStyle.Bold);
            this.radioEthernet.ForeColor = System.Drawing.Color.Black;
            this.radioEthernet.Location = new System.Drawing.Point(341, 315);
            this.radioEthernet.Name = "radioEthernet";
            this.radioEthernet.Size = new System.Drawing.Size(117, 27);
            this.radioEthernet.TabIndex = 20;
            this.radioEthernet.Text = "Use Ethernet";
            this.radioEthernet.UseCompatibleTextRendering = true;
            this.radioEthernet.UseVisualStyleBackColor = true;
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
            this.lblHeader.TabIndex = 23;
            this.lblHeader.Text = "Let\'s connect you to a network";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // NetworkControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.radioEthernet);
            this.Controls.Add(this.assetViewInfo);
            this.Controls.Add(this.radioWifi);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBoxNetworks);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnConnect);
            this.Name = "NetworkControlView";
            this.Size = new System.Drawing.Size(835, 457);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckedListBox listBoxNetworks;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RadioButton radioWifi;
        private System.Windows.Forms.Label assetViewInfo;
        private System.Windows.Forms.RadioButton radioEthernet;
        private System.Windows.Forms.Label lblHeader;
    }
}
