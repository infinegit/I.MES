using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Transactions;
using I.MES.Library.EF;
using I.MES.Tools;
using System.Data;

/*****************************************************************************
*-----------------------------------------------------------------------------
*文 件 名: RK基础信息类
*计算机名：wang-PC
*开发人员：(王必栋)Mazen
*创建时间：2017/2/14 9:24:27
*描述说明：
*
*-----------------------------------------------------------------------------
* 版   本： V1.0          修改时间：           修改人： 
*更改历史：
*
*-----------------------------------------------------------------------------
*Copyright (C) 20013-2015 东尚信息科技有限公司
*-----------------------------------------------------------------------------
******************************************************************************/

namespace I.MES.Library
{
    /// <summary>
    /// 角色数据权限
    /// </summary>
    [Shareable]
    public class RoleSupItemGroupOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleSupItemGroupOP(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public RoleSupItemGroupOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        



    }
}
