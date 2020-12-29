using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 协同-HU明细请求类
    /// </summary>
    public class IFS_HUPkgDetReq
    {
        public List<IFS_HUPkgDet> ReqList = new List<IFS_HUPkgDet>();
    }

    /// <summary>
    /// 协同-HU明细信息
    /// </summary>
    public class IFS_HUPkgDet
    {
        public string HUCode { get; set; }
        public string Barcode { get; set; }
        public string PkgTime { get; set; }
        public string PkgUserAccount { get; set; }
        public string PkgMachine { get; set; }
        public string HUID { get; set; }

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
