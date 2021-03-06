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
    
    [MapWith(typeof(I.MES.Models.MFG_ProduceCategory))]
    public partial class MFG_ProduceCategory
    {
        public int ID { get; set; }
        public string ProduceCtgyCode { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public string CategoryBriefCode { get; set; }
        public string InitPartNo { get; set; }
        public string InitPartVersion { get; set; }
        public string InitControlStatus { get; set; }
        public string InitQualityStatus { get; set; }
        public int BarcodePrintLot { get; set; }
        public string CreateUserAccount { get; set; }
        public string CreateMachine { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string LatestModifyUserAccount { get; set; }
        public System.DateTime LatestModifyTime { get; set; }
        public string LatestModifyMachine { get; set; }
        public bool Enabled { get; set; }
        public string VehicleMode { get; set; }
        public string CustAssemblyLine { get; set; }
        public Nullable<int> Upper { get; set; }
        public Nullable<int> CodeLEFT { get; set; }
        public Nullable<int> Barcodewidth { get; set; }
        public Nullable<int> Barcodeheight { get; set; }
        public Nullable<int> Fontleft { get; set; }
        public Nullable<int> Fontsize { get; set; }
        public string Fontname { get; set; }
        public Nullable<int> ISQRCode { get; set; }
    }
}
