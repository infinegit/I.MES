//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace I.MES.Library.EF
{
    using System;
    using System.Collections.Generic;
    
    [MapWith(typeof(I.MES.Models.MFG_BOM_Disassembled))]
    public partial class MFG_BOM_Disassembled
    {
        public int ID { get; set; }
        public string FactoryCode { get; set; }
        public string PartNo { get; set; }
        public string ParentPartNo { get; set; }
        public string ComponentPartNo { get; set; }
        public string BomVer { get; set; }
        public int ItemNo { get; set; }
        public decimal Qty { get; set; }
        public System.DateTime EffStartTime { get; set; }
        public System.DateTime EffExpireTime { get; set; }
        public string Type { get; set; }
        public string ComponentPMCode { get; set; }
        public System.DateTime DisassembleTime { get; set; }
        public int Level { get; set; }
    }
}
