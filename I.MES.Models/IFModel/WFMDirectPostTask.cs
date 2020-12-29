using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// WFM直接过账的接口模型
    /// </summary>
    [DataContract]
    public class WFMDirectPostTask
    {
        /// <summary>
        ///任务ID号
        /// </summary>
        [DataMember(IsRequired =true)]
        public string TaskID { get;set ;}
        /// <summary>
        /// 零件号
        /// </summary>
        [DataMember(IsRequired =true)]
        public string PartNo { get; set; }
        /// <summary>
        /// 出库工厂代码
        /// </summary>
        [DataMember(IsRequired =true)]
        public string DeliveryFactory { get; set; }
        /// <summary>
        /// 出库库位
        /// </summary>
        [DataMember(IsRequired =true)]
        public string DeliveryStk { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        [DataMember(IsRequired =true)]
        public decimal Qty { get; set; }
        /// <summary>
        /// 生效时间
        /// </summary>
        [DataMember(IsRequired =true)]
        public DateTime EffDate { get; set; }
        /// <summary>
        /// 出库类型
        /// </summary>
        [DataMember(IsRequired =true)]
        public string StdOutType { get; set; }
        /// <summary>
        /// 是否反冲?
        /// </summary>
        [DataMember(IsRequired =true)]
        public bool IsReverse { get; set; }
        /// <summary>
        /// 会计科目
        /// </summary>
        [DataMember(IsRequired =true)]
        public string FinAccount { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        [DataMember(IsRequired =true)]
        public string CostCenter { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [DataMember(IsRequired =true)]
        public string ProjectNo { get; set; }
        /// <summary>
        /// Work Flow Order No
        /// </summary>
        [DataMember(IsRequired =true)]
        public string WFMOrderNo { get; set; }
        /// <summary>
        /// 是否退回?
        /// 批工作流中该流程是否被拒绝退回
        /// </summary>
        [DataMember(IsRequired =true)]
        public bool IsReject { get; set; }

    }
}
