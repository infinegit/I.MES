using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    /// <summary>
    /// 安全库存报警
    /// </summary>
    public class AsmMouldPullList
    {
        /// <summary>
        /// 任务号
        /// </summary>
        public string TaskID { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public int SerialNo { get; set; }
        /// <summary>
        /// 产品类型（FB：前保，RB：后保）
        /// </summary>
        public string Category3 { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 排序单号
        /// </summary>
        public string SeqOrderNo { get; set; }
        /// <summary>
        /// 排序单中的项目顺序号
        /// </summary>
        public int SeqOrderSn { get; set; }


    }
}
