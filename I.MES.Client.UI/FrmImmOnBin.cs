/*
 * 功能名称： 工位扫描
 * 功能描述： 通用的工序扫描界面
 * 创建人： 吴林锋
 * 创建日期： 2015-08-06
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using YFPO.MES.Client.UI;
using YFPO.MES.Models;
using YFPO.MES.Library;
using YFPO.MES.Tools;
using System.Linq;
using System.Threading;
using YFPO.MES.Client.UI.LGS;
using YFPO.MES.Client.UI.MFG;
using System.Diagnostics;
using YFPO.MES.Models.IF;

namespace YFPO.MES.Client.UI.MFG
{
    /// <summary>
    /// 注塑下线扫描窗体
    /// </summary>
    public partial class FrmImmOnBin : YFPO.MES.Client.UI.FrmBaseOpt
    {
        //属性
        private int intScanWait = 0;
        private ScanSiteInfo scansiteInfo = new ScanSiteInfo();
        private InjectionPlanOP injectionPlan = new InjectionPlanOP();
        private ProductBarcodeInfo barcodeInfo = null;
        private MFG_ProductScanCfg productScanCfg = null; //条码扫描配置
        private ProduceProcessInfo produceProcessInfo = null;
        //private MFG_Part newPart = new MFG_Part();
        private List<MFG_ScanAction> scanActions = new List<MFG_ScanAction>();
        private int timerCount = 0;
        private int time = 0;
        private int autoScanNextBarcode = 0;
        private bool isGetBumperRunning = false;
        private readonly PackageOP pkgOp = new PackageOP();
        private readonly WareHouseOP wareHouseOp = new WareHouseOP();
        private readonly TransferOrderOP toOp = new TransferOrderOP();
        private readonly ConfigOP configOP = new ConfigOP();
        private readonly IMMAutoOP immautoOp = new IMMAutoOP();
        //private SYS_GlobalConfig autoGlobalConfig;//是否打印下一个条码
        private SYS_GlobalConfig openBarPrint;//启用条码打印
        private LogInfoOP loginfo = new LogInfoOP();
        List<vHUPkg> currentHuPkgDet = new List<vHUPkg>();//正在打包信息
        private string dlgPackingType = string.Empty;
        private string ControlStatus = "";
        private string ControlStatusCode = "";
        private int isimmld = 0;//联动是否处理完成
        private bool IsAutomation = false;//开启和关闭住宿涂装自动化
        private Dictionary<string, int> PartWaitTime = new Dictionary<string, int>();
        public MonitordataTaskModel IMMData = new MonitordataTaskModel();
        public List<SYS_ExternalDeviceParam> edInParam = new List<SYS_ExternalDeviceParam>();
        public List<SYS_ExternalDeviceParam> edOutParam = new List<SYS_ExternalDeviceParam>();
        private readonly LinkAgeCDOP linkCDOp = new LinkAgeCDOP();
        private readonly ImmAutoBinOP autoBinOp = new ImmAutoBinOP();
        List<YFPO.MES.Models.MFG_BarcodeBinAutoLog> currentBarcodeDet = new List<YFPO.MES.Models.MFG_BarcodeBinAutoLog>();//正在下线的数据

        public FrmImmOnBin(SYS_Prog prog)
        {
            InitializeComponent();
            InitializeForm(); 
            scansiteInfo.prog = prog;
            scansiteInfo.currentUser = Program.currentUser;
            scansiteInfo.currentFactory = Program.currentFactory;
            scansiteInfo.Machine = BasicProperty.ClientInfo.Machine;

            this.Load += new System.EventHandler(this.FrmImmOnBin_Load);
            this.Text = "(" + prog.ProgCode + ")" + prog.ProgName + "-(" + scansiteInfo.currentUser.UserAccount + ")" + scansiteInfo.currentUser.UserName;
        }
        private void FrmImmOnBin_Load(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                DLG.FrmDlgGluingOffLineBoardCD frm = new DLG.FrmDlgGluingOffLineBoardCD(scansiteInfo); 
                frm.ShowDialog();

                if (frm.DialogResult != DialogResult.Yes)
                {
                    this.Close();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

                this.Show();
                this.timer_refresh.Enabled = true;
                resetControls();
                dlgPackingType = scansiteInfo.PackingType;  
                List<MFG_Part> parts = new PartOP().GetPartByProduceCategory(scansiteInfo.produceCategory.ProduceCtgyCode); 
                refreshGrid(); 
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnDoScan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBarcode.Text))
            { 
                BarScaned();
            }
        }
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != null && e.KeyCode != Keys.Return && e.KeyCode != Keys.Enter)
            { return; } 
            btnDoScan_Click(sender, e);
            
        }
        private void btn_exit_Click(object sender, EventArgs e)
        { 
            //timer_wait.Enabled = false;
            this.immAuto1.Active = false;  
            Back();
        }

        #region 界面控制
        private void InitializeForm()
        {
             
        }


         private void timer_refresh_Tick(object sender, EventArgs e)
        {
            refreshGrid();
        } 
        /// <summary>
        /// 载入正在下线的产品
        /// </summary>
        private void refreshGrid()
        { 
            try
            {
                this.timer_refresh.Enabled = false;

                autoBinOp.AutoBinIn(
                    scansiteInfo.currentScanSite.ScanSiteCode,
                    scansiteInfo.prodLine.ProdLineCode, scansiteInfo.PartCategoryCode);
                currentBarcodeDet = autoBinOp.GetAutoBinData(
                    scansiteInfo.currentScanSite.ScanSiteCode,
                    scansiteInfo.prodLine.ProdLineCode);
                c1FlexGrid1.DataSource = currentBarcodeDet;

                this.timer_refresh.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// 重置所有变量
        /// </summary>
        private void resetControls(bool clearPartInfo = true)
        {
            try
            {
                hideMessage();
                barcodeInfo = null;
                productScanCfg = null;
                produceProcessInfo = null;
                BtnForceOn.Enabled = false; 
                intScanWait = 0;

                timerCount = time;  
                dbCmd.Clear();
                dbActionCmd.Clear(); 
                this.txtBarcode.Text = string.Empty;
                this.txtBarcode.Focus(); 
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                ShowErrorDialog(ex.Message);
            }
        } 

        //重置窗口，用于重新扫描。
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.resetControls();
        }
        #endregion
        #region 事务逻辑
        private void BarScaned()
        {
            try
            {
                hideMessage();
                #region 条件检查及初始化 
                string scanedBarcode = this.txtBarcode.Text.Trim().ToUpper();
                     
                this.txtBarcode.Clear();  
                this.lblLastScanedBarcode.Text = barcodeInfo.Barcode; 
                #endregion 
                
                ////初始化条码
                barcodeInfo = productOp.GetProductBarcodeInfo(scanedBarcode);
                if (barcodeInfo == null || string.IsNullOrEmpty(barcodeInfo.Barcode))
                {
                    barcodeInfo = null;
                    ShowError("找不到你所扫描的条码");
                    return;
                }  
                if (barcodeInfo.IsIsolated)
                {
                    ShowError(string.Format("条码{0}已隔离", txtBarcode.Text.Trim()));
                    loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, string.Format("条码{0}已隔离", txtBarcode.Text.Trim()), BasicProperty.ClientInfo.Machine);
                    this.txtBarcode.Clear();
                    return;
                } 
                //Barcode, PartNo, PartVersion, QualityStatus, ScanSiteCode, RctStk, IssStk, BinCode, ControlStatus, 
                //FactoryCode, WCCode, ProdLineCode, CreateTime, CreateMachine, CreateUserAccount, IsDel, IsDelAfter, 
                //LogGUID, HUCode, RKCode
                Models.MFG_BarcodeBinAutoLog NewLog = new MFG_BarcodeBinAutoLog();
                NewLog.Barcode = barcodeInfo.Barcode;
                NewLog.PartNo = barcodeInfo.CurrentPartNo;
                NewLog.PartVersion = barcodeInfo.CurrentPartVersion;
                NewLog.QualityStatus = "1";
                NewLog.ScanSiteCode = scansiteInfo.currentScanSite.ScanSiteCode;
                NewLog.RctStk = "";
                NewLog.IssStk = "";
                NewLog.BinCode = "";
                NewLog.ControlStatus = "0";
                NewLog.FactoryCode = scansiteInfo.prodLine.FactoryCode;
                NewLog.WCCode =scansiteInfo.prodLine.WCCode ;
                NewLog.ProdLineCode = scansiteInfo.prodLine.ProdLineCode;
                NewLog.CreateMachine = "";
                NewLog.CreateUserAccount = "";
                NewLog.IsDel = false;
                NewLog.IsDelAfter = false;
                NewLog.HUCode = "";
                NewLog.RKCode = "";

                string msg = autoBinOp.CreateData(NewLog);
                if (!string.IsNullOrEmpty(msg))
                {
                    ShowError(msg);
                }
                else
                {
                    currentBarcodeDet = autoBinOp.GetAutoBinData(
                                      scansiteInfo.currentScanSite.ScanSiteCode,
                                      scansiteInfo.prodLine.ProdLineCode);
                    c1FlexGrid1.DataSource = currentBarcodeDet;
                }

            }
            catch (MESException ex)
            {
                 if(ConstInfo.ErrorMsgList.ContainsKey(ex.ErrorCode))
                 {
                     SpeakContent(ConstInfo.ErrorMsgList[ex.ErrorCode]);
                 } 
                resetControls(false);
                ShowError(ex.Message);
                //ShowErrorDialog(ex.Message);
            }
        } 

        public void CreateOutMouldLog(ProductBarcodeInfo barcode)
        {
            var scanLog = new BarcodeScanLogOP().GetLastBarcodeLog(scansiteInfo.currentScanSite.ScanSiteCode, scansiteInfo.prodLine.ProdLineCode);
            if (scanLog != null)
            {
                if (barcode.CurrentPartNo != scanLog.NewPartNo)
                {
                    var span = (DateTime.Now - scanLog.CreateTime);
                    int changeMouldTime = span.Days * 24 * 60 + span.Hours * 60 + span.Minutes;
                    var newMould = immautoOp.GetMouldPartMap(barcode.CurrentPartNo);
                    var upMould = immautoOp.GetMouldPartMap(scanLog.NewPartNo);
                    string newMouldCode = newMould == null ? "" : newMould.MouldCode;
                    string upMouldCode = upMould == null ? "" : upMould.MouldCode;

                    immautoOp.CreateOutMouldLog(new MFG_OutMouldLog()
                    {
                        ProdLineCode = scansiteInfo.prodLine.ProdLineCode,
                        ChangeMouldTime = changeMouldTime,
                        NewMouldCode = newMouldCode,
                        UpMouldCode = upMouldCode,
                        UpProductPartNo = scanLog.NewPartNo,
                        NewProductPartNo = barcode.CurrentPartNo,
                        NewPartNoProductTime = DateTime.Now
                    });
                }
            }
        }

        /// <summary>
        /// actionButton被点击后对条码的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doAction(object sender, EventArgs e)
        {
            try
            {
                timer_ok.Enabled = false;
                string msg = string.Empty;
                MFG_ScanAction action = ((Button)sender).Tag as MFG_ScanAction;
                #region Action的Plugin处理
                produceProcessInfo.scanAction = action;
                barcodeInfo.FlowType = cbxFlowType.SelectedValue == null ? "" : cbxFlowType.SelectedValue.ToString();

                if (!doActionPlugin(barcodeInfo, scansiteInfo, produceProcessInfo, ref msg))
                {
                    dbActionCmd.Clear();
                    //SpeakFailure();
                    ShowError(msg);
                    return;
                }
                #endregion

                #region 计算换模时间
                CreateOutMouldLog(barcodeInfo);
                #endregion

                #region 事务提交
                Transaction ts = new Transaction();
                ts.AddRange(dbCmd);
                ts.AddRange(dbActionCmd);
                ts.Commit();
                dbCmd.Clear();
                dbActionCmd.Clear();
                this.hideActionButton(); //隐藏Action按钮 
                #endregion
                #region 打包扫描
                try
                {
                    if (action.ActionCode.Equals(ConstInfo.MFG_ScanAction.IntoOK) || action.ActionCode.Equals(ConstInfo.MFG_ScanAction.IntoDdqOK))
                    {
                        if (cbxFlowType.SelectedValue.ToString() == "打包" || cbxFlowType.SelectedValue.ToString() == "纸箱")
                        {

                            barcodeInfo = productOp.GetProductBarcodeInfo(barcodeInfo.Barcode);
                            //设置打箱类型
                            string result = GetProduceProcessInfo();

                            this.timer_immAuto.Enabled = ckb_AutoWithIMM.Checked;

                            if (result != string.Empty)
                            {
                                resetControls(false);
                                ShowError("生产汇报成功。" + result);
                                //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "生产汇报成功。" + result, BasicProperty.ClientInfo.Machine);
                                return;
                            }
                            if (!DoPackage())
                            {
                                return;
                            }
                        }
                        else if (cbxFlowType.SelectedValue.ToString() == "直流")
                        {
                            //todo:作直流操作。手工做一笔移库操作
                            barcodeInfo = productOp.GetProductBarcodeInfo(barcodeInfo.Barcode);
                            this.CreateTOForDirectFlow();
                        }
                    }
                }
                catch (Exception ex)
                {
                    resetControls(false);
                    //SpeakFailure();
                    ShowError("汇报成功，打包或直流失败，请使用散件拼箱进行打包." + ex.Message);
                    loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "汇报成功，打包或直流失败，请使用散件拼箱进行打包." + ex.Message, BasicProperty.ClientInfo.Machine);
                    Logger.CurrentLog.Error("汇报成功，打包或直流失败，请使用散件拼箱进行打包." + ex.Message);
                    loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "汇报成功，打包或直流失败，请使用散件拼箱进行打包." + ex.Message, BasicProperty.ClientInfo.Machine);
                    return;
                }
                #endregion
                string nextPartNo = barcodeInfo.CurrentPartNo;
                this.timer_immAuto.Enabled = ckb_AutoWithIMM.Checked;
                var currentHU = pkgOp.GetHuPkgMstr(barcodeInfo.Barcode);
                if (barcodeInfo.newPart != null)
                {
                    //var currentHU = pkgOp.GetHuPkgMstr(barcodeInfo.Barcode);
                    if (currentHU != null)
                    {
                        SpeakContent(barcodeInfo.newPart.BriefDesc + Convert.ToInt32(currentHU.HUQty));
                    }
                    else
                    {
                        SpeakContent(barcodeInfo.currentPart.BriefDesc);
                    }
                }

                #region 重置界面
                resetControls();
                ShowMessage(action.ActionName + "操作成功!");
                SpeakSuccess();
                if (!ckb_AutoWithIMM.Checked)
                {
                    Application.DoEvents();
                    //是否打印下一个条码
                    MFG_ProdLine prodLine = new ScanSiteOP()
                        .GetProdLineByProdLineCode(scansiteInfo.prodLine.ProdLineCode, scansiteInfo.prodLine.ProdPlaceCode);

                    //autoGlobalConfig = configOP.GetGlobalCfg("BarPrintAuto", scansiteInfo.currentFactory.CompanyCode);
                    if (this.tx_print.Visible && (prodLine == null || prodLine.IsPrintBarcode == null || prodLine.IsPrintBarcode == true))
                    {
                        if (((List<MFG_Part>)cbxPrintParts.DataSource).Exists(p => p.PartNo == nextPartNo))
                        {
                            cbxPrintParts.SelectedValue = nextPartNo;
                        }
                        int waitTime = 0;
                        if (PartWaitTime.ContainsKey(nextPartNo))
                        {
                            waitTime = PartWaitTime[nextPartNo];
                        }
                        else
                        {
                            waitTime = immautoOp.GetWaitTime(nextPartNo);
                            PartWaitTime.Add(nextPartNo, waitTime);
                        }
                        if (waitTime >= 0)
                            Thread.Sleep(waitTime * 1000);
                        tx_print_Click(null, null);
                    }
                }
                txtBarcode.Focus();

                #endregion

            }
            catch (Exception ex)
            {
                dbActionCmd.Clear();
                dbCmd.Clear();
                ShowError(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 获得生产打包信息
        /// </summary>
        /// <returns></returns>
        private string GetProduceProcessInfo()
        {
            string rtn = "";
            //检查该产品当产是否有正在打箱的记录
            if (cbxFlowType.SelectedValue.ToString() == "打包" || cbxFlowType.SelectedValue.ToString() == "纸箱")
            {
                if (!string.IsNullOrEmpty(produceProcessInfo.HuCode) || !string.IsNullOrEmpty(produceProcessInfo.RackCode))
                {
                    return string.Empty;
                }
                currentHuPkgDet = pkgOp.GetCurrentPackingDet(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prodLine.WCCode, scansiteInfo.prodLine.ProdLineCode, 0, scansiteInfo.Machine);
                vHUPkg pkg = currentHuPkgDet.FirstOrDefault(p => p.PartNo == barcodeInfo.CurrentPartNo && p.PartVersion == barcodeInfo.newPart.PartVersion && p.QualityStatusCode == barcodeInfo.QualityStatus);
                if (pkg == null) //新产品打箱，需要用户扫描RK号
                {
                    if (cbxFlowType.SelectedValue.ToString() == "纸箱")
                    {
                        produceProcessInfo.PkgTypeCode = "CartonRack";
                        DLG.FrmDlgChoosePackageType frm = new DLG.FrmDlgChoosePackageType(barcodeInfo, scansiteInfo, produceProcessInfo);
                        if (frm.ShowDialog() != DialogResult.Yes)
                        {
                            rtn = "没有选择包装类型";
                            //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, rtn, BasicProperty.ClientInfo.Machine);
                        }
                    }
                    else
                    {
                        switch (scansiteInfo.PackingType)
                        {
                            case ConstInfo.PackageType.HU:
                                {
                                    DLG.FrmDlgChoosePackageType frm = new DLG.FrmDlgChoosePackageType(barcodeInfo, scansiteInfo, produceProcessInfo);
                                    if (frm.ShowDialog() != DialogResult.Yes)
                                    {
                                        rtn = "没有选择包装类型";
                                        //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, rtn, BasicProperty.ClientInfo.Machine);
                                    }
                                }
                                break;
                            case ConstInfo.PackageType.RK:
                                {
                                    DLG.FrmDlgInputRackNo frm = new DLG.FrmDlgInputRackNo(barcodeInfo, scansiteInfo, produceProcessInfo);
                                    if (frm.ShowDialog() != DialogResult.Yes)
                                    {
                                        rtn = "没有输入RK号";
                                        //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, rtn, BasicProperty.ClientInfo.Machine);
                                    }
                                }
                                break;
                            default:
                                rtn = "必须先执行包装方式才可进行打包操作";
                                //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, rtn, BasicProperty.ClientInfo.Machine);
                                break;
                        }
                    }
                }
                else
                {
                    produceProcessInfo.PkgTypeCode = pkg.PkgTypeCode;
                    produceProcessInfo.HuCode = pkg.HUCode;
                    produceProcessInfo.RackCode = pkg.RackCode;
                }
            }
            return rtn;
        }

        /// <summary>
        /// 创建并执行TO单
        /// </summary>
        /// <returns></returns>
        private bool CreateTO(string huCode, ref string errMsg)
        {
            errMsg = string.Empty;
            string tempTOGuid = "";
            try
            {
                //根据配置生成TO
                LGS_HUPkgMstr huPkgtmstr = pkgOp.GetHUPkgMstrByHUCode(huCode);
                LGS_ProdPkgTOCfg toConfigs = toOp.GetProdPkgTOCfg(huPkgtmstr, scansiteInfo);//todo  生产地点待定，暂时为空
                if (toConfigs != null)
                {
                    if (!string.IsNullOrEmpty(toConfigs.DestStkCode) && string.IsNullOrEmpty(toConfigs.DestWHCode))
                    {
                        List<string> orders = toOp.CreatePackageTO(toConfigs, scansiteInfo, new List<string>() { huPkgtmstr.HUCode }, true);
                        string toGuid = orders[0];
                        tempTOGuid = toGuid;
                        if (string.IsNullOrEmpty(toGuid))
                        {
                            errMsg = "打箱成功,但是生成TO失败";
                            loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                            ShowError(errMsg);

                            return false;
                        }
                        else
                        {
                            ShowMessage("打箱成功，生成TO成功！");

                            //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "打箱成功，生成TO成功！", BasicProperty.ClientInfo.Machine);
                        }
                        //检查配置自动执行TO
                        string toExecuteResult = toOp.ExecutTOMstrConfig(scansiteInfo, toGuid);
                        if (!string.IsNullOrEmpty(toExecuteResult))
                        {
                            if (toOp.CancelTOOrder(toGuid))
                            {
                                errMsg = "打箱成功，TO执行失败，原因:" + toExecuteResult + "，已取消TO单：" + toGuid;
                                loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                                ShowError(errMsg);
                            }
                            else
                            {
                                errMsg = "打箱成功，TO执行失败,原因:" + toExecuteResult + "，取消TO单：" + toGuid + "失败，请手动取消";
                                loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                                ShowError(errMsg);
                            }
                            return false;
                        }
                        else
                        {
                            ShowMessage("打箱成功，生成并执行TO成功！");
                            //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "打箱成功，生成并执行TO成功！", BasicProperty.ClientInfo.Machine);
                            return true;
                        }
                    }
                    else if (string.IsNullOrEmpty(toConfigs.DestStkCode) && !string.IsNullOrEmpty(toConfigs.DestWHCode))
                    {
                        if (!wareHouseOp.CreatePackageBinRequest(scansiteInfo, toConfigs, new List<string> { huCode }))
                        {
                            errMsg = huCode + "创建上架请求失败";
                            loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                            ShowError(errMsg);
                            return false;
                        }
                        else
                        {
                            ShowMessage(huCode + "创建上架请求成功！");
                            //loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, huCode + "创建上架请求成功！", BasicProperty.ClientInfo.Machine);
                            return true;
                        }
                    }
                    else
                    {
                        errMsg = "获取所需的TOCfg配置错误！请确保目标库位和目标仓库有且只有一个被配置";
                        loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                        ShowError(errMsg);
                        return false;
                    }
                }
                else
                {
                    errMsg = "打箱成功,TO配置不存在，" + huCode + "生成TO失败";
                    loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                    ShowError(errMsg);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(tempTOGuid))
                {
                    if (toOp.CancelTOOrder(tempTOGuid))
                    {
                        errMsg = "打箱成功，TO执行失败，原因:" + ex.Message + "，已取消TO单：" + tempTOGuid;
                        loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                        ShowError(errMsg);
                    }
                    else
                    {
                        errMsg = "打箱成功，TO执行失败,原因:" + ex.Message + "，取消TO单：" + tempTOGuid + "失败，请手动取消";
                        loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                        ShowError(errMsg);
                    }
                }
                else
                {
                    errMsg = "创建并执行上架请求异常,原因:" + ex.Message;
                    loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, errMsg, BasicProperty.ClientInfo.Machine);
                    ShowError(errMsg);
                }
                return false;
            }
        }

        /// <summary>
        /// 直流创建TO并执行
        /// </summary>
        /// <returns></returns>
        private bool CreateTOForDirectFlow()
        {
            string tempTOGuid = "";
            try
            {
                //根据配置生成TO                
                LGS_DirectFlowConfig toConfigs = toOp.GetDirectFlowCfg(barcodeInfo, scansiteInfo);
                if (toConfigs != null)
                {
                    var toMstr = toOp.CreateTOForDirectFlow(toConfigs, scansiteInfo, barcodeInfo, true);
                    if (toMstr != null)
                    {
                        tempTOGuid = toMstr.TOGuid;
                    }
                    else
                    {
                        ShowErrorDialog("生成TO失败!");
                        loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "生成TO失败!", BasicProperty.ClientInfo.Machine);
                        return false;
                    }
                    //检查配置自动执行TO
                    string toExecuteResult = toOp.ExecutTOMstrConfig(scansiteInfo, toMstr.TOGuid);
                    if (!string.IsNullOrEmpty(toExecuteResult))
                    {
                        if (toOp.CancelTOOrder(toMstr.TOGuid))
                        {
                            ShowErrorDialog("TO执行失败，原因:" + toExecuteResult + "，已取消TO单：" + toMstr.TOGuid);
                            loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "TO执行失败，原因:" + toExecuteResult + "，已取消TO单：" + toMstr.TOGuid, BasicProperty.ClientInfo.Machine);

                        }
                        else
                        {
                            ShowErrorDialog("TO执行失败,原因:" + toExecuteResult + "，取消TO单：" + toMstr.TOGuid + "失败，请手动取消");
                            loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "TO执行失败,原因:" + toExecuteResult + "，取消TO单：" + toMstr.TOGuid + "失败，请手动取消", BasicProperty.ClientInfo.Machine);
                        }
                        return false;
                    }
                }
                else
                {
                    ShowErrorDialog("直流TO配置不存在，" + barcodeInfo.Barcode + "生成TO失败");
                    loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "直流TO配置不存在，" + barcodeInfo.Barcode + "生成TO失败", BasicProperty.ClientInfo.Machine);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(tempTOGuid))
                {
                    if (toOp.CancelTOOrder(tempTOGuid))
                    {
                        ShowErrorDialog("TO执行失败，原因:" + ex.Message + "，已取消TO单：" + tempTOGuid);
                        loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "TO执行失败，原因:" + ex.Message + "，已取消TO单：" + tempTOGuid, BasicProperty.ClientInfo.Machine);
                    }
                    else
                    {
                        ShowErrorDialog("TO执行失败,原因:" + ex.Message + "，取消TO单：" + tempTOGuid + "失败，请手动取消");
                        loginfo.InsertErrorLogDB(scansiteInfo.currentFactory.FactoryCode, scansiteInfo.prog.ProgName, scansiteInfo.currentScanSite.ScanSiteCode, scanActions, scansiteInfo.currentUser.UserAccount, "TO执行失败,原因:" + ex.Message + "，取消TO单：" + tempTOGuid + "失败，请手动取消", BasicProperty.ClientInfo.Machine);
                    }
                }
            }
            return true;
        }  
  
        #region <<打印料箱单>>
        /// <summary>
        /// 打印料箱单
        /// </summary>
        /// <param name="PackingType">打包方式</param>
        /// <param name="RKCode"></param>
        /// <param name="HUCode"></param>
        /// <returns>移库单创建是否成功</returns>
        private bool Print(string PackingType, string RKCode, string HUCode)
        {
            string errmsg = string.Empty;
            bool createTO = true;
            bool createTOSuccess = true;
            if (PackingType == ConstInfo.BarcodeType.RK)
            {
                var huMstrs = pkgOp.GetHUPkgMstrByRKCode(RKCode).Where(p => p.IsSealed == false).ToList();
                if (huMstrs.Count > 0)
                {
                    createTO = false;
                }
            }
            if (createTO)
            {
                string factroy = scansiteInfo.currentFactory.FactoryCode.ToString();
                List<SYS_GlobalConfig> hasConfig = new ConfigOP().GetGlobalCfgs("IsUpChange", factroy);
                if (hasConfig.Count > 0)
                {
                    DLG.FrmDlgYesNo frm = new DLG.FrmDlgYesNo("是否移库或上架?");
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        createTOSuccess = CreateTO(HUCode, ref errmsg);
                    }
                }
                else
                {
                    createTOSuccess = CreateTO(HUCode, ref errmsg);
                }
                //

                //HU料箱单打印
                if (PackingType == ConstInfo.BarcodeType.HU)
                {
                    LGS_HUPkgMstr huPkgtmstr = pkgOp.GetHUPkgMstrByHUCode(HUCode);
                    var partNo = new PartOP().GetPart(huPkgtmstr.PartNo, huPkgtmstr.PartVersion);
                    new DocPrintOP().PrintLargeBox(new List<MFG_Part>() { partNo }, new List<LGS_HUPkgMstr>() { huPkgtmstr });
                }
                else if (PackingType == ConstInfo.BarcodeType.RK)
                {
                    new DocPrintOP().PrintRKBox(RKCode, scansiteInfo.currentFactory.FactoryCode);
                }
            }

            return createTOSuccess;
        }
        #endregion
        
        
        /// <summary>键盘区
        private void btn_virtualKeyBoard_Click(object sender, EventArgs e)
        {
            //openVirtualKeyboard(this.txt_barcode.Name, false);
            OpenSysVirtualKeyboard();
        } 

        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void ProdStatistics_Click(object sender, EventArgs e)
        {
            FrmProdStatistics frm = new FrmProdStatistics(scansiteInfo);
            frm.ShowDialog();
        }

        private void BarcodeControlStatus_Click(object sender, EventArgs e)
        {
            BarcodeControlStatus frm = new BarcodeControlStatus();
            frm.ShowDialog();

            ControlStatus = frm.ControlStatus;
            ControlStatusCode = frm.ControlStatusCode; 
        }

        private void btnQucikScan_Click(object sender, EventArgs e)
        { 
            btnDoScan_Click(sender, e);
            btnCancleOn.Visible = false;
            btnCancleOn.Enabled = false;
        }

        private void btn_Fraction_Click(object sender, EventArgs e)
        {
            try
            {
                DLG.FrmDlgFractionIntoOne frm = new DLG.FrmDlgFractionIntoOne(scansiteInfo);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    refreshGrid();
                }
            }
            catch
            {
                ShowError("零头拼箱操作失败");
            }
        } 

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SYS_Prog prog = new SYS_Prog
            {
                ProgCode = "MESScan.QCM.003",
                ProgForm = "FrmSuspectProdVerificationOperat"
            };

            QCM.FrmSuspectProdVerificationOperat frm = new QCM.FrmSuspectProdVerificationOperat(prog);

            frm.ShowDialog();
        }
         
    }

}