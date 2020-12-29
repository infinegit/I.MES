using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// ISV调用MES生成条码生，返回的条码信息
    /// 对应MFG_ProductBarcode
    /// </summary>
    public class ProductBarcode
    {
        public int ID { get; set; }
        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 当前零件号
        /// </summary>
        public string CurrentPartNo { get; set; }
        /// <summary>
        /// 当前零件版本号
        /// </summary>
        public string CurrentPartVersion { get; set; }
        /// <summary>
        /// 质量状态
        /// </summary>
        public string QualityStatus { get; set; }
        /// <summary>
        /// 条码控制状态
        /// </summary>
        public string ControlStatus { get; set; }
        /// <summary>
        /// 是否隔离
        /// </summary>
        public bool IsIsolated { get; set; }
        /// <summary>
        /// 当前库位
        /// </summary>
        public string CurrentStk { get; set; }
        /// <summary>
        /// 打印条码的默认打印机
        /// </summary>
        public string Printer { get; set; }
        /// <summary>
        /// 是否已打印
        /// </summary>
        public bool IsPrinted { get; set; }
        /// <summary>
        /// 打印时间
        /// </summary>
        public Nullable<System.DateTime> PrintTime { get; set; }
        /// <summary>
        /// 喷涂次数
        /// </summary>
        public Nullable<int> PaintTimes { get; set; }
        /// <summary>
        /// 条码物流状态 ,待收货10、正常20、已发运30
        /// </summary>
        public string BarcodeStatus { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateUserAccount { get; set; }
        /// <summary>
        /// 创建机器名
        /// </summary>
        public string CreateMachine { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 颜色代码
        /// </summary>
        public string ColorCode { get; set; }
        /// <summary>
        /// 打磨次数
        /// </summary>
        public Nullable<int> BurnishTimes { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string WorkOrderNo { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string ProjectNo { get; set; }
        /// <summary>
        /// 最后一次生产时间
        /// </summary>
        public Nullable<System.DateTime> LatestProdTime { get; set; }
        
        public object __ObjectFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
