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
    public class IFS_GRC_UserRole : IFS_GRC_ReturnObject
    {
        public List<string> RoleId = new List<string>();
    }

}
