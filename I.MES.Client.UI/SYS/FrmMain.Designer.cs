namespace I.MES.Client.UI
{
    partial class FrmMain
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
            this.pnlPrivBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.bgWorkCheckNetwork = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pnlPrivBtn
            // 
            this.pnlPrivBtn.AutoScroll = true;
            this.pnlPrivBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPrivBtn.Location = new System.Drawing.Point(13, 51);
            this.pnlPrivBtn.Name = "pnlPrivBtn";
            this.pnlPrivBtn.Size = new System.Drawing.Size(925, 486);
            this.pnlPrivBtn.TabIndex = 0;
            // 
            // bgWorkCheckNetwork
            // 
            this.bgWorkCheckNetwork.WorkerReportsProgress = true;
            this.bgWorkCheckNetwork.WorkerSupportsCancellation = true;
            this.bgWorkCheckNetwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkCheckNetwork_DoWork);
            this.bgWorkCheckNetwork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkCheckNetwork_ProgressChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 602);
            this.Controls.Add(this.pnlPrivBtn);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlPrivBtn;
        private System.ComponentModel.BackgroundWorker bgWorkCheckNetwork;
    }
}