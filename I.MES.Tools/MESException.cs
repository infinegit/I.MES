using System;


/*本文档用于MES异常信息，非架构人员不允许修改本文档*/
public class MESException : Exception
{
    public string LogID
    {
        get
        {
            return BasicProperty.ClientInfo.LogID;
        }
    }
    public int ErrorCode { get; set; }

    public MESException()
        : base()
    {
        ErrorCode = 0;
    }

    public MESException(int errorCode)
        : base()
    {
        this.ErrorCode = errorCode;
    }
    public MESException(int errorCode, string message)
        : base(message)
    {
        this.ErrorCode = errorCode;
    }
    public MESException(int errorCode, Exception innerException)
        : base(innerException.Message, innerException)
    {
        this.ErrorCode = errorCode;
    }

    public MESException(int errorCode, string message, Exception innerException)
        : base(message, innerException)
    {
        this.ErrorCode = errorCode;
    }

}

