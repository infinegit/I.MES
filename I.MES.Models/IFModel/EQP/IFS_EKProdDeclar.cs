using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class IFS_EKProdDeclar
    {
        /// <summary>
        /// 产线
        /// </summary>
        public string ProdLine { get; set; }
        /// <summary>
        /// 模具/工装号
        /// </summary>
        public string MouldCode { get; set; }
        ///// <summary>
        ///// 设备号
        ///// </summary>
        //public string DeviceCode { get; set; }
        /// <summary>
        /// 零件号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string PartVersion { get; set; }
        /// <summary>
        /// 扫描点
        /// </summary>
        public string ScanSiteCode { get; set; }
        /// <summary>
        /// 主条码
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 被Bonding 条码
        /// </summary>
        public List<string> SubBarcode { get; set; }
    }
    //public class SubBarcode
    //{ 
       
    //}
}
