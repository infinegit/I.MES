using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// ISV调用MES生成产品HU号，返回的HU
    /// 对应HUPkgMstr
    /// </summary>
    public class ProductHU
    {
        public int ID { get; set; }
        //料箱号
        public string HUCode { get; set; }
        //工厂
        public string FactoryCode { get; set; }
        /// <summary>
        /// 生产地点
        /// </summary>
        public string ProdPlaceCode { get; set; }
        /// <summary>
        /// 工作中心
        /// </summary>
        public string WCCode { get; set; }
        /// <summary>
        /// 生产线
        /// </summary>
        public string ProdLineCode { get; set; }
        /// <summary>
        /// RK号
        /// </summary>
        public string RackCode { get; set; }
        /// <summary>
        /// 包装类型
        /// </summary>
        public string PkgTypeCode { get; set; }
        /// <summary>
        /// 零件号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PartName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PartVersion { get; set; }
        /// <summary>
        /// 质量状态
        /// </summary>
        public string QualityStatusCode { get; set; }
        /// <summary>
        /// 装箱数
        /// </summary>
        public decimal HUQty { get; set; }
        /// <summary>
        /// 整包装数
        /// </summary>
        public decimal HUMaxQty { get; set; }
        /// <summary>
        /// 是否封箱
        /// </summary>
        public bool IsSealed { get; set; }
        /// <summary>
        /// GUID号，用于标识唯一料箱
        /// </summary>
        public string HUID { get; set; }
        /// <summary>
        /// 版本控制【系统用】
        /// </summary>
        public byte[] RowVersion { get; set; }
        public string CreateUserAccount { get; set; }
        public string CreateMachine { get; set; }
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 当前库位
        /// </summary>
        public string StkCode { get; set; }
        /// <summary>
        /// 是否隔离
        /// </summary>
        public bool IsIsolated { get; set; }
        /// <summary>
        /// 是否已收货
        /// </summary>
        public bool IsReceived { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 收货时间
        /// </summary>
        public Nullable<System.DateTime> POReceivedTime { get; set; }
        /// <summary>
        /// 包装物流状态
        /// </summary>
        public string PackageStatus { get; set; }
        /// <summary>
        /// 产品最早生产时间
        /// </summary>
        public Nullable<System.DateTime> EarliestProdTime { get; set; }
        /// <summary>
        /// 生产批号
        /// </summary>
        public string LotNo { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProductionDate { get; set; }
        public object __ObjectFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
