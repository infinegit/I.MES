namespace YFPO.MES.Client.UI.MFG
{
    partial class FrmImmOnBin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImmOnBin));
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerMainBody = new System.Windows.Forms.SplitContainer();
            this.splitContainerMainHeader = new System.Windows.Forms.SplitContainer();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblLastScanedBarcode = new System.Windows.Forms.Label();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ckb_Auto = new System.Windows.Forms.CheckBox();
            this.btnCancleOn = new System.Windows.Forms.Button();
            this.immAuto1 = new YFPO.MES.Client.UI.UserControl.IMMAuto.IMMAuto();
            this.btnDoScan = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnForceOn = new System.Windows.Forms.Button();
            this.btnOpenVirtualKeyBoard = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainBody)).BeginInit();
            this.splitContainerMainBody.Panel1.SuspendLayout();
            this.splitContainerMainBody.Panel2.SuspendLayout();
            this.splitContainerMainBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainHeader)).BeginInit();
            this.splitContainerMainHeader.Panel1.SuspendLayout();
            this.splitContainerMainHeader.Panel2.SuspendLayout();
            this.splitContainerMainHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_refresh
            // 
            this.timer_refresh.Interval = 2000;
            this.timer_refresh.Tick += new System.EventHandler(this.timer_refresh_Tick);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerMainBody);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainerMain.Panel2.Controls.Add(this.btnOpenVirtualKeyBoard);
            this.splitContainerMain.Panel2.Controls.Add(this.btnCheck);
            this.splitContainerMain.Size = new System.Drawing.Size(900, 664);
            this.splitContainerMain.SplitterDistance = 613;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerMainBody
            // 
            this.splitContainerMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMainBody.IsSplitterFixed = true;
            this.splitContainerMainBody.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainBody.Name = "splitContainerMainBody";
            this.splitContainerMainBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainBody.Panel1
            // 
            this.splitContainerMainBody.Panel1.Controls.Add(this.splitContainerMainHeader);
            // 
            // splitContainerMainBody.Panel2
            // 
            this.splitContainerMainBody.Panel2.Controls.Add(this.lblLastScanedBarcode);
            this.splitContainerMainBody.Panel2.Controls.Add(this.c1FlexGrid1);
            this.splitContainerMainBody.Panel2.Controls.Add(this.ckb_Auto);
            this.splitContainerMainBody.Panel2.Controls.Add(this.btnCancleOn);
            this.splitContainerMainBody.Panel2.Controls.Add(this.immAuto1);
            this.splitContainerMainBody.Panel2.Controls.Add(this.btnDoScan);
            this.splitContainerMainBody.Panel2.Controls.Add(this.txtBarcode);
            this.splitContainerMainBody.Panel2.Controls.Add(this.label4);
            this.splitContainerMainBody.Panel2.Controls.Add(this.BtnForceOn);
            this.splitContainerMainBody.Size = new System.Drawing.Size(900, 613);
            this.splitContainerMainBody.SplitterDistance = 38;
            this.splitContainerMainBody.TabIndex = 0;
            // 
            // splitContainerMainHeader
            // 
            this.splitContainerMainHeader.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainerMainHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainHeader.IsSplitterFixed = true;
            this.splitContainerMainHeader.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainHeader.Name = "splitContainerMainHeader";
            // 
            // splitContainerMainHeader.Panel1
            // 
            this.splitContainerMainHeader.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerMainHeader.Panel1.Controls.Add(this.lblMessage);
            // 
            // splitContainerMainHeader.Panel2
            // 
            this.splitContainerMainHeader.Panel2.Controls.Add(this.btnExit);
            this.splitContainerMainHeader.Size = new System.Drawing.Size(900, 38);
            this.splitContainerMainHeader.SplitterDistance = 822;
            this.splitContainerMainHeader.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblMessage.Location = new System.Drawing.Point(5, 1);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(538, 23);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "................................................................................." +
    ".......";
            this.lblMessage.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(-1, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lblLastScanedBarcode
            // 
            this.lblLastScanedBarcode.AutoSize = true;
            this.lblLastScanedBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScanedBarcode.Location = new System.Drawing.Point(582, 81);
            this.lblLastScanedBarcode.Name = "lblLastScanedBarcode";
            this.lblLastScanedBarcode.Size = new System.Drawing.Size(14, 19);
            this.lblLastScanedBarcode.TabIndex = 152;
            this.lblLastScanedBarcode.Text = ".";
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.c1FlexGrid1.AllowEditing = false;
            this.c1FlexGrid1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.c1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid1.AutoClipboard = true;
            this.c1FlexGrid1.AutoGenerateColumns = false;
            this.c1FlexGrid1.AutoResize = false;
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1FlexGrid1.Location = new System.Drawing.Point(5, 3);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 1;
            this.c1FlexGrid1.Rows.DefaultSize = 23;
            this.c1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGrid1.Size = new System.Drawing.Size(428, 563);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 151;
            this.c1FlexGrid1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ckb_Auto
            // 
            this.ckb_Auto.AutoSize = true;
            this.ckb_Auto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_Auto.Location = new System.Drawing.Point(474, 3);
            this.ckb_Auto.Name = "ckb_Auto";
            this.ckb_Auto.Size = new System.Drawing.Size(67, 27);
            this.ckb_Auto.TabIndex = 150;
            this.ckb_Auto.Text = "自动";
            this.ckb_Auto.UseVisualStyleBackColor = true;
            // 
            // btnCancleOn
            // 
            this.btnCancleOn.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancleOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancleOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancleOn.Location = new System.Drawing.Point(516, 500);
            this.btnCancleOn.Name = "btnCancleOn";
            this.btnCancleOn.Size = new System.Drawing.Size(130, 44);
            this.btnCancleOn.TabIndex = 148;
            this.btnCancleOn.Text = "取消上架";
            this.btnCancleOn.UseVisualStyleBackColor = false;
            this.btnCancleOn.Click += new System.EventHandler(this.btnQucikScan_Click);
            // 
            // immAuto1
            // 
            this.immAuto1.Active = false;
            this.immAuto1.edIn = null;
            this.immAuto1.edOut = null;
            this.immAuto1.Location = new System.Drawing.Point(558, 53);
            this.immAuto1.MachineNo = null;
            this.immAuto1.Name = "immAuto1";
            this.immAuto1.Size = new System.Drawing.Size(29, 23);
            this.immAuto1.TabIndex = 144;
            this.immAuto1.Text = "immAuto1";
            // 
            // btnDoScan
            // 
            this.btnDoScan.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoScan.Location = new System.Drawing.Point(845, 110);
            this.btnDoScan.Name = "btnDoScan";
            this.btnDoScan.Size = new System.Drawing.Size(50, 41);
            this.btnDoScan.TabIndex = 133;
            this.btnDoScan.Text = "OK";
            this.btnDoScan.UseVisualStyleBackColor = true;
            this.btnDoScan.Click += new System.EventHandler(this.btnDoScan_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(474, 103);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(365, 56);
            this.txtBarcode.TabIndex = 120;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(470, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 116;
            this.label4.Text = "补录条码";
            // 
            // BtnForceOn
            // 
            this.BtnForceOn.BackColor = System.Drawing.Color.LightGreen;
            this.BtnForceOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnForceOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnForceOn.Location = new System.Drawing.Point(655, 500);
            this.BtnForceOn.Name = "BtnForceOn";
            this.BtnForceOn.Size = new System.Drawing.Size(130, 44);
            this.BtnForceOn.TabIndex = 124;
            this.BtnForceOn.Text = "强制推荐";
            this.BtnForceOn.UseVisualStyleBackColor = false;
            // 
            // btnOpenVirtualKeyBoard
            // 
            this.btnOpenVirtualKeyBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpenVirtualKeyBoard.Location = new System.Drawing.Point(75, 0);
            this.btnOpenVirtualKeyBoard.Name = "btnOpenVirtualKeyBoard";
            this.btnOpenVirtualKeyBoard.Size = new System.Drawing.Size(75, 50);
            this.btnOpenVirtualKeyBoard.TabIndex = 6;
            this.btnOpenVirtualKeyBoard.Text = "键盘区";
            this.btnOpenVirtualKeyBoard.UseVisualStyleBackColor = true;
            this.btnOpenVirtualKeyBoard.Click += new System.EventHandler(this.btn_virtualKeyBoard_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCheck.Location = new System.Drawing.Point(0, 0);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 50);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "嫌疑品校验";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // FrmImmOnBin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 664);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerMain);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImmOnBin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmImmOnBin";
            this.Load += new System.EventHandler(this.FrmImmOnBin_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerMainBody.Panel1.ResumeLayout(false);
            this.splitContainerMainBody.Panel2.ResumeLayout(false);
            this.splitContainerMainBody.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainBody)).EndInit();
            this.splitContainerMainBody.ResumeLayout(false);
            this.splitContainerMainHeader.Panel1.ResumeLayout(false);
            this.splitContainerMainHeader.Panel1.PerformLayout();
            this.splitContainerMainHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainHeader)).EndInit();
            this.splitContainerMainHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerMainBody;
        private System.Windows.Forms.SplitContainer splitContainerMainHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnDoScan;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnForceOn;
        private UserControl.IMMAuto.IMMAuto immAuto1;
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.Button btnCancleOn;
        private System.Windows.Forms.CheckBox ckb_Auto;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblLastScanedBarcode;
        private System.Windows.Forms.Button btnOpenVirtualKeyBoard;
    }
}