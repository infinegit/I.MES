using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using I.MES.Models.IFModel;

namespace I.MES.Models.IF
{

    public class KepReqMessage
    {
        public string timestamp { get; set; }
        public string method { get; set; }
        public string deviceid { get; set; }
        public List<KepTag> values { get; set; }

    }

    public class KepRtnMessage
    {
        public string timestamp { get; set; }
        public string method { get; set; }
        public string deviceid { get; set; }
        public List<KepBriefTag> values { get; set; }

    }

    public class KepTag: KepBriefTag
    {
        
        public string q { get; set; }

        public string t { get; set; }
    }

    public class KepBriefTag
    {
        public string id { get; set; }
        public string v { get; set; }
    }
}