using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class BatchFreeze
    {
        public int ID { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserAccount { get; set; }
        /// <summary>
        /// 创建电脑
        /// </summary>
        public string CreateMachine { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LatestModifyUserAccount { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public System.DateTime LatestModifyTime { get; set; }
        /// <summary>
        /// 最后修改电脑
        /// </summary>
        public string LatestModifyMachine { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public object __ObjectFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
