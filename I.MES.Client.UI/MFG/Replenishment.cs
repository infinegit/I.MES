using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using I.MES.Models;
using I.MES.Library;
using I.MES.Tools;

namespace I.MES.Client.UI.MFG
{
    public partial class FrmRelenishment:FrmBaseOpt
    {
        private static readonly object sync = new object();
        //private readonly ScanSiteInfo _scansiteInfo = new ScanSiteInfo();
        //private readonly ScanSiteOP _scansiteOp = new ScanSiteOP();
        private string siteCode = "ProdScheduleCreate";//扫描站点
        public FrmRelenishment()
        {
            InitializeComponent();
        }

        public FrmRelenishment(SYS_Prog prog)
        {
            InitializeComponent();
            //_scansiteInfo.prog = prog;
            //_scansiteInfo.currentUser = Program.currentUser;
            //_scansiteInfo.currentFactory = Program.currentFactory;
            //_scansiteInfo.currentScanSite = new ScanSiteOP().GetPkgScanSite(siteCode);
            this.Load += new EventHandler(StationScan_Load);
           // this.Disposed += new EventHandler(FrmBTO_Disposed);
            this.Text = "(" + prog.ProgCode + ")" + prog.ProgName + "-(" + Program.currentUser.UserAccount + ")" + Program.currentUser.UserName;
        }

        private void StationScan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void skinLabel1_Click(object sender, EventArgs e)
        {

        }

        private void skinCaptionPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
