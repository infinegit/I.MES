using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 4位零件号和时间模型
    /// </summary>
    public class MESPartNoAndTime
    {
        /// <summary>
        /// MES4位零件号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurrentTime { get; set; }
    }
}
