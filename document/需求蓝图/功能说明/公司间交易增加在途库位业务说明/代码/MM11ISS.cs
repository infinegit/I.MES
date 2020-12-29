 SYS_SAPTransaction sapTs = CreateEntity.CreateSAPTranscation(SAPTransCode: "MM_11_ISS", Module: "MM", BusinessType: 4, FactoryCode: stkDet.FactoryCode, MovementType: "643", PartNo: sOAndSeqSO["PartNo"].ToString(), OrderNo: orderNo, ItemNumber: lgssa.ItemNo, StockAdress: sOAndSeqSO["StkCode"].ToString(), StockStatus: GetStockStatus(sOAndSeqSO["QualityStatusCode"].ToString()), SpecialStock: "",
                           StkGUID: sOAndSeqSO["RctBillGuid"].ToString(), Qty: Convert.ToDecimal(sOAndSeqSO["Qty"].ToString()), Unit: partDetail.Unit, StkQty: Convert.ToDecimal(sOAndSeqSO["Qty"].ToString()), StkUint: partDetail.Unit, AccountingDate: effDate.Date, VoucherDate: Convert.ToDateTime(sOAndSeqSO["CreateTime"].ToString()).Date, PlanDate: planDateNull, RecoilType: "", ProductVersion: "", ParentPart: "", SupplierCode: "", OutSupplierCode: "", RSFactory: lgssa.CustomerCode, ReceiveType: "1");//MM_11_ISS
                        db.Insert(sapTs);