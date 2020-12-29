using System;

namespace I.MES.ClientCore
{
    /// <summary>
    /// 通道工厂
    /// </summary>
    public class ChannelFactory
    {
        /// <summary>
        /// 获取信息通道
        /// </summary>
        /// <returns>信息通道</returns>
        public static IChannel GetChannel()
        {
            IChannel item = null;
            try
            {

                //检查配置，如果配置存在，采用配置的通道
                 item = DependentManage.Current.GetImplement<IChannel>();

                if (item == null)
                {
                    return (IChannel)Activator.CreateInstance(typeof(Channels.WCFChannel));
                }

                return item;
            }
            catch (MESException ex)
            {
                throw new Exception("配置存在，但配置错误！["+ item.ToString2()+"]"+ ex.Message, ex);
            }
            catch (Exception ex)
            {
                return (IChannel)Activator.CreateInstance(typeof(Channels.WCFChannel));
            }
        }
    }
}
