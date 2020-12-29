using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    public class SYS_RoleStkPrivViewModel
    {
        public int ID { get; set; }
        public string RoleCode { get; set; }
        public string StkCode { get; set; }
        public bool AllowIn { get; set; }
        public bool AllowOut { get; set; }
        public bool AllowUpBin { get; set; }
        public bool AllowDownBin { get; set; }
        public string CreateUserAccount { get; set; }
        public string CreateMachine { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string LatestModifyUserAccount { get; set; }
        public System.DateTime LatestModifyTime { get; set; }
        public string LatestModifyMachine { get; set; }
        public string RoleName { get; set; }
        public string StkName { get; set; }
    }
}
