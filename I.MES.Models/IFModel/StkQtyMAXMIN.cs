using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IFModel
{
    public class StkQtyMAXMIN
    {
        public string PartNo { get; set; }
        public string PartDesc { get; set; }
        public string VehicleMode { get; set; }
        public decimal MinQty { get; set; }
        public string StkCode { get; set; }
        public decimal StkQty { get; set; }
        public decimal MaxQty { get; set; }
        public string RegionCode { get; set; }
    }
}
