using System;
using I.MES.Tools;

namespace I.MES.GlobalCore
{
    /// <summary>
    /// 解析器
    /// </summary>
    /// <typeparam name="T">解析后的类型</typeparam>
    public class Resolver<T> where T : new()
    {
        private Serializer serial;

        public Resolver()
        {
            serial = new Serializer();
        }

        public T Resolve(object data)
        {
            try
            {
                if (data is byte[])
                {
                    return ResolveBytes(data as byte[]);
                }
                else
                {
                    string s = data.ToString();

                    if (s.StartsWith("<"))
                    {
                        return ResolveXML(s);
                    }
                    else
                    {
                        return ResolveJson(s);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new MESException(1112, ex);
            }
        }

        public T ResolveBytes(byte[] data)
        {
            return serial.ByteDeSerialize<T>(data);
        }

        public T ResolveXML(string data)
        {
            return serial.XMLDeSerialize<T>(data);
        }

        public T ResolveJson(string data)
        {
            return serial.JsonDeSerialize<T>(data);
        }
    }

    /// <summary>
    /// 解析器
    /// </summary>
    public class Resolver
    {
        private Type type;
        private Serializer serial;

        public Resolver(Type type)
        {
            this.type = type;
            serial = new Serializer();
        }

        public object Resolve(object data)
        {
            try
            {
                if (data == null)
                {
                    return null;
                }
                if (data is byte[])
                {
                    return ResolveBytes(data as byte[], this.type);
                }
                else
                {
                    string s = data.ToString();

                    if (s.StartsWith("<"))
                    {
                        return ResolveXML(s);
                    }
                    else if ((s.StartsWith("[") || s.StartsWith("{") || this.type.FullName.Equals("System.Byte[]")) && !this.type.FullName.Equals("System.String"))
                    {
                        return ResolveJson(s);
                    }
                    else
                    {
                        //return Convert.ChangeType(data, this.type);
                        if (!this.type.IsGenericType)
                        {
                            return Convert.ChangeType(data, this.type);
                            //if (this.type.FullName.Equals("System.Byte[]"))
                            //{
                            //    byte[] byteArray = System.Text.Encoding.Default.GetBytes(data.ToString());
                            //    return byteArray;
                            //}
                            //else
                            //{
                            //    return Convert.ChangeType(data, this.type);
                            //}
                        }
                        else
                        {
                            Type genericTypeDefinition = this.type.GetGenericTypeDefinition();
                            if (genericTypeDefinition == typeof(Nullable<>))
                            {
                                return Convert.ChangeType(data, Nullable.GetUnderlyingType(this.type));
                            }
                            else
                            {
                                throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", data.GetType().FullName, this.type.FullName));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new MESException(1112, ex);
            }
        }

        public object ResolveBytes(byte[] data, Type type)
        {
            return serial.ByteDeSerialize(data, type);
        }

        public object ResolveXML(string data)
        {
            return serial.XMLDeSerialize(data, type);
        }

        public object ResolveJson(string data)
        {
            return serial.JsonDeSerialize(data, type);
        }
    }
}
