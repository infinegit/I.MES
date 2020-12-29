using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using I.MES.Models;
using I.MES.Models.IF;

namespace I.MES.Channel.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IServiceBase
    {
        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        string Send(string xml);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        byte[] SendBytes(byte[] data);


        #region 用户表接口
        [OperationContract]
        bool SaveUser(string UserAccount, string UserName, string UserWorkID,
            string Password, bool IsActive, string CurrentUser);

        #endregion

    



    }
}
