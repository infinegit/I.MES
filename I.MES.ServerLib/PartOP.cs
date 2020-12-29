using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;
using I.MES.Tools;

namespace I.MES.Library
{
    /// <summary>
    /// 零件主表操作类
    /// </summary>
    [Shareable]
    public class PartOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public PartOP(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public PartOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        /// <summary>
        /// 获取所有零件的集合
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_Part> GetPartList()
        {
            return DB.MFG_Part.ToList();
        }



        //[Shareable]
        //public List<V_MFG_Part> GetPartByProduceCategory(string category1, string category3, string ProduceCategory)
        //{
        //    var data = DB.V_MFG_Part.Where(p => p.Category1 == category1 && p.Category3 == category3
        //                                 && p.ProduceCategory == ProduceCategory).OrderBy(p => p.PartNo).ToList();

        //    return data;
        //}

        //[Shareable]
        //public List<V_MFG_Part> GetPartByProduceModel(string category1, string category3, string vehicleModel)
        //{
        //    var data = DB.V_MFG_Part.Where(p => p.Category1 == category1 && p.Category3 == category3
        //                                 && p.VehicleMode == vehicleModel).OrderBy(p => p.PartNo).ToList();

        //    return data;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="category1"></param>
        ///// <param name="category3"></param>
        ///// <param name="vehicleModel"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<V_MFG_Part> GetPartByProduceModelOrderByDesc(string category1, string category3, string vehicleModel)
        //{
        //    var data = DB.V_MFG_Part.Where(p => p.Category1 == category1 && p.Category3 == category3
        //                                 && p.VehicleMode == vehicleModel).OrderBy(p => p.PartNo).OrderByDescending(d => d.PartVersion).ToList();

        //    return data;
        //}


        ///// <summary>
        ///// 根据散件配置表获取零件
        ///// </summary>
        ///// <param name="category1">类别1</param>
        ///// <param name="category3">类别3</param>
        ///// <param name="ProduceCategory">生产类型</param>
        ///// <param name="custStdOrd">产品配置</param>
        ///// <returns></returns>
        //[Shareable]
        //public List<V_MFG_Part> GetPartByProduceCategory(string category1, string category3, string ProduceCategory, string custStdOrd)
        //{

        //    var data = (from a in DB.V_MFG_Part
        //                join b in DB.LGS_CustStdOrdDet on a.PartNo equals b.PartNo
        //                where a.Category1 == category1 && a.Category3 == category3 && a.ProduceCategory == ProduceCategory && b.StdOrdCfg == custStdOrd
        //                select a);

        //    return data.ToList();
        //}




        /// <summary>
        /// 根据零件号获取零件信息
        /// </summary>
        /// <param name="PartNo">零件号</param>
        /// <param name="FactoryCode">工厂代码</param>
        /// <returns></returns>
        [Shareable]
        public MFG_PartDetail GetPartDetail(string PartNo, string FactoryCode)
        {
            var data = DB.MFG_PartDetail.FirstOrDefault(p => p.PartNo == PartNo && p.FactoryCode == FactoryCode);

            return data;
        }
        /// <summary>
        /// 根据零件号获取零件信息
        /// </summary>
        /// <param name="FactoryCode">工厂代码</param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_PartDetail> GetPartDetail(string FactoryCode)
        {
            var data = DB.MFG_PartDetail.Where(p => p.FactoryCode == FactoryCode).ToList();

            return data;
        }

        /// <summary>
        /// 检查零件是否可转换成W2件
        /// </summary>
        /// <param name="factoryCode"></param>
        /// <param name="partNo"></param>
        [Shareable]
        public bool CanConvToW2(string factoryCode, string partNo)
        {
            try
            {
                MFG_PartDetail partDetail = GetData<MFG_PartDetail>(p => p.FactoryCode == factoryCode && p.BaseMaterial == partNo);
                //SELECT * FROM MFG_PartDetail WHERE BaseMaterial = '' AND FactoryCode = ''
                if (partDetail == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据零件号获取零件信息
        /// </summary>
        /// <param name="PartNo">零件号</param>
        /// <returns></returns>
        [Shareable]
        public MFG_Part GetPart(string PartNo)
        {
            var data = DB.MFG_Part.FirstOrDefault(p => p.PartNo == PartNo);

            return data;
        }

        /// <summary>
        /// 获取零件号详情
        /// </summary>
        /// <param name="PartNo">零件号</param>
        /// <returns></returns>
        [Shareable]
        public MFG_PartDetail GerPartDetail(string PartNo)
        {
            var data = DB.MFG_PartDetail.FirstOrDefault(p => p.PartNo == PartNo);

            return data;
        }


        /// <summary>
        /// 根据零件号获取零件信息
        /// </summary>
        /// <param name="PartNo">零件号</param>
        /// <param name="comPartNo">子零件</param>
        /// <returns></returns>
        [Shareable]
        public MFG_Part GetPartInfo(string PartNo, string comPartNo)
        {
            var data = DB.MFG_Part.FirstOrDefault(p => p.PartNo == PartNo && p.CompPartNo == comPartNo);

            return data;
        }




        /// <summary>
        /// 根据零件号获取零件信息
        /// </summary>
        /// <param name="PartNo">零件号</param>
        /// <returns></returns>
        [Shareable]
        public MFG_Part GetPartPartVersion(string PartNo)
        {
            var data = DB.MFG_Part.FirstOrDefault(p => p.PartNo == PartNo);
            return data;
        }

        /// <summary>
        /// 取零件的所有打散到底的BOM
        /// </summary>
        /// <param name="factoryCode"></param>
        /// <param name="partNo"></param>
        /// <param name="bomVer"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_BOM_Disassembled> GetBomDisassembliedList(string factoryCode, string partNo, string bomVer)
        {
            try
            {
                DateTime dtNow = DateTime.Now;
                List<MFG_BOM_Disassembled> bomDisAsmList = GetList<MFG_BOM_Disassembled>(p => p.FactoryCode == factoryCode && p.PartNo == partNo && p.BomVer == bomVer && p.EffStartTime <= dtNow && p.EffExpireTime > dtNow).ToList(); //默认取01版本的BOM，已确认过肯定会有一套01版本的BOM
                return bomDisAsmList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 检查零件号在BOM中是否存在
        /// 全部打散模式
        /// </summary>
        /// <param name="factoryCode"></param>
        /// <param name="parentPartNo"></param>
        /// <param name="bomVer"></param>
        /// <param name="compPartNo"></param>
        /// <returns></returns>
        [Shareable]
        public bool IsCompPartInBOM(string factoryCode, string parentPartNo, string bomVer, string compPartNo)
        {
            try
            {
                List<MFG_BOM_Disassembled> bomDisAsmList = GetBomDisassembliedList(factoryCode, parentPartNo, bomVer).ToList();
                if (bomDisAsmList == null || bomDisAsmList.Count() <= 0)
                {
                    throw new Exception(factoryCode + "," + parentPartNo + "," + bomVer + "找不到BOM，请确认所在工厂入BOM正确");
                }
                if (!bomDisAsmList.Exists(p => p.ComponentPartNo == compPartNo)) //在BOM里面查询有没有扫描条码的零件号，以检查BOM匹配性
                {
                    //throw new Exception("在BOM中找不到你所扫描的产品零件号.父零件：" + parentPartNo+ ",子零件" + compPartNo);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// 取特定版本号的一层BOM
        ///// </summary>
        ///// <param name="factoryCode"></param>
        ///// <param name="parentPartNo"></param>
        ///// <param name="bomVer"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<MFG_BomPartList> GetFirstLevelBom(string factoryCode, string parentPartNo, string bomVer)
        //{
        //    try
        //    {
        //        DateTime dtNow = DateTime.Now;
        //        List<MFG_BomPartList> lstBOM = DB.P_MFG_FristLevelBOM(factoryCode, parentPartNo, bomVer, dtNow).ToList(); //默认取01版本的BOM，已确认过肯定会有一套01版本的BOM
        //        return lstBOM;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //[Shareable]
        //public List<MFG_BomPartList> GetFirstLevelBom(string factoryCode, string parentPartNo, string bomVer, DateTime effDate)
        //{
        //    try
        //    {
        //        List<MFG_BomPartList> lstBOM = DB.P_MFG_FristLevelBOM(factoryCode, parentPartNo, bomVer, effDate).ToList(); //默认取01版本的BOM，已确认过肯定会有一套01版本的BOM
        //        return lstBOM;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 检查子零件号是否在父零件号的第一层BOM中
        ///// </summary>
        ///// <param name="factoryCode"></param>
        ///// <param name="parentPartNo"></param>
        ///// <param name="bomVer"></param>
        ///// <param name="childPartNo"></param>
        ///// <returns></returns>
        //[Shareable]
        //public bool IsCompPartInFirstLevelBOM(string factoryCode, string parentPartNo, string bomVer, string childPartNo)
        //{
        //    try
        //    {
        //        //取第一层BOM
        //        List<MFG_BomPartList> lstBOM = GetFirstLevelBom(factoryCode, parentPartNo, bomVer);
        //        if (lstBOM == null || lstBOM.Count <= 0)
        //        {
        //            throw new Exception("找不到指定版本的BOM，工厂：" + factoryCode + ",父零件：" + parentPartNo + ",版本号:" + bomVer);
        //        }
        //        //检查子零件是否在BOM中
        //        if (!lstBOM.Exists(p => p.PartNo == childPartNo))
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 检查子零件号是否在父零件号的第一层BOM中
        /// </summary>
        /// <param name="factoryCode"></param>
        /// <param name="parentPartNo"></param>
        /// <param name="bomVer"></param>
        /// <param name="childPartNo"></param>
        /// <returns></returns>
        //[Shareable]
        //public bool IsCompPartInFirstLevelBOM(string factoryCode, string parentPartNo, string bomVer, string childPartNo, DateTime effDate)
        //{
        //    try
        //    {
        //        //取第一层BOM
        //        List<MFG_BomPartList> lstBOM = GetFirstLevelBom(factoryCode, parentPartNo, bomVer, effDate);
        //        if (lstBOM == null || lstBOM.Count <= 0)
        //        {
        //            throw new Exception("找不到指定版本的BOM，工厂：" + factoryCode + ",父零件：" + parentPartNo + ",版本号:" + bomVer);
        //        }
        //        //检查子零件是否在BOM中
        //        if (!lstBOM.Exists(p => p.PartNo == childPartNo))
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 获取PartDetail中下拉列表的值
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<Models.SelectListItem> GetReportPartList()
        {
            var data = DB.MFG_PartDetail.Where(p => p.FactoryCode == this.FactoryCode).ToList();

            List<Models.SelectListItem> liPartItem = new List<Models.SelectListItem>();

            foreach (var item in data)
            {
                var slItem = new Models.SelectListItem()
                {
                    Value = item.PartNo,
                    Text = item.PartNo
                };

                liPartItem.Add(slItem);
            }

            return liPartItem;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="part"></param>
        [Shareable]
        public void AddPart(MFG_Part part)
        {
            Insert<MFG_Part>(part);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="part"></param>
        [Shareable]
        public void Update(MFG_Part part)
        {
            MFG_Part mpart = GetData<MFG_Part>(p => p.ID == part.ID);
            mpart.ModifyMachine = part.ModifyMachine;
            mpart.ModifyTime = DateTime.Now;
            mpart.ModifyUser = part.ModifyUser;
            mpart.MeterialDescrition = part.MeterialDescrition;
            mpart.ProjectName = part.ProjectName;
            mpart.PartLevel = part.PartLevel;
            mpart.VehicleMode = part.VehicleMode;
            Update<MFG_Part>(mpart);
        }
        /// <summary>
        /// 根据ID获取Part
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_Part GetPartByID(int id)
        {
            MFG_Part part = DB.MFG_Part.Where(p => p.ID == id).FirstOrDefault();
            return part;
        }
        ///// <summary>
        ///// 获取散件的PartFamily
        ///// </summary>
        ///// <returns></returns>
        //[Shareable]
        //public List<Models.SelectListItem> GetPartFamilyList(string category3)
        //{
        //    var data = from f in DB.LGS_CustStdOrdMstr.Where(p => p.PartFamily != "" && p.Category3 == category3 && p.IsActive == true).OrderBy(c => c.Seq)
        //               select new Models.SelectListItem
        //               {
        //                   Selected = false,
        //                   Value = f.PartFamily,
        //                   Text = f.PartFamily
        //               };
        //    return data.Distinct().ToList();
        //}


        /// <summary>
        /// 获取所有的产品层级
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProduceLevel> GetAllProduceLevel()
        {
            return DB.MFG_ProduceLevel.ToList();
        }

        ///// <summary>
        ///// 获取发运报表
        ///// </summary>
        ///// <param name="strWhere"></param>
        ///// <param name="intPage"></param>
        ///// <param name="PAGE_SIZE"></param>
        ///// <param name="intRowTotal"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<Models.ShipmentModel> GetShipmentList(string strWhere, int intPage, int PAGE_SIZE, out int intRowTotal)
        //{
        //    string sql = @"SELECT  MovementType ,
        //                            dbo.SYS_SAPTransaction.PartNo ,
        //                            StockAdress ,
        //                            MAX(PartDesc) AS PartDesc ,
        //                            SUM(Qty) AS Qty ,
        //                            CustomerCode
        //                    FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
        //                            LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
        //                                                            AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
        //                    WHERE   MovementType IN ( 'Z15', 'Z16', '631', '632' )
        //                            " + strWhere + @"
        //                    GROUP BY MovementType ,
        //                            dbo.SYS_SAPTransaction.PartNo ,
        //                            StockAdress ,
        //                            CustomerCode ";
        //    var list = DB.Database.SqlQuery<Models.ShipmentModel>(sql);

        //    intRowTotal = list.Count();
        //    if (intPage <= 1)
        //    {
        //        list = list.Take(PAGE_SIZE);
        //    }
        //    else
        //    {
        //        list = list.Skip((intPage - 1) * PAGE_SIZE).Take(PAGE_SIZE);
        //    }

        //    return list.ToList();
        //}

        ///// <summary>
        ///// 获取发运报表
        ///// </summary>
        ///// <param name="strWhere"></param>
        ///// <param name="intPage"></param>
        ///// <param name="PAGE_SIZE"></param>
        ///// <param name="intRowTotal"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<Models.ShipmentModel> GetShipmentSumList(string strWhere, int intPage, int PAGE_SIZE, out int intRowTotal)
        //{
        //    string sql = @"SELECT  A.CustomerCode ,
        //                            A.PartNo ,
        //                            A.PartDesc ,
        //                            ( ISNULL(B.[631Qty], 0) - ISNULL(C.[632Qty], 0) + ISNULL(D.[Z15Qty], 0)
        //                              - ISNULL(E.[Z16Qty], 0) ) AS Qty ,
        //                            ISNULL(B.[631Qty], 0) [631Qty] ,
        //                            ISNULL(C.[632Qty], 0) [632Qty] ,
        //                            ISNULL(D.[Z15Qty], 0) [Z15Qty] ,
        //                            ISNULL(E.[Z16Qty], 0) [Z16Qty]
        //                    FROM    ( SELECT    CustomerCode ,
        //                                        dbo.SYS_SAPTransaction.PartNo ,
        //                                        MAX(PartDesc) AS PartDesc
        //                              FROM      dbo.SYS_SAPTransaction WITH ( NOLOCK )
        //                                        LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
        //                                                                        AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
        //                              WHERE     MovementType IN ( 'Z15', 'Z16', '631', '632' )
        //                              " + strWhere + @"
        //                              GROUP BY  dbo.SYS_SAPTransaction.PartNo ,
        //                                        CustomerCode
        //                            ) AS A
        //                            LEFT JOIN ( SELECT  CustomerCode ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                MAX(PartDesc) AS PartDesc ,
        //                                                SUM(Qty) AS '631Qty'
        //                                        FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
        //                                                LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
        //                                                                                AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
        //                                        WHERE   MovementType = '631'
        //                                        " + strWhere + @"
        //                                        GROUP BY MovementType ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                CustomerCode
        //                                      ) AS B ON A.PartNo = B.PartNo
        //                                                AND B.CustomerCode = A.CustomerCode
        //                            LEFT JOIN ( SELECT  CustomerCode ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                MAX(PartDesc) AS PartDesc ,
        //                                                SUM(Qty) AS '632Qty'
        //                                        FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
        //                                                LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
        //                                                                                AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
        //                                        WHERE   MovementType = '632'
        //                                        " + strWhere + @"
        //                                        GROUP BY MovementType ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                CustomerCode
        //                                      ) AS C ON A.PartNo = C.PartNo
        //                                                AND C.CustomerCode = A.CustomerCode
        //                            LEFT JOIN ( SELECT  CustomerCode ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                MAX(PartDesc) AS PartDesc ,
        //                                                SUM(Qty) AS 'Z15Qty'
        //                                        FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
        //                                                LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
        //                                                                                AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
        //                                        WHERE   MovementType = 'Z15'
        //                                        " + strWhere + @"
        //                                        GROUP BY MovementType ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                CustomerCode
        //                                      ) AS D ON A.PartNo = D.PartNo
        //                                                AND D.CustomerCode = A.CustomerCode
        //                            LEFT JOIN ( SELECT  CustomerCode ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                MAX(PartDesc) AS PartDesc ,
        //                                                SUM(Qty) AS 'Z16Qty'
        //                                        FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
        //                                                LEFT JOIN dbo.MFG_PartDetail ON dbo.SYS_SAPTransaction.FactoryCode = dbo.MFG_PartDetail.FactoryCode
        //                                                                                AND dbo.SYS_SAPTransaction.PartNo = dbo.MFG_PartDetail.PartNo
        //                                        WHERE   MovementType = 'Z16'
        //                                        " + strWhere + @"
        //                                        GROUP BY MovementType ,
        //                                                dbo.SYS_SAPTransaction.PartNo ,
        //                                                CustomerCode
        //                                      ) AS E ON A.PartNo = E.PartNo
        //                                                AND E.CustomerCode = A.CustomerCode";
        //    var list = DB.Database.SqlQuery<Models.ShipmentModel>(sql);

        //    intRowTotal = list.Count();
        //    if (intPage <= 1)
        //    {
        //        list = list.Take(PAGE_SIZE);
        //    }
        //    else
        //    {
        //        list = list.Skip((intPage - 1) * PAGE_SIZE).Take(PAGE_SIZE);
        //    }

        //    return list.ToList();
        //}

        [Shareable]
        public MFG_BOM GetMFGBOM(string factoryCode, string partNo)
        {
            var effDate = DateTime.Now;
            try
            {
                MFG_BOM bom = GetData<MFG_BOM>(p => p.FactoryCode == factoryCode && p.ParentPartNo == partNo && p.EffStartTime <= effDate && p.EffExpireTime > effDate);
                return bom;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 根据两个子零件，去找其共同的父零件
        /// </summary>
        /// <param name="compPart1"></param>
        /// <param name="compPart2"></param>
        /// <returns></returns>
        [Shareable]
        public List<string> GetParentPartFrom2CompPart(string compPart1, string compPart2)
        {
            try
            {
                string sql = @"SELECT DISTINCT
                                        PartNo
                                FROM    dbo.MFG_Part
                                WHERE   PartNo IN (
                                        SELECT  ParentPartNo
                                        FROM    dbo.MFG_BOM
                                        WHERE   ComponentPartNo = '" + compPart1 + @"'
                                                AND ParentPartNo IN ( SELECT  ParentPartNo
                                                                FROM    dbo.MFG_BOM
                                                                WHERE   ComponentPartNo = '" + compPart2 + @"' ) )";
                var list = DB.Database.SqlQuery<string>(sql).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据produceCategory 和 category1 获取条件数据数量
        /// </summary>
        /// <param name="produceCategory"></param>
        /// <param name="category1"></param>
        /// <returns></returns>
        [Shareable]
        public List<string> GetPartNo(string produceCategory, string category1)
        {
            string sql = @"SELECT DISTINCT ProduceLevel FROM dbo.MFG_Part WHERE Category1='{0}' AND ProduceCategory='{1}'";
            sql = string.Format(sql, category1, produceCategory);
            List<string> list = DB.Database.SqlQuery<string>(sql).ToList();
            return list;
        }


        /// <summary>
        /// 根据ID获取配置信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_Part GetCfgByID(int ID)
        {
            return GetData<MFG_Part>(p => p.ID == ID);
        }



        /// <summary>
        /// 通过ID删除零件信息
        /// </summary>
        /// <param name="ID"></param>
        [Shareable]
        public void DeletePart(int ID)
        {
            try
            {
                var data = DB.MFG_Part.FirstOrDefault(p => p.ID == ID);
                if (data != null)
                {
                    DB.MFG_Part.Remove(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
