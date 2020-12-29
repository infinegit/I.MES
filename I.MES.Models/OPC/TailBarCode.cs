using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.OPC
{
    public class TailBarCode
    {
        /// <summary>
        /// 传给设备的编号
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 就绪编号
        /// </summary>
        public Boolean Status { get; set; }

        public string ProdLineCode { get; set; }

        public string WorkingProcedure { get; set; }

        public short IsCanDo { get; set; }

        public short ResetSignal { get; set; }

        public short Value { get; set; }

        public string PokayokaCode { get; set; }  //二线防火罩识别
    }
}
