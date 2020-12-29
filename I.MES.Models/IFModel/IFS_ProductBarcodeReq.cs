using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 协同-产品条码请求类
    /// </summary>
    public class IFS_ProductBarcodeReq
    {
        public List<IFS_ProductBarcode> ReqList = new List<IFS_ProductBarcode>();
    }

    /// <summary>
    /// 协同-产品条码信息
    /// </summary>
    public class IFS_ProductBarcode
    {
        public string Barcode { get; set; }
        public string CurrentPartNo { get; set; }
        public string CurrentPartVersion { get; set; }
        public string QualityStatus { get; set; }
        public string ControlStatus { get; set; }
        public string IsIsolated { get; set; }
        public string Printer { get; set; }
        public string IsPrinted { get; set; }
        public string PrintTime { get; set; }
        public string BarcodeStatus { get; set; }
        public string LatestProdTime { get; set; }
        public string TaskId { get; set; }
        public string RecTime { get; set; }
        public string OrigFactoryCode { get; set; }
        public string OrigCompany { get; set; }
        public string DestFactoryCode { get; set; }
        public string DestCompany { get; set; }
        public string SenderOrderNo { get; set; }
        public string BurnishTimes { get; set; }
        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
