using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    /// <summary>
    /// 用于报表 模板
    /// </summary>
    [Serializable]
    public class WhereCondition
    {
        /// <summary>
        /// 列 名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 列 名称
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 列 名称( 例：(ColumnName Operator Value OR OrColumnName Operator Value))
        /// </summary>
        public string OrColumnName { get; set; }
        /// <summary>
        /// 列 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 导出指定列 名称
        /// </summary>
        public string ImportColumnName { get; set; }

        /// <summary>
        /// 排序列
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// 排序列方向
        /// </summary>
        public string SortDirection { get; set; }

    }
}
