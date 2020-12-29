using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;


/*****************************************************************************
*-----------------------------------------------------------------------------
*文 件 名: 
*开发人员： （张茂忠）Mazen
*创建时间： 2016/01/26 16:40:34
*描述说明：
*
*-----------------------------------------------------------------------------
* 版   本：           修改时间：           修改人： 
*更改历史：
*
*-----------------------------------------------------------------------------
*Copyright (C) 20013-2015 东尚信息科技有限公司
*-----------------------------------------------------------------------------
******************************************************************************/
namespace I.MES.Library
{
    /// <summary>
    /// 系统参数配置类
    /// </summary>
    [Shareable]
    public class GlobalDicOP:BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GlobalDicOP(ClientInformation clientInfo):base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public GlobalDicOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }

        /// <summary>
        /// 根据类型代码获取类型类型集合
        /// </summary>
        /// <param name="CodeName"></param>
        /// <returns></returns>
        [Shareable]
        public List<SYS_GlobalDic> GetGlogalDicList(string CodeName)
        {
            return GetList<SYS_GlobalDic>(p => p.CodeName == CodeName).OrderBy(p => p.ID).ToList();
        }
        [Shareable]
        public List<I.MES.Models.SelectListItem> GetDicList(string CodeName)
        {
            var data = from dic in DB.SYS_GlobalDic.Where(p => p.CodeName == CodeName)
                select new I.MES.Models.SelectListItem
                {
                    Value=dic.CodeValue,
                    Text=dic.Desc
                };
            return data.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public bool UpdateGlobalDicCodeValueByCodeName(string CodeName, string CodeValue)
        {
            var config = DB.SYS_GlobalDic.Where(g => g.CodeName == CodeName).FirstOrDefault();
            if (config != null)
            {
                //if (IsEnabled)
                //    config.ParamValue = "1";
                //else
                //    config.ParamValue = "0";
                config.CodeValue = CodeValue;
                DB.Entry(config).State = System.Data.EntityState.Modified;
                Update(config);
                if (DB.SaveChanges() > 0)
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        /// <summary>
        ///根据权限和类型代码选择获取类型类型集合
        /// </summary>
        /// <param name="CodeName"></param>
        /// <returns></returns>
        [Shareable]
        public List<SYS_GlobalDic> GetPrivGlogalDicList(string codeName, string userAccount,string appType)
        {
            var data = from a in DB.SYS_Prog
                       from b in DB.SYS_ProgPriv
                       from c in DB.SYS_UserRole
                       from d in DB.SYS_User
                       from e in DB.SYS_RoleProgPriv
                       from f in DB.SYS_GlobalDic
                       where b.ProgCode == a.ProgCode && b.PrivCode == e.PrivCode && c.RoleCode == e.RoleCode && d.UserAccount == c.UserAccount
                       && d.UserAccount == userAccount && a.AppType == appType && f.CodeName == codeName && f.CodeValue == b.PrivName
                       select f;
            List<SYS_GlobalDic> globalDics = data.Distinct().OrderBy(p => p.ID).ToList();
            return globalDics;
        }
        /// <summary>
        /// 根据costCenter或取SYS_GlobalDic表数据
        /// </summary>
        /// <param name="costCenter"></param>
        /// <returns></returns>
        [Shareable]
        public List<SYS_GlobalDic> GetGlobalDic(string costCenter)
        {
            return GetList<SYS_GlobalDic>(p => p.CodeValue == costCenter).ToList();
        }
        /// <summary>
        /// 查询零件类型
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<SYS_GlobalDic> GetCode()
        {
            try
            {
                string sql = "SELECT * FROM dbo.SYS_GlobalDic WHERE CodeName = 'SeqAsmShipCategory'";
                List<SYS_GlobalDic> list = DB.Database.SqlQuery<SYS_GlobalDic>(sql).ToList();
                return list;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [Shareable]
        public SYS_GlobalDic GetGlobalDicData(string CodeName,string CodeValue)
        {
            try
            {
                return GetData<SYS_GlobalDic>(p => p.CodeName == CodeName && p.CodeValue == CodeValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
