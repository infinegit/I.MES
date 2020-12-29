using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using I.MES.Models.IFModel;

namespace I.MES.Models.IF
{
    /// <summary>
    /// ActionMessage
    /// 根据以下层级结构来进行组织
    /// #FactoryCode工厂代码
    /// #ProdPlace生产区域
    /// #ProdLine 生产线
    /// #EquipNo 生产设备
    /// #Code 指令码
    /// #Data 数据
    /// </summary>
    public class ActionMessage
    {
        /// <summary>
        /// 消息编号 --以后使用Id作为任务号。
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 任务号 
        /// </summary>
        [Obsolete]
        public string TaskId { get; set; }
        /// <summary>
        /// 事件点标识
        /// </summary>
        public int Code { get; set; } 
        /// <summary>
        /// 电文数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [Obsolete]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 电文号 
        /// </summary>
        [Obsolete]
        public int TelId { get; set; }
        /// <summary>
        /// 消息发送端
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 返回状态
        /// </summary>
        public short Status { get; set; }
        /// <summary>
        /// 设备传过来的时间戳
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// 设备传过来重发标致
        /// </summary>
        [Obsolete]
        public int RT { get; set; }
        /// <summary>
        /// 发送方的URL地址，如果是KEP的话，就是Kepserver的服务端地址
        /// </summary>
        public string SenderUrl { get; set; }
        /// <summary>
        /// 工厂代码
        /// </summary>
        public string FactoryCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrMsg { get; set; }
        


    }
}