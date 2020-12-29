using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using I.MES.GlobalCore;
using I.MES.Library;
using I.MES.Models;
using I.MES.Models.IF;
using I.MES.ServerCore;
using I.MES.Tools;

namespace I.MES.Channel.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class BaseService : IServiceBase
    {
        public bool SaveUser(string UserAccount, string UserName, string UserWorkID, string Password, bool IsActive, string CurrentUser)
        {
            throw new NotImplementedException();
        }

        //[OperationBehavior(TransactionScopeRequired = true)]
        public string Send(string xml)
        {
            ServerPort port = new ServerPort();
            var rtn = port.Generate(xml);
            return (string)rtn;
        }
        //[OperationBehavior(TransactionScopeRequired = truse)]
        public byte[] SendBytes(byte[] data)
        {
            ServerPort port = new ServerPort();
            var rtn = port.Generate(data);
            return (byte[])rtn;
        }





   

     

   


    }

}