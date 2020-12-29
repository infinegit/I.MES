/*
 主窗体，用于现场扫描程序的主界面显示
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using I.MES.Models;
using I.MES.Library;
using I.MES.Tools;

namespace I.MES.Client.UI
{
    public partial class FrmMain : FrmBaseOpt
    {
        bool isLoginedIn = false;
        List<SYS_Prog> progs = null;
        Form currentProgForm = null;
        //User currentUser = null;
        //I.MES.Models.Region currentRegion = new I.MES.Models.Region();
        public FrmMain()
        {
            InitializeComponent();
            childActionButtonClick = new ChildButtonClick(ProgBtnClick);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            System.Environment.Exit(0);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.bgWorkCheckNetwork.RunWorkerAsync();
            //如果没有登录过，直接弹出登录界面，如果登录成功了，再进行初始化。
            if (!isLoginedIn)
            {
                this.Hide();
                SYS.FrmLogin frmLogin = new SYS.FrmLogin();
                currentProgForm = frmLogin;
                if (frmLogin.ShowDialog() != DialogResult.Yes)
                {
                    Application.Exit();
                    return;
                    //frmLogin.ShowDialog();
                    //if (frmLogin.DialogResult == DialogResult.Cancel)
                    //{
                    //    this.Close();
                    //}
                }
                //登录成功，进行初始化相关基本参数，并显示用户界面。
                Program.currentUser = frmLogin.currentUser;
                Program.currentFactory = frmLogin.currentFactory;
                Program.currentPrivilegeList = frmLogin.currentPrivilegeList;

                if (BasicProperty.ClientInfo != null)
                {
                    BasicProperty.ClientInfo.LoginUser = Program.currentUser.UserAccount;
                    BasicProperty.ClientInfo.FactoryCode = Program.currentFactory.FactoryCode;
                    BasicProperty.ClientInfo.CompanyCode = Program.currentFactory.CompanyCode;
                }
                else
                {
                    BasicProperty.ClientInfo = new ClientInformation()
                    {
                        CurrentSysUser = Environment.UserName,
                        System = Environment.OSVersion.ToString(),
                        Machine = Environment.MachineName,
                        LogID = BasicProperty.Log.LogID,
                        LoginUser = Program.currentUser.UserAccount,
                        FactoryCode = Program.currentFactory.FactoryCode,
                        CompanyCode = Program.currentFactory.CompanyCode,
                        TransferMethod = TransferType.Json
                    };
                }

                SYS_Company company = new ComPanyOP().GetCompanyList().FirstOrDefault();
                if (company != null)
                {
                    this.Text = "公司:" + company.CompanyName + "[" + company.CompanyCode + "],工厂:" + frmLogin.currentFactory.FactoryName + "[" + frmLogin.currentFactory.FactoryCode + "], 用户:" + Program.currentUser.UserName + "[" + Program.currentUser.UserAccount + "],IP:"+BasicProperty.ClientInfo.IP;
                }
                isLoginedIn = true;
                frmLogin.Close();
                currentProgForm = null;
                this.Show();
                initMenu();
                try 
                {
                    Button btn = (Button)pnlPrivBtn.Controls[0];
                    if (btn != null)
                    {
                        btn.Focus();
                    }
                }
                catch
                {
                
                }
            }
        }

        private void initMenu()
        {
            try
            {
                UserOP userOp = new UserOP();
                progs = userOp.GetUserProgs(Program.currentUser.UserAccount, "MESScan").OrderBy(p=>StringTools.GetSpellCode(p.ProgName)).ToList();
                progs.ForEach(prog =>
                {
                    
                    Button btn = createNewButton(prog.ProgName, prog.ProgCode, string.Empty, string.Empty, 100, 50);
                    pnlPrivBtn.Controls.Add(btn);
                });
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
        private void ProgBtnClick(object sender, EventArgs e)
        {
            try
            {
                string progCode = ((Button)sender).Tag.ToString();
                SYS_Prog prog = progs.First(p => p.ProgCode == progCode);
                FrmBaseOpt frm = null;
                //string formName = ((Button)sender).Text;
                Assembly asm = Assembly.GetExecutingAssembly();
                Object[] parameters = new Object[1];
                parameters[0] = prog;
                //parameters[1] = currentRegion;

                string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                frm = (FrmBaseOpt)asm.CreateInstance(currentNameSpace + "." + prog.ProgType + "." + prog.ProgForm, true, BindingFlags.Default, null, parameters, null, null);
                currentProgForm = frm;
                while (frm.DialogResult != DialogResult.Cancel)
                {
                    this.Hide();
                    frm.ShowDialog();
                }
                frm.Dispose();
                currentProgForm = null; 
                this.Show();
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
                this.Show();//如果子窗体抛异常的话，报完错，当前窗体还需要再显示出来。
            }
        }

        private void bgWorkCheckNetwork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string testIP = new Properties.Settings().HeartBeatIP;
                while (true)
                {
                    try
                    {
                        //Ping pingreq = new Ping();
                        //PingReply pr = pingreq.Send(testIP, 2000);
                        //if (pr.Address != null)
                        //    e.Result = true;
                        //else
                        //    e.Result = false;
                        if (BasicProperty.ServerInfo.Delay <= 1000)
                        {
                            e.Result = true;
                        }
                        else
                        {
                            e.Result = false;
                        }
                    }
                    catch
                    {
                        e.Result = false;
                    }
                    finally
                    {
                        Thread.Sleep(1000);
                        this.bgWorkCheckNetwork.ReportProgress(0, e.Result);
                    }
                }
            }
            catch
            { }
        }

        private void bgWorkCheckNetwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if ((bool)e.UserState)
                     currentProgForm.BackColor = System.Drawing.SystemColors.Control;
                else
                    currentProgForm.BackColor = System.Drawing.SystemColors.HotTrack;
            }
            catch { }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //进程彻底被结束
            System.Environment.Exit(0);
        }
    }
}
