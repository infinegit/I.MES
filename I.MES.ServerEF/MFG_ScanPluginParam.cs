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
    
    [MapWith(typeof(I.MES.Models.MFG_ScanPluginParam))]
    public partial class MFG_ScanPluginParam
    {
        public long ID { get; set; }
        public string PluginID { get; set; }
        public string ParamName { get; set; }
        public string ParamDesc { get; set; }
        public Nullable<int> IsNecessary { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreateMachine { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string ModifyMachine { get; set; }
    }
}