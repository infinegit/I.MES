using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace I.MES.Tools
{
    /// <summary>
    /// 转换Json格式帮助类
    /// </summary>
    public static class JsonHelper
    {
        public static object ToJson(this string Json)
        {
            return JsonConvert.DeserializeObject(Json);
        }
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static DataTable JsonToDataTable(this string strJson)
        {
            #region
            DataTable tb = null;
            //获取数据  
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');
                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = "Table";
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.DataType = typeof(String);
                        dc.ColumnName = strCell[0].ToString().Replace("\"", "").Trim();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    object strText = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "").Replace("\"", "").Trim();
                    if (strText.ToString().Length >= 5)
                    {
                        if (strText.ToString().Substring(0, 5) == "Date(")//判断是否JSON日期格式
                        {
                            strText = JsonToDateTime(strText.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                    dr[r] = strText;
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
            #endregion
        }
        public static List<T> JonsToList<T>(this string Json)
        {
            return JsonConvert.DeserializeObject<List<T>>(Json);
        }
        public static T JsonToEntity<T>(this string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }

        public static object  JsonToEntity(this string Json, Type t)
        {
            if (string.IsNullOrEmpty(Json))
            {
                if (t.IsClass)
                {
                    return null;
                }
                else
                {
                    return 0;
                }
            }

            if (!(Json.StartsWith("{") && Json.EndsWith("}")) && !(Json.StartsWith("[") && Json.EndsWith("]")))
            {
                return Convert.ChangeType(Json, t);
            }
            if(t.Name == "String") //如果要转换的目标是个String的话，其实就不需要转换了，直接返回就可以了
            {
                return Json;
            }
            return JsonConvert.DeserializeObject(Json, t);
        }

        /// <summary>
        /// Json 的日期格式与.Net DateTime类型的转换
        /// </summary>
        /// <param name="jsonDate">Date(1242357713797+0800)</param>
        /// <returns></returns>
        public static DateTime JsonToDateTime(string jsonDate)
        {
            string value = jsonDate.Substring(5, jsonDate.Length - 6) + "+0800";
            DateTimeKind kind = DateTimeKind.Utc;
            int index = value.IndexOf('+', 1);
            if (index == -1)
                index = value.IndexOf('-', 1);
            if (index != -1)
            {
                kind = DateTimeKind.Local;
                value = value.Substring(0, index);
            }
            long javaScriptTicks = long.Parse(value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
            long InitialJavaScriptDateTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
            DateTime utcDateTime = new DateTime((javaScriptTicks * 10000) + InitialJavaScriptDateTicks, DateTimeKind.Utc);
            DateTime dateTime;
            switch (kind)
            {
                case DateTimeKind.Unspecified:
                    dateTime = DateTime.SpecifyKind(utcDateTime.ToLocalTime(), DateTimeKind.Unspecified);
                    break;
                case DateTimeKind.Local:
                    dateTime = utcDateTime.ToLocalTime();
                    break;
                default:
                    dateTime = utcDateTime;
                    break;
            }
            return dateTime;
        }

        /// <summary>
        /// 处理前缀，去掉代码相关附加信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string HandleInput(int code, string jsonData)
        {
            string jsonData1 = jsonData;
            if (!string.IsNullOrEmpty(jsonData))
            {
                jsonData = jsonData.Replace(code.ToString() + "In_", "");
            }
            if (jsonData.Contains("_"))
            {
                jsonData = jsonData1;
                string jsonDataReturn = jsonData1;
                jsonDataReturn = jsonDataReturn.Replace("{","").Replace("}","").Replace("\"", "");
                
                string[] data = jsonDataReturn.Split(',');
                foreach (var item in data)
                {
                    jsonData = jsonData.Replace(item.Substring(0,item.LastIndexOf('_')+1),"");
                }
            }
            return jsonData;
        
        }

        /// <summary>
        /// 处理后缀，去掉代码相关附加信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string HandleOutput(int code, string jsonData)
        {
            if (!string.IsNullOrEmpty(jsonData))
            {
                var dataTemp = jsonData.Replace("{", "").Replace("}", "").Replace("\"","");
                var dataList = dataTemp.Split(',');
                List<string> keyList = new List<string>();
                foreach (var item in dataList)
                {
                    keyList.Add(item.Split(':')[0]);
                }

                foreach (var item in keyList)
                {
                    jsonData = jsonData.Replace(item, code.ToString() + "Out_" + item);
                }
            }
            return jsonData;
        }
    }
}
