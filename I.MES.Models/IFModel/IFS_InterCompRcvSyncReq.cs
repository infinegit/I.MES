using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    public class IFS_InterCompRcvSyncReq
    {
        public List<Models.IF.IFS_InterCompRcvSyncPending> ReqList = new List<Models.IF.IFS_InterCompRcvSyncPending>();
    }

    /// <summary>
    /// 公司间交易收货方收货同步模型
    /// 该数据用于收货方收货时进行记录，并待同步程序同步给发货方进行事务处理
    /// </summary>
    public class IFS_InterCompRcvSyncPending
    {
        public int ID { get; set; }
        public string POFactoryCode { get; set; }
        public string SOFactoryCode { get; set; }
        public string PartNo { get; set; }
        public string Qty { get; set; }
        public string PONo { get; set; }
        public string CreateTime { get; set; }
        public string CreateMachine { get; set; }
        public string CreateUser { get; set; }
        public string IsSyncSAP { get; set; }
        public string TaskId { get; set; }
        public string RefGUID { get; set; }
        public string PostDate { get; set; }
        //public Nullable<System.DateTime> RecTime { get; set; }

        public object __InheritFrom
        {
            set
            {
                this.CopyFrom(value);
            }
        }
    }
}
