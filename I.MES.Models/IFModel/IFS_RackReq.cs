using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 协同-RK信息请求类
    /// </summary>
    public class IFS_RackReq
    {
        public List<IFS_Rack> ReqList = new List<IFS_Rack>();
    }

    /// <summary>
    /// 协同-RK信息
    /// </summary>
    public class IFS_Rack
    {
        public string RackCode { get; set; }
        public string PkgTypeCode { get; set; }
        public string RackStatus { get; set; }
        public string TSCode { get; set; }
        public string FlowType { get; set; }
        public string IsValid { get; set; }
        public string QualityStatus { get; set; }

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
