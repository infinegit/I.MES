using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 接口名称：工作流获取当前用户在MES中的权限
    /// 接口编号：GRC_WFM2MES_001
    /// </summary>
    public class IFS_GRC_RequestUserFactoryRoles
    {
        public string userAccount = string.Empty;
        public string factoryCode = string.Empty;
        public string userName = string.Empty;
        /// <summary>
        /// 用户角色，用","分割的字串，MES处理时再进行拆分
        /// </summary>
        public string userRoles = string.Empty;
        //public List<String> userRoles = new List<String>();
    }
}
