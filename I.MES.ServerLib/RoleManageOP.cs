using System;
using System.Collections.Generic;
using System.Linq;
using I.MES.Library.EF;
using I.MES.Models;
using I.MES.Tools;

namespace I.MES.Library
{
    /// <summary>
    /// 角色对应菜单管理操作类
    /// </summary>
    [Shareable]
    public class RoleManageOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleManageOP(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public RoleManageOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }

        /// <summary>
        /// 获取所有菜单列表
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<SelectListItem> GetAllMenu()
        {
            try
            {
                var dataList = (from a in DB.SYS_ProgPriv
                                select new SelectListItem()
                                {
                                    Text = a.PrivDesc,
                                    Value = a.PrivCode
                                }).Distinct(p => p.Value).OrderBy(p => p.Text).ToList();
                return dataList;
            }
            catch (Exception ex)
            {       
                throw ex;
            }
        }

        /// <summary>
        /// 根据角色编号获取菜单列表
        /// </summary>
        /// <param name="RoleCode"></param>
        /// <returns></returns>
        [Shareable]
        public List<SelectListItem> GetMenuByRoleCode(string RoleCode)
        {
            try
            {
                var dataList = (from a in DB.SYS_ProgPriv
                                join b in DB.SYS_RoleProgPriv on a.PrivCode equals b.PrivCode
                                where b.RoleCode == RoleCode
                                select new SelectListItem()
                                {
                                    Text = a.PrivDesc,
                                    Value = a.PrivCode
                                }).Distinct(p => p.Value).OrderBy(p => p.Text).ToList();   
                return dataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通过角色编号获取角色信息
        /// </summary>
        /// <param name="RoleCode">角色编号</param>
        /// <returns></returns>
        [Shareable]
        public I.MES.Library.EF.SYS_Role GetRoleByRoleCode(string RoleCode)
        {
            try
            {
                return GetData<I.MES.Library.EF.SYS_Role>(p => p.RoleCode == RoleCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通过ProgCode获取SYS_ProgPriv信息
        /// </summary>
        /// <param name="PrivCode"></param>
        /// <returns></returns>
        [Shareable]
        public I.MES.Library.EF.SYS_ProgPriv GetProgPrivByProgCode(string PrivCode)
        {
            try
            {
                return GetData<I.MES.Library.EF.SYS_ProgPriv>(p => p.PrivCode == PrivCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <param name="role"></param>
        [Shareable]
        public void InsertRole(I.MES.Library.EF.SYS_Role role)
        {
            try
            {
                base.Insert(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="role"></param>
        [Shareable]
        public void UpdateRole(I.MES.Library.EF.SYS_Role role)
        {
            try
            {
                var data = GetData<I.MES.Library.EF.SYS_Role>(p => p.RoleCode == role.RoleCode);
                if (data == null)
                    throw new Exception("需要修改的角色【" + role.RoleCode + "】不存在");
                data.RoleCode = role.RoleCode;
                data.RoleName = role.RoleName;
                data.RoleDesc = role.RoleDesc;
                data.LatestModifyUser = this.UserAccount;
                data.LatestModifyTime = DateTime.Now;
                data.LatestModifyMachine = this.MachineName;

                base.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增角色对应菜单关系表
        /// </summary>
        /// <param name="RoleProgPriv"></param>
        [Shareable]
        public void InsertRoleProgPriv(I.MES.Library.EF.SYS_RoleProgPriv RoleProgPriv)
        {
            try
            {
                base.Insert(RoleProgPriv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改角色对应菜单关系表
        /// </summary>
        /// <param name="RoleProgPriv"></param>
        [Shareable]
        public void UpdateRoleProgPriv(I.MES.Library.EF.SYS_RoleProgPriv RoleProgPriv)
        {
            try
            {
                var data = GetData<I.MES.Library.EF.SYS_RoleProgPriv>(p => p.RoleCode == RoleProgPriv.RoleCode && p.PrivCode == RoleProgPriv.PrivCode);
                if (data == null)
                    throw new Exception("需要修改的角色【" + RoleProgPriv.RoleCode + "】对应菜单【" + RoleProgPriv.PrivCode + "】不存在");
                //data.RoleCode = RoleProgPriv.RoleCode;
                data.PrivCode = RoleProgPriv.PrivCode;
                data.LatestModifyUserAccount = this.UserAccount;
                data.LatestModifyTime = DateTime.Now;
                data.LatestModifyMachine = this.MachineName;

                base.Update(data);
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
        public I.MES.Library.EF.SYS_Role GetCfgByID(int ID)
        {
            return GetData<I.MES.Library.EF.SYS_Role>(p => p.ID == ID);
        }

        /// <summary>
        /// 删除配置信息
        /// </summary>
        /// <param name="ID"></param>
        [Shareable]
        public string DeleteCfg(int ID)
        {
            try
            {
                var data = GetData<I.MES.Library.EF.SYS_Role>(p => p.ID == ID);
                if (data == null)
                    return string.Format("需要删除的数据不存在！");
                var dataList = (from a in DB.SYS_RoleProgPriv
                                where a.RoleCode == data.RoleCode
                                select a).ToList();
                if (dataList.Count > 0)
                    return string.Format("删除失败！请先删除该角色下的所有菜单!");

                DB.SYS_Role.Remove(data);
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据角色删除菜单
        /// </summary>
        /// <param name="RoleCode"></param>
        [Shareable]
        public void DeleteRoleProgPrivByRoleCode(string RoleCode)
        {
            try
            {
                var dataList = GetList<I.MES.Library.EF.SYS_RoleProgPriv>(p => p.RoleCode == RoleCode).ToList();
                foreach (var item in dataList)
                {
                    DB.SYS_RoleProgPriv.Remove(item);
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

    }
}
