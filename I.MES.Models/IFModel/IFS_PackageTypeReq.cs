using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 协同-包装类型请求类
    /// </summary>
    public class IFS_PackageTypeReq
    {
        public List<IFS_PackageType> ReqList = new List<IFS_PackageType>();
    }

    /// <summary>
    /// 协同-包装类型信息
    /// </summary>
    public class IFS_PackageType
    {
        public string PkgTypeCode { get; set; }
        public string PkgTypeName { get; set; }
        public string PkgTypeDesc { get; set; }
        public string MixedPackage { get; set; }
        public string MixedQty { get; set; }
        public string AverageDist { get; set; }

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
