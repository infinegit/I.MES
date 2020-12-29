using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;


namespace I.MES.Library
{
    /// <summary>
    /// 工艺路径操作类
    /// </summary>
    [Shareable]
    public class ProdRouteOP : BaseOP
    {
        public ProdRouteOP(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public ProdRouteOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        /// <summary>
        /// 获取所有生产线
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProdLine> getProdLineList(string prodLineCode)
        {
            return GetList<MFG_ProdLine>(p => p.ProdLineCode == prodLineCode || string.IsNullOrEmpty(prodLineCode)).ToList();
        }
        /// <summary>
        /// 根据产线信息获取工位
        /// </summary>
        /// <param name="prodLineCode"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProdStation> getProdStationList(string prodLineCode)
        {
            return GetList<MFG_ProdStation>(p => p.ProdLineCode == prodLineCode || string.IsNullOrEmpty(prodLineCode)).ToList();
        }
        /// <summary>
        /// 获取工艺路径
        /// </summary>
        /// <param name="roteCode"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProcRoute> getProcRoteList(string roteCode)
        {
            return GetList<MFG_ProcRoute>(p => p.RoteCode == roteCode || string.IsNullOrEmpty(roteCode)).ToList();
        }

        /// <summary>
        /// 获取工艺路径
        /// </summary>
        /// <param name="roteID"></param>
        /// <returns></returns>
        [Shareable]
        public MFG_ProcRoute getProcRote(string roteID)
        {
            return GetData<MFG_ProcRoute>(p => p.ID == roteID);
        }
        /// <summary>
        /// 新增工艺路径
        /// </summary>
        /// <param name="procRote"></param>
        [Shareable]
        public void AddProcRote(MFG_ProcRoute procRote)
        {
            Insert<MFG_ProcRoute>(procRote);
        }
        /// <summary>
        /// 修改工艺路径
        /// </summary>
        /// <param name="procRote"></param>
        [Shareable]
        public void updateProcRote(MFG_ProcRoute procRote)
        {
            Update<MFG_ProcRoute>(procRote);
        }
        /// <summary>
        /// 删除工艺路径
        /// </summary>
        /// <param name="procRote"></param>
        [Shareable]
        public string deleteProcRote(string procID)
        {
            if (DB.MFG_RouteStation.Any(p => p.RoteID == procID))
            {
                return "当前工艺下已配置数据，不允许删除";
            }
            else
            {
                Delete<MFG_ProcRoute>(p => p.RoteCode == procID);
                return "";
            }
        }
        /// <summary>
        /// 根据ID查询工艺路径对应的工位
        /// </summary>
        /// <param name="roteID"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_RouteStation> getRoteStationList(string roteID)
        {
            return GetList<MFG_RouteStation>(p => p.RoteID == roteID).OrderBy(s => s.RowNum).ToList();
        }
        /// <summary>
        /// 添加工艺工站
        /// </summary>
        /// <param name="roteStation"></param>
        [Shareable]
        public void addRouteStation(MFG_RouteStation roteStation)
        {
            Insert<MFG_RouteStation>(roteStation);
        }
        /// <summary>
        /// 更新工艺工站
        /// </summary>
        /// <param name="roteStation"></param>
        [Shareable]
        public void updateRouteStation(MFG_RouteStation roteStation)
        {
            MFG_RouteStation droteStation = GetData<MFG_RouteStation>(p => p.ID == roteStation.ID);
            droteStation.StationCode = roteStation.StationCode;
            droteStation.StationName = roteStation.StationName;
            droteStation.RowNum = roteStation.RowNum;
            droteStation.ModifyMachine = roteStation.ModifyMachine;
            droteStation.ModifyTime = DateTime.Now;
            droteStation.ModifyUser = roteStation.ModifyUser;
            Update<MFG_RouteStation>(droteStation);
        }


        /// <summary>
        /// 删除工艺工站
        /// </summary>
        /// <param name="roteStation"></param>
        [Shareable]
        public string deleteRouteStation(string routeStationID)
        {
            if (DB.MFG_ProdWorkSetp.Any(p => p.RouteSationID == routeStationID))
            {
                return "当前工站存在工步，不允许删除";
            }
            else
            {
                Delete<MFG_RouteStation>(p => p.ID == routeStationID);
                return "";
            }

        }
        /// <summary>
        /// 根据工艺工站ID获取工步
        /// </summary>
        /// <param name="roteStationID"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProdWorkSetp> getPordWorkStepList(string roteStationID)
        {
            return GetList<MFG_ProdWorkSetp>(p => p.RouteSationID == roteStationID).ToList();
        }
        /// <summary>
        /// 更新工步参数
        /// </summary>
        /// <param name="param"></param>
        [Shareable]
        public void updateWorkStep(MFG_ProdWorkStepParam param)
        {
            MFG_ProdWorkStepParam oriParam = GetData<MFG_ProdWorkStepParam>(p => p.ID == param.ID);
            oriParam.ParamValue = param.ParamValue;
            oriParam.ModifyUser = ClientInfo.LoginUser;
            oriParam.ModifyMachine = ClientInfo.Machine;
            oriParam.ModifyTime = DateTime.Now;

            Update<MFG_ProdWorkStepParam>(oriParam);
        }
        /// <summary>
        /// 添加工艺工步
        /// </summary>
        /// <param name="prodWorkSetp"></param>
        [Shareable]
        public void addProdWorkSetp(MFG_ProdWorkSetp prodWorkSetp)
        {
            Insert<MFG_ProdWorkSetp>(prodWorkSetp);
            List<MFG_ScanPluginParam> pluginParams = GetList<MFG_ScanPluginParam>(s => s.PluginID == prodWorkSetp.PluginID).ToList();
            if (pluginParams.Count > 0)
            {
                pluginParams.ForEach(
                l =>
                {
                    MFG_ProdWorkStepParam stepParam = new MFG_ProdWorkStepParam
                    {
                        ID = Tools.StringTools.GetGUID(),
                        StepID = prodWorkSetp.ID,
                        ParamName = l.ParamName,
                        ParamDesc = l.ParamDesc,
                        ParamValue = "",
                        CreateUser = ClientInfo.LoginUser,
                        CreateMachine = ClientInfo.Machine,
                        CreateTime = DateTime.Now,
                        ModifyUser = "",
                        ModifyMachine = "",
                        ModifyTime = null
                    };
                    Insert<MFG_ProdWorkStepParam>(stepParam);
                });
            }
        }
        /// <summary>
        /// 更新工步
        /// </summary>
        /// <param name="prodWorkSetp"></param>
        [Shareable]
        public void updatePordWorkStep(MFG_ProdWorkSetp prodWorkSetp)
        {
            MFG_ProdWorkSetp dworkStep = GetData<MFG_ProdWorkSetp>(p => p.ID == prodWorkSetp.ID);
            dworkStep.StepDesc = prodWorkSetp.StepDesc;
            dworkStep.RowNum = prodWorkSetp.RowNum;
            dworkStep.PluginID = prodWorkSetp.PluginID;
            dworkStep.ModifyMachine = prodWorkSetp.ModifyMachine;
            dworkStep.ModifyTime = DateTime.Now;
            dworkStep.ModifyUser = prodWorkSetp.ModifyUser;
            Update<MFG_ProdWorkSetp>(dworkStep);
        }
        /// <summary>
        /// 删除工步
        /// </summary>
        /// <param name="workWorkStepID"></param>
        [Shareable]
        public void deletePordWorkStep(string workWorkStepID)
        {
            Delete<MFG_ProdWorkSetp>(p => p.ID == workWorkStepID);
            Delete<MFG_ProdWorkStepParam>(p => p.StepID == workWorkStepID);
        }
        /// <summary>
        /// 获取所有插件
        /// </summary>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ScanPlugin> getScanPluginList()
        {
            return GetList<MFG_ScanPlugin>(p => true).OrderBy(s => s.PluginID).ToList();
        }
        /// <summary>
        /// 根据插件ID获取插件参数
        /// </summary>
        /// <param name="pluginID"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ScanPluginParam> getScanPluginParam(string pluginID)
        {
            return GetList<MFG_ScanPluginParam>(p => p.PluginID == pluginID).ToList();
        }
        /// <summary>
        /// 根据工步ID获取参数
        /// </summary>
        /// <param name="stepID"></param>
        /// <returns></returns>
        [Shareable]
        public List<MFG_ProdWorkStepParam> getWorkStepParamsByStepID(string stepID)
        {
            List<MFG_ProdWorkStepParam> stepParams = GetList<MFG_ProdWorkStepParam>(p => p.StepID == stepID).ToList();
            MFG_ProdWorkSetp workStep = GetData<MFG_ProdWorkSetp>(p => p.ID == stepID);
            List<MFG_ScanPluginParam> pluginParams = GetList<MFG_ScanPluginParam>(p => p.PluginID == workStep.PluginID).ToList();
            if (pluginParams.Count > 0 && stepParams.Count != pluginParams.Count)
            {
                pluginParams.ForEach(
                l =>
                {
                    if (!stepParams.Any(p => p.ParamName == l.ParamName))
                    {
                        MFG_ProdWorkStepParam stepParam = new MFG_ProdWorkStepParam
                        {
                            ID = Tools.StringTools.GetGUID(),
                            StepID = stepID,
                            ParamName = l.ParamName,
                            ParamDesc = l.ParamDesc,
                            ParamValue = "",
                            CreateUser = ClientInfo.LoginUser,
                            CreateMachine = ClientInfo.Machine,
                            CreateTime = DateTime.Now,
                            ModifyUser = "",
                            ModifyMachine = "",
                            ModifyTime = null
                        };
                        Insert<MFG_ProdWorkStepParam>(stepParam);
                        stepParams.Add(stepParam);
                    }
                }
                    );

            }
            return stepParams;

        }
        /// <summary>
        /// 新增工艺参数
        /// </summary>
        /// <param name="workStepParams"></param>
        [Shareable]
        public void AddorUpdateWorkStepParam(List<MFG_ProdWorkStepParam> workStepParams)
        {
            workStepParams.ForEach(
                p =>
                {
                    MFG_ProdWorkStepParam param = GetData<MFG_ProdWorkStepParam>(s => s.StepID == p.StepID
                    && s.ParamName == p.ParamName);
                    if (param != null && param.ParamValue != p.ParamValue)
                    {
                        p.ID = param.ID;
                        Update<MFG_ProdWorkStepParam>(p);
                    }
                    else
                    {
                        Insert<MFG_ProdWorkStepParam>(p);
                    }
                }
                );
        }
    }
}
