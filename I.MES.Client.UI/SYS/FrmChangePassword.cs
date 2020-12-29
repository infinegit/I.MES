//责任人：cgong
//主要用途：修改密码

using System;
using System.Windows.Forms;

//重构完毕
namespace I.MES.Client.UI.SYS
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
            this.lb_1.Click += new EventHandler(lb_Click);
            this.lb_2.Click += new EventHandler(lb_Click);
            this.lb_3.Click += new EventHandler(lb_Click);
            this.lb_4.Click += new EventHandler(lb_Click);
            this.lb_5.Click += new EventHandler(lb_Click);
            this.lb_6.Click += new EventHandler(lb_Click);
            this.lb_7.Click += new EventHandler(lb_Click);
            this.lb_8.Click += new EventHandler(lb_Click);
            this.lb_9.Click += new EventHandler(lb_Click);
            this.lb_0.Click += new EventHandler(lb_Click);
            this.lb_m.Click += new EventHandler(lb_Click);
            this.lb_s.Click += new EventHandler(lb_Click);
            this.txtUserAccount.GotFocus += new EventHandler(tx_id_GotFocus);
            this.txtOrigPwd.GotFocus += new EventHandler(tx_pwd_GotFocus);
            this.txtNewPwd1.GotFocus += new EventHandler(textBox1_GotFocus);
            this.txtNewPwd2.GotFocus += new EventHandler(textBox2_GotFocus);
        }
        private void lb_confirm_Click(object sender, EventArgs e)
        {
            if (this.txtUserAccount.Focused)
                this.txtOrigPwd.Focus();
            else if (this.txtOrigPwd.Focused)
                this.txtNewPwd1.Focus();
            else if (this.txtNewPwd1.Focused)
                this.txtNewPwd2.Focus();
            else if (this.txtNewPwd2.Focused)
                TryChange();
        }
        private void lb_reset_Click(object sender, EventArgs e)
        {
            if (this.txtUserAccount.Focused)
                this.txtUserAccount.Clear();
            else if (this.txtOrigPwd.Focused)
                this.txtOrigPwd.Clear();
            else if (this.txtNewPwd1.Focused)
                this.txtNewPwd1.Clear();
            else if (this.txtNewPwd2.Focused)
                this.txtNewPwd2.Clear();
        }
        private void lb_Click(object sender, EventArgs e)
        {
            SendKeys.Send(((Label)sender).Text.Trim());
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        private void tx_pwd_GotFocus(object sender, EventArgs e)
        {
            this.txtOrigPwd.SelectAll();
        }
        private void tx_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (this.txtUserAccount.Text == "000")
                {
                    Application.ExitThread();
                    return;
                }
                else
                {
                    this.txtNewPwd1.Focus();
                }
            }
        }
        private void tx_id_GotFocus(object sender, EventArgs e)
        {
            this.txtUserAccount.SelectAll();
        }
        private void tx_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (this.txtUserAccount.Text == "000")
                {
                    Application.ExitThread();
                    return;
                }
                else
                {
                    this.txtOrigPwd.Focus();
                }
            }
        }
        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            this.txtNewPwd1.SelectAll();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (this.txtUserAccount.Text == "000")
                {
                    Application.ExitThread();
                    return;
                }
                else
                {
                    this.txtNewPwd2.Focus();
                }
            }
        }
        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            this.txtNewPwd2.SelectAll();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                TryChange();
        }
        private void TryChange()
        {
            try
            {
                string uid = this.txtUserAccount.Text;
                string origPwd = this.txtOrigPwd.Text;
                if (uid == "000")
                {
                    this.Close();
                }
                if (this.txtNewPwd1.Text.Length < 8)
                {
                    this.txtNewPwd1.Clear();
                    this.txtNewPwd2.Clear();
                    this.txtNewPwd1.Select();
                    this.lb_error.Visible = true;
                    this.lb_error.Text = "密码至少>=8位";
                    return;
                }
                if (this.txtNewPwd1.Text != this.txtNewPwd2.Text)
                {
                    this.lb_error.Visible = true;
                    this.lb_error.Text = "两次输入的密码不一致";
                    return;
                }

                    //校验密码是否与前两次相同，先不做

                string newPwd = txtNewPwd1.Text.Trim();
                //修改密码
                if (!new Library.UserOP().ChangePwd(uid, origPwd, newPwd))
                {
                    this.lb_error.Visible = true;
                    this.lb_error.Text = "密码修改失败";
                }

                this.lb_error.Visible = true;
                this.lb_error.Text = "密码修改成功";

            }
            catch (Exception ex)
            {
                this.lb_error.Visible = true;
                this.lb_error.Text = ex.Message;
            }

        }
    }
}