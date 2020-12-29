using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using I.MES.GlobalCore;
using I.MES.Tools;

namespace I.MES.ServerCore
{
    /// <summary>
    /// 实例化器
    /// </summary>
    internal class Instantiation
    {
        private BaseInformation_I Info;
        private Dictionary<string, object> loginDic = new Dictionary<string, object>();
        
        

        public Instantiation(BaseInformation_I info)
        {
            this.Info = info;
            loginDic.Clear();
            loginDic.Add("UserAccount", info.ClientInfo == null ? "" : info.ClientInfo.LoginUser);
            loginDic.Add("CompanyCode", info.ClientInfo == null ? "" : info.ClientInfo.CompanyCode);
            loginDic.Add("FactoryCode", info.ClientInfo == null ? "" : info.ClientInfo.FactoryCode);
            loginDic.Add("MachineName", info.ClientInfo == null ? "" : info.ClientInfo.Machine);
        }

        public BaseInfomation_O Excute()
        {
            try
            {
                Type type = Type.GetType(Info.ClassName);
                //var obj = Persistence.Current[Info.ClassName];
                //if (obj == null)
                //{
                //    obj = Activator.CreateInstance(type);
                //    Persistence.Current[Info.ClassName] = obj;
                //}
                object[] parameters = new object[1];
                parameters[0] = Info.ClientInfo;
                object obj = Activator.CreateInstance(type, parameters);

                PropertyInfo[] objPros = type.GetProperties();
                foreach (PropertyInfo item in objPros)
                {
                    if (loginDic.ContainsKey(item.Name)) 
                    {
                        item.SetValue(obj, Convert.ChangeType(loginDic[item.Name], item.PropertyType), null);
                    }
                }

                object[] methodParams = new object[Info.Parameters.Count];
                Type[] types = new Type[Info.Parameters.Count];

                List<Parameters> lp = new List<Parameters>();
                Dictionary<string, int> pIndex = new Dictionary<string, int>();
                int i = 0;
                foreach (var p in Info.Parameters)
                {
                    types[i] = Type.GetType(p.TypeName);

                    if (p.IsRef || p.IsOut)
                    {
                        lp.Add(new Parameters()
                        {
                            Name = p.Name,
                            TypeName = p.TypeName
                        });

                        pIndex.Add(p.Name, i);

                    }
                    if (p.IsOut)
                    {

                    }
                    else if (p.IsRef)
                    {
                        methodParams[i] = new Resolver(types[i].GetElementType()).Resolve(Info.Parameters[i].Value);
                    }
                    else
                    {
                        methodParams[i] = new Resolver(types[i]).Resolve(Info.Parameters[i].Value);
                    }
                    i++;
                }

                MethodInfo method = type.GetMethod(Info.FunctionName, types);

                if (method == null)
                {
                    throw new MESException(1005, "未找到相应的方法！" + Info.FunctionName);
                }

                try
                
                {
                    object result = method.Invoke(obj, methodParams);

                    foreach (var rp in lp)
                    {
                        rp.Value = methodParams[pIndex[rp.Name]];
                    }

                    if (obj is I.MES.Library.BaseOP)
                    {
                        var item = obj as I.MES.Library.BaseOP;
                        
                        item.SaveChanges();
                        item.Dispose();
                    }

                    if (result != null)
                    {
                        //object rtn = result;
                        object rtn = GetClientReturn(result);


                        return new BaseInfomation_O { result = new Compiler().Compile(rtn), Parameters = lp, Error = null };
                    }
                    else
                    {
                        return new BaseInfomation_O { result = null, Parameters = lp, Error = null };
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw ex.InnerException;
                    }
                    else
                    {
                        throw ex;
                    }
                }

                throw new MESException(1005, "未找到相应的方法！");
            }
            catch (Exception ex)
            {
                Logger.CurrentLog.Error(string.Format("|类：{0}|方法：{1}|错误：{2}",
                    Info.ClassName, Info.FunctionName, ex.ToString()));
                try
                {
                    MESException mesex = (MESException)ex;
                    return new BaseInfomation_O { result = null, Error = mesex.ToString(),ErrorCode = mesex.ErrorCode };
                }
                catch (Exception exx)
                {
                    return new BaseInfomation_O { result = null, Error = ex.ToString() };
                }  
            }

        }

        private Type GetMapType(Type type)
        {
            var attr = type.GetCustomAttributes(typeof(MapWithAttribute), true);
            if (attr != null && attr.Length > 0)
            {
                return ((MapWithAttribute)attr[0]).MapType;
            }
            else
            {
                return type;
            }
        }

        private object GetClientReturn(object data)
        {
            if (data is Array)  //数组特殊处理
            {
                var da = (Array)data;

                int[] wd = new int[da.Rank];
                for (int i = 0; i < da.Rank; i++)
                {
                    wd[i] = da.GetLength(i);
                }

                var rtn = Array.CreateInstance(GetMapType(data.GetType().GetElementType()), wd);

                int[] indices = new int[wd.Length];
                bool loop = true;
                do
                {
                    var sd = da.GetValue(indices);
                    var cd = GetClientReturn(sd);
                    rtn.SetValue(cd, indices);

                    loop = false;
                    for (int i = 0; i < wd.Length; i++)
                    {
                        if (indices[i] < wd[i] - 1)
                        {
                            indices[i] += 1;
                            loop = true;
                            break;
                        }
                    }

                } while (loop);

                return rtn;
            }
            else if (data is IList)
            {
                var type = data.GetType();
                var fullName = type.AssemblyQualifiedName;
                var types = type.GenericTypeArguments;
                if (types != null)
                {
                    foreach (var t in types)
                    {
                        var ct = GetMapType(t);
                        if (ct.FullName != t.FullName)
                        {
                            fullName = fullName.Replace("[" + t.AssemblyQualifiedName + "]", "[" + ct.AssemblyQualifiedName + "]");
                        }
                    }
                }
                var clientData = (IList)Activator.CreateInstance(Type.GetType(fullName));
                var serverData = (IList)data;

                foreach (var s in serverData)
                {
                    clientData.Add(GetClientReturn(s));
                }
                return clientData;
            }
            else if (data is IDictionary)
            {
                var type = data.GetType();
                var fullName = type.AssemblyQualifiedName;
                var types = type.GenericTypeArguments;
                if (types != null)
                {
                    foreach (var t in types)
                    {
                        var ct = GetMapType(t);
                        if (ct.FullName != t.FullName)
                        {
                            fullName = fullName.Replace("[" + t.AssemblyQualifiedName + "]", "[" + ct.AssemblyQualifiedName + "]");
                        }
                    }
                }
                var clientData = (IDictionary)Activator.CreateInstance(Type.GetType(fullName));
                var serverData = (IDictionary)data;

                foreach (var s in serverData.Keys)
                {
                    clientData.Add(GetClientReturn(s), GetClientReturn(serverData[s]));
                }

                return clientData;

            }
            else if (data.GetType().IsGenericType)  //泛型特殊处理
            {
                var type = data.GetType();
                var types = data.GetType().GenericTypeArguments;

                bool hasMapType = false;

                foreach (var t in types)
                {
                    var ct = GetMapType(t);
                    if (ct.FullName != t.FullName)
                    {
                        hasMapType = true;
                        break;
                    }
                }

                if (!hasMapType)//没有MapWith类型直接返回
                {
                    return data;
                }
                else
                {
                    if (data is IGenericClient)
                    {
                        return ((IGenericClient)data).GenerateClient();
                    }
                    else
                    {
                        throw new Exception("自定义泛型中包含MapWith的类型，必须继承IGenericClient");
                    }
                }
            }
            else
            {
                var rtn = data;
                Type stype = data.GetType();
                Type cType = GetMapType(stype);
                if (stype.FullName != cType.FullName)
                {
                    var crtn = Activator.CreateInstance(cType);
                    crtn.CopyFrom(data);
                    rtn = crtn;
                }
                return rtn;
            }

        }

    }
}
