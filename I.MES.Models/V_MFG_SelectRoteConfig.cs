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
    public class V_MFG_SelectRoteConfig
    {
        public string RouteID { get; set; }
        public string RouteCode { get; set; }
        public string VicheModel { get; set; }
        public string PartNo { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreateMachine { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string ModifyMachine { get; set; }
        public string RoteCode { get; set; }
        public string RoteName { get; set; }
        public string Description { get; set; }
    
    
       public object __InheritFrom
       {
           set
           {
               this.CopyFrom(value);
           }
       }
    }

}
