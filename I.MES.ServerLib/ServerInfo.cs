using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.MES.Library
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    [Shareable]
    public class ServerInfo : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientInfo"></param>
        public ServerInfo(ClientInformation clientInfo) : base(clientInfo)
        {
        }
        ///// <summary>
        ///// 构造函数
        ///// </summary>
        ///// <param name="clientInfo"></param>
        ///// <param name="DBSource"></param>
        //public ServerInfo(ClientInformation clientInfo, IMESEntities DBSource)
        //    : base(clientInfo, DBSource)
        //{
        //}

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns>当前时间</returns>
        [Shareable]
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取服务器当前时间--返回字符串类型
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public string GetServerTime()
        {
            return DateTime.Now.ToString();
        }

        /// <summary>
        /// 获取服务器名称
        /// </summary>
        /// <returns>服务器名称</returns>
        [Shareable]
        public string GetMachine()
        {
            return System.Net.Dns.GetHostName();
        }
    }
}
