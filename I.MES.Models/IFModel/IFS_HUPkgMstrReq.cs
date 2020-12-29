using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 协同-HU主表请求类
    /// </summary>
    public class IFS_HUPkgMstrReq
    {
        public List<IFS_HUPkgMstr> ReqList = new List<IFS_HUPkgMstr>();
    }

    /// <summary>
    /// 协同-HU主表信息
    /// </summary>
    public class IFS_HUPkgMstr
    {
        public string HUCode { get; set; }
        public string RackCode { get; set; }
        public string PkgTypeCode { get; set; }
        public string PartNo { get; set; }
        public string PartVersion { get; set; }
        public string QualityStatusCode { get; set; }
        public string HUQty { get; set; }
        public string HUMaxQty { get; set; }
        public string IsSealed { get; set; }
        public string HUID { get; set; }
        public string IsIsolated { get; set; }
        public string PackageStatus { get; set; }
        public string EarliestProdTime { get; set; }

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
