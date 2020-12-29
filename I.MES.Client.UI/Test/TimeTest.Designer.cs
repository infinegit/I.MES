namespace I.MES.Client.UI.Test
{
    partial class TimeTest
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
            this.indicator1 = new I.MES.Client.UI.UserControls.Indicator();
            this.SuspendLayout();
            // 
            // indicator1
            // 
            this.indicator1.CircleWidth = 5;
            this.indicator1.IsShowLine = true;
            this.indicator1.LineCount = 12;
            this.indicator1.Location = new System.Drawing.Point(224, 42);
            this.indicator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.indicator1.MaxValue = 100F;
            this.indicator1.Name = "indicator1";
            this.indicator1.Size = new System.Drawing.Size(455, 352);
            this.indicator1.TabIndex = 0;
            this.indicator1.Value = 30F;
            // 
            // TimeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.indicator1);
            this.Name = "TimeTest";
            this.Text = "TimeTest";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Indicator indicator1;
    }
}