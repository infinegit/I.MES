using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// 接口名称：工作流获取当前用户在MES中的权限
    /// 接口编号：GRC_WFM2MES_001
    /// </summary>
    public class IFS_TGProdDeclar
    {
        public string BarCode1 { get; set; }

        public string BarCode2 { get; set; }
        public string BarCode3 { get; set; }
        public string BarCode4 { get; set; }
        public string BarCode5 { get; set; }
        public string BarCode6 { get; set; }

        public string TaskId { get; set; }
        //public string NewPartNo { get; set; }

        public string ProdLineCode { get; set; }

    }

}
