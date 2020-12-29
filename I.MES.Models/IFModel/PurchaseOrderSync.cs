using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IFModel
{
    /// <summary>
    /// 只用于 采购单 转 销售单 (因为 MEStoSAP 服务 ，只支持String类型， 所以新建了一上实体类)
    /// </summary>
    public class PurchaseOrderSync
    {
        public string ID;
        public string OrderNo;
        public string ItemNo;
        public string OrderType;
        public string SupplierCode;
        public string PartNo;
        public string Qty;
        public string StkQty;
        public string RecQty;
        public string PurchaseMeasureUnit;
        public string StockMeasureUnit;
        public string Numerator;
        public string Denominator;
        public string DemandDate;
        public string ItemType;
        public string FactoryNo;
        public string StockAdress;
        public string ItemStatus;
        public string PerPackageQty;
        public string WindowTime;
        public string PackageQty;
        public string SupplierUserID;
        public string DeliverySupplierID;
        public string DockAccount;
        public string DockNo;
        public string ITelNo;
        public string BillCreateDT;
        public string VersionNo;
        public string IsDel;
        public string IsConv2TO;
        public string IsTransed;

        //public System.DateTime DocumentTime;//凭证日期
        //public decimal RetrunNum;//退货数量
        //public System.DateTime RetrunDate;//退货日期
        //public string MachineName;//退货机器编号
        //public string UserID;//操作人
        //public decimal ReturnReversalNum;//退货冲销数量

        //用于采购单同步ISV
        public string TaskID;
        public string IsSyncSAP;
        public string RecTime;
        public string IPlanner;//创建人

        public string PurchaseGroup;
        /// <summary>
        /// 销售组
        /// </summary>
        public string SupItemGroupCode;

        public string Remark;
        public string OrigFactoryCode;
        public string OrigCompany;
        public string DestFactoryCode;
        public string DestCompany;
        public string SenderOrderNo;

    }
}
