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
    
    [MapWith(typeof(I.MES.Models.SYS_RPTMenu))]
    public partial class SYS_RPTMenu
    {
        public int ID { get; set; }
        public string MenuID { get; set; }
        public string ProgCode { get; set; }
        public string RightID { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public string MenuName { get; set; }
        public string ParentID { get; set; }
        public Nullable<int> OrderNum { get; set; }
        public string IconUrl { get; set; }
        public Nullable<int> IconRow { get; set; }
        public Nullable<int> IconCol { get; set; }
        public string PrivID { get; set; }
    }
}
