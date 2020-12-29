using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.OPC
{
    public class Tag
    {
        /// <summary>
        /// 标签代码
        /// </summary>
        public string TagCode { get; set; }
        /// <summary>
        /// 标签值类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 标签值
        /// </summary>
        public object Value { get; set; }
    }

}
