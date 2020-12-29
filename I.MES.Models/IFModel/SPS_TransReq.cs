using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
   public class SPS_TransReq
    {
        private List<SPS_Trans> trans;

        public List<SPS_Trans> Trans
        {
            get { return trans; }
            set { trans = value; }
        }
    }
}
