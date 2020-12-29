using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public delegate void DataArrivedEvent<Tvalue>(Tvalue[] data);

    /// <summary>
    /// 协议接口
    /// </summary>
    /// <typeparam name="Tvalue">传输的值的类型</typeparam>
    interface IProtocol<Tvalue>
    {
        /// <summary>
        /// 数据到达事件
        /// </summary>
        event DataArrivedEvent<Tvalue> DataArrived;

        /// <summary>
        /// 当前协议状态
        /// </summary>
        ProtocolStatus Status { get; set; }

        /// <summary>
        /// 打开端口或开启连接
        /// </summary>
        /// <returns></returns>
        bool Open();

        /// <summary>
        /// 关闭端口或关闭连接
        /// </summary>
        /// <returns></returns>
        bool Close();

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns>数据</returns>
        Tvalue[] Read();

        Tvalue[] Read(int address, int length);

        Tvalue ReadByte();

        Tvalue ReadByte(int address);

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">待发送数据</param>
        /// <returns>发送是否成功</returns>
        bool Send(Tvalue[] data);

        /// <summary>
        /// 获取或设置Response的超时时间(单位：毫秒)
        /// </summary>
        int ResposeTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// 获取数据(发送并得到答复）
        /// </summary>
        /// <param name="data">发送数据</param>
        /// <returns>答复数据</returns>
        Tvalue[] GetResponse(Tvalue[] data);

    }

    /// <summary>
    /// 协议状态
    /// </summary>
    public enum ProtocolStatus
    {
        /// <summary>
        /// 初始化
        /// </summary>
        Initial = 1,
        /// <summary>
        /// 打开的
        /// </summary>
        Opend = 2,
        /// <summary>
        /// 关闭的
        /// </summary>
        Closed = 8,
        /// <summary>
        /// 阻塞的
        /// </summary>
        Block = 16,
        /// <summary>
        /// 有异常的
        /// </summary>
        Error = 32,
        /// <summary>
        /// 致命错误（无法启动）
        /// </summary>
        Fatal = 64,
        /// <summary>
        /// 连接着
        /// </summary>
        Connected = 4
    }

}
