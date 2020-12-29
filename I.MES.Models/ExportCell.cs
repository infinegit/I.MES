using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{ 
    /// <summary>
    /// 用于报表主明细导出
    /// </summary>
    [Serializable]
    public class ExportCell
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Key { get; set; }
        public string Value { get; set; }
        public string Field { get; set; }
        public string Title { get; set; }
        public string SortColumn { get; set; }
        public string SortType { get; set; }
       
    }
}
