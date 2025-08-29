namespace Flyoobe
{
    partial class LogForm
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
            this.richLog = new System.Windows.Forms.RichTextBox();
            this.panelLogger = new System.Windows.Forms.Panel();
            this.panelLogger.SuspendLayout();
            this.SuspendLayout();
            // 
            // richLog
            // 
            this.richLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.richLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richLog.Font = new System.Drawing.Font("Cascadia Code", 8.75F);
            this.richLog.Location = new System.Drawing.Point(14, 14);
            this.richLog.Name = "richLog";
            this.richLog.Size = new System.Drawing.Size(608, 290);
            this.richLog.TabIndex = 0;
            this.richLog.Text = "";
            // 
            // panelLogger
            // 
            this.panelLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.panelLogger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogger.Controls.Add(this.richLog);
            this.panelLogger.Location = new System.Drawing.Point(12, 12);
            this.panelLogger.Name = "panelLogger";
            this.panelLogger.Size = new System.Drawing.Size(637, 319);
            this.panelLogger.TabIndex = 1;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(661, 343);
            this.Controls.Add(this.panelLogger);
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications";
            this.panelLogger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richLog;
        private System.Windows.Forms.Panel panelLogger;
    }
}