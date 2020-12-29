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
using CCWin;

namespace I.MES.Client.UI.MFG
{
    public partial class FrmPreAssembly : FrmBaseOpt
    {
        public FrmPreAssembly()
        {
            InitializeComponent();
        }

        private void FrmPreAssembly_Load(object sender, EventArgs e)
        {
            txtSlpBarcode.SkinTxt.Text = "";
            txtSlpBarcode.SkinTxt.Focus();


        }
        /// <summary>
        /// 回车确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {

        }



    }
}
