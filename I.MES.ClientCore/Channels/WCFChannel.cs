using System;
using I.MES.Tools;

namespace I.MES.ClientCore.Channels
{
    public class WCFChannel : IChannel
    {
        public WCFChannel()
        {

        }

        public WCFChannel(string url)
        {
            this.client.Endpoint.Address = new System.ServiceModel.EndpointAddress(url);
        }

        public event CompleteEventHandler AsynCompleted;
        ChannelWCF.ServiceBaseClient client = new ChannelWCF.ServiceBaseClient();
        public object Send(object data)
        {
            if (Transfer != TransferType.Bytes)
            {
                string rtn = client.Send(data.ToString());
                return rtn;
            }
            else
            {
                byte[] rtn = client.SendBytes(data as byte[]);
                return rtn;
            }
        }

        public void SendAsyn(object data)
        {
            //    //client.SendCompleted += client_SendCompleted;
            //    //client.SendAsync((string)data);
        }

        //private void client_SendCompleted(object sender, ChannelWCF.SendCompletedEventArgs e)
        //{
        //    Serializer s = new Serializer();
        //    object result = e.Result;
        //    AsynCompleted(this, new CompleteEventArgs() { Out = new BaseInfomation_O() { result = result, Error = e.Error.ToString() } });
        //}

        public void Open()
        {
            client.Open();
        }

        public void Close()
        {
            client.Close();
        }

        public void Dispose()
        {
            this.Close();
            GC.Collect();
        }

        public TransferType Transfer
        {
            get
            {
                return BasicProperty.ClientInfo.TransferMethod;
            }
        }
    }
}
