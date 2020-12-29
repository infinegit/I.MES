using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;

namespace I.MES.Library
{
    [Shareable]
    /// <summary>
    /// 工艺配置
    /// </summary>
    public class RoteConfigOP : BaseOP
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientInfo"></param>
        public RoteConfigOP(ClientInformation clientInfo) : base(clientInfo)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="DBSource"></param>
        public RoteConfigOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        /// <summary>
        /// 添加路径配置
        /// </summary>
        /// <param name="roteConfig"></param>
        /// <returns></returns>
        [Shareable]
        public string addProdRoteConfig(MFG_RoteConfig roteConfig)
        {
            if (DB.MFG_RoteConfig.Any(p => p.RouteID == roteConfig.RouteID && p.PartNo == roteConfig.PartNo))
            {
                return "数据已存在";
            }
            else
            {
                Insert<MFG_RoteConfig>(roteConfig);
                return "";
            }
        }

        /// 删除
        /// </summary>
        /// <param name="roteConfigID"></param>
        /// <returns></returns>
        [Shareable]
        public void deleteRoteConfigByID(string roteConfigID)
        {
            Delete<MFG_RoteConfig>(p =>p.ID== roteConfigID);
        }
    }
}
