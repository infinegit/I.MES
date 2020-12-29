using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 产品信息
    /// 对应MFG_Part
    /// </summary>
    public class ProductPart
    {
        public int ID { get; set; }
        /// <summary>
        /// 零件号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string PartVersion { get; set; }
        /// <summary>
        /// 零件描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 零件简短描述
        /// </summary>
        public string BriefDesc { get; set; }
        /// <summary>
        /// 子零件
        /// </summary>
        public string CompPartNo { get; set; }
        /// <summary>
        /// 子零件版本号
        /// </summary>
        public string CompPartVersion { get; set; }
        /// <summary>
        /// 生产分组
        /// </summary>
        public string ProduceCategory { get; set; }
        /// <summary>
        /// 生产BOM层次
        /// </summary>
        public string ProduceLevel { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string VehicleMode { get; set; }
        /// <summary>
        /// 分类1
        /// </summary>
        public string Category1 { get; set; }
        /// <summary>
        /// 分类2
        /// </summary>
        public string Category2 { get; set; }
        /// <summary>
        /// 分类3
        /// </summary>
        public string Category3 { get; set; }
        /// <summary>
        /// 按钮前景色
        /// </summary>
        public string ForeColor { get; set; }
        /// <summary>
        /// 按钮背景色
        /// </summary>
        public string BackColor { get; set; }
        /// <summary>
        /// 有效起始时间
        /// </summary>
        public System.DateTime EffStartTime { get; set; }
        /// <summary>
        /// 有效终止时间
        /// </summary>
        public System.DateTime EffEndTime { get; set; }
        /// <summary>
        /// 是否自制
        /// </summary>
        public bool IsSelfMade { get; set; }
        /// <summary>
        /// 是否采购
        /// </summary>
        public bool IsPurchased { get; set; }
        /// <summary>
        /// 是否是条码件
        /// </summary>
        public bool HasBarcode { get; set; }
        /// <summary>
        /// 是否强制禁用
        /// </summary>
        public bool ForceDisable { get; set; }
        public string CreateUserAccount { get; set; }
        public string CreateMachine { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string LatestModifyUserAccount { get; set; }
        public System.DateTime LatestModifyTime { get; set; }
        public string LatestModifyMachine { get; set; }
        /// <summary>
        /// 颜色代码
        /// </summary>
        public string ColorCode { get; set; }
        /// <summary>
        /// 最大打磨次数
        /// </summary>
        public Nullable<int> MaxBurnishTimes { get; set; }

        public object __ObjectFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
