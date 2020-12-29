/************************************************************************************
 * Copyright (c) 2018 All Rights Reserved.
 * CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-7Q30G7T
 *公司名称：
 *命名空间：I.MES.Models.IFEquip
 *文件名：  ThingWorxReturnJson
 *版本号：  V1.0.0.0
 *唯一标识：41b9af14-444f-42cd-a36f-5dfe75a5ac55
 *当前的用户域：DESKTOP-7Q30G7T
 *创建人：  user
 *电子邮箱：XXXX@sina.cn
 *创建时间：2018/11/16 15:23:41
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2018/11/16 15:23:41
 *修改人： user
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IFEquip
{
    public class ThingWorxReturnJson
    {
        public List<rows> rows { get; set; }

    }
    public class rows
    {
        public string T { get; set; }
        public string P { get; set; }
        public string V { get; set; }

    }

}
