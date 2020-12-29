using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/************************************************************************************
 * Copyright (c) 2016Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 *机器名称：HP-PC
 *公司名称：Microsoft
 *命名空间：I.MES.Models
 *文件名：  MenuTree
 *版本号：  V1.0.0.0
 *唯一标识：b33ddf38-b125-46b0-94ae-949bf6ddca93
 *当前的用户域：HP-PC
 *创建人：  罗锋（Hurry）
 *电子邮箱：XXXX@sina.cn
 *创建时间：2016/6/1 9:01:27
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/1 9:01:27
 *修改人： HP
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
namespace I.MES.Models
{
    /// <summary>
    /// 菜单树
    /// </summary>
    public class MenuTreeNode
    {
        public string id { get; set; }  //节点的id值
        public string text { get; set; }  //节点显示的名称
        public string state { get; set; }//节点的状态
        //注意：转成JsonTreeString时，将"Checked"替换成"checked",否则选中效果出不来的 
        public bool Checked { get; set; } 
        public List<MenuTreeNode> children { get; set; }  //集合属性，可以保存子节点
    }
}
