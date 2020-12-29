namespace I.MES.Client.UI.MFG
{
    partial class FrmPreAssembly
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtSlpBarcode = new CCWin.SkinControl.SkinTextBox();
            this.pnlPartInfo = new CCWin.SkinControl.SkinCaptionPanel();
            this.lblPartType = new CCWin.SkinControl.SkinLabel();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.lblPartName = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.lblPartNo = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinCaptionPanel1 = new CCWin.SkinControl.SkinCaptionPanel();
            this.skinDataGridView1 = new CCWin.SkinControl.SkinDataGridView();
            this.SLPBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEnter = new CCWin.SkinControl.SkinButton();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.skinButton4 = new CCWin.SkinControl.SkinButton();
            this.pnlPartInfo.SuspendLayout();
            this.skinCaptionPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(35, 59);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(103, 20);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "SLP Barcode:";
            // 
            // txtSlpBarcode
            // 
            this.txtSlpBarcode.BackColor = System.Drawing.Color.Transparent;
            this.txtSlpBarcode.DownBack = null;
            this.txtSlpBarcode.Icon = null;
            this.txtSlpBarcode.IconIsButton = false;
            this.txtSlpBarcode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSlpBarcode.IsPasswordChat = '\0';
            this.txtSlpBarcode.IsSystemPasswordChar = false;
            this.txtSlpBarcode.Lines = new string[0];
            this.txtSlpBarcode.Location = new System.Drawing.Point(164, 56);
            this.txtSlpBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSlpBarcode.MaxLength = 32767;
            this.txtSlpBarcode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSlpBarcode.MouseBack = null;
            this.txtSlpBarcode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSlpBarcode.Multiline = true;
            this.txtSlpBarcode.Name = "txtSlpBarcode";
            this.txtSlpBarcode.NormlBack = null;
            this.txtSlpBarcode.Padding = new System.Windows.Forms.Padding(5);
            this.txtSlpBarcode.ReadOnly = false;
            this.txtSlpBarcode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSlpBarcode.Size = new System.Drawing.Size(372, 29);
            // 
            // 
            // 
            this.txtSlpBarcode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSlpBarcode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSlpBarcode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSlpBarcode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSlpBarcode.SkinTxt.Multiline = true;
            this.txtSlpBarcode.SkinTxt.Name = "BaseText";
            this.txtSlpBarcode.SkinTxt.Size = new System.Drawing.Size(362, 19);
            this.txtSlpBarcode.SkinTxt.TabIndex = 0;
            this.txtSlpBarcode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSlpBarcode.SkinTxt.WaterText = "";
            this.txtSlpBarcode.TabIndex = 1;
            this.txtSlpBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSlpBarcode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSlpBarcode.WaterText = "";
            this.txtSlpBarcode.WordWrap = true;
            // 
            // pnlPartInfo
            // 
            this.pnlPartInfo.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.pnlPartInfo.Controls.Add(this.lblPartType);
            this.pnlPartInfo.Controls.Add(this.skinLabel6);
            this.pnlPartInfo.Controls.Add(this.lblPartName);
            this.pnlPartInfo.Controls.Add(this.skinLabel4);
            this.pnlPartInfo.Controls.Add(this.lblPartNo);
            this.pnlPartInfo.Controls.Add(this.skinLabel2);
            this.pnlPartInfo.Location = new System.Drawing.Point(27, 100);
            this.pnlPartInfo.Name = "pnlPartInfo";
            this.pnlPartInfo.Size = new System.Drawing.Size(1022, 90);
            this.pnlPartInfo.TabIndex = 2;
            this.pnlPartInfo.Text = "Part Information";
            // 
            // lblPartType
            // 
            this.lblPartType.AutoSize = true;
            this.lblPartType.BackColor = System.Drawing.Color.Transparent;
            this.lblPartType.BorderColor = System.Drawing.Color.White;
            this.lblPartType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPartType.Location = new System.Drawing.Point(878, 41);
            this.lblPartType.Name = "lblPartType";
            this.lblPartType.Size = new System.Drawing.Size(70, 20);
            this.lblPartType.TabIndex = 8;
            this.lblPartType.Text = "Model Y";
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(783, 40);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(89, 20);
            this.skinLabel6.TabIndex = 7;
            this.skinLabel6.Text = "PartType：";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.BackColor = System.Drawing.Color.Transparent;
            this.lblPartName.BorderColor = System.Drawing.Color.White;
            this.lblPartName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPartName.Location = new System.Drawing.Point(358, 40);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(382, 20);
            this.lblPartName.TabIndex = 6;
            this.lblPartName.Text = "Tesla Model Y pre-warranty - high matching - pearl ";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(259, 40);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(96, 20);
            this.skinLabel4.TabIndex = 5;
            this.skinLabel4.Text = "PartName：";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPartNo.BorderColor = System.Drawing.Color.White;
            this.lblPartNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPartNo.Location = new System.Drawing.Point(133, 41);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(99, 20);
            this.lblPartNo.TabIndex = 4;
            this.lblPartNo.Text = "1328010055";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(47, 40);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(64, 20);
            this.skinLabel2.TabIndex = 3;
            this.skinLabel2.Text = "PartNo:";
            // 
            // skinCaptionPanel1
            // 
            this.skinCaptionPanel1.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.skinCaptionPanel1.Controls.Add(this.skinDataGridView1);
            this.skinCaptionPanel1.Location = new System.Drawing.Point(27, 196);
            this.skinCaptionPanel1.Name = "skinCaptionPanel1";
            this.skinCaptionPanel1.Size = new System.Drawing.Size(1022, 363);
            this.skinCaptionPanel1.TabIndex = 3;
            this.skinCaptionPanel1.Text = "Scaning Record";
            // 
            // skinDataGridView1
            // 
            this.skinDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.skinDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skinDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView1.ColumnFont = null;
            this.skinDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skinDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLPBarcode,
            this.PartNo,
            this.PartName,
            this.Color,
            this.PartStatus,
            this.CreateTime});
            this.skinDataGridView1.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.skinDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinDataGridView1.EnableHeadersVisualStyles = false;
            this.skinDataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.skinDataGridView1.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinDataGridView1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView1.Location = new System.Drawing.Point(2, 24);
            this.skinDataGridView1.Name = "skinDataGridView1";
            this.skinDataGridView1.ReadOnly = true;
            this.skinDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skinDataGridView1.RowTemplate.Height = 23;
            this.skinDataGridView1.Size = new System.Drawing.Size(1018, 337);
            this.skinDataGridView1.TabIndex = 0;
            this.skinDataGridView1.TitleBack = null;
            this.skinDataGridView1.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView1.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // SLPBarcode
            // 
            this.SLPBarcode.HeaderText = "SLPBarcode";
            this.SLPBarcode.Name = "SLPBarcode";
            this.SLPBarcode.ReadOnly = true;
            this.SLPBarcode.Width = 180;
            // 
            // PartNo
            // 
            this.PartNo.HeaderText = "PartNo";
            this.PartNo.Name = "PartNo";
            this.PartNo.ReadOnly = true;
            this.PartNo.Width = 150;
            // 
            // PartName
            // 
            this.PartName.HeaderText = "PartName";
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            this.PartName.Width = 300;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 80;
            // 
            // PartStatus
            // 
            this.PartStatus.HeaderText = "PartStatus";
            this.PartStatus.Name = "PartStatus";
            this.PartStatus.ReadOnly = true;
            this.PartStatus.Width = 120;
            // 
            // CreateTime
            // 
            this.CreateTime.HeaderText = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 120;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnEnter.DownBack = null;
            this.btnEnter.Location = new System.Drawing.Point(562, 49);
            this.btnEnter.MouseBack = null;
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.NormlBack = null;
            this.btnEnter.Size = new System.Drawing.Size(102, 39);
            this.btnEnter.TabIndex = 5;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Location = new System.Drawing.Point(685, 50);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(102, 39);
            this.skinButton2.TabIndex = 6;
            this.skinButton2.Text = "Reset";
            this.skinButton2.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Location = new System.Drawing.Point(320, 575);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(134, 68);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
          //  this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // skinButton4
            // 
            this.skinButton4.BackColor = System.Drawing.Color.Transparent;
            this.skinButton4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton4.DownBack = null;
            this.skinButton4.Location = new System.Drawing.Point(562, 575);
            this.skinButton4.MouseBack = null;
            this.skinButton4.Name = "skinButton4";
            this.skinButton4.NormlBack = null;
            this.skinButton4.Size = new System.Drawing.Size(140, 68);
            this.skinButton4.TabIndex = 8;
            this.skinButton4.Text = "NG";
            this.skinButton4.UseVisualStyleBackColor = false;
            // 
            // FrmPreAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 671);
            this.Controls.Add(this.skinButton4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.skinButton2);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.skinCaptionPanel1);
            this.Controls.Add(this.pnlPartInfo);
            this.Controls.Add(this.txtSlpBarcode);
            this.Controls.Add(this.skinLabel1);
            this.Name = "FrmPreAssembly";
            this.Text = "pre-inspection station";
            this.Load += new System.EventHandler(this.FrmPreAssembly_Load);
            this.pnlPartInfo.ResumeLayout(false);
            this.pnlPartInfo.PerformLayout();
            this.skinCaptionPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox txtSlpBarcode;
        private CCWin.SkinControl.SkinCaptionPanel pnlPartInfo;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel lblPartType;
        private CCWin.SkinControl.SkinLabel lblPartName;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel lblPartNo;
        private CCWin.SkinControl.SkinCaptionPanel skinCaptionPanel1;
        private CCWin.SkinControl.SkinButton btnEnter;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton btnOK;
        private CCWin.SkinControl.SkinButton skinButton4;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLPBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
    }
}