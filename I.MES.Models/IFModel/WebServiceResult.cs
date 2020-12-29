using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models.IF
{
    /// <summary>
    /// WFM直接过账的接口模型
    /// </summary>
    public class WebServiceResult
    {
        /// <summary>
        ///任务ID号
        /// </summary>
        public string TaskID { get;set ;}
        /// <summary>
        /// int类型的返回值。
        /// 1;True
        /// 0:False
        /// </summary>
        public int ResultInt;
        /// <summary>
        /// bool类型的返回值。
        /// True、False
        /// </summary>
        private bool result;
        public bool Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                if (result == true)
                {
                    ResultInt = 1;
                }
                else
                {
                    ResultInt = 0;
                }
            }
        }
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message { get; set; }
    }
}
