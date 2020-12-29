using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Objects;
using I.MES.Library.EF;
using I.MES.Tools;


namespace I.MES.Library
{
    /// <summary>
    /// 用户操作类
    /// </summary>
    [Shareable]
    public class UserOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public UserOP(ClientInformation clientInfo) : base(clientInfo)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public UserOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="userPassword">用户密码</param>
        /// <returns>是否登录验证成功</returns>
        [Shareable]
        public bool Login(string userAccount, string userPassword)
        {
            //using (IMESEntities db = new IMESEntities())
            //{
            try
            {
                //SYS_User user = db.SYS_User.FirstOrDefault(p => p.UserAccount == userAccount && p.Password == userPassword);
                SYS_User user = GetData<SYS_User>(p => p.UserAccount == userAccount && p.Password == userPassword && p.IsActive == true);
                if (user == null)
                {
                    return false;
                }
                user.LatestLoginMachine = this.MachineName;
                user.LatestLoginTime = DateTime.Now;
                Update<SYS_User>(user);
                return true;
            }
            catch (Exception ex)
            {
                BasicProperty.Log.Error(ex);
                throw ex;
            }
            //}
        }
        /// <summary>
        /// 取用户对象
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns>用户对象</returns>
        [Shareable]
        public SYS_User GetUser(string userAccount)
        {
            try
            {
                //using (IMESEntities db = new IMESEntities())
                //{
                //SYS_User user = db.SYS_User.FirstOrDefault(p => p.UserAccount == userAccount);
                //return user;
                //}
               
                return GetData<SYS_User>(p => p.UserAccount == userAccount && p.IsActive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="origPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [Shareable]
        public bool ChangePwd(string userAccount, string origPwd, string newPwd)
        {
            try
            {
                SYS_User user = GetData<SYS_User>(p => p.UserAccount == userAccount);
                if (user == null)
                {
                    throw new Exception("找不到该用户");
                }
                if (user.Password != origPwd)
                {
                    throw new Exception("原密码不匹配");
                }
                user.Password = newPwd;
                user.LatestModifyMachine = this.MachineName;
                user.LatestModifyTime = DateTime.Now;
                user.LatestModifyUser = this.UserAccount;
                Update<SYS_User>(user);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取所有有效用户对象
        /// </summary>
        /// <returns>用户对象</returns>
        [Shareable]
        public List<SYS_User> GetAvailUsers()
        {
            try
            {
                //using (IMESEntities db = new IMESEntities())
                //{
                //SYS_User user = db.SYS_User.FirstOrDefault(p => p.UserAccount == userAccount);
                //return user;
                //}
                return GetList<SYS_User>(p => p.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取用户的可登录工厂
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns>工厂列表</returns>
        [Shareable]
        public List<SYS_Factory> GetUserAvailFactories(string userAccount)
        {
            try
            {
                ArrayList alFactories = new ArrayList();
                var data = from a in DB.SYS_User
                           from b in DB.SYS_UserFactoryPriv
                           from c in DB.SYS_Factory
                           where a.UserAccount == b.UserAccount
                           && b.Enabled && b.FactoryCode == c.FactoryCode && b.UserAccount == userAccount
                           select c;
                return data.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw new MESException(1023, ex);
            }
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>是否成功</returns>
        [Shareable]
        public bool AddUser(SYS_User user)
        {
            try
            {
                //using (IMESEntities db = new IMESEntities())
                //{
                DB.SYS_User.Add(user);
                return true;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取用户的可用程序
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="appType">应用类型</param>
        /// <returns>可用程序列表</returns>
        [Shareable]
        public List<SYS_Prog> GetUserProgs(string userAccount, string appType)
        {
            try
            {
                //using (IMESEntities db = new IMESEntities())
                //{
                var data = from a in DB.SYS_Prog
                           from b in DB.SYS_ProgPriv
                           from c in DB.SYS_UserRole
                           from d in DB.SYS_User
                           from e in DB.SYS_RoleProgPriv
                           where b.ProgCode == a.ProgCode && b.PrivCode == e.PrivCode && c.RoleCode == e.RoleCode && d.UserAccount == c.UserAccount
                           && d.UserAccount == userAccount && a.AppType == appType
                           select a;
                List<SYS_Prog> progs = data.Distinct().OrderBy(p => p.ID).ToList();
                return progs;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MES根据帐号获得用户
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        [Shareable]
        public SYS_User GetUserByUserAccount(string userAccount)
        {
            return DB.SYS_User.FirstOrDefault(p => p.UserAccount == userAccount);

        }
        /// <summary>
        /// MES获得所有的用户信息
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<SYS_User> GetAllUser()
        {
            return DB.SYS_User.ToList();
        }
        /// <summary>
        /// 根据工厂代码获取工厂
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        [Shareable]
        public SYS_Factory GetFactory(string factory)
        {
            return GetData<SYS_Factory>(f => f.FactoryCode == factory);
        }
       


        /// <summary>
        /// 获取用户所有权限
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="appType"></param>
        /// <returns></returns>
        [Shareable]
        public List<SYS_ProgPriv> GetUserPrivs(string userAccount)
        {
            try
            {

                var data = from b in DB.SYS_ProgPriv
                           from c in DB.SYS_UserRole
                           from d in DB.SYS_User
                           from e in DB.SYS_RoleProgPriv
                           where b.PrivCode == e.PrivCode && c.RoleCode == e.RoleCode && d.UserAccount == c.UserAccount
                           && d.UserAccount == userAccount
                           select b;
                List<SYS_ProgPriv> privs = data.Distinct().ToList();
                return privs;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获取用户Report菜单权限
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="appType"></param>
        /// <returns></returns>
        [Shareable]
        public List<SYS_RPTMenu> GetUserMenuPrivs(string userAccount)
        {
            try
            {
                var data = from b in DB.SYS_RPTMenu
                           from c in DB.SYS_UserRole
                           from d in DB.SYS_User
                           from e in DB.SYS_RoleProgPriv
                           from f in DB.SYS_ProgPriv
                           where e.PrivCode == f.PrivCode && b.ProgCode == f.ProgCode && c.RoleCode == e.RoleCode && d.UserAccount == c.UserAccount
                           && d.UserAccount == userAccount && f.PrivName == "报表"
                           select b;
                List<SYS_RPTMenu> privs = data.Distinct().ToList();
                return privs;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Shareable]
        public List<SYS_RPTMenu> GetAllMenu()
        {
            try
            {
                List<SYS_RPTMenu> privs = DB.SYS_RPTMenu.Distinct().ToList();
                return privs;
                //}
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
        public SYS_User GetCfgByID(int ID)
        {
            return GetData<SYS_User>(p => p.ID == ID);
        }

        /// <summary>
        /// 新增配置信息
        /// </summary>
        /// <param name="Cfg"></param>
        [Shareable]
        public void InsertCfg(SYS_User Cfg)
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
                Cfg.LatestModifyUser = this.UserAccount;
                base.Insert(Cfg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="Cfg"></param>
        [Shareable]
        public void UpdateCfg(SYS_User Cfg)
        {
            try
            {
                if (Cfg == null)
                    throw new Exception("请提供需要修改的配置信息！");

                SYS_User item = DB.SYS_User.FirstOrDefault(p => p.ID == Cfg.ID);
                if (item == null)
                    throw new Exception("需要修改的配置信息不存在，请检查！");

                item.UserAccount = Cfg.UserAccount;
                item.UserName = Cfg.UserName;
                item.UserWorkID = Cfg.UserWorkID;
                item.Password = Cfg.Password;
                item.IsActive = Cfg.IsActive;
                item.LatestModifyMachine = this.MachineName;
                item.LatestModifyTime = DateTime.Now;
                item.LatestModifyUser = this.UserAccount;

                Update<SYS_User>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除配置信息 优化删除功能（2018-04-02 never）
        /// </summary>
        /// <param name="ID"></param>
        [Shareable]
        public void DeleteCfg(int ID)
        {
            try
            {
                var data = DB.SYS_User.FirstOrDefault(p => p.ID == ID);
                if (data != null)
                {
                    List<SYS_UserFactoryPriv> userFactoryPrivList = DB.SYS_UserFactoryPriv.Where(uf => uf.UserAccount == data.UserAccount).ToList();
                    if (userFactoryPrivList.Count > 0)
                    {
                        foreach (var userFactoryPriv in userFactoryPrivList)
                        {
                            DB.SYS_UserFactoryPriv.Remove(userFactoryPriv);
                        }
                    }
                    List<SYS_UserRole> userRoleList = DB.SYS_UserRole.Where(ur => ur.UserAccount == data.UserAccount).ToList();
                    foreach (var userRole in userRoleList)
                    {
                        DB.SYS_UserRole.Remove(userRole);
                    }
                    DB.SYS_User.Remove(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
