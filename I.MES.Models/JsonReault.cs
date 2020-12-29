using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    [Serializable]
    public class JsonReault
    {
        public string Data { get; set; }
        public string ErrorCode { get; set;}
        public string ErrorMsg { get; set; }
        public bool IsError { get; set; }

    }
}
