using System;

/*本文档用于包含客户端属性，非架构人员不允许修改本文档*/

[Serializable]
public class ClientInformation
{
    public string LogID { get; set; }
    public string Machine { get; set; }
    public string CurrentSysUser { get; set; }
    public string System { get; set; }
    public string IP { get; set; }
    public TransferType TransferMethod { get; set; }
    private string clientTraceInfo = string.Empty;
    public string LoginUser { get; set; }
    public string CompanyCode { get; set; }
    public string FactoryCode { get; set; }
    public string ClientTraceInfo
    {
        get
        {
            return clientTraceInfo;
        }
        set
        {
            this.clientTraceInfo = value;
        }
    }
}

[Serializable]
public class ServerInformation
{
    public string Machine { get; set; }
    private DateTime currentTime;

    public DateTime CurrentTime
    {
        get { return currentTime; }
        set { currentTime = DateTime.Now; }
    }
    //public DateTime CurrentTime;
    public int Delay { get; set; }
    public object NearestIn { get; set; }
    public object NearestOut { get; set; }
}

[Serializable]
public enum TransferType
{
    Xml = 1,
    Json = 2,
    Bytes = 4
}

