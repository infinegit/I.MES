using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using I.MES.GlobalCore;
using I.MES.Library;
using I.MES.ServerCore;
using I.MES.Tools;
using I.MES.Models.IF;
using System.Reflection;

namespace I.MES.Channel.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“JsonService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 JsonService.svc 或 JsonService.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JsonService : IJsonService
    {
        public ActionMessage InvokeMethod(ActionMessage message)
        {
            throw new NotImplementedException();
        }

        //[OperationBehavior(TransactionScopeRequired = true)]
        public string Send(string json)
        {
            ServerPort port = new ServerPort();
            var rtn = port.Generate(json);
            return (string)rtn;
        }


    }
       
}
