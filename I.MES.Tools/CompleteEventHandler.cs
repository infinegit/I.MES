using System;

namespace I.MES.Tools
{
    public delegate void CompleteEventHandler(object sender, CompleteEventArgs eventArgs);

    public class CompleteEventArgs : EventArgs
    {
        public BaseInfomation_O Out { get; set; }
    }
}
