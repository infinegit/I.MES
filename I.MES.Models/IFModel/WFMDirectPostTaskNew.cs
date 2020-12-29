using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// WFM直接过账的接口模型
    /// </summary>
    public class WFMDirectPostTaskNew
    {
        /// <summary>
        ///任务ID号
        /// </summary>
        public string TaskID { get;set ;}
        /// <summary>
        /// 零件号
        /// </summary>
        public string PartNo { get; set; }
        /// <summary>
        /// 出库工厂代码
        /// </summary>
        public string DeliveryFactory { get; set; }
        /// <summary>
        /// 出库库位
        /// </summary>
        public string DeliveryStk { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        public string Qty { get; set; }
        /// <summary>
        /// 生效时间
        /// </summary>
        public string EffDate { get; set; }
        /// <summary>
        /// 出库类型
        /// </summary>
        public string StdOutType { get; set; }
        /// <summary>
        /// 是否反冲?
        /// </summary>
        public string IsReverse { get; set; }
        /// <summary>
        /// 会计科目
        /// </summary>
        public string FinAccount { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectNo { get; set; }
        /// <summary>
        /// Work Flow Order No
        /// </summary>
        public string WFMOrderNo { get; set; }

    }
}
