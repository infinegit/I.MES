using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class SPS_PkgChg
    {
        public string RackCode { get; set; }
        public string PartNo { get; set; }
        public string ProductBarcode { get; set; }
        public string Status { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public string LatestModifyUser { get; set; }
        public DateTime LastestModifyTime { get; set; }
        public bool IsSyncSAP { get; set; }
        public string TaskId { get; set; }
        public DateTime RecTime { get; set; }
    }
}
