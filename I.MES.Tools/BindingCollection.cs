using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

/*****************************************************************************
*-----------------------------------------------------------------------------
*文 件 名: List    绑定类
*计算机名：MAZEN-PC
*开发人员：(张茂忠)Mazen
*创建时间：2016/5/22 10:40:26
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
namespace I.MES.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class  BindingCollection<T> : BindingList<T>
    {
        private bool isSorted;
        private PropertyDescriptor sortProperty;
        private ListSortDirection sortDirection;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BindingCollection()
            : base()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">IList类型的列表对象</param>
        public BindingCollection(IList<T> list)
            : base(list)
        {
        }

        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;

            if (items != null)
            {
                ObjectPropertyCompare<T> pc = new ObjectPropertyCompare<T>(property, direction);
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }

            sortProperty = property;
            sortDirection = direction;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        //排序
        public void Sort(PropertyDescriptor property, ListSortDirection direction)
        {
            this.ApplySortCore(property, direction);
        }
    }
}
