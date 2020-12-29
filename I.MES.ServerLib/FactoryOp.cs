using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using I.MES.Library.EF;
using I.MES.Tools;
using System.Data;


namespace I.MES.Library
{
    /// <summary>
    /// 工厂操作类
    /// </summary>
    [Shareable]
    public class FactoryOp : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FactoryOp(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public FactoryOp(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {

        }
        /// <summary>
        /// 取工厂对象
        /// </summary>
        /// <param name="factoryCode">工厂代码</param>
        /// <returns>工厂对象</returns>
        [Shareable]
        public SYS_Factory GetFactory(string factoryCode)
        {
            try
            {
                //using (IMESEntities db = new IMESEntities())
                //{
                //    return db.SYS_Factory.First(p => p.FactoryCode == factoryCode);
                //}
                return GetData<SYS_Factory>(p => p.FactoryCode == factoryCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据工厂找公司
        /// </summary>
        /// <param name="CompanyCode">公司代码</param>
        /// <returns></returns>
        [Shareable]
        public SYS_Company getCompany(string CompanyCode)
        {
            try
            {
                return DB.SYS_Company.Where(p => p.CompanyCode == CompanyCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取工厂列表
        /// </summary>
        /// <returns>工厂列表</returns>
        [Shareable]
        public List<SYS_Factory> GetFactoryList()
        {
            try
            {
                //using (IMESEntities db = new IMESEntities())
                //{
                //    return db.SYS_Factory.First(p => p.FactoryCode == factoryCode);
                //}
                return GetList<SYS_Factory>(p => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取工厂列表
        /// </summary>
        /// <returns>工厂列表</returns>
        [Shareable]
        public List<Models.SelectListItem> GetRoleFactoryList()
        {
            try
            {
                var data = from FactoryPriv in DB.SYS_UserFactoryPriv
                           join Factory in DB.SYS_Factory on FactoryPriv.FactoryCode equals Factory.FactoryCode
                           where FactoryPriv.UserAccount == this.UserAccount
                           select new Models.SelectListItem
                           {
                               Text = Factory.FactoryName,
                               Value = Factory.FactoryCode
                           };

                return data.Distinct().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[Shareable]
        //public List<WMS_ProductBinConfig> GetProdctBinconfig()
        //{
        //    try
        //    {
        //        return GetList<WMS_ProductBinConfig>(p => true).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 获取零件版本
        /// </summary>
        /// <returns></returns>

       
        //[Shareable]
        //public List<MFG_ProduceCategory> GetproduceCategory()
        //{
        //    try
        //    {
        //        return GetList<MFG_ProduceCategory>(p => true).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



        ///// <summary>
        ///// 包装类型
        ///// </summary>
        ///// <returns></returns>
        //[Shareable]
        //public List<LGS_PackageType> Getpkytype()
        //{
        //    try
        //    {
        //        return GetList<LGS_PackageType>(p => true).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}



        ///// <summary>
        ///// 根据工厂代码，去该工厂所对应的所有生产地点
        ///// </summary>
        ///// <param name="factoryCode"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<LGS_ProducePlace> GetAvailProducePlaceByFactory(string factoryCode)
        //{
        //    try
        //    {
        //        var data = GetList<LGS_ProducePlace>(p => p.FactoryCode == factoryCode).ToList();
        //        var datalist = new ProducePlaceFobidOP(ClientInfo).RemoveProducePlaceFobid(data);
        //        return datalist;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 根据工厂代码，从枚举表SYS_GlobalMapConfig获取生产地点
        ///// </summary>
        ///// <param name="factoryCode"></param>
        ///// <param name="configName"></param>
        ///// <param name="cfgKey"></param>
        ///// <returns></returns>
        //[Shareable]
        //public List<LGS_ProducePlace> GetProducePlaceByGlobalMap(string factoryCode, string configName, string cfgKey)
        //{
        //    var data = from place in DB.LGS_ProducePlace
        //               join global in DB.SYS_GlobalMapConfig on place.ProdPlaceCode equals global.CfgValue
        //               where place.FactoryCode == factoryCode
        //               && global.ConfigName == configName
        //               && global.CfgKey == cfgKey
        //               select place;
        //    var datalist = new ProducePlaceFobidOP(ClientInfo).RemoveProducePlaceFobid(data.ToList());
        //    return datalist;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="config"></param>
        ///// <returns></returns>
        //[Shareable]
        //public bool Insert(WMS_ProductBinConfig config)
        //{
        //    DB.WMS_ProductBinConfig.Add(config);
        //    return (DB.SaveChanges() > 0 ? true : false);
        //}
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        //[Shareable]
        //public bool update(WMS_ProductBinConfig xiu)
        //{
        //    try
        //    {
        //        Update<WMS_ProductBinConfig>(xiu);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    //DB.WMS_ProductBinConfig.Attach(xiu);
        //    //DB.Entry<WMS_ProductBinConfig>(xiu).State = EntityState.Modified;
        //    //return (DB.SaveChanges() > 0 ? true : false);
        // }
        ///// <summary>
        ///// 查询
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //[Shareable]
        //public WMS_ProductBinConfig GetChaProductBin(int ID)
        //{
        //    return DB.WMS_ProductBinConfig.Where(p => p.ID == ID).FirstOrDefault();
        //}

        /// <summary>
        /// 获取零件号
        /// </summary>
        [Shareable]
        public string GetPartDetailByPartNo(string partNo)
        {
            try
            {
                if (DB.MFG_PartDetail.Count(p => p.PartNo == partNo) > 0)
                    return "";
                return "该【" + partNo + "】零件号不存在";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// 验证Bin位
        ///// </summary>
        ///// <returns></returns>
        //[Shareable]
        //public string GetBinByBinCode(string binCode)
        //{
        //    try
        //    {
        //        if (DB.WMS_Bin.Count(p => p.BinCode == binCode) > 0)
        //            return "";
        //        return "该【" + binCode + "】BIN位不存在";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 產品包裝
        /// </summary>
        /// <returns></returns>
        //[Shareable]
        //public List<SYS_GlobalDic> GetGlobalDic()
        //{
        //    try
        //    {
        //      return GetList<SYS_GlobalDic>(p => true).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 根据生产地点代码，取生产地点对象
        ///// </summary>
        ///// <param name="producePlaceCode"></param>
        ///// <returns></returns>
        //[Shareable]
        //public LGS_ProducePlace GetProducePlace(string producePlaceCode)
        //{
        //    try
        //    {
        //        LGS_ProducePlace prodPlace = GetData<LGS_ProducePlace>(p => p.ProdPlaceCode == producePlaceCode);
        //        if (prodPlace == null)
        //        {
        //            throw new Exception("找不到生产地点" + producePlaceCode);
        //        }
        //        return prodPlace;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


       

        /// <summary>
        /// 获取公司的工厂列表
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns>工厂列表</returns>
        [Shareable]
        public List<SYS_Factory> GetFactoryListByCompany(string companyCode)
        {
            try
            {
                return GetList<SYS_Factory>(p => p.CompanyCode == companyCode).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据ID获取配置信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Shareable]
        public SYS_UserFactoryPriv GetCfgByID(int ID)
        {
            return GetData<SYS_UserFactoryPriv>(p => p.ID == ID);
        }

        /// <summary>
        /// 根据用户账号获取用户信息
        /// </summary>
        /// <param name="UserAccount"></param>
        /// <returns></returns>
        [Shareable]
        public SYS_User GetUserByUserAccount(string UserAccount)
        {
            return GetData<SYS_User>(p => p.UserAccount == UserAccount);
        }

        /// <summary>
        /// 根据工厂代码获取工厂信息
        /// </summary>
        /// <param name="FactoryCode"></param>
        /// <returns></returns>
        [Shareable]
        public SYS_Factory GetFactoryByFactoryCode(string FactoryCode)
        {
            return GetData<SYS_Factory>(p => p.FactoryCode == FactoryCode);
        }

        /// <summary>
        /// 新增配置信息
        /// </summary>
        /// <param name="Cfg"></param>
        [Shareable]
        public void InsertCfg(SYS_UserFactoryPriv Cfg)
        {
            try
            {
                if (Cfg == null)
                    throw new Exception("请提供需要新增的配置信息！");

                Cfg.CreateMachine = this.MachineName;
                Cfg.CreateTime = DateTime.Now;
                Cfg.CreateUserAccount = this.UserAccount;
                Cfg.LatestModifyMachine = this.MachineName;
                Cfg.LatestModifyTime = DateTime.Now;
                Cfg.LatestModifyUserAccount = this.UserAccount;
                base.Insert(Cfg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改配置信息表
        /// </summary>
        /// <param name="Cfg"></param>
        [Shareable]
        public void UpdateCfg(SYS_UserFactoryPriv Cfg)
        {
            try
            {
                if (Cfg == null)
                    throw new Exception("请提供需要修改的配置信息！");

                SYS_UserFactoryPriv item = DB.SYS_UserFactoryPriv.FirstOrDefault(p => p.ID == Cfg.ID);
                if (item == null)
                    throw new Exception("需要修改的配置信息不存在，请检查！");

                item.UserAccount = Cfg.UserAccount;
                item.FactoryCode = Cfg.FactoryCode;
                item.Enabled = Cfg.Enabled;
                item.IsDefault = Cfg.IsDefault;

                item.LatestModifyMachine = this.MachineName;
                item.LatestModifyTime = DateTime.Now;
                item.LatestModifyUserAccount = this.UserAccount;

                Update<SYS_UserFactoryPriv>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除配置信息
        /// </summary>
        /// <param name="ID"></param>
        [Shareable]
        public void DeleteCfg(int ID)
        {
            try
            {
                var data = DB.SYS_UserFactoryPriv.FirstOrDefault(p => p.ID == ID);
                if (data != null)
                {
                    DB.SYS_UserFactoryPriv.Remove(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取用户所属工厂
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<Models.SelectListItem> GetFactoryListByUserRole(string userId)
        {
            try
            {
                var data = (from a in DB.SYS_UserFactoryPriv
                            join b in DB.SYS_Factory on a.FactoryCode equals b.FactoryCode
                            where a.Enabled == true && a.UserAccount == userId
                            select new Models.SelectListItem()
                            {
                                Text = b.FactoryName,
                                Value = b.FactoryCode
                            }).ToList();
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}