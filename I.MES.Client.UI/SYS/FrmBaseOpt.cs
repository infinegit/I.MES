using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using I.MES.Models;
using I.MES.Library;
using I.MES.Tools;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Caching;
using CCWin;

namespace I.MES.Client.UI
{
    public delegate void ChildButtonClick(object sender, EventArgs e);

    public partial class FrmBaseOpt : CCSkinMain
    {
        protected List<DBCommand> dbCmd = new List<DBCommand>();
        protected List<DBCommand> dbActionCmd = new List<DBCommand>();
        protected List<DBCommand> dbSeqCmd = new List<DBCommand>();
        //protected ProcessScanOP processScanOp = new ProcessScanOP();
        //protected ProductOP productOp = new ProductOP();
        protected ChildButtonClick childActionButtonClick = null;
        protected MESException MESExceptionResault = null;
        public FrmBaseOpt()
        {
            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/OneBlue.ssk";
            //Control.CheckForIllegalCrossThreadCalls = false;
        }
        //#region 信息显示相关
        ///// <summary>
        ///// 显示提示信息(指定标签名称)
        ///// </summary>
        ///// <param name="message"></param>
        //protected virtual void ShowMessage(string message, string lableName)
        //{
        //    try
        //    {
        //        Label lbl = (Label)this.Controls.Find(lableName, true)[0];
        //        lbl.Text = message;
        //        lbl.ForeColor = System.Drawing.Color.Green;
        //        lbl.Visible = true;
        //        //new frm_PlaySD().success();
        //        //Program.speakSuccess();

        //    }
        //    catch (Exception ex) //如果前面的显示失败的话，就通过对话框的形式进行显示。
        //    {
        //        ShowMessageDialog("ShowMessage执行失败" + ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 显示提示信息
        ///// </summary>
        ///// <param name="message"></param>
        //protected virtual void ShowMessage(string message)
        //{
        //    ShowMessage(message, "lblMessage");
        //}
        //protected virtual void ShowMessageDialog(string message)
        //{
        //    MessageBox.Show(message);
        //}
        /// <summary>
        /// 显示出错信息
        /// </summary>
        /// <param name="message"></param>
        protected virtual void ShowError(string message)
        {
            try
            {
                SpeakFailure();
                ShowError(message, "lblMessage", string.Empty);
                Logger.CurrentLog.Info(message);
                //try
                //{
                //    Label lbl = (Label)this.Controls.Find("lbl_message", true)[0];
                //    lbl.Text = message;
                //    lbl.Visible = true;
                //    lbl.ForeColor = System.Drawing.Color.Red;
                //}
                //catch (Exception ex)
                //{
                //    ShowErrorDialog(message);
                //}
                //new frm_PlaySD().alert();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ShowError执行失败" + ex.Message);
            }
        }
        /// <summary>
        /// 显示出错信息（无语音版）
        /// </summary>
        /// <param name="message"></param>
        protected virtual void ShowErrorWithoutVoice(string message)
        {
            SpeakFailure();
            ShowError(message, "lblMessage", string.Empty);
            try
            {
                Label lbl = (Label)this.Controls.Find("lbl_message", true)[0];
                lbl.Text = message;
                lbl.Visible = true;
                lbl.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                ShowErrorDialog(message);
            }
            // new frm_PlaySD().alert();
        }
        /// <summary>
        /// 显示出错信息(指定Label控件显示)
        /// </summary>
        /// <param name="message"></param>
        protected virtual void ShowError(string message, string lableName)
        {
            ShowError(message, lableName, string.Empty);
        }
        /// <summary>
        /// 显示出错信息(指定Label控件显示)
        /// </summary>
        /// <param name="message"></param>
        protected void ShowError(string message, string lableName, string content)
        {
            try
            {
                Label lbl = (Label)this.Controls.Find(lableName, true)[0];
                lbl.Text = message;
                lbl.ForeColor = System.Drawing.Color.Red;
                lbl.Font = new Font("Tahoma", 10);
                lbl.Visible = true;
                //new frm_PlaySD().alert();
                //if (content == string.Empty)
                //    Program.speakAlert();
                //else
                //    Program.speak(content + "," + MessageText.MsgDict.E0091);
            }
            catch (Exception ex)
            {
                ShowErrorDialog(message);
            }

        }
        /// <summary>
        /// 显示出错信息提示框
        /// </summary>
        /// <param name="message"></param>
        protected virtual void ShowErrorDialog(string message)
        {
            try
            {
                MessageBox.Show(message);
                //new frm_PlaySD().alert();
                //Program.speakAlert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 隐藏信息显示
        /// </summary>
        protected virtual void hideMessage()
        {
            //Label lbl = (Label)this.Controls.Find("lblMessage", true)[0];
            //lbl.Visible = false;
        }


        #region 按钮操作相关
        /// <summary>
        /// //关联不同的Action按钮所对应的操作，此方法在各form中需要重载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void actionBtnClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                button.Enabled = false;
                if (childActionButtonClick != null)
                {
                    SpeakContent(button.Text);
                    childActionButtonClick(sender, e);
                }
                button.Enabled = true;
            }
            catch (Exception ex)
            {
                button.Enabled = true;
                this.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 指定标签名称，在按钮对象（Action）
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        protected Button createNewButton(string label)
        {
            try
            {
                Button btn = new Button();
                btn.Name = label.ToString();
                btn.Text = label.ToString();
                btn.Size = new System.Drawing.Size(60, 30);
                btn.Click += new System.EventHandler(actionBtnClicked);
                return btn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        /// <summary>
        /// 根据指定的属性创建一个按钮
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tag"></param>
        /// <param name="backColor"></param>
        /// <param name="foreColor"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        protected Button createNewButton(string text, object tag, string backColor, string foreColor, int width, int height)
        {
            try
            {
                width = width == 0 ? 60 : width;
                height = height == 0 ? 30 : height;
                CCWin.SkinControl.SkinButton btn = new CCWin.SkinControl.SkinButton();
                btn.Name = text;
                btn.Text = text;
                btn.Tag = tag;
                btn.Size = new System.Drawing.Size(width, height);
                btn.ForeColor = System.Drawing.Color.FromName(foreColor);
                btn.BackColor = System.Drawing.Color.FromName(backColor);
                btn.Click += new System.EventHandler(actionBtnClicked);
                return btn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected virtual void Back()
        {
            Tools.MemoryCacheHelper.ClearAllCache();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region 工序扫描相关
        /// <summary>
        /// 渲染Plugin Form
        /// </summary>
        /// <param name="scanPlugin"></param>
        /// <param name="barcodeInfo"></param>
        /// <param name="scansiteInfo"></param>
        /// <param name="produceProcessInfo"></param>
        /// <returns></returns>
        //protected virtual FrmBaseOpt renderPluginForm(MFG_ScanPlugin scanPlugin, ProductBarcodeInfo barcodeInfo, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo)
        //{
        //    FrmBaseOpt frm = null;
        //    string formName = scanPlugin.PluginForm;
        //    Assembly asm = Assembly.GetExecutingAssembly();
        //    Object[] parameters = new Object[4];
        //    parameters[0] = scanPlugin;
        //    parameters[1] = barcodeInfo;
        //    parameters[2] = scansiteInfo;
        //    parameters[3] = produceProcessInfo;
        //    frm = (FrmBaseOpt)asm.CreateInstance("I.MES.Client.UI.PLG." + formName, true, BindingFlags.Default, null, parameters, null, null);
        //    return frm;
        //}
        //protected virtual bool doPreRequisitionPlugin(ProductBarcodeInfo barcodeInfo, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{
        //    string sql = "";
        //    try
        //    {

        //        errmsg = string.Empty;
        //        //根据productScanCfg取PreRequisition的所有插件
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.PreRequisition;
        //        //List<MFG_ScanPlugin> plugins = processScanOp.GetPreRequisitionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp);
        //        List<MFG_ScanPlugin> plugins = new CachingDataOP().GetPreRequisitionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp);
        //        sql = "SELECT a.* FROM MFG_ScanPlugin AS a INNER JOIN MFG_ScanOperateDetail AS b ON a.PluginID=b.PluginID INNER JOIN MFG_ScanOperateGroup AS c ON b.ScanOptGrp=c.ScanOptGrp WHERE b.Enabled=1 AND c.ScanOptGrp='" + produceProcessInfo.productScanCfg.ScanOptGrp + "' AND b.ScanStage='PreRequisition' AND b.ActionCode='' ORDER BY b.PluginOrder";
        //        Logger.CurrentLog.Info(string.Format("正在查找PreRequisition插件【{0}】,插件数量【{1}】", sql, plugins != null ? plugins.Count.ToString() : ""));
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            var strLog = string.Empty;
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                strLog = errmsg = "该插件的属性配置有误." + plg.PluginType.ToString();
        //                return false;
        //            }
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm) //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            {
        //                continue;
        //            }
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                dbCmd.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, barcodeInfo, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来
        //                strLog = string.Format("PluginType【METHOD】,PluginID【{0}】", plg.PluginID);
        //                Logger.CurrentLog.Info(strLog);
        //            }
        //            else if (plg.PluginType.ToUpper().Trim() == "FORM")
        //            {
        //                FrmBaseOpt frm = renderPluginForm(plg, barcodeInfo, scansiteInfo, produceProcessInfo);//渲染Plugin窗体

        //                if (frm == null)
        //                {
        //                    errmsg = "没有该项目的插件配置." + plg.PluginID;
        //                    return false;
        //                }
        //                strLog = string.Format("PluginType【FORM】,PluginID【{0}】", plg.PluginID);
        //                BasicProperty.Log.Info(strLog);
        //                frm.ShowDialog(); //所有窗口必须模态显示
        //                if (frm.DialogResult != DialogResult.Yes) //操作全部正常完成
        //                {
        //                    // errmsg = plg.PluginName + "未执行成功";
        //                    frm.Dispose();
        //                    return false;
        //                }
        //                dbCmd.AddRange(frm.dbCmd);//把插件数据库执行命令搞进来
        //                frm.Dispose();
        //                continue;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (MESException ex)
        //    {
        //        BasicProperty.Log.Info(string.Format("doPreRequisitionPlugin执行异常【{0}】【{1}】", sql, ex.Message));
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}
        /// <summary>
        /// 执行扫描插件--返回值：0表示未执行成功，1表示执行成功，2表示已完成
        /// </summary>
        /// <param name="barcodeInfo"></param>
        /// <param name="scansiteInfo"></param>
        /// <param name="produceProcessInfo"></param>
        /// <param name="errmsg"></param>
        /// <returns>返回值：0表示未执行成功，1表示执行成功，2表示已完成</returns>
        //protected virtual int doScanPlugin(ProductBarcodeInfo barcodeInfo, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{

        //    try
        //    {
        //        errmsg = string.Empty;
        //        //根据productScanCfg取Scan的所有插件
        //        //List<MFG_ScanPlugin> plugins = processScanOp.GetScanScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp);
        //        List<MFG_ScanPlugin> plugins = new CachingDataOP().GetScanScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp);
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.Scan;
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            //检查是否是非法插件
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                errmsg = "该插件的属性配置有误" + plg.PluginType.ToString();
        //                return 0;
        //            }
        //            //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm)
        //            {
        //                continue;
        //            }
        //            //方法执行
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                dbCmd.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, barcodeInfo, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来
        //            }
        //            else if (plg.PluginType.ToUpper().Trim() == "FORM")
        //            {
        //                FrmBaseOpt frm = renderPluginForm(plg, barcodeInfo, scansiteInfo, produceProcessInfo);//渲染Plugin窗体
        //                if (frm == null)
        //                {
        //                    errmsg = "没有该项目的插件配置" + plg.PluginID;
        //                    return 0;
        //                }
        //                frm.ShowDialog(); //所有窗口必须模态显示
        //                if (frm.DialogResult == DialogResult.OK) //操作全部正常完成
        //                {
        //                    errmsg = plg.PluginName + "已完成";
        //                    frm.Dispose();
        //                    return 2;
        //                }
        //                var cfg = new ConfigOP().GetGlobalCfg("FrmPlugBtnBack", "IsEnabeld");
        //                if (cfg != null && cfg.ParamValue == "1" && frm.DialogResult == DialogResult.Cancel)
        //                {
        //                    return 3;
        //                }
        //                if (frm.DialogResult != DialogResult.Yes) //操作全部正常完成
        //                {
        //                    errmsg = plg.PluginName + "未执行成功";
        //                    if (frm.MESExceptionResault != null)
        //                    {
        //                        frm.Dispose();
        //                        throw frm.MESExceptionResault;
        //                    }
        //                    frm.Dispose();
        //                    return 0;
        //                }
        //                dbCmd.AddRange(frm.dbCmd);//把插件数据库执行命令搞进来
        //                frm.Dispose();
        //            }
        //        }
        //        return 1;
        //    }
        //    catch (MESException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}
        ///// <summary>
        ///// 执行Action
        ///// </summary>
        ///// <param name="barcodeInfo"></param>
        ///// <param name="scansiteInfo"></param>
        ///// <param name="produceProcessInfo"></param>
        ///// <param name="errmsg"></param>
        ///// <returns></returns>
        //protected virtual bool doActionPlugin(ProductBarcodeInfo barcodeInfo, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{
        //    try
        //    {
        //        List<DBCommand> lstTmpCmds = new List<DBCommand>();
        //        errmsg = string.Empty;
        //        if (produceProcessInfo.scanAction == null)
        //        {
        //            errmsg = "没有对Action进行赋值，请检查程序正确性。";
        //            return false;
        //        }
        //        //根据productScanCfg取PreRequisition的所有插件
        //        //List<MFG_ScanPlugin> plugins = processScanOp.GetActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        List<MFG_ScanPlugin> plugins = new CachingDataOP().GetActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);

        //        if (plugins == null || plugins.Count <= 0)
        //        {
        //            errmsg = "没有配置Action对应的插件.组:" + produceProcessInfo.productScanCfg.ScanOptGrp + ",Action:" + produceProcessInfo.scanAction.ActionCode;
        //            return false;
        //        }
        //        string sql =
        //         "SELECT a.* FROM MFG_ScanPlugin AS a INNER JOIN MFG_ScanOperateDetail AS b ON a.PluginID=b.PluginID INNER JOIN MFG_ScanOperateGroup AS c ON b.ScanOptGrp=c.ScanOptGrp WHERE b.Enabled=1 AND c.ScanOptGrp='" + produceProcessInfo.productScanCfg.ScanOptGrp + "' AND b.ScanStage='Action' AND b.ActionCode='" + produceProcessInfo.scanAction.ActionCode + "' ORDER BY b.PluginOrder";
        //        Logger.CurrentLog.Info(string.Format("正在查找Action插件【{0}】,插件数量【{1}】", sql, plugins.Count.ToString()));
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.Action;
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            var strLog = string.Empty;
        //            //检查是否是非法插件
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                errmsg = "该插件的属性配置有误" + plg.PluginType.ToString(); ;
        //                return false;
        //            }
        //            //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm)
        //            {
        //                continue;
        //            }
        //            //方法执行
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                lstTmpCmds.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, barcodeInfo, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来
        //                strLog = string.Format("PluginType【METHOD】,PluginID【{0}】", plg.PluginID);
        //                Logger.CurrentLog.Info(strLog);
        //            }
        //            else if (plg.PluginType.ToUpper().Trim() == "FORM")
        //            {
        //                FrmBaseOpt frm = renderPluginForm(plg, barcodeInfo, scansiteInfo, produceProcessInfo);//渲染Plugin窗体
        //                if (frm == null)
        //                {
        //                    errmsg = "没有该项目的插件配置" + plg.PluginID;
        //                    return false;
        //                }
        //                strLog = string.Format("PluginType【FORM】,PluginID【{0}】", plg.PluginID);
        //                Logger.CurrentLog.Info(strLog);
        //                frm.ShowDialog(); //所有窗口必须模态显示
        //                if (frm.DialogResult != DialogResult.Yes) //操作全部正常完成
        //                {
        //                    errmsg = plg.PluginName + "未执行成功";
        //                    frm.Dispose();
        //                    return false;
        //                }
        //                lstTmpCmds.AddRange(frm.dbCmd); //把插件数据库执行命令搞进来
        //                frm.Dispose();
        //                continue;
        //            }
        //        }
        //        dbActionCmd.AddRange(lstTmpCmds);
        //        return true;
        //    }
        //    catch (MESException ex)
        //    {
        //        BasicProperty.Log.Info(string.Format("doActionPlugin执行异常{0}", ex.Message));
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}

        ///// <summary>
        ///// 执行ActionHU
        ///// </summary>
        ///// <param name="huDetList"></param>
        ///// <param name="scansiteInfo"></param>
        ///// <param name="produceProcessInfo"></param>
        ///// <param name="errmsg"></param>
        ///// <returns></returns>
        //protected virtual bool doActionPlugin(LGS_HUPkgMstr huPkgMstr, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{
        //    try
        //    {
        //        List<DBCommand> lstTmpCmds = new List<DBCommand>();
        //        errmsg = string.Empty;
        //        if (produceProcessInfo.scanAction == null)
        //        {
        //            errmsg = "没有对Action进行赋值，请检查程序正确性。";
        //            return false;
        //        }
        //        //根据productScanCfg取PreRequisition的所有插件
        //        //List<MFG_ScanPlugin> plugins = processScanOp.GetActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        List<MFG_ScanPlugin> plugins = new CachingDataOP().GetActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        if (plugins == null || plugins.Count <= 0)
        //        {
        //            errmsg = "没有配置Action对应的插件.组:" + produceProcessInfo.productScanCfg.ScanOptGrp + ",Action:" + produceProcessInfo.scanAction.ActionCode;
        //            return false;
        //        }
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.Action;
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            //检查是否是非法插件
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                errmsg = "该插件的属性配置有误" + plg.PluginType.ToString(); ;
        //                return false;
        //            }
        //            //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm)
        //            {
        //                continue;
        //            }
        //            //方法执行
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                lstTmpCmds.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, huPkgMstr, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来
        //            }
        //        }
        //        dbActionCmd.AddRange(lstTmpCmds);
        //        return true;
        //    }
        //    catch (MESException ex)
        //    {
        //        BasicProperty.Log.Info(string.Format("dLGS_HUPkgMstr类型的oActionPlugin方法执行异常{0}", ex.Message));
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}

        ///// <summary>
        ///// 执行ActionHU
        ///// </summary>
        ///// <param name="huDetList"></param>
        ///// <param name="scansiteInfo"></param>
        ///// <param name="produceProcessInfo"></param>
        ///// <param name="errmsg"></param>
        ///// <returns></returns>
        //protected virtual bool doActionPlugin1(List<LGS_HUPkgMstr> huPkgMstrList, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{
        //    try
        //    {
        //        List<DBCommand> lstTmpCmds = new List<DBCommand>();
        //        errmsg = string.Empty;
        //        if (produceProcessInfo.scanAction == null)
        //        {
        //            errmsg = "没有对Action进行赋值，请检查程序正确性。";
        //            return false;
        //        }
        //        //根据productScanCfg取PreRequisition的所有插件
        //        //List<MFG_ScanPlugin> plugins = processScanOp.GetActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        List<MFG_ScanPlugin> plugins = new CachingDataOP().GetActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        if (plugins == null || plugins.Count <= 0)
        //        {
        //            errmsg = "没有配置Action对应的插件.组:" + produceProcessInfo.productScanCfg.ScanOptGrp + ",Action:" + produceProcessInfo.scanAction.ActionCode;
        //            return false;
        //        }
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.Action;
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            //检查是否是非法插件
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                errmsg = "该插件的属性配置有误" + plg.PluginType.ToString(); ;
        //                return false;
        //            }
        //            //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm)
        //            {
        //                continue;
        //            }
        //            //方法执行
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                foreach (var huPkgMstr in huPkgMstrList)
        //                {
        //                    lstTmpCmds.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, huPkgMstr, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来
        //                }
        //            }
        //        }
        //        dbActionCmd.AddRange(lstTmpCmds);
        //        return true;
        //    }
        //    catch (MESException ex)
        //    {
        //        BasicProperty.Log.Info(string.Format("dLGS_HUPkgMstr类型的oActionPlugin方法执行异常{0}", ex.Message));
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}

        ///// <summary>
        ///// 执行Action事务提交后，所再执行的插件
        ///// </summary>
        ///// <param name="barcodeInfo"></param>
        ///// <param name="scansiteInfo"></param>
        ///// <param name="produceProcessInfo"></param>
        ///// <param name="errmsg"></param>
        ///// <returns></returns>
        //protected virtual bool doPostActionPlugin(ProductBarcodeInfo barcodeInfo, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{
        //    try
        //    {
        //        List<DBCommand> lstTmpCmds = new List<DBCommand>();
        //        errmsg = string.Empty;
        //        if (produceProcessInfo.scanAction == null)
        //        {
        //            errmsg = "没有对Action进行赋值，请检查程序正确性。";
        //            return false;
        //        }
        //        //根据productScanCfg取PreRequisition的所有插件
        //        List<MFG_ScanPlugin> plugins = processScanOp.GetPostActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        if (plugins == null || plugins.Count <= 0)
        //        {
        //            return true;
        //            //errmsg = "没有配置Action对应的插件.组:" + produceProcessInfo.productScanCfg.ScanOptGrp + ",Action:" + produceProcessInfo.scanAction.ActionCode;
        //            //return false;
        //        }
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.PostAction;
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            //检查是否是非法插件
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                errmsg = "该插件的属性配置有误" + plg.PluginType.ToString(); ;
        //                return false;
        //            }
        //            //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm)
        //            {
        //                continue;
        //            }
        //            //方法执行
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                lstTmpCmds.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, barcodeInfo, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来
        //            }
        //            else if (plg.PluginType.ToUpper().Trim() == "FORM")
        //            {
        //                FrmBaseOpt frm = renderPluginForm(plg, barcodeInfo, scansiteInfo, produceProcessInfo);//渲染Plugin窗体
        //                if (frm == null)
        //                {
        //                    errmsg = "没有该项目的插件配置" + plg.PluginID;
        //                    return false;
        //                }
        //                frm.ShowDialog(); //所有窗口必须模态显示
        //                if (frm.DialogResult != DialogResult.Yes) //操作全部正常完成
        //                {
        //                    errmsg = plg.PluginName + "未执行成功";
        //                    frm.Dispose();
        //                    return false;
        //                }
        //                lstTmpCmds.AddRange(frm.dbCmd); //把插件数据库执行命令搞进来
        //                frm.Dispose();
        //                continue;
        //            }
        //        }
        //        dbActionCmd.AddRange(lstTmpCmds);
        //        return true;
        //    }
        //    catch (MESException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}
        ///// <summary>
        ///// 排序扫描执行Action业务
        ///// </summary>
        ///// <param name="barcodeInfo"></param>
        ///// <param name="scansiteInfo"></param>
        ///// <param name="produceProcessInfo"></param>
        ///// <param name="errmsg"></param>
        ///// <returns></returns>
        //protected virtual bool doSeqActionPlugin(ProductBarcodeInfo barcodeInfo, ScanSiteInfo scansiteInfo, ProduceProcessInfo produceProcessInfo, ref string errmsg)
        //{
        //    try
        //    {
        //        List<DBCommand> lstTmpCmds = new List<DBCommand>();
        //        errmsg = string.Empty;
        //        //根据productScanCfg取Scan的所有插件
        //        //List<MFG_ScanPlugin> plugins = processScanOp.GetSeqActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        List<MFG_ScanPlugin> plugins = new CachingDataOP().GetSeqActionScanPlugins(produceProcessInfo.productScanCfg.ScanOptGrp, produceProcessInfo.scanAction.ActionCode);
        //        string sql =
        //        "SELECT a.* FROM MFG_ScanPlugin AS a INNER JOIN MFG_ScanOperateDetail AS b ON a.PluginID=b.PluginID INNER JOIN MFG_ScanOperateGroup AS c ON b.ScanOptGrp=c.ScanOptGrp WHERE b.Enabled=1 AND c.ScanOptGrp='" + produceProcessInfo.productScanCfg.ScanOptGrp + "' AND b.ScanStage='SeqAction'  ORDER BY b.PluginOrder";
        //        Logger.CurrentLog.Info(string.Format("正在查找Action插件【{0}】,插件数量【{1}】【{2}】", sql, plugins.Count.ToString(), barcodeInfo.Barcode));
        //        produceProcessInfo.ScanStage = ConstInfo.ScanStage.SeqAction;
        //        foreach (MFG_ScanPlugin plg in plugins)
        //        {
        //            var strLog = string.Empty;
        //            //检查是否是非法插件
        //            if (plg.PluginType.ToUpper().Trim() != "METHOD" && plg.PluginType.ToUpper().Trim() != "FORM")
        //            {
        //                errmsg = "该插件的属性配置有误" + plg.PluginType; ;
        //                return false;
        //            }
        //            //如果当前工位没有启用设备通讯，但是插件是使用设备通讯的的话，就直接跳过该插件。
        //            if (!scansiteInfo.useDeviceComm && plg.UseDeviceComm)
        //            {
        //                continue;
        //            }
        //            //方法执行
        //            if (plg.PluginType.ToUpper().Trim() == "METHOD")
        //            {
        //                strLog = string.Format("开始执行PluginType【METHOD】,PluginID【{0}】【{1}】", plg.PluginID, barcodeInfo.Barcode);
        //                Logger.CurrentLog.Info(strLog);
        //                lstTmpCmds.AddRange(processScanOp.ExcecutePlugin(plg.PluginID, barcodeInfo, scansiteInfo, produceProcessInfo));//把插件数据库执行命令搞进来 strLog = string.Format("PluginType【METHOD】,PluginID【{0}】", plg.PluginID);
        //                strLog = string.Format("执行结束PluginType【METHOD】,PluginID【{0}】【{1}】", plg.PluginID, barcodeInfo.Barcode);
        //                Logger.CurrentLog.Info(strLog);
        //            }
        //            else if (plg.PluginType.ToUpper().Trim() == "FORM")
        //            {
        //                FrmBaseOpt frm = renderPluginForm(plg, barcodeInfo, scansiteInfo, produceProcessInfo);//渲染Plugin窗体
        //                if (frm == null)
        //                {
        //                    errmsg = "没有该项目的插件配置" + plg.PluginID;
        //                    return false;
        //                }
        //                frm.ShowDialog(); //所有窗口必须模态显示
        //                if (frm.DialogResult != DialogResult.Yes) //操作全部正常完成
        //                {
        //                    errmsg = plg.PluginName + "未执行成功";
        //                    frm.Dispose();
        //                    return false;
        //                }
        //                lstTmpCmds.AddRange(frm.dbCmd);//把插件数据库执行命令搞进来
        //                frm.Dispose();
        //            }
        //        }
        //        dbSeqCmd.AddRange(lstTmpCmds);
        //        return true;
        //    }
        //    catch (MESException ex)
        //    {
        //        string msg = "产品装配成功，但是排序失败" + ex.Message;
        //        errmsg = string.Format("PluginType【METHOD】,PluginID【{0}】", msg);
        //        Logger.CurrentLog.Error(errmsg);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        produceProcessInfo.ScanStage = string.Empty;
        //    }
        //}

        #endregion

        #region 调用虚拟键盘

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004; private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010; private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_NOSENDCHANGING = 0x0400;
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
                                        int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        //public static void ShowScreenKeyboard()
        //{
        //    if (System.IO.File.Exists(Environment.SystemDirectory + "\\FreeVK.exe"))
        //    {
        //        Process process = new Process();
        //        process.StartInfo.UseShellExecute = false;
        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.StartInfo.RedirectStandardError = true;
        //        process.StartInfo.CreateNoWindow = true;
        //        process.StartInfo.FileName = "FreeVK.exe";
        //        process.StartInfo.Arguments = "";
        //        process.Start();
        //        process.WaitForInputIdle();

        //        SetWindowPos(process.MainWindowHandle,
        //        process.MainWindowHandle,
        //        0,
        //        0,
        //        600,
        //        600,
        //        SWP_SHOWWINDOW | SWP_NOZORDER);

        //        SetForegroundWindow(process.MainWindowHandle);
        //    }

        //}
        #endregion

        #region 通用的按键区功能
        /// <summary>
        /// 打开键盘区（虚拟键盘）
        /// </summary>
        /// <param name="nameOfInputTextControl"></param>
        /// <param name="isPassword"></param>
        protected void OpenSysVirtualKeyboard()
        {
            try
            {
                try
                {

                    string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tpl", "FreeVK.exe");
                    System.Diagnostics.Process.Start(FilePath); //打开软键盘

                    //ShowScreenKeyboard();
                }
                catch (Exception ex)
                {
                    ShowError("" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
        ///// <summary>
        ///// 打开键盘区（虚拟键盘）
        ///// </summary>
        ///// <param name="nameOfInputTextControl"></param>
        ///// <param name="isPassword"></param>
        //protected void OpenMesVirtualKeyboard(string nameOfInputTextControl, bool isPassword)
        //{
        //    try
        //    {
        //        string returnValue = string.Empty;
        //        //打开键盘区，用户输入内容
        //        DLG.FrmDlgKeyBoardDialog frm = new DLG.FrmDlgKeyBoardDialog();
        //        frm.Text = "请输入";
        //        frm.IsPassWord = isPassword;
        //        if (frm.ShowDialog() == DialogResult.Yes)
        //        { returnValue = frm.ReturnValue; }
        //        //将输入的数据放到指定控件中
        //        TextBox inputTextControl = (TextBox)this.Controls.Find(nameOfInputTextControl, true)[0];
        //        if (inputTextControl == null)
        //        {
        //            ShowErrorDialog("找不到输入控件:" + nameOfInputTextControl);
        //            return;
        //        }
        //        inputTextControl.Text = returnValue;
        //        inputTextControl.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowErrorDialog(ex.Message);
        //    }
        //}

        /// <summary>
        /// 打开条码启用对话框
        /// </summary>
        protected void OpenBarcodeEnableDialog(string scanCode)
        {
            try
            {
                List<SYS_Prog> progs = new UserOP().GetUserProgs(Program.currentUser.UserAccount, "MESScan");
                if (progs == null || !progs.Exists(p => p.ProgForm == "FrmBarcodeEnable"))
                {
                    ShowError("您没有进行条码启用的权限!");
                    return;
                }
                //string progCode = ((Button)sender).Tag.ToString();
                SYS_Prog prog = progs.First(p => p.ProgForm == "FrmBarcodeEnable");
                FrmBaseOpt frm = null;
                //string formName = ((Button)sender).Text;
                Assembly asm = Assembly.GetExecutingAssembly();
                Object[] parameters = new Object[2];
                parameters[0] = prog;
                parameters[1] = scanCode;
                string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                frm = (FrmBaseOpt)asm.CreateInstance(currentNameSpace + "." + prog.ProgType + "." + prog.ProgForm, true, BindingFlags.Default, null, parameters, null, null);
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// 打开条码启用对话框
        /// </summary>
        protected void OpenBarcodeEnableDialog()
        {
            try
            {
                List<SYS_Prog> progs = new UserOP().GetUserProgs(Program.currentUser.UserAccount, "MESScan");
                if (progs == null || !progs.Exists(p => p.ProgForm == "FrmBarcodeEnable"))
                {
                    ShowError("您没有进行条码启用的权限!");
                    return;
                }
                //string progCode = ((Button)sender).Tag.ToString();
                SYS_Prog prog = progs.First(p => p.ProgForm == "FrmBarcodeEnable");
                FrmBaseOpt frm = null;
                //string formName = ((Button)sender).Text;
                Assembly asm = Assembly.GetExecutingAssembly();
                Object[] parameters = new Object[1];
                parameters[0] = prog;
                string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                frm = (FrmBaseOpt)asm.CreateInstance(currentNameSpace + "." + prog.ProgType + "." + prog.ProgForm, true, BindingFlags.Default, null, parameters, null, null);
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        ///// <summary>
        ///// 打开设备报修对话框
        ///// </summary>
        //protected void OpenEquipRepairDialog()
        //{
        //    try
        //    {
        //        List<SYS_Prog> progs = new UserOP().GetUserProgs(Program.currentUser.UserAccount, "MESScan");
        //        if (progs == null || !progs.Exists(p => p.ProgForm == "FrmEquipRepair"))
        //        {
        //            ShowError("您没有进行设备报修的权限!");
        //            return;
        //        }
        //        //string progCode = ((Button)sender).Tag.ToString();
        //        SYS_Prog prog = progs.First(p => p.ProgForm == "FrmEquipRepair");
        //        EMS.FrmEquipRepair frm = new EMS.FrmEquipRepair(prog);
        //        frm.ShowDialog();
        //        frm.BringToFront();
        //        frm.Dispose();
        //        //FrmBaseOpt frm = null;
        //        ////string formName = ((Button)sender).Text;
        //        //Assembly asm = Assembly.GetExecutingAssembly();
        //        //Object[] parameters = new Object[1];
        //        //parameters[0] = prog;
        //        //string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        //        //frm = (FrmBaseOpt)asm.CreateInstance(currentNameSpace + "." + prog.ProgType + "." + prog.ProgForm, true, BindingFlags.Default, null, parameters, null, null);
        //        //frm.ShowDialog();
        //        //frm.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError(ex.Message);
        //    }
        //}
        /// <summary>
        /// 打开物料拉动对话框
        /// </summary>
        protected void OpenProdFeedDialog()
        {
            try
            {
                List<SYS_Prog> progs = new UserOP().GetUserProgs(Program.currentUser.UserAccount, "MESScan");
                if (progs == null || !progs.Exists(p => p.ProgForm == "FrmProdFeed"))
                {
                    ShowError("您没有进行物料拉动的权限!");
                    return;
                }
                //string progCode = ((Button)sender).Tag.ToString();
                SYS_Prog prog = progs.First(p => p.ProgForm == "FrmProdFeed");
                FrmBaseOpt frm = null;
                //string formName = ((Button)sender).Text;
                Assembly asm = Assembly.GetExecutingAssembly();
                Object[] parameters = new Object[1];
                parameters[0] = prog;
                string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                frm = (FrmBaseOpt)asm.CreateInstance(currentNameSpace + "." + prog.ProgType + "." + prog.ProgForm, true, BindingFlags.Default, null, parameters, null, null);
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        ///// <summary>
        ///// 打开解除绑定条码对话框
        ///// </summary>
        ///// <param name="scansiteinfo"></param>
        //protected void OpenRemoveBindDialog(string barcode)
        //{
        //    //首先要先进行判断 在主程序执行过程中不允许进行解除绑定
        //    try
        //    {
        //        //List<SYS_Prog> progs = new UserOP().GetUserProgs(Program.currentUser.UserAccount, "MESScan");
        //        //if (progs == null || !progs.Exists(p => p.ProgName == "FrmPluginRemoveBindBarcode"))
        //        //{
        //        //    ShowError("您没有进行解除条码绑定的权限!");
        //        //    return;
        //        //}
        //        //SYS_Prog prog = progs.First(p => p.ProgName == "FrmPluginRemoveBindBarcode");
        //        PLG.FrmPluginRemoveBindBarcode frm = new PLG.FrmPluginRemoveBindBarcode(barcode);
        //        frm.ShowDialog();
        //        frm.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError(ex.Message);
        //    }
        //}
        #endregion

        #region 语音播报相关
        /// <summary>
        /// 播报成功
        /// </summary>
        protected virtual void SpeakSuccess()
        {
            try
            {
                Speecher.GetInstance().SpeakSuccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected virtual void SpeakSerNum(string sernum)
        {
            try
            {
                Speecher.GetInstance().SpeakSerNum(sernum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 播报失败
        /// </summary>
        protected virtual void SpeakFailure()
        {
            try
            {
                Speecher.GetInstance().SpeakFailure();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 播报具体内容,清空上次内容
        /// </summary>
        /// <param name="content">需播报的内容</param>
        protected virtual void SpeakContent(object content)
        {
            try
            {
                Speecher.GetInstance().SpeakContent(content.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///// <summary>
        ///// 播报具体内容,不清空上次播报内容
        ///// </summary>
        ///// <param name="content">需播报的内容</param>
        //protected virtual void SpeakContentNoClear(object content)
        //{
        //    try
        //    {
        //        Speecher.GetInstance().SpeakContentNoClear(content.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //#endregion

        //#region 获取本机IP地址

        //public string GetLocalIp()
        //{
        //    //string hostname = Dns.GetHostName();//得到本机名   

        //    //IPHostEntry localhost = Dns.GetHostEntry(hostname);
        //    //IPAddress localaddr = localhost.AddressList[0];
        //    //return localaddr.ToString();

        //    //获取本地的IP地址
        //    string AddressIP = string.Empty;
        //    foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        //    {
        //        if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
        //        {
        //            AddressIP = _IPAddress.ToString();
        //        }
        //    }

        //    return AddressIP;
        //}
        //#endregion

        //#region [设置客户端信息]
        ///// <summary>
        ///// 设置是否默认勾选设备
        ///// </summary>
        ///// <param name="fileName"></param>
        //public void SetClientConfig(string fileName, CheckBox cbx_useDeviceComm)
        //{
        //    FileStream fs = new FileStream(fileName + ".bin", FileMode.OpenOrCreate);
        //    if (fs.Length > 0)
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        var clientConfig = bf.Deserialize(fs) as ClientConfig;
        //        cbx_useDeviceComm.Checked = clientConfig.EquipmentSelect;

        //    }
        //    fs.Close();
        //}
        ///// <summary>
        ///// 写配置
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="value"></param>
        //public void WriteClientConfig(string fileName, bool value)
        //{
        //    FileStream fs = new FileStream(fileName + ".bin", FileMode.Create);
        //    Models.ClientConfig config = new ClientConfig();
        //    config.EquipmentSelect = value;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(fs, config);
        //    fs.Close();
        //}
        #endregion

    }
}