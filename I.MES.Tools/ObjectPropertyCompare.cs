using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

/*****************************************************************************
*-----------------------------------------------------------------------------
*文 件 名: 
*计算机名：MAZEN-PC
*开发人员：(张茂忠)Mazen
*创建时间：2016/5/22 10:34:52
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
    public class ObjectPropertyCompare<T> : System.Collections.Generic.IComparer<T>
    {
        private PropertyDescriptor property;
        private ListSortDirection direction;
        public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        {
            this.property = property;
            this.direction = direction;
        }
        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="x">相对属性</param>
        /// <param name="y">相对属性</param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            object xValue = property.GetValue(x);
            object yValue = property.GetValue(y); 

            int returnValue;

            if (xValue is IComparable)
            {
                returnValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (null == xValue && null != yValue)
            {
                returnValue = -1;
            }
            else if (null != xValue && null == yValue)
            {
                returnValue = 1;
            }
            else if (null == xValue && null == yValue)
            {
                returnValue = 0;
            }
            else if (xValue.Equals(yValue))
            {
                returnValue = 0;
            }
            else
            {
                returnValue = xValue.ToString().CompareTo(yValue.ToString());
            }

            if (direction == ListSortDirection.Ascending)
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }
        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
