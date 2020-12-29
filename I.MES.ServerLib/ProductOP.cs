using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using I.MES.Library.EF;
using I.MES.Tools;
using System.Diagnostics;


namespace I.MES.Library
{
    /// <summary>
    /// 产品操作类
    /// </summary>
    [Shareable]
    public class ProductOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public ProductOP(ClientInformation clientInfo)
            : base(clientInfo)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public ProductOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        /// <summary>
        /// 取有效的产品生产分组
        /// example:L538前保
        /// </summary>
        /// <returns>产品生产分组</returns>
        [Shareable]
        public List<MFG_ProduceCategory> GetAvailProduceCategory()
        {
            try
            {
                //using (MESEntities db = new MESEntities())
                //{
                var data = (from produceCtgy in DB.MFG_ProduceCategory
                            where produceCtgy.Enabled == true
                            select produceCtgy).OrderBy(p => p.ProduceCtgyCode).Distinct().ToList();
                return data;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取生产打包执行数据
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_BarcodeScanLog> GetBarCode(string StartTime, string EndTime, int PageNumber, int PageSize, out int total)
        {
            List<MFG_BarcodeScanLog> dates = new List<MFG_BarcodeScanLog>();
            StringBuilder SqlStringBuilder = new StringBuilder(1024);
            SqlStringBuilder.Append("SELECT   ");
            SqlStringBuilder.Append(" d.ScanSiteName AS ScanSiteCode, ");
            SqlStringBuilder.Append("e.ActionName AS ActionCode, ");
            SqlStringBuilder.Append("f.UserName AS CreateUserAccount, ");
            SqlStringBuilder.Append("* ");
            SqlStringBuilder.Append("FROM    dbo.MFG_BarcodeScanLog c WITH ( NOLOCK, INDEX ( IDX_BarcodeScanLog_6 ) ) ");
            SqlStringBuilder.Append("LEFT JOIN dbo.MFG_ScanSite d  ON c.ScanSiteCode=d.ScanSiteCode ");
            SqlStringBuilder.Append("LEFT JOIN dbo.MFG_ScanAction e ON c.ActionCode=e.ActionCode  ");
            SqlStringBuilder.Append("LEFT JOIN dbo.SYS_User f ON c.CreateUserAccount=f.UserAccount  ");
            SqlStringBuilder.Append("WHERE ( ( ( c.ScanSiteCode = 'OutLineQualityCheck' ");
            SqlStringBuilder.Append("            AND ( c.ActionCode = 'IntoPolishOK' ");
            SqlStringBuilder.Append("                  OR c.ActionCode = 'IntoSpotRepairOK' ");
            SqlStringBuilder.Append("                )) ");
            SqlStringBuilder.Append("          ) ");
            SqlStringBuilder.Append("          OR ( ( c.ScanSiteCode = 'PaintOffLineScan' ");
            SqlStringBuilder.Append("               AND c.ActionCode = 'IntoOK' ");
            SqlStringBuilder.Append("               AND OrigPartNo <> NewPartNo) ");
            SqlStringBuilder.Append("             ) ");
            SqlStringBuilder.Append("        ) ");
            SqlStringBuilder.Append("        AND ( ( c.CreateTime > = '" + StartTime + "' ");
            SqlStringBuilder.Append("              AND c.CreateTime <= '" + EndTime + "' ");
            SqlStringBuilder.Append("              AND NOT EXISTS ( SELECT   * ");
            SqlStringBuilder.Append("                               FROM     [LGS_PartExcludeConfig] b ");
            SqlStringBuilder.Append("                               WHERE    b.PartNo = c.NewPartNo ");
            SqlStringBuilder.Append("                                        AND b.ExcludeType = 'PaintPKG' ) ");
            SqlStringBuilder.Append("            ) ");
            SqlStringBuilder.Append("            ) ");
            SqlStringBuilder.Append("        AND c.Barcode NOT IN ( SELECT Barcode ");
            SqlStringBuilder.Append("                             FROM   LGS_HUPkgLog WITH ( NOLOCK ) ");
            SqlStringBuilder.Append("                             WHERE  prodplacecode = 'PNT' ");
            SqlStringBuilder.Append("                                    AND createtime > = '" + StartTime + "' ");
            SqlStringBuilder.Append("                                    AND CreateTime <= '" + EndTime + "' ) ");

            var data = DB.Database.SqlQuery<MFG_BarcodeScanLog>(SqlStringBuilder.ToString()).ToList();
            total = data.Count();
            var datad = data.OrderByDescending(p => p.CreateTime).Skip((PageNumber - 1) * PageSize).Take(PageSize);
            var list = datad.ToList();
            foreach (var a in list)
            {
                MFG_BarcodeScanLog mfg_barcodeLog = new MFG_BarcodeScanLog();
                mfg_barcodeLog.CopyFrom(a);
                dates.Add(mfg_barcodeLog);
            }
            return dates;
        }
        /// <summary>
        /// 根据条码自动获取生产线信息
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_BarcodeScanLog GetLastProdLine(string barcode)
        {
            try
            {
                string sql = string.Format("SELECT * FROM dbo.MFG_BarcodeScanLog(NOLOCK) WHERE Barcode='{0}' AND ProdLineCode<>'' ORDER BY id desc", barcode);
                return DB.Database.SqlQuery<MFG_BarcodeScanLog>(sql).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 根据生产线代码获取产线信息
        /// </summary>
        /// <param name="prodLineCode"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_ProdLine GetProdLine(string prodLineCode)
        {
            try
            {
                string sql = string.Format("SELECT * FROM dbo.MFG_ProdLine(NOLOCK) WHERE ProdLineCode='{0}'", prodLineCode);
                return DB.Database.SqlQuery<MFG_ProdLine>(sql).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据工作中心取可生产的产品类型
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProduceCategory> GetAvailProduceCategoryByWC(string factoryCode, string workCenterCode, string vehicleMode)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取产品生产分组信息
        /// </summary>
        /// <param name="produceCategoryCode">产品生产分组代码</param>
        /// <returns>生产分组信息</returns>
        [Shareable]
        public MFG_ProduceCategory GetProduceCategory(string produceCategoryCode)
        {
            try
            {
                //using (MESEntities db = new MESEntities())
                //{
                //    return db.MFG_ProduceCategory.First(p => p.ProduceCtgyCode == produceCategoryCode);
                //}
                return GetData<MFG_ProduceCategory>(p => p.ProduceCtgyCode == produceCategoryCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 小件分类
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<I.MES.Models.SelectListItem> GetProduceCategoryXJ()
        {
            try
            {
                var data = from a in DB.MFG_ProduceCategory
                           select new I.MES.Models.SelectListItem()
                           {
                               Text = a.CategoryName,
                               Value = a.ProduceCtgyCode
                           };
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 取产品条码实例
        /// </summary>
        /// <param name="barcode">产品条码</param>
        /// <returns>产品条码信息</returns>
        [Shareable]
        public MFG_ProductBarcode GetProductBarcode(string barcode)
        {
            try
            {
                //取条码数据
                //using (MESEntities db = new MESEntities())
                //{
                //    return db.MFG_ProductBarcode.FirstOrDefault(p => p.Barcode == barcode);
                //}
                return GetData<MFG_ProductBarcode>(p => p.Barcode == barcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// 取产品条码信息
        ///// 包含零件等信息
        ///// <param name="barcode">产品条码</param>
        ///// <returns>产品条码信息</returns>
        //[Shareable]
        //public Models.ProductBarcodeInfo GetProductBarcodeInfo(string barcode)
        //{
        //    try
        //    {
        //        Models.ProductBarcodeInfo barcodeInfo = new Models.ProductBarcodeInfo();
        //        //取条码数据
        //        //using (MESEntities db = new MESEntities())
        //        //{
        //        //ProductBarcode productBarcode =  db.ProductBarcode.FirstOrDefault(p => p.Barcode == barcode);
        //        //barcodeInfo.CopyFrom( db.MFG_ProductBarcode.FirstOrDefault(p => p.Barcode == barcode));
        //        var bc = GetData<MFG_ProductBarcode>(p => p.Barcode == barcode);

        //        if (bc == null)
        //        {
        //            throw new Exception(string.Format("条码{0}在MFG_ProductBarcode表中不存在，请检查", barcode));
        //        }

        //        barcodeInfo.CopyFrom(bc);
        //        barcodeInfo.currentPart = new Models.MFG_Part();
        //        //打磨件和空零件号都是不用配MFG_Part的，他们找的时候，默认先找Normal的
        //        string partVer = barcodeInfo.CurrentPartVersion == ConstInfo.MFG_PartVersion.EMPTY || barcodeInfo.CurrentPartVersion == ConstInfo.MFG_PartVersion.DM ? ConstInfo.MFG_PartVersion.NORMAL : barcodeInfo.CurrentPartVersion;
        //        MFG_Part tmppart = GetPart(barcodeInfo.CurrentPartNo, partVer);
        //        if (tmppart == null)
        //        {
        //            var x = GetParts(barcodeInfo.CurrentPartNo).ToList();
        //            if (x.Exists(p => p.PartVersion == ConstInfo.MFG_PartVersion.NORMAL))
        //            {
        //                tmppart = x.Find(p => p.PartVersion == ConstInfo.MFG_PartVersion.NORMAL);
        //            }
        //            else if (x.Exists(p => p.CompPartVersion == ConstInfo.MFG_PartVersion.NORMAL))
        //            {
        //                tmppart = x.Find(p => p.CompPartVersion == ConstInfo.MFG_PartVersion.NORMAL);
        //            }
        //            else
        //            {
        //                tmppart = GetParts(barcodeInfo.CurrentPartNo).FirstOrDefault();
        //            }
        //        }
        //        if (tmppart == null)
        //        {
        //            throw new Exception("找不到零件的MFG_Part配置." + barcodeInfo.CurrentPartNo);
        //        }
        //        barcodeInfo.currentPart.CopyFrom(tmppart);

        //        barcodeInfo.currentPart.PartVersion = barcodeInfo.CurrentPartVersion;
        //        barcodeInfo.newPart = barcodeInfo.currentPart;//默认情况下新零件号与旧零件号相同，当进行状态转换时，才将他们的状态进行切换
        //        return barcodeInfo;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#region 获取配置信息
        ///// <summary>
        ///// 获取配置信息
        ///// </summary>
        ///// <param name="partNo"></param>
        ///// <returns></returns>
        //[Shareable]
        //public LGS_AutoToPartConfig GetAuto(string partNo)
        //{
        //    return GetData<LGS_AutoToPartConfig>(p => p.PartNo == partNo);
        //}
        //#endregion

        //#region 获取配置信息列表
        ///// <summary>
        ///// 获取配置信息列表
        ///// </summary>
        ///// <param name="PartNo"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<LGS_AutoToPartConfig> GetPartTransInfo(string PartNo)
        //{
        //    return GetList<LGS_AutoToPartConfig>(p => p.PartNo == PartNo).ToList();
        //}
        //#endregion

        //#region 获取总成零件号信息
        ///// <summary>
        ///// 获取总成零件号
        ///// </summary>
        ///// <param name="partno">零件号</param>
        ///// <returns>零件信息</returns>
        //[Shareable]
        //public Models.AutoToPartConfigModel GetProductAuto(string partno)
        //{
        //    try
        //    {
        //        Models.AutoToPartConfigModel autotopart = new Models.AutoToPartConfigModel();

        //        var bc = GetData<LGS_AutoToPartConfig>(p => p.PartNo == partno);
        //        autotopart.CopyFrom(bc);

        //        return autotopart;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

        //#region 根据总成零件号获取该零件中文描述
        ///// <summary>
        ///// 根据总成零件号获取该零件中文描述
        ///// </summary>
        ///// <param name="PartNo"></param>
        ///// <returns></returns>
        //[Shareable]
        //public Models.CompartInfoModel GetPartInfo(string PartNo)
        //{
        //    try
        //    {
        //        Models.CompartInfoModel ComPInfo = new Models.CompartInfoModel();
        //        var dc = GetData<MFG_Part>(p => p.CompPartNo == PartNo);
        //        ComPInfo.CopyFrom(dc);

        //        return ComPInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

        /// <summary>
        /// 取产品零件信息
        /// </summary>
        /// <param name="partNo"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_Part> GetParts(string partNo)
        {
            try
            {
                return GetList<MFG_Part>(p => p.PartNo == partNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取父零件信息
        /// </summary>
        /// <param name="ComppartNo"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_Part> GetComParts(string ComppartNo)
        {
            try
            {
                return GetList<MFG_Part>(p => p.CompPartNo == ComppartNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
      

      
      
    


        ///// <summary>
        ///// 取一个零件的可用上阶零件（父零件）
        ///// 1.MFG_Part中有层级关系
        ///// 2.有生产版本
        ///// </summary>
        ///// <param name="currentPartNo">子零件号</param>
        ///// <param name="currentPartVersion">子零件版本号</param>
        ///// <returns>父零件列表</returns>
        //[Shareable]
        //public List<MFG_Part> GetParentPart(string factoryCode, string prodLineCode, string mould, string currentPartNo, string currentPartVersion)
        //{
        //    try
        //    {
        //        //using (MESEntities db = new MESEntities())
        //        //{
        //        //    List<MFG_Part> parts = db.MFG_Part.Where(p => p.CompPartNo == currentPartNo && p.CompPartVersion == currentPartVersion).ToList();
        //        //   return parts;
        //        //}
        //        string workVersion = new ProcessScanOP(ClientInfo).GenerateWorkVersionCode(factoryCode, prodLineCode, mould, currentPartVersion);
        //        if (string.IsNullOrEmpty(workVersion))
        //        {
        //            throw new Exception("找不到产品的生产版本.工厂:" + factoryCode + ",生产线:" + prodLineCode + ",模具:" + mould + ",版本号:" + currentPartVersion);
        //        }
        //        var availParentParts = from mfgPart in DB.MFG_Part
        //                               join workVer in DB.MFG_WorkVersion on mfgPart.PartNo equals workVer.PartNo
        //                               where workVer.EffStartTime <= DateTime.Now && workVer.EffExpireTime > DateTime.Now && workVer.FactoryCode == factoryCode
        //                                    && mfgPart.CompPartVersion == currentPartVersion && mfgPart.CompPartNo == currentPartNo && workVer.WorkVer == workVersion
        //                               select mfgPart;
        //        return availParentParts.ToList();
        //        //return GetList<MFG_Part>(p => p.CompPartNo == currentPartNo && p.CompPartVersion == currentPartVersion).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

       
        /// <summary>
        /// 获得所有的MFG_PartCategory
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_PartCategory> GetAllPartCategory()
        {
            return GetList<MFG_PartCategory>(p => true).ToList();
        }

        /// <summary>
        /// 获得排序扫描的产品类型
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_PartCategory> GetJisPartCategory()
        {
            //var data = from d in 
            return GetList<MFG_PartCategory>(p => true).ToList();
        }
        ///// <summary>
        ///// 获取散件的产品类型
        ///// </summary>
        ///// <returns></returns>
        //[Shareable]
        //public List<MFG_PartCategory> GetStdPartCategory()
        //{
        //    var stdPartCategory = from category in DB.MFG_PartCategory
        //                          join std in DB.LGS_CustStdOrdMstr
        //                          on
        //                          category.CategoryCode equals std.Category3
        //                          select category;
        //    return stdPartCategory.Distinct().ToList();
        //}

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category1"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_VehicleMode> GetVehicleModeList(string category1)
        {
            try
            {
                var list = from mode in DB.MFG_VehicleMode
                           //join part in DB.MFG_Part on mode.VehicleMode equals part.VehicleMode
                           //join category in DB.MFG_ProduceCategory on part.ProduceCategory equals category.ProduceCtgyCode
                           //where part.HasBarcode == false && part.IsSelfMade == true && category.ProduceCtgyCode == category1
                           select mode;
                return list.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
       
      
        ///// <summary>
        ///// 获取小件下线产品列表数据
        ///// </summary>
        ///// <param name="scansiteInfo">扫描点信息</param>
        ///// <param name="produceCategoryCode"></param>
        ///// <param name="category1"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<MFG_Part> GetAvailXJPartByWC(Models.ScanSiteInfo scansiteInfo, string produceCategoryCode, string category1)
        //{
        //    try
        //    {
        //        var data = (from part in DB.MFG_Part
        //                    join produceCategory in DB.MFG_ProduceCategory on part.ProduceCategory equals produceCategory.ProduceCtgyCode
        //                    join procRoute in DB.MFG_ProcRoute on part.PartNo equals procRoute.PartNo
        //                    where produceCategory.Enabled == true && procRoute.WCCode == scansiteInfo.prodLine.WCCode && procRoute.FactoryCode == scansiteInfo.currentFactory.FactoryCode
        //                            && procRoute.IsDel == false
        //                            && part.HasBarcode == false && part.IsSelfMade == true && part.ProduceCategory == produceCategoryCode && part.Category1 == category1
        //                            && part.ForceDisable == false
        //                    select part).Distinct();
        //        return data.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 获取多边产品组
        ///// </summary>
        ///// <param name="partNo"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<MFG_Part> GetXJPartGroup(string partNo)
        //{
        //    try
        //    {
        //        var data = (from a in DB.LGS_XJPartGroup
        //                    join b in DB.LGS_XJPartGroup on a.GroupId equals b.GroupId
        //                    join c in DB.MFG_Part on a.PartNo equals c.PartNo
        //                    where b.PartNo == partNo
        //                    select c).ToList();
        //        return data.Distinct(new MFG_PartComparer()).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 获取多边产品组
        ///// </summary>
        ///// <param name="partNo"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<MFG_Part> GetXJPartGroup(string partNo, string partVersion)
        //{
        //    try
        //    {
        //        var data = (from a in DB.LGS_XJPartGroup
        //                    join b in DB.LGS_XJPartGroup on a.GroupId equals b.GroupId
        //                    join c in DB.MFG_Part on a.PartNo equals c.PartNo
        //                    where b.PartNo == partNo && c.PartVersion == partVersion
        //                    select c).ToList();
        //        return data.Distinct(new MFG_PartComparer()).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 获得所有MFG_Part信息
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_Part> GetAllPart()
        {
            return GetList<MFG_Part>(p => true).ToList();
        }

        ///// <summary>
        ///// 获取所有去重之后的V_MFG_Part信息
        ///// </summary>
        ///// <returns></returns>
        //[Shareable]
        //public List<V_MFG_Part> GetVPartList()
        //{
        //    return GetList<V_MFG_Part>(p => true).ToList();
        //}

        /// <summary>
        /// 根据工厂和零件号获得零件明细
        /// </summary>
        /// <param name="factoryCode">工厂号</param>
        /// <param name="partNo">零件号</param>
        /// <returns></returns>
        [Shareable]
        public MFG_PartDetail GetPartDetailByFacAndPartNo(string factoryCode, string partNo)
        {
            return GetData<MFG_PartDetail>(p => p.FactoryCode == factoryCode && p.PartNo == partNo);
        }
        public List<MFG_Part> GetMfgPartByScanSite(string scansiteCode)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据PartNo获得零件明细
        /// </summary>
        /// <param name="PartNo"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_PartDetail GetPartDetailByPartNo(string PartNo)
        {
            return GetData<MFG_PartDetail>(p => p.PartNo == PartNo);
        }
        /// <summary>
        /// 根据LGS_SupItemGroupDet表获得LGS_ProductPackageQty表的包装数量及单价之类的信息
        /// </summary>
        /// <param name="PartNo"></param>
        /// <param name="ProduceCategory"></param>
        /// <param name="ProduceLevel"></param>
        /// <param name="PartVersion"></param>
        /// <returns></returns>
        //[Shareable]
        //public LGS_ProductPackageQty GetProductPackageType(string PartNo,string PartVersion) {

        //    try
        //    {
        //        LGS_ProductPackageType ppt = GetData<LGS_ProductPackageType>(p => p.PartNo == PartNo && p.PartVersion == PartVersion);
        //        //return GetData<LGS_ProductPackageQty>(p => p.MappingID == ppt.MappingID);
        //        if(ppt!=null){
        //        return GetProductPackageQty(ppt.MappingID);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public LGS_ProductPackageQty GetProductPackageQty(string MappingID)
        //{
        //    return GetData<LGS_ProductPackageQty>(p => p.MappingID == MappingID);

        //}
        ///// <summary>
        ///// 根据LGS_SupItemGroupDet表获得LGS_ProductPackageQty表的包装数量及单价之类的信息
        ///// </summary>
        ///// <param name="PartNo"></param>
        ///// <param name="GroupCode"></param>
        ///// <param name="PartVersion"></param>
        ///// <returns></returns>
        //[Shareable]
        //public LGS_SupItemGroupDet GetProductPackageDet(string PartNo, string PartVersion, string GroupCode)
        //{
        //    return GetData<LGS_SupItemGroupDet>(p => p.PartNo == PartNo && p.PartVersion == PartVersion && p.GroupCode == GroupCode);
        //}
        //[Shareable]
        //public WMS_ProductBinConfig GetProductBinConfig(string BinCode)
        //{
        //    return GetData<WMS_ProductBinConfig>(p => p.BinCode == BinCode);
        //}

        /// <summary>
        /// 获取生产统计数据
        /// </summary>
        /// <param name="scanSiteInfo"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        //[Shareable]
        //public List<I.MES.Models.ProdStatisticsModel> GetProdStatistics(I.MES.Models.ScanSiteInfo scanSiteInfo, DateTime StartTime, DateTime EndTime, string categoryCode)
        //{

        //    if (!scanSiteInfo.currentScanSite.ScanSiteCode.Equals("CleanScan")
        //        && !scanSiteInfo.currentScanSite.ScanSiteCode.Equals("ClearStopScan")
        //        && !scanSiteInfo.currentScanSite.ScanSiteCode.Equals("PrimeCoatScan")
        //        && !scanSiteInfo.currentScanSite.ScanSiteCode.Equals("QCScan"))
        //    {
        //        var data = (from a in DB.MFG_BarcodeScanLog.Where(p => p.ScanSiteCode == scanSiteInfo.currentScanSite.ScanSiteCode
        //       && p.CreateTime >= StartTime && p.CreateTime <= EndTime
        //       && p.FactoryCode == scanSiteInfo.currentFactory.FactoryCode
        //       && (p.OrigPartNo != p.NewPartNo || p.OrigPartVersion != p.NewPartVersion || p.ControlStatus == "PntUpLine")
        //       && p.ProdLineCode == scanSiteInfo.prodLine.ProdLineCode)
        //                    group a by new
        //                    {
        //                        a.FactoryCode,
        //                        a.ProdLineCode,
        //                        a.NewPartNo,
        //                        a.NewPartVersion,
        //                        a.NewQualityStatus
        //                    }
        //                        into res
        //                    select new Models.ProdStatisticsModel
        //                    {
        //                        FactoryCode = res.Key.FactoryCode,
        //                        PartNo = res.Key.NewPartNo,
        //                        PartVersion = res.Key.NewPartVersion,
        //                        QualityStatusCode = res.Key.NewQualityStatus,
        //                        ProdLineCode = res.Key.ProdLineCode,
        //                        QualityStatusName = DB.QCM_QualityStatus.FirstOrDefault(p => p.QualityStatusCode == res.Key.NewQualityStatus).QualityStatusName,
        //                        PartDesc = DB.V_MFG_Part.FirstOrDefault(p => p.PartNo == res.Key.NewPartNo && p.PartVersion == res.Key.NewPartVersion).Description,
        //                        ProdLineName = DB.MFG_ProdLine.FirstOrDefault(p => p.ProdLineCode == res.Key.ProdLineCode).ProdLineName,
        //                        ProdCount = res.Count()
        //                    }).OrderBy(p => p.FactoryCode).ThenBy(p => p.ProdLineCode).ThenBy(p => p.PartNo);


        //        if (categoryCode != "")
        //        {
        //            data = (from a in data
        //                    join b in DB.V_MFG_Part on a.PartNo equals b.PartNo
        //                    where b.Category3 == categoryCode
        //                    select a).Distinct().OrderBy(p => p.FactoryCode);
        //        }
        //        return data.ToList();
        //    }
        //    else
        //    {
        //        var data = (from a in DB.MFG_BarcodeScanLog.Where(p => p.ScanSiteCode == scanSiteInfo.currentScanSite.ScanSiteCode
        //                      && p.CreateTime >= StartTime && p.CreateTime <= EndTime
        //                      && p.FactoryCode == scanSiteInfo.currentFactory.FactoryCode
        //                      && p.ProdLineCode == scanSiteInfo.prodLine.ProdLineCode)
        //                    group a by new
        //                    {
        //                        a.FactoryCode,
        //                        a.ProdLineCode,
        //                        a.NewPartNo,
        //                        a.NewPartVersion,
        //                        a.NewQualityStatus
        //                    }
        //                        into res
        //                    select new Models.ProdStatisticsModel
        //                    {
        //                        FactoryCode = res.Key.FactoryCode,
        //                        PartNo = res.Key.NewPartNo,
        //                        PartVersion = res.Key.NewPartVersion,
        //                        QualityStatusCode = res.Key.NewQualityStatus,
        //                        ProdLineCode = res.Key.ProdLineCode,
        //                        QualityStatusName = DB.QCM_QualityStatus.FirstOrDefault(p => p.QualityStatusCode == res.Key.NewQualityStatus).QualityStatusName,
        //                        PartDesc = DB.V_MFG_Part.FirstOrDefault(p => p.PartNo == res.Key.NewPartNo && p.PartVersion == res.Key.NewPartVersion).Description,
        //                        ProdLineName = DB.MFG_ProdLine.FirstOrDefault(p => p.ProdLineCode == res.Key.ProdLineCode).ProdLineName,
        //                        ProdCount = res.Count()
        //                    }).OrderBy(p => p.FactoryCode).ThenBy(p => p.ProdLineCode).ThenBy(p => p.PartNo);
        //        if (categoryCode != "")
        //        {
        //            data = (from a in data
        //                    join b in DB.V_MFG_Part on a.PartNo equals b.PartNo
        //                    where b.Category3 == categoryCode
        //                    select a).Distinct().OrderBy(p => p.FactoryCode);
        //        }
        //        return data.ToList();
        //    }
        //}


        ///// <summary>
        ///// 根据RK号获得HU打箱的条码明细
        ///// </summary>
        ///// <param name="rackCode">RK号</param>
        ///// <returns></returns>
        //[Shareable]
        //public List<I.MES.Models.ProductBarcodeInfo> GetProductBarcodeByRKCode(string rackCode)
        //{
        //    try
        //    {
        //        List<I.MES.Models.ProductBarcodeInfo> productBarcodeInfoList = new List<I.MES.Models.ProductBarcodeInfo>();
        //        var data = from a in DB.LGS_HUPkgMstr
        //                   from b in DB.LGS_HUPkgDet
        //                   from c in DB.MFG_ProductBarcode
        //                   where a.HUCode == b.HUCode && b.Barcode == c.Barcode && a.RackCode == rackCode
        //                   select c;


        //        foreach (var productBarcode in data.ToList())
        //        {
        //            Models.ProductBarcodeInfo barcodeInfo = new Models.ProductBarcodeInfo();

        //            barcodeInfo.CopyFrom(productBarcode);
        //            barcodeInfo.currentPart = new Models.MFG_Part();

        //            string partVer = barcodeInfo.CurrentPartVersion == ConstInfo.MFG_PartVersion.EMPTY || barcodeInfo.CurrentPartVersion == ConstInfo.MFG_PartVersion.DM ? ConstInfo.MFG_PartVersion.NORMAL : barcodeInfo.CurrentPartVersion;
        //            barcodeInfo.currentPart.CopyFrom(GetPart(barcodeInfo.CurrentPartNo, partVer));
        //            barcodeInfo.currentPart.PartVersion = barcodeInfo.CurrentPartVersion;
        //            barcodeInfo.newPart = barcodeInfo.currentPart;//默认情况下新零件号与旧零件号相同，当进行状态转换时，才将他们的状态进行切换
        //            productBarcodeInfoList.Add(barcodeInfo);
        //        }

        //        return productBarcodeInfoList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

       
        /// <summary>
        /// 设置条码为已盘点
        /// </summary>
        /// <param name="serialNum"></param>
        /// <param name="scanSiteInfo"></param>
        //[Shareable]
        //public void SetStockSerialNum(string serialNum, Models.ScanSiteInfo scanSiteInfo)
        //{
        //    //暂时注释
        //    string barCodeType = new LGSCommOP(ClientInfo, DB).GetBarcodeType(serialNum);

        //    if (barCodeType == "")
        //        throw new Exception(serialNum + ":条码类型异常！");

        //    switch (barCodeType)
        //    {
        //        case ConstInfo.BarcodeType.HU:
        //        case ConstInfo.BarcodeType.RK:
        //        case ConstInfo.BarcodeType.TP:
        //            SetStockPkgBarcode(serialNum, scanSiteInfo);
        //            break;
        //        case ConstInfo.BarcodeType.Product:
        //            SetStockProductBarcode(serialNum, scanSiteInfo);
        //            break;
        //        default:
        //            break;
        //    }

        //}
        ///// <summary>
        ///// 设置包装条码为已盘点状态
        ///// </summary>
        ///// <param name="barCode"></param>
        ///// <param name="scanSiteInfo"></param>
        //[Shareable]
        //public void SetStockPkgBarcode(string barCode, Models.ScanSiteInfo scanSiteInfo)
        //{
        //    try
        //    {
        //        //暂时注释
        //        List<LGS_HUPkgMstr> huPkgList
        //         = new LGSCommOP(ClientInfo, DB).GetHUPkgMstrBySerialNum(barCode);
        //        if (huPkgList.Count > 0)
        //        {
        //            huPkgList.ForEach(
        //                p =>
        //                {
        //                    List<LGS_HUPkgDet> detList = GetList<LGS_HUPkgDet>(s => s.HUCode == p.HUCode).ToList();
        //                    if (detList.Count > 0)
        //                    {
        //                        detList.ForEach(
        //                            d =>
        //                            {
        //                                SetStockProductBarcode(d.Barcode, scanSiteInfo);
        //                            }
        //                            );
        //                    }
        //                }
        //                );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
       
       
        ///// <summary>
        ///// 设置产品条码未已盘点的状态
        ///// </summary>
        ///// <param name="barCode"></param>
        //[Shareable]
        //public void SetStockProductBarcode(string barCode, Models.ScanSiteInfo scanSiteInfo)
        //{
        //    try
        //    {
        //        MFG_ProductBarcode UpdateBarcode = GetData<MFG_ProductBarcode>(p => p.Barcode == barCode);

        //        if (scanSiteInfo.currentScanSite != null)
        //        {
        //            if (scanSiteInfo.currentScanSite.ScanSiteCode.Equals("ImmScan"))
        //            {
        //                UpdateBarcode.ProdLineCode = scanSiteInfo.prodLine.ProdLineCode;
        //            }
        //            Update<MFG_ProductBarcode>(UpdateBarcode);
        //        }
        //        //暂时注释
        //        if (!IsNotStock(barCode))
        //        {

        //            ////变更条码未已盘点
        //            MFG_ProductBarcode barcode = GetData<MFG_ProductBarcode>(p => p.Barcode == barCode);
        //            barcode.IsStock = true;

        //            Update<MFG_ProductBarcode>(barcode);

        //            //增加条码扫描日志
        //            Models.ProductBarcodeInfo barcodeInfo = new Models.ProductBarcodeInfo();
        //            barcodeInfo.CopyFrom(barcode);

        //            LGSCommOP commOp = new LGSCommOP(ClientInfo, DB);
        //            MFG_BarcodeScanLog barcodeLog = new BarcodeOP(ClientInfo).AddBarcodeScanLog(barcodeInfo.Barcode, barcodeInfo.CurrentPartNo, barcodeInfo.CurrentPartVersion,
        //            barcodeInfo.QualityStatus, barcodeInfo.CurrentPartNo, barcodeInfo.CurrentPartVersion, barcode.QualityStatus,
        //                 ConstInfo.MFG_ScanAction.SetStock, "", "", barcodeInfo.ControlStatus, scanSiteInfo);
        //            barcodeLog.OpType = (int)ConstInfo.BarcodeScanLogOpType.SetStock;
        //            Insert<MFG_BarcodeScanLog>(barcodeLog);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region 小件下线
        ///// <summary>
        ///// 生产统计
        ///// </summary>
        ///// <param name="ProdPlaceCode"></param>
        ///// <param name="StartTime"></param>
        ///// <param name="EndTime"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<V_MFG_XJReport> GetXJProdStatistics(string ProdPlaceCode, DateTime StartTime, DateTime EndTime)
        //{
        //    //DB.MFG_ScanSite.ToList();
        //    List<V_MFG_XJReport> data = DB.V_MFG_XJReport.Where(p => p.ProdPlaceCode == ProdPlaceCode && p.CreateTime >= StartTime && p.CreateTime <= EndTime).ToList();
        //    return data;
        //}

        //[Shareable]
        //public List<vHUPkg> gettest()
        //{
        //    var data =GetList<vHUPkg>(p=>true);
        //    return data.ToList();
        //}

        #endregion

        /// <summary>
        /// 产品类型
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_PartCategory> GetProductType()
        {

            return GetList<MFG_PartCategory>(p => p.CategoryType == "Category3").ToList();

        }

       

      

        //#region 嫌疑品

        //[Shareable]
        //public string getMessage(int id)
        //{
        //    string message = "校验负库存所需时间：";
        //    Stopwatch sw = new Stopwatch();

        //    MESEntities db = new MESEntities();
        //    StockOP stockOP = new StockOP(ClientInfo, db);
        //    var data = DB.MFG_ProductBarcode.FirstOrDefault(p => p.ID == id); //GetData<MFG_ProductBarcode>(p => p.ID == id);
        //    var conn = db.Database.Connection;
        //    conn.Open();
        //    DateTime effdate = stockOP.GetCorrectEffDate("10402210", DateTime.Now);
        //    List<MFG_BomPartList> bomList = DB.P_MFG_FristLevelBOM("1040", "12002057", "101", effdate).ToList();
        //    sw.Start();
        //    foreach (MFG_BomPartList bomPart in bomList)
        //    {
        //        //sw.Restart();
        //        stockOP.IsStockCheck("1040", "10402200", bomPart.PartNo, "NORMAL", bomPart.Qty, "OK", "0");
        //        //sw.Stop();
        //        //message += "+" + sw.ElapsedMilliseconds;
        //    }
        //    sw.Stop();
        //    message += "+" + sw.ElapsedMilliseconds;

        //    //sw.Restart();
        //    //stockOP.IsStockCheckBatch("2010", "12013559", "NORMAL", "20102200", "OK", "0", "101", effdate);
        //    //sw.Stop();
        //    //message += "+" + sw.ElapsedMilliseconds;

        //    return message;
        //}


        //[Shareable]
        //public bool ProdBarCodeCCRComps(string barcode)
        //{
        //    try
        //    {
        //        var data1 = GetData<MFG_ProdBarCodeCCRComps>(p => p.BarCode == barcode);
        //        if (data1 == null)
        //        {
        //            //UpdateBarCode(barcode);
        //            return true;
        //        }
        //        var data = GetData<MFG_ProdBarCodeCCRComps>(p => p.BarCode == barcode && p.AssembliedQty > 0);
        //        if (data == null)
        //        {
        //            var a = GetList<MFG_ProdBarCodeCCRComps>(p => p.BarCode == barcode && p.AssembliedQty == 0);
        //            if (a.Count() > 0)
        //            {
        //                foreach (var item in a)
        //                {
        //                    MFG_ProdBarCodeCCRComps b = new MFG_ProdBarCodeCCRComps();
        //                    b = item;
        //                    Delete<MFG_ProdBarCodeCCRComps>(b);
        //                }
        //                return true;
        //            }
        //        }
        //        return false;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[Shareable]
        //public MFG_ProductBarcode UpdateBarCode(string BarCode)
        //{
        //    try
        //    {
        //        var barcode = GetData<MFG_ProductBarcode>(p => p.Barcode == BarCode);
        //        if (barcode == null)
        //        {
        //            throw new Exception("找不到条码" + BarCode + " 的产品！");
        //        }
        //        //MFG_BarcodeScanLog Barcodelog = new MFG_BarcodeScanLog();
        //        //Barcodelog.Barcode = barcode.Barcode;
        //        //Barcodelog.OrigPartNo = barcode.CurrentPartNo;
        //        //Barcodelog.OrigPartVersion = barcode.CurrentPartVersion;
        //        //Barcodelog.OrigQualityStatus = "1";
        //        //Barcodelog.NewPartNo = barcode.CurrentPartNo;
        //        //Barcodelog.NewPartVersion = barcode.CurrentPartVersion;
        //        //Barcodelog.NewQualityStatus = "2";
        //        //Barcodelog.OrigStdOrdCfg = barcode.StdOrdCfg;
        //        //Barcodelog.ScanSiteCode = "SuspectProdVeri";
        //        //Barcodelog.ActionCode = "IntoFreeze";
        //        //Barcodelog.RctStk = string.Empty;
        //        //Barcodelog.IssStk = string.Empty;
        //        //Barcodelog.ControlStatus = string.Empty;
        //        //Barcodelog.RctBOM = string.Empty;
        //        //Barcodelog.FactoryCode = this.FactoryCode;
        //        //Barcodelog.WCCode = string.Empty;
        //        //Barcodelog.ProdLineCode = string.Empty;
        //        //Barcodelog.IsDel = false;
        //        //Barcodelog.IsDelAfter = false;
        //        //Barcodelog.CreateTime = DateTime.Now;
        //        //Barcodelog.CreateUserAccount = this.UserAccount;
        //        //Barcodelog.CreateMachine = this.MachineName;
        //        //Barcodelog.LogGUID = Tools.StringTools.GetGUID();
        //        //Barcodelog.ClientTraceInfo = ClientInfo.ClientTraceInfo;
        //        //Barcodelog.ServerTraceInfo = Helper.getMethodTrace();

        //        //barcode.StdOrdCfg = "";
        //        //barcode.Spare1 = "";
        //        //barcode.IsCCR = false;

        //        //Update<MFG_ProductBarcode>(barcode);
        //        // Insert<MFG_BarcodeScanLog>(Barcodelog);
        //        return barcode;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        ///// <summary>
        ///// 判断条码是否在架上
        ///// </summary>
        ///// <param name="Barcode"></param>
        ///// <returns></returns>
        //[Shareable]
        //public bool IsUpBin(string Barcode)
        //{
        //    var data = (from a in DB.WMS_ProductBinDet
        //                join b in DB.LGS_HUPkgDet on a.Barcode equals b.HUCode
        //                where b.Barcode == Barcode
        //                select a).ToList().FirstOrDefault();
        //    if (data == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


        //#endregion

    }


    public class MFG_PartComparer : IEqualityComparer<MFG_Part>
    {
        public bool Equals(MFG_Part x, MFG_Part y)
        {
            return x.PartNo.Equals(y.PartNo);
        }

        public int GetHashCode(MFG_Part obj)
        {
            return 0;
        }
    }


}
