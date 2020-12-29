using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class IFS_InterCompanyOrderReq
    {
        public List<IFS_InterCompanyOrder> ReqList = new List<IFS_InterCompanyOrder>();
    }

    /// <summary>
    /// 公司间交易收货方收货同步模型
    /// 该数据用于收货方收货时进行记录，并待同步程序同步给发货方进行事务处理
    /// </summary>
    public class IFS_InterCompanyOrder
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public string OrderType { get; set; }
        public string PartNo { get; set; }
        public string DeliveryQty { get; set; }
        public string DeliveryTime { get; set; }
        public string IsSyncSAP { get; set; }
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
