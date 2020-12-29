 else if (deliveryMstr.OrderType == "11")//(pa.OrderType == "ZSTO" || pa.OrderType == "ZST1")//公司间（ZSTO）
                    {
                        //string comPanyCode = GetCompanyCode();
                        //WMS_InTransit oritransit = db.GetEntity<WMS_InTransit>("SELECT * FROM dbo.WMS_InTransit WITH (NOLOCK) WHERE OrderNo = '" + deliveryMstr.OrderNo + "' AND PartNo = '" + poReject["PartNo"].ToString() + "' AND CompanyCode = '" + comPanyCode + "'AND FactoryCode= '" + stkDet.FactoryCode + "'");
                        if (isCOGI)
                        {
                            //if (oritransit == null)
                            //{
                            //    WMS_InTransit inTransit = InsertInTransit("TransactionMonitor", "TransactionMonitor", deliveryMstr.OrderNo, 0, poReject["PartNo"].ToString(), comPanyCode, stkDet.FactoryCode, "", partDetail.Unit, Convert.ToDecimal(poReject["Qty"].ToString()), 0, "", "", effDate.Date);
                            //    db.Insert(inTransit);
                            //}
                            //else
                            //{
                            //    WMS_InTransit inTransit = UpdateInTransit(oritransit, "TransactionMonitor", "TransactionMonitor", Convert.ToDecimal(poReject["Qty"].ToString()), 0);
                            //    db.Update(inTransit);
                            //}
                            db.Update(stkDet);
                            WMS_StkDet stkDetm = GetWmsStkDet(poReject["FactoryCode"].ToString(), poReject["FactoryCode"].ToString() + "Z003", poReject["PartNo"].ToString());
                            stkDetm.NonRtctNormal = stkDetm.NonRtctNormal + Convert.ToDecimal(poReject["Qty"].ToString());
                            db.Update(stkDetm);

                            string rSStockAdress = stkDet.FactoryCode + "Z003";
                            //SYS_SAPTransaction sapTransaction = CreateEntity.CreateSAPTranscation(SAPTransCode: "MM_12_ISS", Module: "MM", BusinessType: 4, FactoryCode: stkDet.FactoryCode, MovementType: "161", PartNo: poReject["PartNo"].ToString(), OrderNo: deliveryMstr.OrderNo, ItemNumber: pa.ItemNo, StockAdress: poReject["StkCode"].ToString(), StockStatus: GetStockStatus(poReject["QualityStatusCode"].ToString()), SpecialStock: "",
                            //    StkGUID: poReject["RctBillGuid"].ToString(), Qty: Convert.ToDecimal(poReject["Qty"].ToString()), Unit: partDetail.Unit, StkQty: Convert.ToDecimal(poReject["Qty"].ToString()), StkUint: partDetail.Unit, AccountingDate: effDate.Date, VoucherDate: Convert.ToDateTime(poReject["CreateTime"].ToString()).Date, PlanDate: planDateNull, RecoilType: "", ProductVersion: "", ParentPart: "", RSFactory: deliveryMstr.Destination, ReceiveType: "1", SupplierCode: deliveryMstr.Destination);//MM_12_ISS
                            SYS_SAPTransaction sapTransaction = CreateEntity.CreateSAPTranscation(SAPTransCode: "MM_39_ISS", Module: "MM", BusinessType: 3, FactoryCode: stkDet.FactoryCode, MovementType: "Z31", PartNo: poReject["PartNo"].ToString(), OrderNo: deliveryMstr.OrderNo, ItemNumber: pa.ItemNo, StockAdress: poReject["StkCode"].ToString(), StockStatus: GetStockStatus(poReject["QualityStatusCode"].ToString()), SpecialStock: "",
                                StkGUID: poReject["RctBillGuid"].ToString(), Qty: Convert.ToDecimal(poReject["Qty"].ToString()), Unit: partDetail.Unit, StkQty: Convert.ToDecimal(poReject["Qty"].ToString()), StkUint: partDetail.Unit, AccountingDate: effDate.Date, VoucherDate: Convert.ToDateTime(poReject["CreateTime"].ToString()).Date, PlanDate: planDateNull, RecoilType: "", ProductVersion: "", ParentPart: "", RSFactory: stkDet.FactoryCode, RSStockAdress: rSStockAdress, ReceiveType: "", SupplierCode: deliveryMstr.Destination, MESOrderNo: deliveryMstr.OrderNo);
                            db.Insert(sapTransaction);
                        }
                        else
                        {
                            //此处需要记录COGI
                            string guid = Guid.NewGuid().ToString();
                            string rSStockAdress = stkDet.FactoryCode + "Z003";
                            WMS_COGI cogi = CreateEntity.CreateWMSCOGI(guid, "Z31", stkDet.FactoryCode, stkDet.StkCode, poReject["PartNo"].ToString(), Convert.ToDecimal(poReject["Qty"].ToString()), partDetail.Unit, now, effDate, deliveryMstr.OrderNo, "MM_39_ISS-Z31库存不满足-POReject");
                            db.Insert(cogi);
                            WMS_SAPTransactionPending sapTP = CreateEntity.CreateWMSSAPTransactionPending(CogiGUID: guid, SAPTransCode: "MM_39_ISS", Module: "MM", BusinessType: 3, FactoryCode: stkDet.FactoryCode, MovementType: "Z31", PartNo: poReject["PartNo"].ToString(), OrderNo: deliveryMstr.OrderNo, ItemNumber: pa.ItemNo, StockAdress: poReject["StkCode"].ToString(), StockStatus: GetStockStatus(poReject["QualityStatusCode"].ToString()), SpecialStock: "",
                                StkGUID: poReject["RctBillGuid"].ToString(), Qty: Convert.ToDecimal(poReject["Qty"].ToString()), Unit: partDetail.Unit, StkQty: Convert.ToDecimal(poReject["Qty"].ToString()), StkUint: partDetail.Unit, AccountingDate: effDate.Date, VoucherDate: Convert.ToDateTime(poReject["CreateTime"].ToString()).Date, PlanDate: planDateNull, RecoilType: "", ProductVersion: "", ParentPart: "", RSFactory: stkDet.FactoryCode, RSStockAdress: rSStockAdress, ReceiveType: "", SupplierCode: deliveryMstr.Destination, MESOrderNo: deliveryMstr.OrderNo);
                            db.Insert(sapTP);
                            WMS_StkChangePending stkCP = CreateEntity.CreateWMSStkChangePending(guid, stkDet.FactoryCode, poReject["StkCode"].ToString(), poReject["PartNo"].ToString(), GetStockStatus(poReject["QualityStatusCode"].ToString()), GetSpecialStock(poReject["StkMngStatusCode"].ToString()), -Convert.ToDecimal(poReject["Qty"].ToString()), partDetail.Unit);
                            db.Insert(stkCP);
                            //记录在途COGI
                            //WMS_InTransitCOGI intsCogi = CreateEntity.CreateInTransitCOGI(guid, "TransactionMonitor", "TransactionMonitor", deliveryMstr.OrderNo, poReject["PartNo"].ToString(), comPanyCode, stkDet.FactoryCode, "", partDetail.Unit, Convert.ToDecimal(poReject["Qty"].ToString()), 0, 0, "", "", effDate.Date);
                            //db.Insert(intsCogi);
                        }
                    }
                    else
                    {
                        Logger.Error("deliveryMstr.OrderType不存在OrderNo：" + poReject["RefOrderGuid"].ToString());
                        return;
                    }