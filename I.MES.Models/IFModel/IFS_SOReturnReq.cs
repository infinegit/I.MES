using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 协同-发货单数据给收货单请求类
    /// </summary>
    public class IFS_SOReturnReq
    {
        public List<IFS_SOReturn> ReqList = new List<IFS_SOReturn>();
    }

    /// <summary>
    /// 协同-公司间采购退货信息
    /// </summary>
    public class IFS_SOReturn
    {
        public string OrderNo { get; set; }
        public string RecStk { get; set; }
        public string OrderType { get; set; }
        public string OrderStatus { get; set; }
        public string RefOrderNo { get; set; }
        public string PartNo { get; set; }
        public string Qty { get; set; }
        public string Unit { get; set; }
        public string CustomerPartNo { get; set; }
        public string TaskId { get; set; }
        public string RecTime { get; set; }
        public string OrigFactoryCode { get; set; }
        public string OrigCompany { get; set; }
        public string DestFactoryCode { get; set; }
        public string DestCompany { get; set; }

        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
