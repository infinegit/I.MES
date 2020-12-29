using System.Web;
/*本文档用于包含基本属性，非架构人员不允许修改本文档*/

public static class BasicProperty
{
    public static Logger Log
    {
        get
        {
            return Logger.CurrentLog;
        }
    }

    private static ClientInformation clientInfo;

    /// <summary>
    /// 由客户端生成，在服务器端由通道还原
    /// </summary>
    public static ClientInformation ClientInfo
    {
        get
        {
            //if (Persistence.Current["clientInfo"] == null)
            //{
            //    Persistence.Current["clientInfo"] = new ClientInformation()
            //     {
            //         CurrentSysUser = "未设置",
            //         IP = "未设置",
            //         LogID = "",
            //         Machine = "未设置",
            //         System = "未设置",
            //         TransferMethod = TransferType.Xml
            //     };
            //}
            //return (ClientInformation)(Persistence.Current["clientInfo"]);
            if (clientInfo == null)
            {
                clientInfo = new ClientInformation()
                {
                    CurrentSysUser = "未设置",
                    IP = "未设置",
                    LogID = "",
                    Machine = "未设置",
                    System = "未设置",
                    LoginUser = "未登录",
                    FactoryCode = "未选择",
                    CompanyCode = "未选择",
                    TransferMethod = TransferType.Json
                };
            }
            //return (ClientInformation)(Persistence.Current["clientInfo"]);
            return clientInfo;
        }
        set
        {
            //Persistence.Current["clientInfo"] = value;
            clientInfo = value;
        }
    }

    private static ServerInformation serverInfo = new ServerInformation();
    /// <summary>
    /// 服务器信息，实时更新
    /// </summary>
    public static ServerInformation ServerInfo
    {
        get
        {
            if (serverInfo == null)
            {
                lock (serverInfo)
                {
                    if (serverInfo == null)
                    {
                        serverInfo = new ServerInformation();
                    }
                }
            }
            return serverInfo;
        }
    }
}

