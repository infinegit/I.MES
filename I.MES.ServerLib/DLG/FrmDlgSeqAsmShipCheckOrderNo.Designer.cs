namespace YFPO.MES.Library.DLG
{
    partial class FrmDlgSeqAsmShipCheckOrderNo
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
            this.lbOrderNo = new System.Windows.Forms.Label();
            this.lbOrderName = new System.Windows.Forms.Label();
            this.lb_message = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtjyBarcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbOrderNo
            // 
            this.lbOrderNo.AutoSize = true;
            this.lbOrderNo.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.lbOrderNo.Location = new System.Drawing.Point(173, 40);
            this.lbOrderNo.Name = "lbOrderNo";
            this.lbOrderNo.Size = new System.Drawing.Size(46, 22);
            this.lbOrderNo.TabIndex = 13;
            this.lbOrderNo.Text = "...";
            // 
            // lbOrderName
            // 
            this.lbOrderName.AutoSize = true;
            this.lbOrderName.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.lbOrderName.Location = new System.Drawing.Point(39, 33);
            this.lbOrderName.Name = "lbOrderName";
            this.lbOrderName.Size = new System.Drawing.Size(125, 22);
            this.lbOrderName.TabIndex = 12;
            this.lbOrderName.Text = "当前排序单";
            // 
            // lb_message
            // 
            this.lb_message.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lb_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_message.ForeColor = System.Drawing.Color.Red;
            this.lb_message.Location = new System.Drawing.Point(17, 107);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(594, 155);
            this.lb_message.TabIndex = 11;
            this.lb_message.Text = "...";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.lblNo.Location = new System.Drawing.Point(39, 68);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(125, 22);
            this.lblNo.TabIndex = 10;
            this.lblNo.Text = "扫描排序单";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(309, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 80);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Green;
            this.btnOk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(66, 265);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(153, 80);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtjyBarcode
            // 
            this.txtjyBarcode.Font = new System.Drawing.Font("宋体", 18F);
            this.txtjyBarcode.Location = new System.Drawing.Point(174, 65);
            this.txtjyBarcode.Name = "txtjyBarcode";
            this.txtjyBarcode.Size = new System.Drawing.Size(423, 35);
            this.txtjyBarcode.TabIndex = 7;
            this.txtjyBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // FrmDlgSeqAsmShipCheckOrderNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 348);
            this.Controls.Add(this.lbOrderNo);
            this.Controls.Add(this.lbOrderName);
            this.Controls.Add(this.lb_message);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtjyBarcode);
            this.Name = "FrmDlgSeqAsmShipCheckOrderNo";
            this.Text = "校验排序单号";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrderNo;
        private System.Windows.Forms.Label lbOrderName;
        public System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtjyBarcode;
    }
}