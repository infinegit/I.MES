using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I.MES.Library.EF;

namespace I.MES.Library
{      
    /// <summary>
    /// 角色扫描点配置
    /// </summary>
    [Shareable]
    public class RoleScanSitePrivOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public RoleScanSitePrivOP(ClientInformation clientInfo)
            : base(clientInfo)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public RoleScanSitePrivOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }

       
      
        /// <summary>
        /// 获取所有的角色列表
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<SYS_Role> GetAllRoleList()
        {
            try
            {
                return GetList<SYS_Role>(p => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
