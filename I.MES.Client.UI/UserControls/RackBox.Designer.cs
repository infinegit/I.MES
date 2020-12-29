namespace I.MES.Client.UI.UserControls
{
    partial class RackBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinCaption = new CCWin.SkinControl.SkinCaptionPanel();
            this.skinFlowLayoutPanel1 = new CCWin.SkinControl.SkinFlowLayoutPanel();
            this.lbPartNo = new CCWin.SkinControl.SkinLabel();
            this.lblPartName = new System.Windows.Forms.Label();
            this.btnOpen = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.lblCurrentState = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.lblPickState = new CCWin.SkinControl.SkinLabel();
            this.skinCaption.SuspendLayout();
            this.skinFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinCaption
            // 
            this.skinCaption.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.skinCaption.Controls.Add(this.lblPickState);
            this.skinCaption.Controls.Add(this.skinLabel3);
            this.skinCaption.Controls.Add(this.lblCurrentState);
            this.skinCaption.Controls.Add(this.skinLabel1);
            this.skinCaption.Controls.Add(this.btnOpen);
            this.skinCaption.Controls.Add(this.skinFlowLayoutPanel1);
            this.skinCaption.Controls.Add(this.lbPartNo);
            this.skinCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinCaption.Location = new System.Drawing.Point(0, 0);
            this.skinCaption.Name = "skinCaption";
            this.skinCaption.Size = new System.Drawing.Size(294, 296);
            this.skinCaption.TabIndex = 0;
            this.skinCaption.Text = "skinCaptionPanel1";
            // 
            // skinFlowLayoutPanel1
            // 
            this.skinFlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinFlowLayoutPanel1.Controls.Add(this.lblPartName);
            this.skinFlowLayoutPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinFlowLayoutPanel1.DownBack = null;
            this.skinFlowLayoutPanel1.Location = new System.Drawing.Point(14, 79);
            this.skinFlowLayoutPanel1.MouseBack = null;
            this.skinFlowLayoutPanel1.Name = "skinFlowLayoutPanel1";
            this.skinFlowLayoutPanel1.NormlBack = null;
            this.skinFlowLayoutPanel1.Size = new System.Drawing.Size(275, 51);
            this.skinFlowLayoutPanel1.TabIndex = 2;
            // 
            // lbPartNo
            // 
            this.lbPartNo.AutoSize = true;
            this.lbPartNo.BackColor = System.Drawing.Color.Transparent;
            this.lbPartNo.BorderColor = System.Drawing.Color.White;
            this.lbPartNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPartNo.Location = new System.Drawing.Point(104, 39);
            this.lbPartNo.Name = "lbPartNo";
            this.lbPartNo.Size = new System.Drawing.Size(81, 20);
            this.lbPartNo.TabIndex = 0;
            this.lbPartNo.Text = "80000003";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPartName.Location = new System.Drawing.Point(3, 0);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(263, 30);
            this.lblPartName.TabIndex = 0;
            this.lblPartName.Text = "Front fog lamp - dark green and black";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOpen.DownBack = null;
            this.btnOpen.Location = new System.Drawing.Point(78, 241);
            this.btnOpen.MouseBack = null;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.NormlBack = null;
            this.btnOpen.Size = new System.Drawing.Size(124, 38);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(27, 153);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(106, 20);
            this.skinLabel1.TabIndex = 4;
            this.skinLabel1.Text = "CurrentState:";
            // 
            // lblCurrentState
            // 
            this.lblCurrentState.AutoSize = true;
            this.lblCurrentState.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentState.BorderColor = System.Drawing.Color.White;
            this.lblCurrentState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentState.Location = new System.Drawing.Point(168, 154);
            this.lblCurrentState.Name = "lblCurrentState";
            this.lblCurrentState.Size = new System.Drawing.Size(49, 20);
            this.lblCurrentState.TabIndex = 5;
            this.lblCurrentState.Text = "Open";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(52, 190);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(80, 20);
            this.skinLabel3.TabIndex = 6;
            this.skinLabel3.Text = "PickState:";
            // 
            // lblPickState
            // 
            this.lblPickState.AutoSize = true;
            this.lblPickState.BackColor = System.Drawing.Color.Transparent;
            this.lblPickState.BorderColor = System.Drawing.Color.White;
            this.lblPickState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPickState.Location = new System.Drawing.Point(168, 190);
            this.lblPickState.Name = "lblPickState";
            this.lblPickState.Size = new System.Drawing.Size(49, 20);
            this.lblPickState.TabIndex = 7;
            this.lblPickState.Text = "Open";
            // 
            // RackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinCaption);
            this.Name = "RackBox";
            this.Size = new System.Drawing.Size(294, 296);
            this.skinCaption.ResumeLayout(false);
            this.skinCaption.PerformLayout();
            this.skinFlowLayoutPanel1.ResumeLayout(false);
            this.skinFlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinCaptionPanel skinCaption;
        private CCWin.SkinControl.SkinFlowLayoutPanel skinFlowLayoutPanel1;
        private CCWin.SkinControl.SkinLabel lbPartNo;
        private CCWin.SkinControl.SkinButton btnOpen;
        private System.Windows.Forms.Label lblPartName;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel lblCurrentState;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel lblPickState;
    }
}
