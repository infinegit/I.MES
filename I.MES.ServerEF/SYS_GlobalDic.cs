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
    
    [MapWith(typeof(I.MES.Models.SYS_GlobalDic))]
    public partial class SYS_GlobalDic
    {
        public int ID { get; set; }
        public string CodeName { get; set; }
        public string CodeValue { get; set; }
        public string Desc { get; set; }
        public string CreateUserAccount { get; set; }
        public string CreateMachine { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string LatestModifyUserAccount { get; set; }
        public System.DateTime LatestModifyTime { get; set; }
        public string LatestModifyMachine { get; set; }
    }
}
