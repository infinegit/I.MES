//责任人：cgong
//主要用途：登录校验，工厂变更

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using I.MES.Models;
using I.MES.Library;

using System.Net;

namespace I.MES.Client.UI.SYS
{
    public partial class FrmLogin : FrmBaseOpt
    {
        public string title;
        public SYS_User currentUser = null;
        public I.MES.Models.SYS_Factory currentFactory = null;
        UserOP userOp = new UserOP();
        FactoryOp factoryOp = new FactoryOp();
        string password = string.Empty;
        public List<SYS_ProgPriv> currentPrivilegeList = new List<SYS_ProgPriv>();
        public List<SYS_User> availUsers = new List<SYS_User>();

        /// <summary>  
        /// Set the resource culture  
        /// </summary>  
        private void SetResourceCulture()
        {

            // Set the form title text  
            this.Text = ResourceCulture.GetString("Login_frmText");

            // Set the groupbox text  
            this.gbLanguageSelection.Text = ResourceCulture.GetString("Login_gbLanguageSelectionText");

            // Set radiobutton text  
            this.rbEnglish.Text = ResourceCulture.GetString("Login_rbEnglishText");
            this.rbChinese.Text = ResourceCulture.GetString("Login_rbChineseText");

            //set lbl
            this.lblWebcome.Text = ResourceCulture.GetString("Login_lblWelcomeText");
            this.lblstaffno.Text = ResourceCulture.GetString("Login_lblstaffnoText");
            this.lblPassword.Text = ResourceCulture.GetString("Login_lblPasswordText");
            this.lblFactory.Text = ResourceCulture.GetString("Login_lblFactoryText");

            //set btn
            this.btnChagePwd.Text = ResourceCulture.GetString("Login_btnChagePwdText");
            this.btnBack.Text = ResourceCulture.GetString("Login_btnBackText");
            this.btnConfirm.Text = ResourceCulture.GetString("Login_btnConfirmText");
            this.btnReset.Text = ResourceCulture.GetString("Login_btnResetText");

        }

        public FrmLogin()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmLogin_Load);
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
            this.tx_id.GotFocus += new EventHandler(tx_id_GotFocus);
            this.tx_pwd.GotFocus += new EventHandler(tx_pwd_GotFocus);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Set the default language  
            ResourceCulture.SetCurrentCulture("en-US");
            rbEnglish.Select();
            this.SetResourceCulture();
            try
            {
                availUsers = userOp.GetAvailUsers() as List<SYS_User>;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnChagePwd_Click(object sender, EventArgs e)
        {
            SYS.FrmChangePassword frm = new FrmChangePassword();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            

            if (this.tx_id.Focused)
            {
                this.tx_pwd.Focus();
            }
            else if (this.tx_pwd.Focused)
            { }
            TryLogin();
        }

        public static string HttpPost(string url, string body)
        {
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            byte[] buffer = encoding.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.tx_id.Focused)
            { }
            //this.tx_id.Clear();
            else
            { }
                //this.tx_pwd.Text.c();
        }
        private void lb_Click(object sender, EventArgs e)
        {
            SendKeys.Send(((Label)sender).Text.Trim());
        }
        private void tx_id_GotFocus(object sender, EventArgs e)
        {
            //this.tx_id.SelectAll();
        }
        private void tx_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != null && e.KeyCode != Keys.Return && e.KeyCode != Keys.Enter)
                { return; }
            tx_pwd.Focus();
        }
        private void tx_pwd_GotFocus(object sender, EventArgs e)
        {
            //this.tx_pwd.SelectAll();
        }
        private void tx_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                TryLogin();
        }
        private void cb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tx_pwd.Focus();
        }
        private void cb_factory_DropDown(object sender, EventArgs e)
       {
            try
            {
               if (this.cbFactory.Items.Count == 0)
                {
                 
                    hideMessage();
                   // UserOP userOp = new UserOP();

                    currentUser = userOp.GetUser(tx_id.Text.Trim());
                    //currentUser = availUsers.Find(p => p.UserAccount == tx_id.Text.Trim());
                    if (currentUser == null)
                    {
                        ShowError("用户名不存在!");
                        return;
                    }

                    ///
                    //List<I.MES.Models.Region> regions = userOp.GetUserAvailRegions(tx_id.Text.Trim());
                    List<I.MES.Models.SYS_Factory> factories = userOp.GetUserAvailFactories(currentUser.UserAccount);
                    cbFactory.DataSource = factories;
                    cbFactory.DisplayMember = "FactoryName";
                    cbFactory.ValueMember = "FactoryCode";

                    //ArrayList regions = userOp.GetUserRegions(tx_id.Text.Trim());
                    //List<UserRegionPriv> userRegions = (List<UserRegionPriv>)userOp.GetUserRegions(user.UserAccount);
                    //if (userRegions == null)
                    //{
                    //    return;
                    //}
                    //InitRegionCombo(userRegions);
                    //string loginMsg = UserModule.CheckLoginInfo(this.tx_id.Text.Trim(), this.tx_pwd.Text.Trim());
                    //if (string.IsNullOrEmpty(loginMsg))
                    //{
                    //    InitRegionCombo();
                    //}
                    //else
                    //{
                    //    this.lb_error.Text = loginMsg;
                    //    this.lb_error.Visible = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
        private void tx_id_TextChanged(object sender, EventArgs e)
        {
            this.cbFactory.DataSource = null;
        }
        private void tx_pwd_TextChanged(object sender, EventArgs e)
        {
            if (tx_pwd.Text == this.password)
            {
                cb_factory_DropDown(null, null);
            }
            else
            {
                cbFactory.DataSource = null;
            }
        }

        private void TryLogin()
        {

            //BasicProperty.Log.Info("尝试登录...");
            try
            {
                //以下代码检验登录
                string uid = this.tx_id.Text;
                string pwd = this.tx_pwd.Text;
                if (uid == "000")
                {
                    this.Close();
                    return;
                }

                if (!userOp.Login(tx_id.Text.Trim(), tx_pwd.Text.Trim()))
                {
                    ShowError("用户名或密码错误!");
                    return;
                }
                //检查工厂是否为空
                if (this.cbFactory.SelectedValue == null || this.cbFactory.SelectedValue.ToString() == string.Empty)
                {
                    ShowError("请选择登录工厂");
                    return;
                }
                currentUser = userOp.GetUser(tx_id.Text.Trim());
                //currentRegion = regionOp.GetRegion(this.cb_region.SelectedValue.ToString());
                currentFactory = (I.MES.Models.SYS_Factory)this.cbFactory.SelectedItem;

                currentPrivilegeList = userOp.GetUserPrivs(tx_id.Text.Trim());
                if (BasicProperty.ClientInfo != null)
                {
                    BasicProperty.ClientInfo.LoginUser = currentUser.UserAccount;
                    BasicProperty.ClientInfo.FactoryCode = currentFactory.FactoryCode;
                    BasicProperty.ClientInfo.CompanyCode = currentFactory.CompanyCode;
                }
                else
                {
                    BasicProperty.ClientInfo = new ClientInformation()
                    {
                        CurrentSysUser = Environment.UserName,
                        System = Environment.OSVersion.ToString(),
                        Machine = Environment.MachineName,
                        LogID = BasicProperty.Log.LogID,
                        LoginUser = currentUser.UserAccount,
                        FactoryCode = currentFactory.FactoryCode,
                        CompanyCode = currentFactory.CompanyCode,
                        TransferMethod = TransferType.Json
                    };
                }
                
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch (Exception ex)
            {
                BasicProperty.Log.Error(ex);
                throw;
            }
            //else
            //{
            //    if (this.cb_region.SelectedValue == null || this.cb_region.SelectedValue.ToString() == string.Empty)
            //    {
            //        this.tx_id.Focus();
            //        this.lb_error.Visible = true;
            //        this.lb_error.Text = MessageText.MsgDict.E0012;
            //        return;
            //    }

            //    string loginresult = UserModule.CheckLoginInfo(uid, pwd);
            //    if (loginresult == string.Empty)
            //    {
            //        frm_YesNoDialog frmt = new frm_YesNoDialog();
            //        frmt.lb_message.Text = MessageText.MsgDict.E0004 + this.cb_region.Text + "";
            //        if (frmt.ShowDialog() != DialogResult.Yes)
            //        {
            //            this.tx_id.Focus();
            //            this.lb_error.Visible = true;
            //            this.lb_error.Text = MessageText.MsgDict.E0005;
            //        }
            //        else
            //        {
            //            if (LocModule.UpdateCurrentMachineRegion(Program.machinename, this.cb_region.SelectedValue.ToString()))
            //            {
            //                //更新成功后切换工厂
            //                Program.region = this.cb_region.SelectedValue.ToString();
            //                Program.username = uid;

            //                //检查是否在黑名单内
            //                if (UserModule.IsInBlackList(Program.machinename))
            //                {
            //                    MessageText.ShowErrorBox(MessageText.MsgDict.E0006);
            //                    Application.ExitThread();
            //                    return;
            //                }

            //                //正式发布时去掉注释
            //                //UpdateFile();

            //                frm_Menu frm = new frm_Menu();
            //                frm.title = this.Text;
            //                frm.loginform = this;
            //                frm.Show();
            //                this.tx_id.Text = string.Empty;
            //                this.tx_pwd.Text = string.Empty;
            //                this.lb_error.Visible = false;
            //                this.tx_id.Focus();
            //                this.Hide();
            //            }
            //            else
            //            {
            //                this.tx_id.Focus();
            //                this.lb_error.Visible = true;
            //                this.lb_error.Text = MessageText.MsgDict.E0000;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        this.tx_id.Focus();
            //        this.lb_error.Visible = true;
            //        this.lb_error.Text = loginresult;
            //    }
            //}
        }
        private void UpdateFile()
        {
            try
            {
                //string ufile = "file.upg";
                //IniFileTools inifile = new IniFileTools(Application.StartupPath + @"\IMES.DB.DLL");
                //ArrayList listserver = new ArrayList();
                //ArrayList listlocal = new ArrayList();

                //SqlConnection conn = new SqlConnection();
                //string connstr = inifile.GetString("Connection", "localmes", string.Empty);
                //conn.ConnectionString = connstr;
                //conn.Open();
                //SqlCommand mycomm = new SqlCommand();
                //mycomm.CommandText = ConfigModule.GetAllFileSql();
                //mycomm.Connection = conn;
                //SqlDataReader myreader = mycomm.ExecuteReader();
                //while (myreader.Read())
                //{
                //    listserver.Add(myreader[0].ToString() + "," + myreader[1].ToString() + "," + myreader[2].ToString());
                //}
                //myreader.Close();
                //conn.Close();

                ////校验版本是否正确
                //CheckVersion("I.MES.Client.UI.exe", listserver);
                //CheckOtherVersion("IMESBiz.dll", listserver);

                //try
                //{
                //    StreamReader sr = new StreamReader(ufile);
                //    string line;
                //    while ((line = sr.ReadLine()) != null)
                //    {
                //        listlocal.Add(line);
                //    }
                //    sr.Close();
                //    File.Delete(ufile);
                //}
                //catch { }

                //StreamWriter sw = new StreamWriter(ufile);
                //foreach (string x in listserver)
                //{
                //    if (listlocal.IndexOf(x) < 0)
                //    {
                //        string[] xfile = x.Split(',');
                //        string filename = xfile[0];
                //        if (filename != "I.MES.Client.UI.exe")
                //        {
                //            if (filename.ToLower() == "localdb.mdb")
                //            {
                //                if (ConfigModule.CheckLocalDbHasData(cn))
                //                {
                //                    MessageText.ShowErrorBox(MessageText.MsgDict.E0009);
                //                    Application.ExitThread();
                //                    return;
                //                }
                //            }
                //            int length = Convert.ToInt32(xfile[2]);
                //            string strSql = ConfigModule.GetFileSqlByName(filename);
                //            SqlConnection connx = new SqlConnection();
                //            connx.ConnectionString = connstr;
                //            connx.Open();
                //            SqlCommand mycommx = new SqlCommand();
                //            mycommx.CommandText = strSql;
                //            mycommx.Connection = connx;

                //            SqlDataReader myreaderx = mycommx.ExecuteReader();
                //            if (myreaderx.Read())
                //            {
                //                try
                //                {
                //                    byte[] b = (byte[])myreaderx.GetValue(0);
                //                    FileStream fs = new FileStream(filename, FileMode.Create);
                //                    for (int i = 0; i < b.Length; i++)
                //                    {
                //                        fs.WriteByte(b[i]);
                //                    }
                //                    fs.Close();
                //                }
                //                catch { }
                //            }
                //        }
                //    }
                //    sw.WriteLine(x);
                //}
                //sw.Close();
            }
            catch { }
        }
        private void InitFactoryCombo(List<SYS_UserFactoryPriv> userFactories)
        {

            //System.Collections.Generic.List<User> users = new System.Collections.Generic.List<User>();
            this.cbFactory.DataSource = userFactories;
            this.cbFactory.DisplayMember = "FactoryName";
            this.cbFactory.ValueMember = "FactoryCode";

            //this.

            ////初始化工厂下拉框MO
            //foreach (string region in regions)
            //{
            //    this.cb_region.Items.Add(region);
            //}
            //if (this.cb_region.Items.Contains(Program.region))
            //{
            //    this.cb_region.SelectedValue = Program.region;
            //}
            //DataTable dt = LocModule.GetAvailableRegion(this.tx_id.Text.Trim());
            //this.cb_region.DisplayMember = "name";
            //this.cb_region.ValueMember = "region";
            //this.cb_region.DataSource = dt;
            //try
            //{
            //    this.cb_region.SelectedValue = Program.region;
            //}
            //catch { }
        }
        private void CheckVersion(string programm, ArrayList listserver)
        {
            //foreach (string x in listserver)
            //{
            //    if (x.Split(',')[0] == programm)
            //    {
            //        string[] xfile = x.Split(',');
            //        if (xfile[1] != Assembly.GetExecutingAssembly().GetName().Version.ToString())
            //        {
            //            MessageText.ShowErrorBox(programm + MessageText.MsgDict.E0007);
            //            Application.ExitThread();
            //            return;
            //        }
            //    }
            //}
        }
        private void CheckOtherVersion(string programm, ArrayList listserver)
        {
            foreach (string x in listserver)
            {
                //if (x.Split(',')[0] == programm)
                //{
                //    string[] xfile = x.Split(',');
                //    if (xfile[1] != Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "/" + programm).GetName().Version.ToString())
                //    {
                //        MessageText.ShowErrorBox(programm + MessageText.MsgDict.E0008);
                //        if (ConfigModule.GetIntValue(MessageText.CodeMstrStr.ForceUpdate) == 1)
                //        {
                //            Application.ExitThread();
                //            return;
                //        }
                //    }
                //}
            }
        }


        private void tx_id_Leave(object sender, EventArgs e)
        {
            var user = userOp.GetUser(tx_id.Text);
            if (user != null)
            {
                this.password = user.Password;
            }
        }

        private void DownloadLocalData()
        {
            //try
            //{
            //    if (NeedDownload)
            //    {
            //        this.toolStripContainer1.Visible = false;
            //        ConfigModule.Initial911csv();
            //        ConfigModule.UpdateLocalData();
            //        this.toolStripContainer1.Visible = true;
            //    }
            //}
            //catch
            //{
            //    this.toolStripContainer1.Visible = true;
            //    Control.CheckForIllegalCrossThreadCalls = true;
            //}
        }

        private void rbEnglish_CheckedChanged(object sender, EventArgs e)
        {
            ResourceCulture.SetCurrentCulture("en-US");
            this.SetResourceCulture();
        }

        private void rbChinese_CheckedChanged(object sender, EventArgs e)
        {
            ResourceCulture.SetCurrentCulture("zh-CN");
            this.SetResourceCulture();
        }







    }
}
