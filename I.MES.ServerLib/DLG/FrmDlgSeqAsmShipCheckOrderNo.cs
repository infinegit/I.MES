using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YFPO.MES.Models;
using YFPO.MES.Library;

namespace YFPO.MES.Library.DLG
{
    public partial class FrmDlgSeqAsmShipCheckOrderNo:Form
    {


        private string SeqOrderNo = string.Empty;

        public FrmDlgSeqAsmShipCheckOrderNo(string seqOrderNo)
        {
            InitializeComponent();
            this.SeqOrderNo = seqOrderNo;
            this.Load += new EventHandler(FrmPluginSeqAsmShipCheckOrderNo_Load);
        }

        private void FrmPluginSeqAsmShipCheckOrderNo_Load(object sender, EventArgs e)
        {
            if (SeqOrderNo == "")
            {
                lb_message.Text = "当前排序单号为空";
            }
            lbOrderNo.Text = SeqOrderNo;
            lb_message.Text = "";
        }

        private void dialogReturnYes()
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void dialogReturnNo()
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        public FrmDlgSeqAsmShipCheckOrderNo()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtjyBarcode.Text.ToUpper() == SeqOrderNo)
            {
                dialogReturnYes();
            }
            lb_message.Text = "扫描排序单号" + txtjyBarcode.Text.Trim() + "和当前排序单号不一致。";

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnOk_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dialogReturnNo();
        }
    }
}
