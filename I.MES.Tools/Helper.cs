using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Reflection;
using System.Text;
using System.Data.Objects;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Diagnostics;
/*本文档用于公用扩展，一般程序员，请申请审核后再增加*/

public static class Helper
{
    /// <summary>
    /// 输出各属性的值
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToString2(this object obj)
    {
        if (obj == null)
        {
            return "";
        }
        if (obj is string || obj is char[])
        {
            return obj.ToString();
        }
        if (obj.ToString() != obj.GetType().ToString())
        {
            return obj.ToString();
        }

        try
        {
            StringBuilder rtn;
            if (obj is IEnumerable)
            {
                IEnumerable IEnum = (IEnumerable)obj;
                rtn = new StringBuilder();
                rtn.Append(obj.GetType().Name + "(");
                foreach (var v in IEnum)
                {
                    rtn.Append("{" + v.ToString2() + "}");
                }
                rtn.Append(")");
                return rtn.ToString();
            }

            rtn = new StringBuilder(obj.GetType().Name + "(");
            var pros = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var pro in pros)
            {
                rtn.Append("[" + pro.Name + "=" + pro.GetValue(obj, null) + "]");
            }
            rtn.Append(")");
            return rtn.ToString();
        }
        catch
        {
            return obj.ToString();
        }
    }

    /// <summary>
    /// 输入异常的值
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static string ToString2(this Exception ex)
    {
        string rtn = ex.ToString();
        if (ex.InnerException != null)
        {
            rtn += "\nInnerException" + ex.InnerException.ToString2();
        }

        return rtn;
    }

    /// <summary>
    /// 获取实体中某字段的值
    /// </summary>
    /// <param name="obj">实体</param>
    /// <param name="propertyName">字段</param>
    /// <returns>值</returns>
    public static object GetPropertyValue(this object obj, string propertyName)
    {
        var p = obj.GetType().GetProperty(propertyName);
        return p.GetValue(obj, null);
    }

    /// <summary>
    /// 把可为null的时间类型转换为字符串
    /// </summary>
    /// <param name="date">DateTime?</param>
    /// <param name="formate">输入格式（默认为yyyy-MM-dd）</param>
    /// <returns>转换后的字符串</returns>
    public static string ToFormateString(this DateTime? date, string formate = "yyyy-MM-dd")
    {
        if (date == null)
        {
            return "";
        }
        else
        {
            return date.Value.ToString(formate);
        }
    }

    /// <summary>
    /// 判断字符串是否为NULL,如果为NULL返回""，防止报错
    /// </summary>
    /// <param name="source">本源字符串</param>
    /// <returns>转换后的字符串</returns>
    public static string Null(this string source)
    {
        return source ?? "";
    }

    /// <summary>
    /// 从另一个实体中复制各相同属性的值
    /// (注：必须类型相同，属性名相同）
    /// </summary>
    /// <param name="Entity">本实体</param>
    /// <param name="Source">来源实体</param>
    public static void CopyFrom(this object Entity, object Source)
    {
        var pros = Entity.GetType().GetProperties();
        foreach (var p in pros)
        {
            try
            {
                string field = p.Name;
                if (Source.GetType().GetProperty(field) != null)
                    if (Source.GetType().GetProperty(field).PropertyType == Entity.GetType().GetProperty(field).PropertyType)
                    {
                        object value = Source.GetType().GetProperty(field).GetValue(Source, null);
                        //if (value != null)
                        //{
                        Entity.GetType().GetProperty(field).SetValue(Entity, value, null);
                        //}
                    }
            }
            catch
            { }
        }
    }

    /// <summary>
    /// 从另一个实体中复制各相同属性的(不为null)值
    /// (注：必须类型相同，属性名相同）
    /// </summary>
    /// <param name="Entity">本实体</param>
    /// <param name="Source">来源实体</param>
    public static void CopyNoNull(this object Entity, object Source)
    {
        var pros = Entity.GetType().GetProperties();
        foreach (var p in pros)
        {
            try
            {
                string field = p.Name;
                if (Source.GetType().GetProperty(field) != null)
                    if (Source.GetType().GetProperty(field).PropertyType == Entity.GetType().GetProperty(field).PropertyType)
                    {
                        object value = Source.GetType().GetProperty(field).GetValue(Source, null);
                        if (value != null)
                        {
                            Entity.GetType().GetProperty(field).SetValue(Entity, value, null);
                        }
                    }
            }
            catch
            {
            }
        }
    }
    /// <summary>
    /// 从另一个实体中复制各相同属性的值,如果值为NULL，则复制为类型的默认值
    /// (注：必须类型相同，属性名相同）
    /// </summary>
    /// <param name="Entity"></param>
    /// <param name="Source"></param>
    public static void CopyFromDefaultIfNull(this object Entity, object Source)
    {
        var pros = Entity.GetType().GetProperties();
        foreach (var p in pros)
        {
            try
            {
                string field = p.Name;
                var sourceP = Source.GetType().GetProperty(field);
                if (sourceP == null)
                {
                    continue;
                }
                if (p.PropertyType != sourceP.PropertyType)
                {
                    continue;
                }
                var value = Source.GetType().GetProperty(field).GetValue(Source, null);
                if (value == null)
                {
                    if (sourceP.PropertyType.Name == typeof(bool).Name)
                    {
                        value = false;
                    }
                    else if (sourceP.PropertyType.Name == typeof(int).Name || sourceP.PropertyType.Name == typeof(short).Name ||
                     sourceP.PropertyType.Name == typeof(long).Name || sourceP.PropertyType.Name == typeof(float).Name ||
                     sourceP.PropertyType.Name == typeof(double).Name || sourceP.PropertyType.Name == typeof(decimal).Name)
                    {
                        value = 0;
                    }
                    else if (sourceP.PropertyType.Name == typeof(DateTime).Name)
                    {
                        value = DateTime.Now;
                    }
                    else if (sourceP.PropertyType.Name == typeof(string).Name)
                    {
                        value = "";
                    }
                }
                p.SetValue(Entity, value, null);
            }
            catch
            {

            }
        }
    }

    /// <summary>
    /// 查看SQL语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static string ToSQLString<T>(this IQueryable<T> t)
    {
        string sql = "";
        ObjectQuery<T> oqt = t as ObjectQuery<T>;
        if (oqt != null)
            sql = oqt.ToTraceString();
        return sql;
    }
    /// <summary>
    /// ArryList转换成string[]
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string[] ToStringArray(this ArrayList obj)
    {
        string[] array = new string[obj.Count];
        for (int i = 0; i < obj.Count; i++)
        {
            array[i] = obj[i].ToString();
        }
        return array;
    }
    /// <summary>
    /// 将List<T>转换成Dataset
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="list">list实体</param>
    /// <returns>Dataset</returns>
    public static DataSet ToDataSet<T>(this IList<T> list)
    {
        Type elementType = typeof(T);
        var ds = new DataSet();
        var t = new DataTable();
        ds.Tables.Add(t);
        elementType.GetProperties().ToList().ForEach(propInfo => t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType));
        foreach (T item in list)
        {
            var row = t.NewRow();
            elementType.GetProperties().ToList().ForEach(propInfo =>
            {
                try
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }
                catch { }
            });
            t.Rows.Add(row);
        }
        return ds;
    }

    /// <summary>
    /// 从DataTable中获取Model
    /// 谢彬    2013-10-10    创建
    /// </summary>
    /// <typeparam name="T">Model类型</typeparam>
    /// <param name="dataTable">DataTable</param>
    /// <param name="ext">对Model字段进行扩展的字符串</param>
    /// <returns></returns>
    public static List<T> GetModel<T>(this DataTable dataTable, string ext = "") where T : new()
    {
        if (dataTable == null)
        {
            return null;
        }

        List<T> rtn = new List<T>();

        if (dataTable.Rows.Count == 0)
        {
            return rtn;
        }

        var pros = typeof(T).GetProperties();
        foreach (DataRow dr in dataTable.Rows)
        {
            T t = new T();
            foreach (var p in pros)
            {
                try
                {
                    string field = p.Name;
                    object v = dr[field + ext];
                    if (v != null)
                    {
                        try
                        {
                            var value = Convert.ChangeType(v, p.PropertyType);
                            p.SetValue(t, value, null);
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {
                }
            }
            rtn.Add(t);
        }

        return rtn;
    }

    /// <summary>
    /// 转换为文件大小的字符串格式
    /// </summary>
    /// <param name="length">文件大小</param>
    /// <returns></returns>
    public static string ToFileSizeString(this int length)
    {
        string[] units = new string[] { "B", "KB", "MB", "GB", "TB" };
        int i = 0;
        float size = length;
        while (size >= 1024)
        {
            size = size / 1024;
            i++;
        }
        return size.ToString("0.##") + units[i];
    }

    public static T ToEntities<T>(this string jsonStr)
    {
        if (string.IsNullOrEmpty(jsonStr))
        {
            return default(T);
        }
        else
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }

    public static object ToEntities(this string jsonStr, Type type)
    {
        if (string.IsNullOrEmpty(jsonStr))
        {
            if (type.IsClass)
            {
                return null;
            }
            else
            {
                return 0;
            }
        }

        if (!jsonStr.StartsWith("{"))
        {
            return Convert.ChangeType(jsonStr, type);
        }

        return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonStr, type);
    }

    public static string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
    /// <summary>
    /// 将对象转换为Json字符串
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static string Encode(this object o)
    {
        if (o == null || o.ToString() == "null") return null;

        if (o != null && (o.GetType() == typeof(String) || o.GetType() == typeof(string)))
        {
            return o.ToString();
        }
        IsoDateTimeConverter dt = new IsoDateTimeConverter();
        dt.DateTimeFormat = DateTimeFormat;

        return JsonConvert.SerializeObject(o, dt);
    }

    public static string getMethodTrace()
    {
        string traceInfo = string.Empty;
        try
        {
            StackTrace trace = new StackTrace();
            //int framecount = 10;
            int framecount = trace.FrameCount > 6 ? 6 : trace.FrameCount;
            for (int i = 1; i < framecount; i++)
            {
                StackFrame frame = trace.GetFrame(i);
                MethodBase method = frame.GetMethod();
                traceInfo += method.ReflectedType.Name + "/" + method.Name + ";";
            }
        }
        catch (Exception ex)
        {
        }
        if (traceInfo.Length > 250) //如果超出250个字符，截取前250字符
        {
            traceInfo = traceInfo.Substring(0, 250);
        }
        return traceInfo;
    }

    public static void SetCommandTimeOut(this ObjectContext oc, int seconds)
    {
        oc.CommandTimeout = seconds;
        //return oc;
    }

    /// <summary>
    /// 任意类型转换
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="convertibleValue"></param>
    /// <returns></returns>
    public static T ConvertTo<T>(this IConvertible convertibleValue)
    {
        if (null == convertibleValue)
        {
            return default(T);
        }

        if (!typeof(T).IsGenericType)
        {
            return (T)Convert.ChangeType(convertibleValue, typeof(T));
        }
        else
        {
            Type genericTypeDefinition = typeof(T).GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(Nullable<>))
            {
                return (T)Convert.ChangeType(convertibleValue, Nullable.GetUnderlyingType(typeof(T)));
            }
        }
        throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", convertibleValue.GetType().FullName, typeof(T).FullName));
    }

}

