using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 供应商ASN请求同步类
    /// </summary>
    public class IFS_SupplierAsnReq
    {
        public List<IFS_SupplierAsn> lstAsn = new List<IFS_SupplierAsn>();
    }


    public class IFS_SupplierAsn : IFS_SupplierAsnMstr
    {
        /// <summary>
        /// ASN明细
        /// </summary>
        public List<IFS_SupplierAsnDet> AsnDet { get; set; }
        /// <summary>
        /// XML序列化的ASN明细数据
        /// </summary>
        public string AsnDet4Xml { get; set; }
    }
    /// <summary>
    /// ASN主记录
    /// </summary>
    public class IFS_SupplierAsnMstr
    {
        /// <summary>
        /// ID号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// ASN号
        /// </summary>
        public string AsnNo { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 工厂代码
        /// </summary>
        public string FactoryCode { get; set; }
        /// <summary>
        /// 收货道口
        /// </summary>
        public string DockCode { get; set; }
        /// <summary>
        /// ASN创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 传输时间
        /// </summary>
        public DateTime DeliverTime { get; set; }
        /// <summary>
        /// 是否已提取
        /// </summary>
        public bool IsTransfer { get; set; }
        /// <summary>
        /// 是否测试报文
        /// </summary>
        public bool IsTest { get; set; }
       /// <summary>
       /// 时间戳
       /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 状态
        /// 6.正式; 5.变更; 3.删除
        /// </summary>
        public int Status { get; set; }

        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
    /// <summary>
    /// ASN物料明细记录
    /// </summary>
    public class IFS_SupplierAsnDet
    {
        /// <summary>
        /// ID号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// ASN主记录的ID号
        /// </summary>
        public int AsnMstrID { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 物料行项目号
        /// </summary>
        public string ItemNo { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string PartDesc { get; set; }
        /// <summary>
        /// 供应商物料代码
        /// </summary>
        public string SupplierPartNo { get; set; }
        /// <summary>
        /// 物料数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 物料单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 物料单包装数
        /// </summary>
        public decimal QtyPerPkg { get; set; }
        /// <summary>
        /// 生产批次
        /// </summary>
        public string  ProdLot { get; set; }
        /// <summary>
        /// 供货批次
        /// </summary>
        public string LotNo { get; set; }
        /// <summary>
        /// 安全件标识
        /// </summary>
        public string SafetyMark { get; set; }
        /// <summary>
        /// 托盘信息
        /// </summary>
        public List<IFS_SupplierAsnTP> AsnTp { get; set; }
        /// <summary>
        /// 料箱信息
        /// </summary>
        public List<IFS_SupplierAsnHU> AsnHU { get; set; }

        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }

    /// <summary>
    /// ASN托盘明细
    /// </summary>
    public class IFS_SupplierAsnTP
    {
        /// <summary>
        /// 托盘ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// ASN明细ID
        /// </summary>
        public string AsnDetId { get; set; }
        /// <summary>
        /// 托盘号
        /// </summary>
        public string RackCode { get; set; }
        /// <summary>
        /// 行项目号
        /// </summary>
        public string ItemNo { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 包装类型
        /// </summary>
        public string RackType { get; set; }
        /// <summary>
        /// 子包装数量
        /// </summary>
        public decimal HUQty { get; set; }
        /// <summary>
        /// 物料数量
        /// </summary>
        public decimal Qty { get; set; }

        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
    /// <summary>
    /// ASN料箱明细
    /// </summary>
    public class IFS_SupplierAsnHU
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// HU号
        /// </summary>
        public string HUCode { get; set; }
        /// <summary>
        /// RK号
        /// </summary>
        public string RackCode { get; set; }
        /// <summary>
        /// 行项目号
        /// </summary>
        public string ItemNo { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 装箱数
        /// </summary>
        public decimal HUQty { get; set; }
        /// <summary>
        /// 满包装数
        /// </summary>
        public decimal HUMaxQty { get; set; }
        /// <summary>
        /// 包装类型
        /// </summary>
        public string PkgTypeCode { get; set; }
        /// <summary>
        /// 生产批次
        /// </summary>
        public string ProdLot { get; set; }
        /// <summary>
        /// 供货批次
        /// </summary>
        public string LotNo { get; set; }
        /// <summary>
        /// 安全件标识
        /// </summary>
        public string SafetyMark { get; set; }


        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }

}
