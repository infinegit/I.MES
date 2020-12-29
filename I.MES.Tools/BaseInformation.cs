using System;
using System.Collections.Generic;

/*本文档用于生成相关的传递Model，非架构人员不允许修改本文档*/

namespace I.MES.Tools
{
    [Serializable]
    public class BaseInformation_I
    {
        public ClientInformation ClientInfo { get; set; }
        public string PersistenceCode { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public List<Parameters> Parameters { get; set; }
    }

    [Serializable]
    public class BaseInfomation_O
    {
        public object result { get; set; }
        public List<Parameters> Parameters { get; set; }
        public string Error { get; set; }
        //public MESException ErrorExcepiton { get; set; }
        public int ErrorCode { get; set; }
    }

    [Serializable]
    public class Parameters
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string TypeName { get; set; }
        public bool IsRef { get; set; }
        public bool IsOut { get; set; }
    }
}
