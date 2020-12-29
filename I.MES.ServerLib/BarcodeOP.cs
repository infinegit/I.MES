using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Collections;
using System.Transactions;
using I.MES.Library.EF;
using I.MES.Tools;


namespace I.MES.Library
{
    /// <summary>
    /// 条码处理类
    /// </summary>
    [Shareable]
    public class BarcodeOP : BaseOP
    {
      
        /// <summary>
        /// 构造函数
        /// </summary>
        public BarcodeOP(ClientInformation clientInfo)
            : base(clientInfo)
        {
           
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public BarcodeOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
           
        }
        /// <summary>
        /// 根据BarCode获得条码信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        [Shareable]
        public I.MES.Library.EF.MFG_ProductBarcode GetProductBarcodeByBarcode(string BarCode)
        {
            return GetData<I.MES.Library.EF.MFG_ProductBarcode>(p => p.Barcode == BarCode);
        }
        ///// <summary>
        ///// 根据scansite获得扫描点信息
        ///// </summary>
        ///// <param name="scansite"></param>
        ///// <returns></returns>
        //[Shareable]
        //public I.MES.Library.EF.MFG_BarcodeScanLog GetProductscansite(string scansite)
        //{
        //    return GetData<I.MES.Library.EF.MFG_BarcodeScanLog>(p => p.ScanSiteCode == scansite);
        //}




      
        /// <summary>
        /// 获取控制状态
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<Models.SelectListItem> GetControlStatus()
        {
            var data = from c in DB.MFG_BarcodeControlStatus
                       select new Models.SelectListItem
                       {
                           Selected = false,
                           Text = c.ControlStatusName,
                           Value = c.ControlStatus
                       };
            return data.ToList();
        }

        
        /// <summary>
        /// 根据零件和和版本获取产品种类
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public MFG_ProduceCategory getCategoryByInitPart(string initPartNo, string initPartVersion)
        {
            return GetData<MFG_ProduceCategory>(p => p.InitPartNo == initPartNo && p.InitPartVersion == initPartVersion);
        }

        /// <summary>
        /// 获得扫描控制状态
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_BarcodeControlStatus> GetBarcodeControlStatus()
        {
            return GetList<MFG_BarcodeControlStatus>(p => 1 == 1).ToList();
        }
        /// <summary>
        /// 生成新条码
        /// </summary>
        /// <param name="printer">打印机</param>
        /// <param name="produceCategoryCode">生产分组编号</param>
        /// <param name="printCount">打印批次数,默认为0，表示使用系统配置批量进行打印</param>
        /// <param name="immld">注塑机联动ID号</param>
        /// <param name="isPrinted">是否已经打印</param>
        /// <returns>产品条码列表</returns>
        //[Shareable]
        //public List<MFG_ProductBarcode> GenerateProductBarcode(string printer, string produceCategoryCode, int printCount = 0, int immld = 0, bool isPrinted = false)
        //{
        //    for (int tryCount = 0; tryCount < 5; tryCount++)
        //    {
        //        try
        //        {

        //            using (DataEntities db = new DataEntities())
        //            {
        //                MFG_ProduceCategory produceCategory = new ProductOP(ClientInfo).GetProduceCategory(produceCategoryCode);
        //                if (produceCategoryCode == null)
        //                {
        //                    throw new Exception("找不到产品生产分组" + produceCategoryCode);
        //                }
        //                if (produceCategory.BarcodePrintLot <= 0)
        //                {
        //                    throw new Exception("没有配置该产品的打印批量(MFG_ProduceCagetory.BarcodePrintLot)");
        //                }
        //                //todo: 检查同一小时内产品条码打印数是否达到上限



        //                List<MFG_ProductBarcode> barcodes = new List<MFG_ProductBarcode>();
        //                int nextSerialNum = 0;
        //                int lastSerialNum = 0;
        //                //ConfigOP configOP = new ConfigOP(ClientInfo, DB);
        //                //SYS_GlobalConfig config = GetData<SYS_GlobalConfig>(p => p.ConfigName == "BarCodePrint"
        //                //                && p.ParamCode == produceCategory.VehicleMode);
        //                string prefix = "";
        //                //if (config != null)
        //                //{
        //                //    prefix = config.ParamValue + DateTime.Now.ToString("yyMMddHH");
        //                //}
        //                //else
        //                //{
        //                //    prefix = GenBarcodePrefix(1);
        //                //}
        //                //1.生成条码的prefix

        //                //prefix = prefix + produceCategory.CategoryBriefCode.PadLeft(2, '0').Substring(0, 2);
        //                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew)) //这里新建一个transactionscope,在范围内事务作为新事务执行。
        //                {
        //                    //2.取当前流水号
        //                    SYS_SerialNum currentSerialNum = GetCurrentSerialNum(prefix);
        //                    nextSerialNum = currentSerialNum.CurrentNum + 1;
        //                    if (printCount > 0)
        //                    {
        //                        lastSerialNum = currentSerialNum.CurrentNum + printCount;
        //                    }
        //                    else
        //                    {
        //                        lastSerialNum = currentSerialNum.CurrentNum + produceCategory.BarcodePrintLot;
        //                    }
        //                    //3.更新流水号
        //                    currentSerialNum.CurrentNum = lastSerialNum;
        //                    db.SYS_SerialNum.AddOrUpdate(currentSerialNum);
        //                    //db.Entry(currentSerialNum).State = System.Data.EntityState.Modified;
        //                    db.SaveChanges();
        //                    ts.Complete();
        //                }
        //                //4.生成条码
        //                MFG_BarcodeScanLog barcodeLog = new MFG_BarcodeScanLog();
        //                MFG_ProductBarcode barcode = new MFG_ProductBarcode();
        //                for (int i = nextSerialNum; i <= lastSerialNum; i++)
        //                {
        //                    //if (i > 9999) //超过9999的话，现在就完全不作处理，就让他条码长一位吧。
        //                    //{
        //                    //    continue;
        //                    //}
        //                    barcode = new MFG_ProductBarcode();
        //                    string strBarcode = prefix + i.ToString().PadLeft(4, '0');
        //                    barcode.Barcode = strBarcode;
        //                    barcode.CurrentPartNo = produceCategory.InitPartNo;
        //                    //barcode.CurrentPartVersion = produceCategory.InitPartVersion;
        //                    barcode.QualityStatus = produceCategory.InitQualityStatus;
        //                    barcode.ControlStatus = produceCategory.InitControlStatus;
        //                    //barcode.IsIsolated = false;
        //                    //barcode.CurrentStk = string.Empty;
        //                    //barcode.Printer = printer;
        //                    //barcode.IsPrinted = isPrinted;
        //                    //barcode.PrintTime = DateTime.Now;
        //                    //barcode.PaintTimes = 0;
        //                    //barcode.IsDel = false;
        //                    //barcode.BarcodeStatus = ConstInfo.BarcodeStatus.Normal;
        //                    //barcode.CreateUserAccount = this.UserAccount;
        //                    barcode.CreateMachine = this.MachineName;
        //                    barcode.CreateTime = DateTime.Now;
        //                    //barcode.ColorCode = string.Empty;
        //                    //barcode.BurnishTimes = 0;
        //                    //barcode.WorkOrderNo = string.Empty;
        //                    //barcode.ProjectNo = string.Empty;
        //                    //barcode.Spare2 = immld.ToString();
        //                    //barcode.IsStock = true;

        //                    db.MFG_ProductBarcode.Add(barcode);
        //                    barcodes.Add(barcode);

        //                    //条码扫描日志记录
        //                    //todo:这个届时用那个封装的逻辑来做
        //                    barcodeLog = new MFG_BarcodeScanLog();
        //                    barcodeLog.Barcode = strBarcode;
        //                    barcodeLog.OrigPartNo = "";
        //                    barcodeLog.OrigPartVersion = "";
        //                    barcodeLog.OrigQualityStatus = "1";
        //                    barcodeLog.NewPartNo = produceCategory.InitPartNo;
        //                    barcodeLog.NewPartVersion = produceCategory.InitPartVersion;
        //                    barcodeLog.NewQualityStatus = produceCategory.InitQualityStatus;
        //                    barcodeLog.ScanSiteCode = "BarcodePrint";
        //                    barcodeLog.ActionCode = "IntoOK";
        //                    barcodeLog.RctStk = string.Empty;
        //                    barcodeLog.IssStk = string.Empty;
        //                    barcodeLog.ControlStatus = produceCategory.InitControlStatus;
        //                    barcodeLog.RctBOM = produceCategory.InitPartNo;
        //                    barcodeLog.FactoryCode = this.FactoryCode;
        //                    barcodeLog.WCCode = string.Empty;
        //                    barcodeLog.ProdLineCode = string.Empty;
        //                    barcodeLog.IsDel = false;
        //                    barcodeLog.IsDelAfter = false;
        //                    barcodeLog.CreateTime = DateTime.Now;
        //                    barcodeLog.CreateUserAccount = this.UserAccount;
        //                    barcodeLog.CreateMachine = this.MachineName;
        //                    barcodeLog.LogGUID = Tools.StringTools.GetGUID();
        //                    barcodeLog.ClientTraceInfo = ClientInfo.ClientTraceInfo;
        //                    barcodeLog.ServerTraceInfo = Helper.getMethodTrace();

        //                    //barcodeLog.WorkingHours = CalProductWorkingHours(barcodeLog);
        //                    db.MFG_BarcodeScanLog.Add(barcodeLog);
        //                    // Insert<MFG_BarcodeScanLog>(barcodeLog);
        //                }
        //                //5.保存条码信息并返回
        //                db.SaveChanges();
        //                return barcodes;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            if (tryCount >= 4)
        //            {
        //                throw ex;
        //            }
        //            else
        //            {
        //                System.Threading.Thread.Sleep(200);
        //                continue;
        //            }
        //        }
        //    }
        //    throw new Exception("生成条码失败，请检查！");
        //}
       
        /// <summary>
        /// 检查每小时的条码打印次数限制
        /// </summary>
        /// <param name="partNo"></param>
        /// <param name="limitedPrintNumPerHour"></param>
        /// <returns></returns>
        public bool CheckBarcodePrintLimit(string partNo, string limitedPrintNumPerHour)
        {
            return true;
        }
       
        /// <summary>
        /// 生产计划单单号
        /// </summary>
        /// <returns></returns>
        public string GenaratePSOrderNo()
        {
            try
            {
                var serialNum = GetCurrentSerialNum("PS" + DateTime.Now.ToString("yyMMdd"));
                serialNum.CurrentNum++;
                string rtn = "PS" + DateTime.Now.ToString("yyMMdd") + serialNum.CurrentNum.ToString("D4");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// EMS报警单号
        /// </summary>
        /// <returns></returns>
        public string GenerateAlarmOrderNo()
        {
            try
            {
                var serialNum = GetCurrentSerialNum("AM" + DateTime.Now.ToString("yyMMdd"));
                serialNum.CurrentNum++;
                string rtn = "AM" + DateTime.Now.ToString("yyMMdd") + serialNum.CurrentNum.ToString("D6");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 生成通知单单号
        /// </summary>
        /// <param name="companyCode">公司代号</param>
        /// <returns></returns>
        public string GenerateNoticeOrderNo(string companyCode)
        {
            try
            {
                var serialNum = GetCurrentSerialNum("I" + companyCode);
                serialNum.CurrentNum++;
                string rtn = "I" + companyCode + serialNum.CurrentNum.ToString("D7");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 生成工单编号
        /// 注：EM、PD、CI
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GenerateWorkOrderNo(string companyCode)
        {
            try
            {
                var serialNum = GetCurrentSerialNum("PM" + companyCode);
                serialNum.CurrentNum++;
                string rtn = companyCode + serialNum.CurrentNum.ToString("D8");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        ///// <summary>
        ///// 获取最后一条条码日志记录
        ///// </summary>
        ///// <param name="Barcode"></param>
        ///// <returns></returns>
        //[Shareable]
        //public MFG_BarcodeScanLog BarcodeScan(string Barcode)
        //{
        //    //string sql = "SELECT * FROM dbo.MFG_BarcodeScanLog(NOLOCK) WHERE Barcode='"+Barcode+"' ORDER BY CreateTime DESC";
        //    //var bbd = new DataEntities().Database.SqlQuery<MFG_BarcodeScanLog>(sql);

        //    //return bbd.First();

        //    var barcodeLog = GetList<MFG_BarcodeScanLog>(p => p.Barcode == Barcode).OrderByDescending(p => p.CreateTime);
        //    return barcodeLog.FirstOrDefault();
        //}
      
        /// <summary>
        /// 取条码的前缀
        /// </summary>
        /// <param name="type">1：产品条码 2：料箱HU条码 3：临时托盘号 4：TO单</param>
        /// <returns>条码前缀</returns>
        private string GenBarcodePrefix(int type)
        {
            try
            {
                //using (DataEntities db = new DataEntities())
                //{
                string prefix = string.Empty;
               
                if (type == 1) //产品条码
                {
                   SYS_GlobalConfig config = DB.SYS_GlobalConfig.Where(p => p.ConfigName == "BarcodePrint" && p.ParamCode == "prefix").FirstOrDefault();
                    //3. 拼接起来返回
                   prefix = config .ParamValue+ DateTime.Now.ToString("yyMMddHH");
                }
              
                return prefix;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取当前前缀的流水号
        /// </summary>
        /// <param name="prefix">条码前缀</param>
        /// <returns>当前条码前缀对象</returns>
        private SYS_SerialNum GetCurrentSerialNum(string prefix)
        {
            try
            {
                using (DataEntities db = new DataEntities())
                {
                    //int currentNum = 0;
                    //取流水号
                    SYS_SerialNum serialNum = db.SYS_SerialNum.Where(p => p.Prefix == prefix).FirstOrDefault();
                    //如果取不到返回0,新插入新的流水记录，如果取到，返回当前流水号
                    if (serialNum != null)
                    {
                        return serialNum;
                    }
                    serialNum = new SYS_SerialNum
                    {
                        Prefix = prefix,
                        CurrentNum = 0,
                        CreateUserAccount = this.UserAccount,
                        CreateMachine = this.MachineName,
                        CreateTime = DateTime.Now,
                        LatestModifyMachine = this.MachineName,
                        LatestModifyTime = DateTime.Now,
                        LatestModifyUserAccount = this.UserAccount
                    };
                    db.SYS_SerialNum.Add(serialNum);
                    db.SaveChanges();
                    //serialNum = db.SYS_SerialNum.Where(p => p.Prefix == prefix).FirstOrDefault();
                    return serialNum;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   


 

        //#region <<批量生成编号>>
        ///// <summary>
        ///// 条码生成
        ///// 条码规则：{Prefix}{CompanyCode}{FactoryCode}{Time}{SerialNum}
        ///// 条码配置表：[SYS_OrderNoFormatCfg]
        ///// </summary>
        ///// <param name="orderType"></param>
        ///// <param name="factoryCode"></param>
        ///// <param name="BatchNum"></param>
        ///// <returns></returns>
        //[Shareable]
        //public string GenerateOrderNo(string orderType, string factoryCode, int BatchNum)
        //{
        //    try
        //    {
        //        //根据订单类型取条码配置
        //        SYS_OrderNoFormatCfg formatCfg = GetOrderNoFormatCfg(orderType);
        //        if (formatCfg == null)
        //        {
        //            throw new Exception("找不到该订单类型的配置." + orderType);
        //        }
        //        string strFormated = formatCfg.BarcodeFormat;
        //        //获取公司代码
        //        SYS_Company company = DB.SYS_Company.FirstOrDefault();
        //        if (company == null)
        //        {
        //            throw new Exception("找不到公司数据。");
        //        }
        //        //获取工厂代码
        //        SYS_Factory factory = new SYS_Factory();
        //        if (!string.IsNullOrEmpty(factoryCode))
        //        {
        //            factory = GetData<SYS_Factory>(p => p.FactoryCode == factoryCode);
        //            if (company == null)
        //            {
        //                throw new Exception("找不到工厂数据。" + factoryCode);
        //            }
        //        }
        //        //条码生成
        //        strFormated = strFormated.Replace("{Prefix}", formatCfg.Prefix);
        //        strFormated = strFormated.Replace("{CompanyCode}", company.CompanyCode);
        //        strFormated = strFormated.Replace("{FactoryCode}", factory.FactoryCode == null ? string.Empty : factory.FactoryCode);
        //        strFormated = strFormated.Replace("{Time}", DateTime.Now.ToString(formatCfg.TimeFormat));

        //        string prefix = strFormated.Split('{')[0];
        //        SYS_SerialNum nextSerialNum = GetNextSerialNum(prefix, BatchNum);
        //        strFormated = strFormated.Replace("{SerialNum}", nextSerialNum.CurrentNum.ToString("D" + formatCfg.SerialNumLength.ToString()));

        //        return strFormated;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 取下一个流水码
        ///// </summary>
        ///// <param name="prefix"></param>
        ///// <returns></returns>
        //private SYS_SerialNum GetNextSerialNum(string prefix, int BatchNum)
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            using (DataEntities db = new DataEntities())
        //            {
        //                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
        //                {
        //                    try
        //                    {
        //                        SYS_SerialNum currentSerialNum = GetCurrentSerialNum(prefix);
        //                        currentSerialNum.CurrentNum += BatchNum;
        //                        db.SYS_SerialNum.AddOrUpdate(currentSerialNum);
        //                        db.SaveChanges();
        //                        ts.Complete();
        //                        return currentSerialNum;
        //                    }
        //                    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException) //如果发生并发更新的话，让其重新执行一次
        //                    {
        //                        continue;
        //                    }
        //                    catch (Exception ex) //如果是其它不可预见的错误，抛出异常
        //                    {
        //                        throw ex;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_ProductBarcode GetBarCode(string barCode)
        {
            return GetData<MFG_ProductBarcode>(p => p.Barcode == barCode);
        }
        

       



     
        /// <summary>
        /// 新增条码打印日志
        /// </summary>
        public void InsertBarPri(I.MES.Models.MFG_BarcodePrintLog barpri)
        {

            try
            {
                if (barpri.Barcode != null)
                {
                    barpri.CreateMachine = this.MachineName;
                    barpri.CreateTime = DateTime.Now;
                    barpri.PrintMachine = this.MachineName;
                    barpri.PrintTime = DateTime.Now;
                    Insert<I.MES.Models.MFG_BarcodePrintLog>(barpri);
                    DB.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
  

        #region 来自I.Report
        /// <summary>
        /// 生成通知单单号
        /// </summary>
        /// <param name="companyCode">公司代号</param>
        /// <param name="userAccount"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        [Shareable]
        public string GenerateNoticeOrderNo(string companyCode, string userAccount, string machineName)
        {
            try
            {
                var serialNum = GetCurrentSerialNum("I" + companyCode, userAccount, machineName);
                serialNum.CurrentNum++;
                string rtn = "I" + companyCode + serialNum.CurrentNum.ToString("D7");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 生成工单编号
        /// 注：EM、PD、CI
        /// </summary>
        /// <param name="companyCode">公司代号</param>
        /// <param name="userAccount">创建人</param>
        /// <param name="machineName">机器名</param>
        /// <returns></returns>
        [Shareable]
        public string GenerateWorkOrderNo(string companyCode, string userAccount, string machineName)
        {
            try
            {
                var serialNum = GetCurrentSerialNum("PM" + companyCode, userAccount, machineName);
                serialNum.CurrentNum++;
                string rtn = companyCode + serialNum.CurrentNum.ToString("D8");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取当前前缀的流水号
        /// </summary>
        /// <param name="prefix">条码前缀</param>
        /// <param name="userAccount">操作人</param>
        /// <param name="machineName">操作时间</param>
        /// <returns>当前条码前缀对象</returns>
        [Shareable]
        private SYS_SerialNum GetCurrentSerialNum(string prefix, string userAccount, string machineName)
        {
            try
            {
                //int currentNum = 0;
                //取流水号
                SYS_SerialNum serialNum = DB.SYS_SerialNum.FirstOrDefault(p => p.Prefix == prefix);
                //如果取不到返回0,新插入新的流水记录，如果取到，返回当前流水号
                if (serialNum != null)
                {
                    return serialNum;
                }
                serialNum = new SYS_SerialNum
                {
                    Prefix = prefix,
                    CurrentNum = 0,
                    CreateUserAccount = userAccount,
                    CreateMachine = machineName,
                    CreateTime = DateTime.Now,
                    LatestModifyMachine = userAccount,
                    LatestModifyTime = DateTime.Now,
                    LatestModifyUserAccount = machineName
                };
                DB.SYS_SerialNum.Add(serialNum);
                DB.SaveChanges();
                return serialNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 判断barcode是否有效
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        //[Shareable]
        //public bool IsProductBarcode(string barCode)
        //{
        //    var model = DB.MFG_ProductBarcode.Where(p => p.Barcode == barCode && p.IsDel == false);
        //    if (model != null)
        //        return true;
        //    else
        //        return false;
        //}


        /// <summary>
        /// 获取barcode状态
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [Shareable]
        public string getProductBarcodeStatus(string barcode)
        {
            var model = DB.MFG_ProductBarcode.Where(p => p.Barcode == barcode).FirstOrDefault();
            //if (model != null)
            //    return model.BarcodeStatus;
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [Shareable]
        public bool IsCheckBarcodeStatus(string barcode)
        {
            var currentPartNo = DB.MFG_ProductBarcode.Where(p => p.Barcode == barcode).FirstOrDefault().CurrentPartNo;

            if (DB.MFG_Part.Count(p => p.CompPartNo == currentPartNo) == 0)
            {
                return true;
            }
            return false;

        }


        /// <summary>
        /// 获取条码所在的工厂
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public string GetFactoryCode(string CurrentPartNo, string Barcode)
        {
            var sql = @"select top 1 mstr.FactoryCode from WMS_StkRctMstr mstr WITH(NOLOCK) 
                           left join WMS_StkRctDet det WITH(NOLOCK) on mstr.RctBillGuid = det.RctBillGuid 
                           where mstr.TransTypeCode  IN ('ProdDeclar','PartConv') AND PartNo = '" + CurrentPartNo +
                           "' AND IsTransDone = '1' AND Barcode = '" + Barcode + "'";
            return DB.Database.SqlQuery<string>(sql).FirstOrDefault();
        }



        /// <summary>
        /// 根据目视单获取条码信息
        /// </summary>
        /// <param name="visualNo"></param>
        /// <param name="category3"></param>
        /// <returns></returns>
        //[Shareable]
        //public MFG_ProductBarcode GetProductBarcodeByVisualNo(string visualNo, string category3)
        //{
        //    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {
        //        var data = from a in DB.MFG_ProductBarcode
        //                   //join b in DB.MFG_Part on new { partNo = a.CurrentPartNo, partVersion = a.CurrentPartVersion }
        //                   //equals new { partNo = b.PartNo, partVersion = b.PartVersion }
        //                   //where a.VisualNo == visualNo && b.Category3 == category3
        //                   //select a;
        //        if (data != null)
        //        {
        //            return data.FirstOrDefault();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 根据条码获取产品类
        ///// </summary>
        ///// <param name="barcode"></param>
        ///// <returns></returns>
        //[Shareable]
        //public MFG_ProduceCategory GetProduceCategoryByBarcode(string barcode)
        //{
        //    var data = from a in DB.MFG_ProduceCategory
        //               join b in DB.MFG_Part on a.ProduceCtgyCode equals b.ProduceCategory
        //               join c in DB.MFG_ProductBarcode on new { partNo = b.PartNo, partVersion = b.PartVersion }
        //               equals new { partNo = c.CurrentPartNo, partVersion = c.CurrentPartVersion }
        //               where c.Barcode == barcode
        //               select a;
        //    if (data != null && data.Any())
        //    {
        //        return data.FirstOrDefault();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 根据barcode获取零件号
        /// </summary>
        /// <param name="Barcode"></param>
        /// <returns></returns>
        [Shareable]
        public string GetCustCustomerPartNoByBarcode(string Barcode)
        {
            try
            {
                var productBarcode = DB.MFG_ProductBarcode.Where(p => p.Barcode == Barcode).FirstOrDefault();
                if (productBarcode != null)
                {
                    return productBarcode.CurrentPartNo.ToString();

                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 插入条码绑定信息
        /// </summary>
        /// <param name="bbd"></param>
        /// <returns></returns>
        [Shareable]
        public bool InsertBarcodeBindDet(MFG_BarcodeBindDet bbd)
        {
            //写入绑定信息
            Insert<MFG_BarcodeBindDet>(bbd);

            //更新原条码状态
            MFG_ProductBarcode pb = new MFG_ProductBarcode();

            pb = DB.MFG_ProductBarcode.Where(p => p.Barcode == bbd.Barcode).FirstOrDefault();

           // pb.BarcodeStatus = ConstInfo.BarcodeStatus.End;

            Update<MFG_ProductBarcode>(pb);

            return DB.SaveChanges() > 0 ? true : false;

        }
       

        [Shareable]
        public List<MFG_BarcodeBindDet> GetMainBarcode1(string BarcodeNo)
        {
            try
            {
                List<MFG_BarcodeBindDet> BarcodeData = GetList<MFG_BarcodeBindDet>(p => p.MainBarcode == BarcodeNo).ToList();
                return BarcodeData;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 解除条码绑定
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [Shareable]
        public int RemoveBindRelation(string barcode)
        {
            //MFG_ProductBarcode prodbind = GetList<MFG_ProductBarcode>(p => p.Barcode == barcode).FirstOrDefault();
            //修改数据库
            string sql = @"update MFG_ProductBarcode set BarcodeStatus=20 where Barcode= '" + barcode + "' ";
            return DB.Database.ExecuteSqlCommand(sql);
        }

       
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [Shareable]
        public string GetBarcodeStatusByBarcode(string barcode)
        {
            var product = DB.MFG_ProductBarcode.Where(p => p.Barcode == barcode).FirstOrDefault();
            //if (product != null)
            //    return product.BarcodeStatus;
            return "";
        }
       
      
       
        /// <summary>
        /// 根据主条码取子条码
        /// </summary>
        /// <param name="_Mainbacode"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_BarcodeBindDet> GetBarCodeBindetBarcode(string _Mainbacode)
        {
            return GetList<MFG_BarcodeBindDet>(p => p.MainBarcode == _Mainbacode && p.BindType == "SelfBarcodeBind" && p.BindStatus == 1).ToList();
        }

        /// <summary>
        /// 根据子条码取主条码
        /// </summary>
        /// <param name="_Barcode"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_BarcodeBindDet GetBarCodeBindetMainBarcode(string _Barcode)
        {
            return GetData<MFG_BarcodeBindDet>(p => p.Barcode == _Barcode && p.BindType == "SelfBarcodeBind" && p.BindStatus == 1);
        }

       
        /// <summary>
        /// 转半角字体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Shareable]
        public string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 二维码流水号
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public string QRCodeSerialNum(int id)
        {
            try
            {
                var serialNum = GetCurrentSerialNum("QRCode" + id + DateTime.Now.ToString("yyMMdd"));
                serialNum.CurrentNum++;
                string rtn = serialNum.CurrentNum.ToString("D4");
                DB.SYS_SerialNum.AddOrUpdate(serialNum);
                DB.SaveChanges();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///// <summary>
        ///// 修改ISCCR
        ///// </summary>
        ///// <param name="barcode"></param>
        ///// <returns></returns>
        //[Shareable]
        //public bool UpdateBarCodeIsCCR(MFG_ProductBarcode barcode)
        //{
        //    try
        //    {
        //        barcode.IsCCR = false;
        //        Update<MFG_ProductBarcode>(barcode);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

    }
}
