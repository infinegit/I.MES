using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
   public class SPS_Trans
    {
        public string RackCode { get; set; }
        public string OrigStk { get; set; }
        public string DestStk { get; set; }
        public DateTime TransTime { get; set; }
        public string Status { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public string LatestModifyUser { get; set; }
        public DateTime LastestModifyTime { get; set; }
        public bool IsSyncSAP { get; set; }
        public string TaskId { get; set; }
        public string LogID { get; set; }
        public DateTime RecTime { get; set; } 
    }
}
