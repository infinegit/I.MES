using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 用于江夏采购订单【LGS_PurchaseOrder】数据同步到东风彼欧【LGS_DeliveryMstr】、【LGS_DeliveryDet】中
    /// </summary>
    public class DeliverReq
    {
        public List<I.MES.Models.IFModel.PurchaseOrderSync> ReqList = new List<I.MES.Models.IFModel.PurchaseOrderSync>();
    }
}
