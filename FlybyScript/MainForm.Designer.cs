namespace Flyby11
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
            this.panelDragDrop = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkCompPatch = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.panelFAQ = new System.Windows.Forms.Panel();
            this.linkAppDev = new System.Windows.Forms.LinkLabel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelDragDrop.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDragDrop
            // 
            this.panelDragDrop.AllowDrop = true;
            this.panelDragDrop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDragDrop.Controls.Add(this.linkLabel1);
            this.panelDragDrop.Controls.Add(this.linkCompPatch);
            this.panelDragDrop.Controls.Add(this.statusLabel);
            this.panelDragDrop.Location = new System.Drawing.Point(47, 184);
            this.panelDragDrop.Name = "panelDragDrop";
            this.panelDragDrop.Size = new System.Drawing.Size(436, 256);
            this.panelDragDrop.TabIndex = 0;
            this.panelDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDragDrop_DragDrop);
            this.panelDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDragDrop_DragEnter);
            this.panelDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDragDrop_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkLabel1.AutoEllipsis = true;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(141, 230);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(157, 15);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Can I upgrade to Windows 11?";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkCompPatch
            // 
            this.linkCompPatch.ActiveLinkColor = System.Drawing.Color.BlueViolet;
            this.linkCompPatch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkCompPatch.AutoSize = true;
            this.linkCompPatch.BackColor = System.Drawing.Color.Transparent;
            this.linkCompPatch.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCompPatch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkCompPatch.LinkColor = System.Drawing.Color.DimGray;
            this.linkCompPatch.Location = new System.Drawing.Point(95, 208);
            this.linkCompPatch.Name = "linkCompPatch";
            this.linkCompPatch.Size = new System.Drawing.Size(244, 15);
            this.linkCompPatch.TabIndex = 211;
            this.linkCompPatch.TabStop = true;
            this.linkCompPatch.Text = "Apply Compatibility Patch to ISO (Clean Install)";
            this.linkCompPatch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCompPatch_LinkClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(39, 44);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(352, 139);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Move ISO here";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFAQ
            // 
            this.panelFAQ.AutoScroll = true;
            this.panelFAQ.BackColor = System.Drawing.Color.Gainsboro;
            this.panelFAQ.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFAQ.Location = new System.Drawing.Point(561, 0);
            this.panelFAQ.Name = "panelFAQ";
            this.panelFAQ.Size = new System.Drawing.Size(359, 585);
            this.panelFAQ.TabIndex = 207;
            // 
            // linkAppDev
            // 
            this.linkAppDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAppDev.AutoSize = true;
            this.linkAppDev.BackColor = System.Drawing.Color.Gainsboro;
            this.linkAppDev.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAppDev.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAppDev.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(115)))), ((int)(((byte)(193)))));
            this.linkAppDev.Location = new System.Drawing.Point(821, -1);
            this.linkAppDev.Name = "linkAppDev";
            this.linkAppDev.Size = new System.Drawing.Size(99, 15);
            this.linkAppDev.TabIndex = 208;
            this.linkAppDev.TabStop = true;
            this.linkAppDev.Text = "We live on GitHub";
            this.linkAppDev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAppDev_LinkClicked);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelMain);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(561, 585);
            this.panelContainer.TabIndex = 209;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelDragDrop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(561, 585);
            this.panelMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(920, 585);
            this.Controls.Add(this.linkAppDev);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelFAQ);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flyby11 Upgrading Assistant";
            this.panelDragDrop.ResumeLayout(false);
            this.panelDragDrop.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDragDrop;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel panelFAQ;
        private System.Windows.Forms.LinkLabel linkAppDev;
        private System.Windows.Forms.LinkLabel linkCompPatch;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

