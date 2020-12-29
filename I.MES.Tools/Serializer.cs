using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

/*本文档用于信息系列化，非架构人员不允许修改本文档*/

namespace I.MES.Tools
{
    public class Serializer
    {
        public string XMLSerialize(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }

                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                MemoryStream ms = new MemoryStream();
                serializer.Serialize(ms, obj);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                //string x = sr.ReadToEnd();
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T XMLDeSerialize<T>(string xml) where T : new()
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader sr = new StringReader(xml);
                return (T)serializer.Deserialize(sr);
            }
            catch (Exception ex)
            {
                Type t = typeof(T);

                var attrs = t.GetCustomAttributes(typeof(MapWithAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    var item = XMLDeSerialize(xml, ((MapWithAttribute)attrs[0]).MapType);
                    T rtn = new T();
                    rtn.CopyFrom(item);
                    return rtn;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public object XMLDeSerialize(string xml, Type type)
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(type);
                StringReader sr = new StringReader(xml);
                return serializer.Deserialize(sr);
            }
            catch (Exception ex)
            {
                var attrs = type.GetCustomAttributes(typeof(MapWithAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    var item = XMLDeSerialize(xml, ((MapWithAttribute)attrs[0]).MapType);
                    var rtn = Activator.CreateInstance(type);
                    rtn.CopyFrom(item);
                    return rtn;
                }
                else
                {
                    throw ex;
                }
            }

        }

        public byte[] ByteSerialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, obj);
            ms.Position = 0;
            return ms.ToArray();
        }

        public T ByteDeSerialize<T>(byte[] bytes) where T : new()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            try
            {
                return (T)serializer.Deserialize(ms);
            }
            catch (Exception ex)
            {
                Type t = typeof(T);
                var attrs = t.GetCustomAttributes(typeof(MapWithAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    ms.Position = 0;
                    var item = serializer.Deserialize(ms);
                    T rtn = new T();
                    rtn.CopyFrom(item);
                    return rtn;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public object ByteDeSerialize(byte[] bytes, Type type)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            object obj = serializer.Deserialize(ms);

            if (type.IsClass && type.FullName != "System.String" && type.FullName != obj.GetType().FullName)
            {
                object rtn = Activator.CreateInstance(type);
                rtn.CopyFrom(obj);
                return rtn;
            }
            return obj;
        }

        public string JsonSerialize(object obj)
        {
            if (obj == null || obj.ToString().ToLower().Equals("null"))
            {
                return null;
            }

            if (obj != null && (obj.GetType() == typeof(String) || obj.GetType() == typeof(string) || obj.GetType() == typeof(DateTime)))
            {
                return obj.ToString();
            }
            //if (obj.GetType() == typeof(byte[]))
            //{
            //    return System.Text.Encoding.Default.GetString(obj as byte []);  
            //}
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public T JsonDeSerialize<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
        }

        public object JsonDeSerialize(string json, Type type)
        {
            if (string.IsNullOrEmpty(json))
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

            if (!(json.StartsWith("{") && json.EndsWith("}")) && !(json.StartsWith("[") && json.EndsWith("]")) && !type.FullName.Equals("System.Byte[]"))
            {
                return Convert.ChangeType(json, type);
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
        }

    }
}
