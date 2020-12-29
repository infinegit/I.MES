using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class IFS_IntercompanyReq
    {
        public List<IFS_Intercompany> ReqList = new List<IFS_Intercompany>();
    }

    /// <summary>
    /// 协同-HU明细信息
    /// </summary>
    public class IFS_Intercompany
    {
        public string FactoryCode { get; set; }
        public string PartNo { get; set; }
        public string Qty { get; set; }
        public string OrderNo { get; set; }
        public string CreateTime { get; set; }
        public string CreateMachine { get; set; }

        public string TaskId { get; set; }
        public string RecTime { get; set; }
        public string OrigFactoryCode { get; set; }
        public string OrigCompany { get; set; }
        public string DestFactoryCode { get; set; }
        public string DestCompany { get; set; }
        public string SenderOrderNo { get; set; }

        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
