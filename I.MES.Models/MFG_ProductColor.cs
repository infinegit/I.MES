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
    public class MFG_ProductColor
    {
        public int ID { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorEName { get; set; }
        public string CreateUserAccount { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreateMachine { get; set; }
        public string LatestModifyUserAccount { get; set; }
        public System.DateTime LatestModifyTime { get; set; }
        public string LatestModifyMachine { get; set; }
        public int IsDel { get; set; }
    
    
       public object __InheritFrom
       {
           set
           {
               this.CopyFrom(value);
           }
       }
    }

}
