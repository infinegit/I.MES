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
    public class sysdiagrams
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public Nullable<int> version { get; set; }
        public byte[] definition { get; set; }
    
    
       public object __InheritFrom
       {
           set
           {
               this.CopyFrom(value);
           }
       }
    }

}
