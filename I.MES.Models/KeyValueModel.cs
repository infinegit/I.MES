using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    /// <summary>
    /// 键值对模型
    /// 注：这是一个通用模型，尽量使用具体的模型，慎用本模型
    /// </summary>
    public class KeyValueModel : IEqualityComparer<KeyValueModel>
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Select { get; set; }
        public DateTime DateTimeKey { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public decimal DecimalValue { get; set; }

        public bool Equals(KeyValueModel x, KeyValueModel y)
        {
            if (x.Value == y.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(KeyValueModel obj)
        {
            return 0;
        }
    }
}
