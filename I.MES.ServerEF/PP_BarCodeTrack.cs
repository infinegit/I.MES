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
    
    [MapWith(typeof(I.MES.Models.PP_BarCodeTrack))]
    public partial class PP_BarCodeTrack
    {
        public long ID { get; set; }
        public string SerialNum { get; set; }
        public string PartNo { get; set; }
        public string StationCode { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemValue { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreateMachine { get; set; }
    }
}
