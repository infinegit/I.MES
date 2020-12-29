/*****************************************************************************
*-----------------------------------------------------------------------------
*文 件 名: 
*计算机名：
*开发人员：张永全
*创建时间：2016/4/6 
*描述说明：枚举处理类
*
*-----------------------------------------------------------------------------
* 版   本： V1.0          修改时间：           修改人： 
*更改历史：
*
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace I.MES.Tools
{
    public static class EnumHelper
    {
        #region<<枚举方法>>

        /// <summary>
        /// 获取枚举名称
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="sender">枚举</param>
        /// <returns>名称</returns>
        public static string GetEnumName<T>(this T sender)
        {
            return Enum.GetName(typeof(T), sender);
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="sender">枚举</param>
        /// <returns>对应属性</returns>
        public static string ToDescription<T>(this T sender)
        {
            var type = typeof(T);
            var info = type.GetField(sender.ToString());
            var descriptionAttribute = info.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;

            return descriptionAttribute != null ? descriptionAttribute.Description : type.ToString();
        }


        /// <summary>
        /// 对应的字符转换为枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="valueName">名称</param>
        /// <returns>T</returns>
        public static T FromNameToEnum<T>(this string valueName)
        {
            var type = typeof(T);
            var info = type.GetField(valueName);
            if (info == null) return default(T);

            var value = (T)info.GetRawConstantValue();

            return value;
        }

        /// <summary>
        /// 根据描述定位枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="desp"></param>
        /// <returns></returns>
        public static T FromDespToEnum<T>(this string desp)
        {
            var t = typeof(T);
            var infos = t.GetFields();
            if (infos.All(x => (x.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute) == null)) return default(T);
            var info =
                infos.First(
                    x => (x.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute) != null);

            return (T)info.GetRawConstantValue();
        }

        /// <summary>
        /// 获取枚举列表字典
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <returns>枚举列表字典</returns>
        public static IList<EnumList> GetEnumList<T>()
        {
            var t = typeof(T);
            var infos = t.GetFields();
            if (!infos.Any()) return null;

            // 获取枚举属性赋值到列表并返回
            IList<EnumList> list = new List<EnumList>();
            for (var i = 1; i < infos.Count(); i++)
            {
                var el = new EnumList();
                var field = infos[i];
                el.Key = field.Name;
                try
                {
                    el.KeyValue = ((int)(Enum.Parse(t, field.Name))).ToString();
                    var descriptionAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
                    el.KeyDesc = descriptionAttribute != null ? descriptionAttribute.Description : t.ToString();
                }
                catch (Exception ex)
                {
                    el.KeyValue = "0";
                }
                list.Add(el);
            }
            return list;
        }


        /// <summary>
        /// 根据值获取结构的描述
        /// </summary>
        /// <param name="list"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string GetDesc(IList<EnumHelper.EnumList> list, string strValue)
        {
            var obj = list.Where(p => p.KeyValue == strValue).SingleOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.KeyDesc;
            }
        }


        #endregion
        #region <<结构方法>>

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="sender">枚举</param>
        /// <returns>对应属性</returns>
        public static string ToStructDescription<T>(string Value)
        {
            var t = typeof(T);
            var infos = t.GetFields();
            if (!infos.Any()) return null;
            // 获取枚举属性赋值到列表并返回
            IList<EnumList> list = new List<EnumList>();
            for (var i = 0; i < infos.Count(); i++)
            {
                var field = infos[i];
                try
                {
                    if (field.GetValue(t).ToString() == Value)
                    {
                        var descriptionAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
                        string strDesc = descriptionAttribute != null ? descriptionAttribute.Description : t.ToString();
                        return strDesc;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return "";
        }

        /// <summary>
        /// 获取结构列表字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<EnumList> GetStructList<T>()
        {
            var t = typeof(T);
            var infos = t.GetFields();


            if (!infos.Any()) return null;

            // 获取枚举属性赋值到列表并返回
            IList<EnumList> list = new List<EnumList>();
            for (var i = 0; i < infos.Count(); i++)
            {
                var el = new EnumList();
                var field = infos[i];
                el.Key = field.Name;
                try
                {
                    el.KeyValue = field.GetValue(t).ToString();
                    var descriptionAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
                    el.KeyDesc = descriptionAttribute != null ? descriptionAttribute.Description : t.ToString();
                }
                catch (Exception ex)
                {
                    el.KeyValue = "0";
                }
                list.Add(el);
            }
            return list;
        }

        #endregion
        #region <<实体>>
        /// <summary>
        /// 枚举列表类
        /// </summary>
        [Serializable]
        public class EnumList
        {
            private string key;
            private string keyValue;
            private string keyDesc;

            /// <summary>
            /// 枚举key
            /// </summary>
            public string Key
            {
                get { return key; }
                set { key = value; }
            }

            /// <summary>
            /// 枚举value
            /// </summary>
            public string KeyValue
            {
                get { return keyValue; }
                set { keyValue = value; }
            }

            /// <summary>
            /// 枚举对应enum值描述
            /// </summary>
            public string KeyDesc
            {
                get { return keyDesc; }
                set { keyDesc = value; }
            }
        }
        #endregion

    }
}
