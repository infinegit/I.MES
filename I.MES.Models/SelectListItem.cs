using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.MES.Models
{
    public class SelectListItem
    {

        // 摘要:
        //     获取或设置一个值，该值指示是否选择此 System.Web.Mvc.SelectListItem。
        //
        // 返回结果:
        //     如果选定此项，则为 true；否则为 false。
        public bool Selected { get; set; }
        //
        // 摘要:
        //     获取或设置选定项的文本。
        //
        // 返回结果:
        //     文本。
        public string Text { get; set; }
        //
        // 摘要:
        //     获取或设置选定项的值。
        //
        // 返回结果:
        //     值。
        public string Value { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
