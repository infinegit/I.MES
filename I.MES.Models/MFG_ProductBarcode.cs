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
    public class MFG_ProductBarcode
    {
        public long ID { get; set; }
        public string Barcode { get; set; }
        public string OrderNo { get; set; }
        public string CurrentPartNo { get; set; }
        public string QualityStatus { get; set; }
        public string ControlStatus { get; set; }
        public Nullable<System.DateTime> PrintTime { get; set; }
        public Nullable<int> BarcodeStatus { get; set; }
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
