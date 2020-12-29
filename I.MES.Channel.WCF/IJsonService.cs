using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using I.MES.Models.IF;

namespace I.MES.Channel.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IJsonService”。
    [ServiceContract]
    public interface IJsonService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        string Send(string json);


        #region 自动化业务

        //[OperationContract]
        //[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ////[TransactionFlow(TransactionFlowOption.Allowed)]
        //string BarcodeCache(ActionMessage message);

        //[OperationContract]
        //[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ////[TransactionFlow(TransactionFlowOption.Allowed)]
        //string AutomationPkgRK(ActionMessage message);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ActionMessage InvokeMethod(ActionMessage message);



        #endregion
    }
}
 