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
    public class V_SYS_TABLE_STRUCT
    {
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public string ColName { get; set; }
        public string TypeName { get; set; }
        public short Max_Length { get; set; }
        public bool IsPrimary { get; set; }
        public int IsIdentity { get; set; }
        public string defaultVaule { get; set; }
    
    
       public object __InheritFrom
       {
           set
           {
               this.CopyFrom(value);
           }
       }
    }

}
