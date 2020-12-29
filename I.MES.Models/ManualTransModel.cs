using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    public class ManualTransModel
    {
        /// <summary>
        /// 发货工厂
        /// </summary>
        public string OrigFactory { get; set; }
        /// <summary>
        /// 发货库位
        /// </summary>
        public string OrigStk { get; set; }
        /// <summary>
        /// 收货工厂
        /// </summary>
        public string DestFactory { get; set; }
        /// <summary>
        /// 收货库位
        /// </summary>
        public string DestStk { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 记账日期
        /// </summary>
        public DateTime? PostingDate { get; set; }
        /// <summary>
        /// 特殊库存标记(发货)
        /// </summary>
        public string StkMngStatusCodeOrig { get; set; }
        /// <summary>
        /// 特殊库存标记(收货)
        /// </summary>
        public string StkMngStatusCodeDest { get; set; }
        /// <summary>
        /// 事务类型
        /// </summary>
        public int TransType { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
    }
}
