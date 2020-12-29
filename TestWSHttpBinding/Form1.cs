using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestWSHttpBinding.ServiceReference1;
using YFPO.MES.ClientCore;
namespace TestWSHttpBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (IChannel channel = ChannelFactory.GetChannel())
                {
                    channel.Open();
                }

                ServiceBaseClient client = new ServiceBaseClient();
                client.Open();
                client.Send("abc");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
