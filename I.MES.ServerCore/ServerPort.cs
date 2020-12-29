using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.GlobalCore;
using I.MES.Tools;

namespace I.MES.ServerCore
{
    public class ServerPort
    {
        public object Generate(object data)
        {
            BaseInformation_I info = new Resolver<BaseInformation_I>().Resolve(data);
            PersistenceStore.Current.PersistenceCode = info.PersistenceCode ?? info.ClientInfo.LogID;
            BasicProperty.ClientInfo = info.ClientInfo;
            //BasicProperty.Log.Info(data);
            Instantiation intantiation = new Instantiation(info);
            DateTime startTime = DateTime.Now;
            var rtn = intantiation.Excute();
            object rtnObj = new Compiler().Compile(rtn);
            if (!info.ClassName.Contains("ServerInfo"))
            {
                try
                {
                    TimeSpan span = DateTime.Now - startTime;
                    BasicProperty.Log.Info(info.ClassName + "|" + info.FunctionName + "|" + span.TotalSeconds + "|" + info.ClientInfo.Machine + "|" + info.ClientInfo.IP);
                    if (span.TotalSeconds > 5)
                    {
                        try
                        {
                            BasicProperty.Log.Info("大于5秒的查询:" + data);
                        }
                        catch { }
                    }
                }
                catch { }
            }
            return rtnObj;
        }
    }
}
