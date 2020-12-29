using System;
using log4net;

/*本文档用于LOG记录，非架构人员不允许修改本文档*/

public class Logger
{
    private readonly string logID;

    private static Logger currentLog;
    public static Logger CurrentLog
    {
        get
        {
            if (currentLog == null)
            {
                currentLog = new Logger();
            }
            return currentLog;
        }
    }

    private Logger()
    {
        if (BasicProperty.ClientInfo == null || string.IsNullOrEmpty(BasicProperty.ClientInfo.LogID))
        {
            logID = GenericLogID();
        }
        else
        {
            logID = BasicProperty.ClientInfo.LogID;
        }
        logger = LogManager.GetLogger("");
    }

    private string GenericLogID()
    {
        return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
    }

    public Logger(string logID)
    {
        this.logID = logID;
        logger = LogManager.GetLogger("");
    }

    private ILog logger;

    /// <summary>
    /// 日志记录者
    /// </summary>
    public ILog LogManage
    {
        get
        {
            return logger;
        }
    }

    /// <summary>
    /// 信息日志
    /// </summary>
    /// <param name="message">信息</param>
    public void Info(object message)
    {
        LogManage.Info("[" + LogID + "]" + message);
    }

    /// <summary>
    /// 调试日志
    /// </summary>
    /// <param name="message">调试信息</param>
    public void Debug(object message)
    {
        LogManage.Debug("[" + LogID + "]" + message);
    }

    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="message">错误信息</param>
    public void Error(object message)
    {
        LogManage.Error("[" + LogID + "]" + message);
    }

    /// <summary>
    /// 致命日志
    /// </summary>
    /// <param name="message">致命信息</param>
    public void Fatal(object message)
    {
        LogManage.Fatal("[" + LogID + "]" + message);

    }

    /// <summary>
    /// 警告日志
    /// </summary>
    /// <param name="message">警告信息</param>
    public void Warn(object message)
    {
        LogManage.Warn("[" + LogID + "]" + message);
    }

    public string LogID
    {
        get
        {
            return logID;
        }
    }
}
