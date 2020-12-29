using System;
using I.MES.Tools;

namespace I.MES.GlobalCore.Combinator
{
    /// <summary>
    /// CS架构使用的合成器
    /// </summary>
    public class CSCombinator : ICombinator
    {
        public object Combination(object data)
        {
            if (data is BaseInformation_I)
            {
                BaseInformation_I dt = data as BaseInformation_I;
                if (dt.ClientInfo == null)
                {
                    dt.ClientInfo = GetClientInfo();
                }
                dt.ClientInfo.ClientTraceInfo = Helper.getMethodTrace();
                return dt;
            }
            else
            {
                throw new MESException(1010);
            }
        }

        private ClientInformation GetClientInfo()
        {
            if (BasicProperty.ClientInfo == null)
            {

                BasicProperty.ClientInfo = new ClientInformation()
                {
                    CurrentSysUser = Environment.UserName,
                    System = Environment.OSVersion.ToString(),
                    Machine = Environment.MachineName,
                    LogID = BasicProperty.Log.LogID,
                    LoginUser = "未登录",
                    FactoryCode = "未选择",
                    CompanyCode = "未选择",
                    TransferMethod = TransferType.Json
                };
            }
            
            return BasicProperty.ClientInfo;
        }
    }
}
