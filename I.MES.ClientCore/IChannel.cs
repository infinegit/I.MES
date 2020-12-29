using System;
using I.MES.Tools;

namespace I.MES.ClientCore
{
    /// <summary>
    /// 通讯通道
    /// </summary>
    public interface IChannel : IDisposable
    {
        TransferType Transfer { get; }
        event CompleteEventHandler AsynCompleted;
        object Send(object data);
        void SendAsyn(object data);
        void Open();
        void Close();
    }

}
