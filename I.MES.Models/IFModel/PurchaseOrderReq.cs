using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class PurchaseOrderReq
    {
        public List<ReceiptStatusInterface> Data = new List<ReceiptStatusInterface>();
    }

    public class SalesAgreementReq
    {
        public List<I.MES.Models.IFModel.PurchaseOrderSync> ReqList = 
            new List<I.MES.Models.IFModel.PurchaseOrderSync>();
    }
}
