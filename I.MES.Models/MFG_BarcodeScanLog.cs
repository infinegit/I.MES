//------------------------------------------------------------------------------
// <auto-generated>
//    MES团队制作，不得以任何原因手动变更当前文档
// </auto-generated>
//------------------------------------------------------------------------------

namespace I.MES.Models
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public class MFG_BarcodeScanLog
    {
        public int ID { get; set; }
        public string FactoryCode { get; set; }
        public string ProdLineCode { get; set; }
        public string BarCode { get; set; }
        public string StationCode { get; set; }
        public string OrigPartNo { get; set; }
        public string OrigQualityStatus { get; set; }
        public string NewPartNo { get; set; }
        public string NewQualityStatus { get; set; }
        public string OpType { get; set; }
        public string OrderNo { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreateMachine { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string ModifyMachine { get; set; }
    
    
       public object __InheritFrom
       {
           set
           {
               this.CopyFrom(value);
           }
       }
    }

}
