using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 数据传输服务调用接口把订单关闭信息同步进MES3.0
    /// 对应LGS_ReceiptStatusInterface
    /// </summary>
    public class ReceiptStatusInterface
    {
         public string SeriID { get; set; }
         public string TaskID { get; set; }
         public string OrderNo { get; set; }
         public string ItemNo { get; set; }
         public decimal ReceiptQty{get;set;}
         public string OrderStatus { get; set; }
         public string SAPWriteDT { get; set; }
         public string ReceiptDate { get; set; }
         public int IsRead{get;set;}
         public string ReadDT { get; set; }
         public string ReadResult { get; set; }
         public string ReadResultNote{get;set;}
         public string IsTransed { get; set; }
         public string IsSyncSAP { get; set; }
         public string RecTime { get; set; }
         public object __ObjectFrom
         {
             set
             {
                 this.CopyFrom(value);
             }
         }
    }
}
