namespace I.MES.Client.UI.SYS
{
    partial class FrmChangePassword
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_error = new System.Windows.Forms.Label();
            this.txtNewPwd2 = new System.Windows.Forms.TextBox();
            this.txtNewPwd1 = new System.Windows.Forms.TextBox();
            this.txtOrigPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_pwd = new System.Windows.Forms.Label();
            this.txtUserAccount = new System.Windows.Forms.TextBox();
            this.lb_staffno = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_s = new System.Windows.Forms.Label();
            this.lb_9 = new System.Windows.Forms.Label();
            this.lb_6 = new System.Windows.Forms.Label();
            this.lb_3 = new System.Windows.Forms.Label();
            this.lb_0 = new System.Windows.Forms.Label();
            this.lb_8 = new System.Windows.Forms.Label();
            this.lb_5 = new System.Windows.Forms.Label();
            this.lb_m = new System.Windows.Forms.Label();
            this.lb_2 = new System.Windows.Forms.Label();
            this.lb_7 = new System.Windows.Forms.Label();
            this.lb_reset = new System.Windows.Forms.Label();
            this.lb_4 = new System.Windows.Forms.Label();
            this.lb_confirm = new System.Windows.Forms.Label();
            this.lb_1 = new System.Windows.Forms.Label();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.groupBox1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.groupBox3);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(700, 354);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(700, 354);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_error);
            this.groupBox1.Controls.Add(this.txtNewPwd2);
            this.groupBox1.Controls.Add(this.txtNewPwd1);
            this.groupBox1.Controls.Add(this.txtOrigPwd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lb_pwd);
            this.groupBox1.Controls.Add(this.txtUserAccount);
            this.groupBox1.Controls.Add(this.lb_staffno);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 371);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(150, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 47);
            this.label1.TabIndex = 7;
            this.label1.Text = "退出";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_error
            // 
            this.lb_error.AutoSize = true;
            this.lb_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_error.ForeColor = System.Drawing.Color.Red;
            this.lb_error.Location = new System.Drawing.Point(15, 229);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(166, 25);
            this.lb_error.TabIndex = 6;
            this.lb_error.Text = "用户名密码错误";
            this.lb_error.Visible = false;
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd2.Location = new System.Drawing.Point(150, 181);
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.PasswordChar = '●';
            this.txtNewPwd2.Size = new System.Drawing.Size(248, 38);
            this.txtNewPwd2.TabIndex = 3;
            this.txtNewPwd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // txtNewPwd1
            // 
            this.txtNewPwd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd1.Location = new System.Drawing.Point(150, 137);
            this.txtNewPwd1.Name = "txtNewPwd1";
            this.txtNewPwd1.PasswordChar = '●';
            this.txtNewPwd1.Size = new System.Drawing.Size(248, 38);
            this.txtNewPwd1.TabIndex = 2;
            this.txtNewPwd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txtOrigPwd
            // 
            this.txtOrigPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrigPwd.Location = new System.Drawing.Point(150, 79);
            this.txtOrigPwd.Name = "txtOrigPwd";
            this.txtOrigPwd.PasswordChar = '●';
            this.txtOrigPwd.Size = new System.Drawing.Size(248, 38);
            this.txtOrigPwd.TabIndex = 1;
            this.txtOrigPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_pwd_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(14, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "确认密码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(14, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "新密码:";
            // 
            // lb_pwd
            // 
            this.lb_pwd.AutoSize = true;
            this.lb_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_pwd.Location = new System.Drawing.Point(14, 82);
            this.lb_pwd.Name = "lb_pwd";
            this.lb_pwd.Size = new System.Drawing.Size(107, 31);
            this.lb_pwd.TabIndex = 9;
            this.lb_pwd.Text = "原密码:";
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserAccount.Location = new System.Drawing.Point(150, 35);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.Size = new System.Drawing.Size(248, 38);
            this.txtUserAccount.TabIndex = 0;
            this.txtUserAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_id_KeyDown);
            // 
            // lb_staffno
            // 
            this.lb_staffno.AutoSize = true;
            this.lb_staffno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_staffno.Location = new System.Drawing.Point(14, 38);
            this.lb_staffno.Name = "lb_staffno";
            this.lb_staffno.Size = new System.Drawing.Size(79, 31);
            this.lb_staffno.TabIndex = 8;
            this.lb_staffno.Text = "工号:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lb_s);
            this.groupBox3.Controls.Add(this.lb_9);
            this.groupBox3.Controls.Add(this.lb_6);
            this.groupBox3.Controls.Add(this.lb_3);
            this.groupBox3.Controls.Add(this.lb_0);
            this.groupBox3.Controls.Add(this.lb_8);
            this.groupBox3.Controls.Add(this.lb_5);
            this.groupBox3.Controls.Add(this.lb_m);
            this.groupBox3.Controls.Add(this.lb_2);
            this.groupBox3.Controls.Add(this.lb_7);
            this.groupBox3.Controls.Add(this.lb_reset);
            this.groupBox3.Controls.Add(this.lb_4);
            this.groupBox3.Controls.Add(this.lb_confirm);
            this.groupBox3.Controls.Add(this.lb_1);
            this.groupBox3.Location = new System.Drawing.Point(410, -4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 371);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // lb_s
            // 
            this.lb_s.BackColor = System.Drawing.Color.Navy;
            this.lb_s.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_s.ForeColor = System.Drawing.Color.White;
            this.lb_s.Location = new System.Drawing.Point(198, 229);
            this.lb_s.Name = "lb_s";
            this.lb_s.Size = new System.Drawing.Size(68, 55);
            this.lb_s.TabIndex = 23;
            this.lb_s.Text = "#";
            this.lb_s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_9
            // 
            this.lb_9.BackColor = System.Drawing.Color.Navy;
            this.lb_9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_9.ForeColor = System.Drawing.Color.White;
            this.lb_9.Location = new System.Drawing.Point(198, 165);
            this.lb_9.Name = "lb_9";
            this.lb_9.Size = new System.Drawing.Size(68, 55);
            this.lb_9.TabIndex = 20;
            this.lb_9.Text = "9";
            this.lb_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_6
            // 
            this.lb_6.BackColor = System.Drawing.Color.Navy;
            this.lb_6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_6.ForeColor = System.Drawing.Color.White;
            this.lb_6.Location = new System.Drawing.Point(198, 100);
            this.lb_6.Name = "lb_6";
            this.lb_6.Size = new System.Drawing.Size(68, 55);
            this.lb_6.TabIndex = 17;
            this.lb_6.Text = "6";
            this.lb_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_3
            // 
            this.lb_3.BackColor = System.Drawing.Color.Navy;
            this.lb_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_3.ForeColor = System.Drawing.Color.White;
            this.lb_3.Location = new System.Drawing.Point(198, 35);
            this.lb_3.Name = "lb_3";
            this.lb_3.Size = new System.Drawing.Size(68, 55);
            this.lb_3.TabIndex = 14;
            this.lb_3.Text = "3";
            this.lb_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_0
            // 
            this.lb_0.BackColor = System.Drawing.Color.Navy;
            this.lb_0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_0.ForeColor = System.Drawing.Color.White;
            this.lb_0.Location = new System.Drawing.Point(118, 229);
            this.lb_0.Name = "lb_0";
            this.lb_0.Size = new System.Drawing.Size(68, 55);
            this.lb_0.TabIndex = 22;
            this.lb_0.Text = "0";
            this.lb_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_8
            // 
            this.lb_8.BackColor = System.Drawing.Color.Navy;
            this.lb_8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_8.ForeColor = System.Drawing.Color.White;
            this.lb_8.Location = new System.Drawing.Point(118, 165);
            this.lb_8.Name = "lb_8";
            this.lb_8.Size = new System.Drawing.Size(68, 55);
            this.lb_8.TabIndex = 19;
            this.lb_8.Text = "8";
            this.lb_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_5
            // 
            this.lb_5.BackColor = System.Drawing.Color.Navy;
            this.lb_5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_5.ForeColor = System.Drawing.Color.White;
            this.lb_5.Location = new System.Drawing.Point(118, 100);
            this.lb_5.Name = "lb_5";
            this.lb_5.Size = new System.Drawing.Size(68, 55);
            this.lb_5.TabIndex = 16;
            this.lb_5.Text = "5";
            this.lb_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_m
            // 
            this.lb_m.BackColor = System.Drawing.Color.Navy;
            this.lb_m.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_m.ForeColor = System.Drawing.Color.White;
            this.lb_m.Location = new System.Drawing.Point(38, 229);
            this.lb_m.Name = "lb_m";
            this.lb_m.Size = new System.Drawing.Size(68, 55);
            this.lb_m.TabIndex = 21;
            this.lb_m.Text = "*";
            this.lb_m.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_2
            // 
            this.lb_2.BackColor = System.Drawing.Color.Navy;
            this.lb_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_2.ForeColor = System.Drawing.Color.White;
            this.lb_2.Location = new System.Drawing.Point(118, 35);
            this.lb_2.Name = "lb_2";
            this.lb_2.Size = new System.Drawing.Size(68, 55);
            this.lb_2.TabIndex = 13;
            this.lb_2.Text = "2";
            this.lb_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_7
            // 
            this.lb_7.BackColor = System.Drawing.Color.Navy;
            this.lb_7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_7.ForeColor = System.Drawing.Color.White;
            this.lb_7.Location = new System.Drawing.Point(38, 165);
            this.lb_7.Name = "lb_7";
            this.lb_7.Size = new System.Drawing.Size(68, 55);
            this.lb_7.TabIndex = 18;
            this.lb_7.Text = "7";
            this.lb_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_reset
            // 
            this.lb_reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_reset.ForeColor = System.Drawing.Color.White;
            this.lb_reset.Location = new System.Drawing.Point(38, 298);
            this.lb_reset.Name = "lb_reset";
            this.lb_reset.Size = new System.Drawing.Size(111, 47);
            this.lb_reset.TabIndex = 4;
            this.lb_reset.Text = "重置";
            this.lb_reset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_reset.Click += new System.EventHandler(this.lb_reset_Click);
            // 
            // lb_4
            // 
            this.lb_4.BackColor = System.Drawing.Color.Navy;
            this.lb_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_4.ForeColor = System.Drawing.Color.White;
            this.lb_4.Location = new System.Drawing.Point(38, 100);
            this.lb_4.Name = "lb_4";
            this.lb_4.Size = new System.Drawing.Size(68, 55);
            this.lb_4.TabIndex = 15;
            this.lb_4.Text = "4";
            this.lb_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_confirm
            // 
            this.lb_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_confirm.ForeColor = System.Drawing.Color.White;
            this.lb_confirm.Location = new System.Drawing.Point(155, 298);
            this.lb_confirm.Name = "lb_confirm";
            this.lb_confirm.Size = new System.Drawing.Size(111, 47);
            this.lb_confirm.TabIndex = 5;
            this.lb_confirm.Text = "确认";
            this.lb_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_confirm.Click += new System.EventHandler(this.lb_confirm_Click);
            // 
            // lb_1
            // 
            this.lb_1.BackColor = System.Drawing.Color.Navy;
            this.lb_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_1.ForeColor = System.Drawing.Color.White;
            this.lb_1.Location = new System.Drawing.Point(38, 35);
            this.lb_1.Name = "lb_1";
            this.lb_1.Size = new System.Drawing.Size(68, 55);
            this.lb_1.TabIndex = 12;
            this.lb_1.Text = "1";
            this.lb_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmChangePassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(700, 354);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "r";
            this.TopMost = true;
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_confirm;
        private System.Windows.Forms.Label lb_reset;
        private System.Windows.Forms.TextBox txtOrigPwd;
        private System.Windows.Forms.Label lb_pwd;
        private System.Windows.Forms.TextBox txtUserAccount;
        private System.Windows.Forms.Label lb_staffno;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lb_1;
        private System.Windows.Forms.Label lb_6;
        private System.Windows.Forms.Label lb_3;
        private System.Windows.Forms.Label lb_5;
        private System.Windows.Forms.Label lb_2;
        private System.Windows.Forms.Label lb_4;
        private System.Windows.Forms.Label lb_s;
        private System.Windows.Forms.Label lb_9;
        private System.Windows.Forms.Label lb_0;
        private System.Windows.Forms.Label lb_8;
        private System.Windows.Forms.Label lb_m;
        private System.Windows.Forms.Label lb_7;
        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPwd2;
        private System.Windows.Forms.TextBox txtNewPwd1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

    }
}