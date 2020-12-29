using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I.MES.Library.EF;


namespace I.MES.Library
{
    [Shareable]
    public class UserRoleOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public UserRoleOP(ClientInformation clientInfo)
            : base(clientInfo)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public UserRoleOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        [Shareable]
        public List<SYS_UserRole> GetUserRole(string UserAccount)
        {
            var data = DB.SYS_UserRole.Where(p => p.UserAccount == UserAccount).ToList();

            return data;

        }

        [Shareable]
        public List<I.MES.Models.SelectListItem> GetUserRoleToList(string UserAccount)
        {
            var data = from userRole in DB.SYS_UserRole
                       join role in DB.SYS_Role
                       on userRole.RoleCode equals role.RoleCode
                       where userRole.UserAccount == UserAccount
                       select new
                       {
                           UserAccount = userRole.UserAccount,
                           RoleName = role.RoleName,
                           RoleCode = role.RoleCode
                       };

            List<I.MES.Models.SelectListItem> sl = new List<I.MES.Models.SelectListItem>();

            foreach (var v in data)
            {
                sl.Add(new I.MES.Models.SelectListItem()
                {
                    Text = v.RoleName,
                    Value = v.RoleCode
                });
            }

            return sl;

        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>返回角色集合</returns>
        [Shareable]
        public List<SYS_Role> GetRoleList(string Account)
        {
            var data = from c in DB.SYS_Role
                       where !(from d in DB.SYS_UserRole where d.UserAccount == Account select d.RoleCode).Contains(c.RoleCode)
                       select c;

            return data.ToList();

        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>返回用户信息集合</returns>
        [Shareable]
        public List<SYS_User> GetUserList()
        {
            var data = DB.SYS_User.ToList();
            return data;
        }

        [Shareable]
        public int UpdateUserRole(string UserAccount, string RoleList)
        {
            var item = DB.SYS_UserRole.Where(p => p.UserAccount == UserAccount).ToList();

            if (item.Count > 0)
            {
                item.ForEach(p =>
                {
                    DB.SYS_UserRole.Remove(p);
                });
            }

            if (!string.IsNullOrEmpty(RoleList))
            {
                RoleList = RoleList.Remove(RoleList.LastIndexOf(';'));

                string[] strRole = RoleList.Split(';');

                foreach (var Role in strRole)
                {
                    SYS_UserRole sur = new SYS_UserRole();

                    sur.UserAccount = UserAccount;
                    sur.RoleCode = Role;
                    sur.EffitiveTime = DateTime.Now;
                    sur.ExpireTime = Convert.ToDateTime("2099-12-31 00:00:00.000");
                    sur.CreateTime = DateTime.Now;
                    sur.CreateUserAccount = " ";
                    sur.CreateMachine = " ";
                    sur.LatestModifyMachine = "";
                    sur.LatestModifyTime = DateTime.Now;
                    sur.LatestModifyUserAccount = "";

                    DB.SYS_UserRole.Add(sur);
                }
            }
            return DB.SaveChanges();
        }
        /// <summary>
        /// 当前用户在MES中的GRC角色代码
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public List<Models.KeyValueModel> GetGRCUserRoles(string userAccount)
        {
            try
            {
                using (DataEntities db = new DataEntities())
                {

                    string sql = @"SELECT  UserAccount as [Key] ,RoleID as Value
                                FROM    dbo.SYS_UserRole
                                        JOIN dbo.SYS_Role ON dbo.SYS_UserRole.RoleCode = dbo.SYS_Role.RoleCode
                                WHERE   UserAccount = '" + userAccount + @"'
                                /*
                                UNION 
                                SELECT  UserAccount AS [Key] ,
                                        RoleID as Value
                                FROM    REPORT.dbo.RPT_UserRole
                                        JOIN REPORT.dbo.RPT_Role ON REPORT.dbo.RPT_UserRole.RoleCode = REPORT.dbo.RPT_Role.RoleCode
                                WHERE   UserAccount = '" + userAccount + "'*/";

                    List<Models.KeyValueModel> result = new List<Models.KeyValueModel>();

                    result = db.Database.SqlQuery<Models.KeyValueModel>(sql).ToList();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除用户在MES中的权限
        /// </summary>
        /// <param name="userAccount"></param>
        public string DeleteGRCUserRoles(string userAccount)
        {
            try
            {
                var user = GetUserList().FindAll(p => p.UserAccount == userAccount).FirstOrDefault();
                if (user == null)
                {
                    return "1";
                }
                else
                {
                    string updateSql = string.Format("UPDATE dbo.SYS_User SET IsActive ='0' WHERE UserAccount ='{0}'", userAccount);
                    using (DataEntities db = new DataEntities())
                    {

                        string sql = @"DELETE  FROM    dbo.SYS_UserRole
                                        WHERE   UserAccount = '" + userAccount + @"';
                                   /*DELETE  FROM    REPORT.dbo.RPT_UserRole
                                        WHERE   UserAccount = '" + userAccount + "'*/";
                        var result = db.Database.ExecuteSqlCommand(sql);
                        db.Database.ExecuteSqlCommand(updateSql);
                        return "0";
                    }
                }
            }
            catch (Exception ex)
            {
                return "2";
            }
        }
        public string ResetUserPwd(string userAccount, string cipherText)
        {
            try
            {
                var user = GetData<SYS_User>(p => p.UserAccount == userAccount);
                if (user == null)
                {
                    throw new Exception("找不到用户：" + userAccount);
                }
                //检查密文是否匹配
                byte[] origCipherText = Encoding.Default.GetBytes(userAccount + DateTime.Now.ToString("d") + ClientInfo.LoginUser);
                var md5Service = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] resultCipherText = md5Service.ComputeHash(origCipherText);
                string internalCipherText = Encoding.Default.GetString(resultCipherText);
                if (internalCipherText != cipherText)
                {
                    throw new Exception("认证失败!");
                }
                string password = userAccount + Tools.StringTools.GenRandChar(4);
                user.Password = password;
                DB.SaveChanges();
                return user.Password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 设置用户在MES中的角色
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="userName"></param>
        /// <param name="userRoles"></param>
        public string SetGRCUserRoles(string factoryCode, string userAccount, string userName, List<string> userRoles)
        {
            try
            {
                string returnMsg = string.Empty;
                var user = GetUserList().FindAll(p => p.UserAccount == userAccount).FirstOrDefault();
                if (user == null)
                {
                    string password = userAccount + Tools.StringTools.GenRandChar(4);
                    user = new SYS_User
                    {
                        UserAccount = userAccount,
                        UserName = userName,
                        UserWorkID = userAccount,
                        Password = password,
                        IsActive = true,
                        LatestLoginTime = DateTime.Now,
                        LatestLoginMachine = ClientInfo.Machine,
                        LatestModifyUser = ClientInfo.LoginUser,
                        LatestModifyTime = DateTime.Now,
                        LatestModifyMachine = ClientInfo.Machine,
                        CreateUserAccount = ClientInfo.LoginUser,
                        CreateTime = DateTime.Now,
                        CreateMachine = ClientInfo.Machine
                    };
                    new UserOP(ClientInfo, DB).AddUser(user);
                    DB.SaveChanges();
                    returnMsg = "用户:" + userAccount + "创建成功，密码：" + password;
                    //throw new Exception("找不到用户:" + userAccount);
                }
                string userRolesString = string.Empty;
                foreach (string role in userRoles)
                {
                    userRolesString += "'" + role + "',";
                }
                userRolesString = userRolesString.Trim(',');
                using (DataEntities db = new DataEntities())
                {
                    //删除老权限
                    string sql = @"DELETE  FROM    dbo.SYS_UserRole
                                        WHERE   UserAccount = '" + userAccount + @"';
                                   /*DELETE  FROM    REPORT.dbo.RPT_UserRole
                                        WHERE   UserAccount = '" + userAccount + @"';*/
                                    ";
                    //设置MES权限
                    sql += @"INSERT  INTO dbo.SYS_UserRole
                                    ( UserAccount ,
                                        RoleCode ,
                                        EffitiveTime ,
                                        ExpireTime ,
                                        CreateUserAccount ,
                                        CreateMachine ,
                                        CreateTime ,
                                        LatestModifyUserAccount ,
                                        LatestModifyTime ,
                                        LatestModifyMachine
                                    )
                                    SELECT  '" + userAccount + @"' ,
                                            RoleCode ,
                                            GETDATE() ,
                                            '2099-12-31' ,
                                            '" + ClientInfo.LoginUser + @"' ,
                                            '" + ClientInfo.Machine + @"' ,
                                            GETDATE() ,
                                             '" + ClientInfo.LoginUser + @"' ,
                                            GETDATE() ,
                                            '" + ClientInfo.Machine + @"' 
                                    FROM    dbo.SYS_Role
                                    WHERE   RoleID IN ( " + userRolesString + @" );
                                    ";
                    //设置report权限
                    //                    sql += @"
                    //                            INSERT  INTO REPORT.dbo.RPT_UserRole
                    //                                    ( UserAccount ,
                    //                                      UserName ,
                    //                                      RoleCode ,
                    //                                      RoleName ,
                    //                                      CreateUser ,
                    //                                      CreateTime
                    //                                    )
                    //                                    SELECT  '" + userAccount + @"' ,
                    //                                            '" + userAccount + @"' ,
                    //                                            RoleCode ,
                    //                                            RoleName ,
                    //                                            '" + ClientInfo.LoginUser + @"' ,
                    //                                            GETDATE()
                    //                                    FROM    REPORT.dbo.RPT_Role
                    //                                    WHERE   RoleID IN ( " + userRolesString + " )";

                    sql += @"INSERT INTO dbo.SYS_UserFactoryPriv 
                                ( UserAccount ,
                                  FactoryCode ,
                                  Enabled ,
                                  IsDefault ,
                                  CreateUserAccount ,
                                  CreateMachine ,
                                  CreateTime ,
                                  LatestModifyUserAccount ,
                                  LatestModifyTime ,
                                  LatestModifyMachine
                                )
                        VALUES  ( N'" + userAccount + @"' , 
                                  N'" + factoryCode + @"' , 
                                  1 , -- Enabled - bit
                                  1 , -- IsDefault - bit
                                  '" + ClientInfo.LoginUser + @"' , 
                                  '" + ClientInfo.Machine + @"' , 
                                  GETDATE()  , 
                                  '" + ClientInfo.LoginUser + @"' ,
                                  GETDATE() , 
                                  '" + ClientInfo.Machine + @"'
                                );  ";

                    var result = db.Database.ExecuteSqlCommand(sql);
                }
                return returnMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
