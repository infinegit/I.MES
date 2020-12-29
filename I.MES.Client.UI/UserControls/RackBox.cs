using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CCWin.SkinControl;

namespace I.MES.Client.UI.UserControls
{
    public partial class RackBox : UserControl
    {
        private string catptionName;

        private int refreTime;

        private string currentState;

        private string s;

     
        public  RackBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// currentState
        /// </summary>
         public string CurrentState
        {
          get { return currentState; }
          set { currentState = value; }
        }
        /// <summary>
        /// BOX Caption
        /// </summary>
        public string CatptionName
        {
            get
            {
                return catptionName;
            }
            set
            {
                catptionName = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// refreshTime
        /// </summary>
        public int RefreTime
        {
            get { return refreTime; }
            set { refreTime = value; }
        }
        /// <summary>
        /// open door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        public delegate void RefreshControl(string s);


    }
}
