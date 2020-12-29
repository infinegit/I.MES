
using System.Collections.Generic;
using System.ComponentModel;
namespace I.MES.Tools
{
    public static class ConstInfo
    {

        #region 设备管理
        /// <summary>
        /// 报警类型
        /// </summary>
        public struct EMSAlarmType
        {
            /// <summary>
            /// 机修支持,创建EM工单
            /// </summary>
            public const string Equip = "Equip";
            /// <summary>
            /// 质量支持
            /// </summary>
            public const string Quality = "Quality";
            /// <summary>
            /// 模修支持
            /// </summary>
            public const string Mould = "Mould";
            /// <summary>
            /// 工艺支持
            /// </summary>
            public const string Technic = "Technic";
            /// <summary>
            /// 物流支持
            /// </summary>
            public const string Logistic = "Logistic";
            /// <summary>
            /// 生产支持
            /// </summary>
            public const string Product = "Product";
            /// <summary>
            /// 换模支持
            /// </summary>
            public const string Chgmold = "Chgmold";
            /// <summary>
            /// 物料支持
            /// </summary>
            public const string Materiel = "Materiel";
            /// <summary>
            /// 托盘车支持
            /// </summary>
            public const string TrayCar = "TrayCar";
        }
        /// <summary>
        /// 工单类型
        /// </summary>
        public struct EMSOrderType
        {
            /// <summary>
            /// EM工单
            /// </summary>
            public const string EM = "EM";
            /// <summary>
            /// PD工单
            /// </summary>
            public const string PD = "PD";
            /// <summary>
            /// PM工单
            /// </summary>
            public const string PM = "PM";
            /// <summary>
            /// IPQC巡检单
            /// </summary>
            public const string IPQC = "IPQC";
            /// <summary>
            /// PDCA工单
            /// </summary>
            public const string PDCA = "PDCA";
        }
        /// <summary>
        /// 通知单类型
        /// </summary>
        public struct EMSNoticeOrderType
        {
            /// <summary>
            /// PD、PM、CI工单
            /// </summary>
            public const string PD = "M1";
            /// <summary>
            /// EM工单
            /// </summary>
            public const string EM = "M2";
            /// <summary>
            /// 巡检通知单
            /// </summary>
            public const string IPQC = "M3";
        }
        /// <summary>
        /// 工单同步表类型
        /// </summary>
        public struct EMSSynOrderType
        {
            /// <summary>
            /// EM工单
            /// </summary>
            public const string EM = "ZPM2";
            /// <summary>
            /// PD工单
            /// </summary>
            public const string PD = "ZPM3";
        }

        /// <summary>
        /// 工单同步表类型
        /// </summary>
        public struct EMSWorkFlowAction
        {
            /// <summary>
            /// 维持生产
            /// </summary>
            public const string KeepProd = "KeepProd";
            /// <summary>
            /// 维修完成
            /// </summary>
            public const string MaintainComplete = "MaintainComplete";
            /// <summary>
            /// 正常关闭
            /// </summary>
            public const string Close = "Close";
            /// <summary>
            /// 下一步
            /// </summary>
            public const string Next = "Next";
            /// <summary>
            /// 不同意，生产PD工单
            /// </summary>
            public const string GoToPD = "GoToPD";
            /// <summary>
            /// 生成PD工单
            /// </summary>
            public const string CreatePD = "CreatePD";
            /// <summary>
            /// 退回
            /// </summary>
            public const string GoBack = "GoBack";
            /// <summary>
            /// 退回到创建
            /// </summary>
            public const string GoBackCreate = "GoBackCreate";
            /// <summary>
            /// 预执行PD\PM工单
            /// </summary>
            public const string PrePare = "PrePare";
            /// <summary>
            /// 取消预执行PD\PM工单
            /// </summary>
            public const string CancelPrePare = "CancelPrePare";
            /// <summary>
            /// 重做PD\PM工单
            /// </summary>
            public const string ReDo = "ReDo";
            /// <summary>
            /// 取消
            /// </summary>
            public const string Cancel = "Cancel";
            /// <summary>
            /// 跟着PD工单关闭
            /// </summary>
            public const string PDClose = "PDClose";
        }

        /// <summary>
        /// 工单同步表类型
        /// </summary>
        public struct EMSUserRoles
        {
            /// <summary>
            /// EMSDBZZ
            /// </summary>
            public const string EMSDBZZ = "EMSDBZZ";
            /// <summary>
            /// EMSEngineer
            /// </summary>
            public const string EMSEngineer = "EMSEngineer";
            /// <summary>
            /// EMSEngineerLead
            /// </summary>
            public const string EMSEngineerLead = "EMSEngineerLead";
            /// <summary>
            /// EMSMaintain
            /// </summary>
            public const string EMSMaintain = "EMSMaintain";
            /// <summary>
            /// EMSMaintainLead
            /// </summary>
            public const string EMSMaintainLead = "EMSMaintainLead";
            /// <summary>
            /// EMSProdLead
            /// </summary>
            public const string EMSProdLead = "EMSProdLead";
            /// <summary>
            /// 注塑班组长
            /// </summary>
            public const string ZS001 = "ZS001";
            /// <summary>
            /// 涂装班组长
            /// </summary>
            public const string TZ001 = "TZ001";
            /// <summary>
            /// 涂装班组长
            /// </summary>
            public const string ZP001 = "ZP001";
        }

        /// <summary>
        /// EM工单状态
        /// </summary>
        public enum EMSEMOrderStatus
        {
            /// <summary>
            /// 创建            
            /// </summary>
            Create = 1000,
            /// <summary>
            /// 人员到位           
            /// </summary>
            InPlace = 1001,
            /// <summary>
            /// 恢复生产            
            /// </summary>
            ResumeProd = 1002,
            /// <summary>
            /// 开始维修            
            /// </summary>
            StartMaintain = 2000,
            /// <summary>
            /// 维持生产
            /// </summary>
            KeepProd = 3000,
            /// <summary>
            /// 维修完成
            /// </summary>
            MaintainComplete = 4000,
            /// <summary>
            /// 维持生产维修工补充资料提交
            /// </summary>
            KepProdSubmit = 5000,
            /// <summary>
            /// 维修完成维修工补充资料提交
            /// </summary>
            MaintainCompleteSubmit = 6000,
            /// <summary>
            /// 工程师已审核，提交给主管工程师
            /// </summary>
            EngineerLeadAudit = 7000,
            /// <summary>
            /// 主管工程师审核同意，关闭
            /// </summary>
            Close = 9100,
            /// <summary>
            /// 维修工取消报修
            /// </summary>
            Cancel = 9200,
            /// <summary>
            /// 维持生产关闭，转成PD
            /// </summary>
            GoToPD = 9300,
            /// <summary>
            /// 不同意处理结果，转成PD
            /// </summary>
            CreatePD = 9400,
            /// <summary>
            /// 强制关闭
            /// </summary>
            ForceClose = 9500,
        }
        /// <summary>
        /// PD、PM、CI工单状态
        /// </summary>
        public enum EMSPDOrderStatus
        {
            /// <summary>
            /// 创建            
            /// </summary>
            Create = 1000,
            /// <summary>
            /// 工程师不认可处理结果，重回工单池
            /// </summary>
            GoBack = 1100,
            /// <summary>
            /// 预执行
            /// </summary>
            Prepare = 2000,
            /// <summary>
            /// 分配到维修工
            /// </summary>
            Allocation = 3000,
            /// <summary>
            /// 维修完成，维修工补充资料提交
            /// </summary>
            MaintainCompleteSubmit = 4000,
            /// <summary>
            /// 工程师已审核，提交给主管工程师
            /// </summary>
            EngineerLeadAudit = 5000,
            /// <summary>
            /// 主管工程师审核同意，关闭
            /// </summary>
            Close = 9100,
            /// <summary>
            /// 维修工取消报修
            /// </summary>
            PDCI = 9200,
            /// <summary>
            /// 生成PDCA
            /// </summary>
            ForceClose = 9300
        }
        /// <summary>
        /// 巡检通知单状态
        /// </summary>
        public enum EMSIPQCOrderStatus
        {
            /// <summary>
            /// 创建            
            /// </summary>
            Create = 1000,
            /// <summary>
            /// 生成PD工单审核中
            /// </summary>
            PDAudit = 2000,
            /// <summary>
            /// 工程师正常关闭
            /// </summary>
            Close = 9100,
            /// <summary>
            /// 转成PD关闭
            /// </summary>
            PDClose = 9200,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel = 9300,
        }
        /// <summary>
        /// 通知单状态
        /// </summary>
        public enum EMSNoticeOrderStatus
        {
            /// <summary>
            /// 创建
            /// </summary>
            Create = 1,
            /// <summary>
            /// 修改
            /// </summary>
            Update = 2,
            /// <summary>
            /// 完成
            /// </summary>
            Complete = 3
        }
        /// <summary>
        /// 通知单操作类型
        /// </summary>
        public enum EMSNoticeOperateType
        {
            /// <summary>
            /// 创建
            /// </summary>
            Create = 1,
            /// <summary>
            /// 修改
            /// </summary>
            Update = 2,
            /// <summary>
            /// 删除
            /// </summary>
            Delete = 3
        }

        #endregion

        #region 收货类型
        /// <summary>
        ///收货类型
        /// </summary>
        public struct ReceiveType
        {
            /// <summary>
            /// 采购订单收货-供应商
            /// </summary>
            public const string RecivePO_Vendor = "10";
            /// <summary>
            /// 采购订单收货-公司
            /// </summary>
            public const string RecivePO_Commpany = "11";
            /// <summary>
            /// 销售退货
            /// </summary>
            public const string ReceiveSD = "20";
            /// <summary>
            /// 转储收货-同公司不同工厂
            /// </summary>
            public const string ReceiveTO_UNFactory = "30";
            /// <summary>
            /// 转储收货-同工厂不同库位
            /// </summary>
            public const string ReceiveTO_Factory = "40";
        }
        #endregion

        #region 发货类型
        /// <summary>
        ///发货类型
        /// </summary>
        public struct DeliveryType
        {
            /// <summary>
            /// 采购订单退货-供应商退货
            /// </summary>
            public const string DeliveryPO_Vendor = "10";
            /// <summary>
            /// 采购订单退货-公司间退货
            /// </summary>
            public const string DeliveryPO_Company = "11";
            /// <summary>
            /// 采购订单退货-加驳发运
            /// </summary>
            public const string DeliveryPO_JB = "12";
            /// <summary>
            /// 发货单-非寄售加驳
            /// </summary>
            public const string DeliveryPO_FH = "13";
            /// <summary>
            /// 委外退货
            /// </summary>
            public const string DeliveryPO_Delegation = "15";
            /// <summary>
            /// 发货单-非寄售加驳
            /// </summary>
            public const string DeliveryPO_PUS = "16";
            /// <summary>
            /// 合资公司间发货单
            /// </summary>
            public const string DeliveryPO_JV = "18";
            /// <summary>
            /// 客户销售发运
            /// </summary>
            public const string DeliverySD_Cus = "20";
            /// <summary>
            /// 销售公司发运
            /// </summary>
            public const string DeliverySD_Company = "21";
            /// <summary>
            /// 公司间特殊交易
            /// </summary>
            public const string DeliverySD_ZOR7 = "21";
            /// <summary>
            /// 转储发运-备料发运
            /// </summary>
            public const string DeliveryTO_Prepare = "30";
            /// <summary>
            /// 转储发运-集中发运（BTO）
            /// </summary>
            public const string DeliveryTO_BTO = "31";
            /// <summary>
            /// 转储发运-工厂间移库
            /// </summary>
            public const string DeliveryTO_FactoryBtwTrans = "32";
            /// <summary>
            /// 转储发运-工厂间退货
            /// </summary>
            public const string DeliveryTO_FactoryBtwReturn = "33";
            /// <summary>
            /// 转储发运-工厂内转储
            /// </summary>
            public const string DeliveryTO_FactoryInsideTrans = "34";

            /// <summary>
            /// 转储发运-工厂间移库(采购订单自动转换成To移库单)
            /// </summary>
            public const string DeliveryTO_AutoFactoryBtwTrans = "35";

            /// <summary>
            /// 转储发运-内部配料(物料拉动产生的移库单)
            /// </summary>
            public const string DeliveryTO_MeterialPull = "36";
            /// <summary>
            /// 排序发运
            /// </summary>
            public const string DeliverySort = "40";
        }
        #endregion

        #region 采购退货单状态
        /// <summary>
        /// 采购退货单状态,LGS_DeliveryMstr-OrderStatus
        /// </summary>
        public struct DeliveryMstrStatus
        {
            /// <summary>
            /// 供应商退货
            /// </summary>
            public const string PurSaleReturn = "10";
            /// <summary>
            /// 公司间退货
            /// </summary>
            public const string FactoryReturn = "11";
            /// <summary>
            /// 加驳销售
            /// </summary>
            public const string BargeReturn = "12";
            /// <summary>
            /// 非寄售加驳
            /// </summary>
            public const string SaleRec = "13";

            /// <summary>
            /// 寄售冲销
            /// </summary>
            public const string JxRev = "14";
            /// <summary>
            /// 委外退货
            /// </summary>
            public const string DelegationReturn = "15";
        }
        #endregion

        #region 销售退货状态
        /// <summary>
        /// 销售退货状态
        /// </summary>
        public struct SORetuanStatus
        {
            /// <summary>
            /// 开启订单
            /// </summary>
            [Description("打开")]
            public const string OPEN = "OPEN";

            /// <summary>
            /// 关闭订单
            /// </summary>
            [Description("关闭")]
            public const string Close = "Close";
        }
        #endregion

        #region [预装配排序状态]
        public struct SeqItemStatus
        {
            /// <summary>
            /// 未排序生产
            /// </summary>
            public const string UnHandled = "0";
            /// <summary>
            /// 预排序正常完成
            /// </summary>
            public const string Done = "1";
            /// <summary>
            /// 装配完成
            /// </summary>
            public const string Assembly = "2";
            /// <summary>
            /// 已跳过
            /// </summary>
            public const string Skipped = "9";
        }
        #endregion

        #region 排序装配计划类型
        /// <summary>
        ///计划类型
        /// </summary>
        public struct PreAssemblyType
        {
            /// <summary>
            ///全部
            /// </summary>
            [Description("全部")]
            public const string ALL = "0";
            /// <summary>
            /// 排序计划
            /// </summary>
            [Description("排序计划")]
            public const string JISPlan = "1";
           
            /// <summary>
            /// 手工计划
            /// </summary>
            [Description("手工计划")]
            public const string Manual = "2";

        }
        #endregion

        #region 发货配置库位订单类型
        /// <summary>
        ///发货配置库位订单类型
        /// </summary>
        public struct CustStkConfigOrderType
        {
            /// <summary>
            /// 排序发运
            /// </summary>
            [Description("排序发运")]
            public const string JIS = "01";

            /// <summary>
            /// 加拨发运
            /// </summary>
            [Description("加拨发运")]
            public const string JB = "02";

            /// <summary>
            /// 销售发运
            /// </summary>
            [Description("销售发运")]
            public const string So = "04";

            /// <summary>
            /// 销售退货
            /// </summary>
            [Description("销售退货")]
            public const string SoReturn = "05";
            /// <summary>
            /// DD发运
            /// </summary>
            [Description("DD发运")]
            public const string DD = "06";
            /// <summary>
            /// 采购退货
            /// </summary>
            [Description("采购退货")]
            public const string SaReturn = "07";
            /// <summary>
            /// 供应商条码退货（类似东风彼欧与江夏工厂之间的退货）
            /// </summary>
            [Description("供应商条码退货")]
            public const string BarcodeReturn = "08";
        }
        #endregion

        #region 条码状态
        /// <summary>
        /// 包装条码状态,包装表中对应PackageStatus
        /// 物流状态
        /// </summary>
        public struct PackageStatus
        {
            /// <summary>
            /// 待收货
            /// </summary>
            [Description("待收货")]
            public const string Receiptgoods = "10";
            /// <summary>
            /// 正常
            /// </summary>
            [Description("正常")]
            public const string Normal = "20";
            /// <summary>
            /// 已出库
            /// </summary>
            [Description("已出库")]
            public const string AlreadyShip = "30";
            /// <summary>
            /// 移库冻结
            /// </summary>
            [Description("移库冻结")]
            public const string ToFrozen = "40";

            /// <summary>
            /// 料箱终结
            /// </summary>
            [Description("料箱终结")]
            public const string End = "99";
        }

        /// <summary>
        /// 产品条码状态,产品表中对应BarcodeStatus
        /// 物流状态
        /// </summary>
        public struct BarcodeStatus
        {
            /// <summary>
            /// 待收货
            /// </summary>
            //[Description("初始化")]  
            //public const string Init = "10";

            /// <summary>
            /// 待收货
            /// </summary>
            [Description("待收货")]
            public const string Received = "10";

            /// <summary>
            /// 正常
            /// </summary>
            [Description("正常")]
            public const string Normal = "20";
            /// <summary>
            /// 已出库
            /// </summary>
            [Description("已出库")]
            public const string AlreadyShip = "30";
            /// <summary>
            /// 移库冻结
            /// </summary>
            [Description("移库冻结")]
            public const string ToFrozen = "40";
            /// <summary>
            /// 客户安全发运
            /// </summary>
            [Description("客户安全发运")]
            public const string CustSafeSend = "50";

           
 
            /// <summary>
            /// 条码终结
            /// </summary>
            [Description("条码终结")]
            public const string End = "99";
        }
        /// <summary>
        /// 收货配置条码移动类型
        /// </summary>
        public struct RecCfgType
        {
            /// <summary>
            /// 不处理
            /// </summary>
            [Description("不处理")]
            public const string NoAction = "10";
            /// <summary>
            /// 上架
            /// </summary>
            [Description("上架")]
            public const string UpBin = "20";
            /// <summary>
            /// 移库
            /// </summary>
            [Description("移库")]
            public const string Move = "30";
        }
        /// <summary>
        /// 待评审不合格原因
        /// </summary>
        public struct QualityReviewPendingCause
        {
            public const string Scrap = "Scrap";

            public const string Defect = "Defect";

            public const string Return = "Return";
        }

        /// <summary>
        /// 产品质量状态
        /// 料箱与产品条码通用
        /// </summary>
        public struct QualityStatus
        {
            /// <summary>
            /// 合格
            /// </summary>
            [Description("合格")]
            public const string OK = "1";
            /// <summary>
            /// 冻结
            /// </summary>
            [Description("冻结")]
            public const string FREEZE = "2";
            /// <summary>
            /// 待报废
            /// </summary>
            [Description("待报废")]
            public const string ScrapPending = "3";
            /// <summary>
            /// 已报废
            /// </summary>
            [Description("已报废")]
            public const string Scrap = "9";
            /// <summary>
            /// 待退货
            /// </summary>
            [Description("待退货")]
            public const string ReturnPending = "4";
            /// <summary>
            /// 已退货
            /// </summary>
            [Description("已退货")]
            public const string Return = "8";
            /// <summary>
            /// W2
            /// </summary>
            [Description("W2")]
            public const string W2 = "5";
            /// <summary>
            /// 待检
            /// </summary>
            [Description("待检")]
            public const string QCPending = "6";
        }
        /// <summary>
        /// 库存质量状态 
        /// 对应表：QCM_StkQualityStatus
        /// </summary>
        public struct StkQualityStatus
        {
            /// <summary>
            /// 非限制
            /// </summary>
            public const string OK = "OK";
            /// <summary>
            /// 冻结
            /// </summary>
            public const string FREEZE = "FREEZE";
            /// <summary>
            /// 待检
            /// </summary>
            public const string QCPEND = "QCPEND";
        }
        #endregion

        #region 过点信息拉动状态
        /// <summary>
        /// 表【LGS_JISPointInfo】过点信息拉动状态
        /// </summary>
        public struct PullStatus
        {
            /// <summary>
            /// 信息接入时初始值
            /// </summary>
            [Description("初始值")]
            public const int Initial = 0;
            /// <summary>
            /// 打印过点信息（20点信息）
            /// </summary>
            [Description("打印")]
            public const int Print = 1;
            /// <summary>
            /// 扫描bongding1或bongding2（20点信息）
            /// </summary>
            [Description("绑定1或绑定2")]
            public const int BongDing1_2 = 2;
            /// <summary>
            /// 扫描bongding3（20点信息）
            /// </summary>
            [Description("绑定3")]
            public const int BongDing3 = 3;
            /// <summary>
            /// 已拉动（50点信息）
            /// </summary>
            [Description("已拉动")]
            public const int ExecPull = 4;
            /// <summary>
            /// 已删除的拉动信息（50点信息）
            /// </summary>
            [Description("已删除的拉动信息")]
            public const int DeletePull = 5;
        }
        #endregion
        /// <summary>
        /// 立体库模式
        /// </summary>
        public struct AutoWHMode
        {
            /// <summary>
            /// 入库模式
            /// </summary>
            public const string PalletIn = "KI";

            /// <summary>
            /// 正常模式
            /// </summary>
            public const string Normal = "O";
        }
        /// <summary>
        /// ScanStage生产扫描阶段
        /// </summary>
        public struct ScanStage
        {
            /// <summary>
            /// 预处理PreRequisition
            /// </summary>
            public const string PreRequisition = "PreRequisition";
            /// <summary>
            /// 扫描Scan
            /// </summary>
            public const string Scan = "Scan";
            /// <summary>
            /// Action
            /// </summary>
            public const string Action = "Action";
            /// <summary>
            /// PostAction
            /// </summary>
            public const string PostAction = "PostAction";
            /// <summary>
            /// SeqAction
            /// </summary>
            public const string SeqAction = "SeqAction";
        }
        /// <summary>
        /// 出门证明细状态
        /// </summary>
        public struct CMZInfoStatus
        {
            /// <summary>
            /// 初始化
            /// </summary>
            public const int Init = 0;
            /// <summary>
            /// 部分完成
            /// </summary>
            public const int Depart = 1;

            /// <summary>
            /// 完成
            /// </summary>
            public const int Finish = 2;

            /// <summary>
            /// 完成
            /// </summary>
            public const int Close = 2;
            /// <summary>
            /// 数据生成
            /// </summary>
            public const int Insert = 3;
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public struct SOOrderstatus
        {
            /// <summary>
            /// 关闭订单
            /// </summary>
            public const string Closed = "Closed";
            /// <summary>
            /// 开启订单
            /// </summary>
            public const string Open = "Open";
        }
        /// <summary>
        /// 出门证订单类型
        /// </summary>
        public struct CMZOrderType
        {
            /// <summary>
            /// 排序
            /// </summary>
            public const string JIS = "JIS";
            /// <summary>
            /// 销售
            /// </summary>
            public const string SO = "SO";

            /// <summary>
            /// 加拨
            /// </summary>
            public const string JB = "JB";

            /// <summary>
            ///采购退货
            /// </summary>
            public const string POReturn = "POReturn";
           // public const string CompanyReturn = "CompanyReturn";

            /// <summary>
            ///公司间退货
            /// </summary>
            public const string CompanyReturn = "CompanyReturn";

        }

        #region tsla enum
        /// <summary>
        /// pick state
        /// </summary>
        public struct PickState
        {
            /// <summary>
            /// Free
            /// </summary>
            [Description("Free")]
            public const string Free = "Free";

            /// <summary>
            /// Picking
            /// </summary>
            [Description("Picking")]
            public const string Picking = "Picking";  
        }
        #endregion

        #region[出门证状态]
        /// <summary>
        /// 出门证状态
        /// </summary>
        public struct CMZStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            [Description("正常")]
            public const string Normal = "0";
            /// <summary>
            //撤销
            /// </summary>
            [Description("撤销")]
            public const string Cancel = "1";
        }
        #endregion

        #region 工序扫描
        /// <summary>
        /// 打包方式
        /// </summary>
        public struct PackageType
        {
            /// <summary>
            /// HU
            /// </summary>
            [Description("HU")]
            public const string HU = "HU";
            /// <summary>
            /// RK
            /// </summary>
            [Description("RK")]
            public const string RK = "RK";
        }
        /// <summary>
        /// TO状态
        /// </summary>
        public struct TOStatus
        {
            /// <summary>
            /// 创建
            /// </summary>
            [Description("创建")]
            public const string Create = "1000";
            /// <summary>
            /// 确认
            /// </summary>
            [Description("确认")]
            public const string Confirm = "2000";
            /// <summary>
            /// 部分完成
            /// </summary>
            [Description("部分完成")]
            public const string ParticalComplete = "5000";
            /// <summary>
            /// 关闭
            /// </summary>
            [Description("关闭")]
            public const string Close = "9000";
            /// <summary>
            /// 取消
            /// </summary>
            [Description("取消")]
            public const string Cancel = "9100";
        }
        /// <summary>
        /// 条码类型
        /// </summary>
        public struct BarcodeType
        {
            /// <summary>
            /// RK
            /// </summary>
            public const string RK = "RK";
            /// <summary>
            /// HU
            /// </summary>
            public const string HU = "HU";
            /// <summary>
            /// TP
            /// </summary>
            public const string TP = "TP";
            /// <summary>
            /// Product
            /// </summary>
            public const string Product = "Product";
            /// <summary>
            /// EmptyRK:空RK
            /// </summary>
            public const string EmptyRK = "EmptyRK";
            /// <summary>
            /// PartNo
            /// </summary>
            public const string PartNo = "PartNo";
        }
        /// <summary>
        /// LGS_HUPkgLog记录OpType
        /// </summary>
        public enum HUPkgLogOpType
        {
            /// <summary>
            /// 打箱
            /// </summary>
            [Description("打箱")]
            Package = 1,
            /// <summary>
            /// 掏箱
            /// </summary>
            [Description("掏箱")]
            Open = 2,
            /// <summary>
            /// RK清空
            /// </summary>
            [Description("RK清空")]
            ClearRK = 3,
            /// <summary>
            /// 散件拼箱
            /// </summary>
            [Description("散件拼箱")]
            SpareIntoHU = 4,
            /// <summary>
            /// 发运
            /// </summary>
            [Description("发运")]
            Ship = 5,

            /// <summary>
            /// 收货
            /// </summary>
            [Description("收货")]
            Revice = 6,

            /// <summary>
            /// 小件入库
            /// </summary>
            [Description("小件入库")]
            XJDown = 7,

            /// <summary>
            /// 小件冲销
            /// </summary>
            [Description("小件冲销")]
            XJRev = 8,

            // <summary>
            /// 整箱拆解
            /// </summary>
            [Description("整箱拆解")]
            PkgDis = 9,
            /// <summary>
            /// 隔离
            /// </summary>
            [Description("隔离")]
            Isolated = 10,
            /// <summary>
            /// 反隔离
            /// </summary>
            [Description("反隔离")]
            IsolatedRev = 11,
            /// <summary>
            /// 释放
            /// </summary>
            [Description("释放")]
            Desponse = 12,
            /// <summary>
            /// 打印
            /// </summary>
            [Description("打印")]
            Print = 13,
             /// <summary>
            /// 释放
            /// </summary>
            [Description("收货清除历史RK与HU的绑定关系")]
            CleanHistoryRK = 14,
            /// <summary>
            /// HU防错
            /// </summary>
            [Description("粒子上料时,扫HU和料箱号防错")]
            HuPokayoke = 15,
            /// <summary>
            /// 满箱后自动封箱
            /// </summary>
            [Description("满箱后自动封箱")]
            AutoSealed = 20,
            /// <summary>
            /// 强制手工封箱
            /// </summary>
            [Description("强制手工封箱")]
            ForceSealed = 21
        }

        /// <summary>
        /// MFG_BarcodeScanLog记录OpType
        /// </summary>
        public enum BarcodeScanLogOpType
        {
            /// <summary>
            /// 收货
            /// </summary>
            [Description("收货")]
            Recive = 5,
            /// <summary>
            /// 发运
            /// </summary>
            [Description("发运")]
            Delivery = 6,
            /// <summary>
            /// 隔离
            /// </summary>
            [Description("隔离")]
            Isolated = 10,
            /// <summary>
            /// 反隔离
            /// </summary>
            [Description("反隔离")]
            IsolatedRev = 11,
            /// <summary>
            /// 标记盘点
            /// </summary>
            [Description("标记盘点")]
            SetStock = 13,
            /// <summary>
            /// 条码回收
            /// </summary>
            [Description("条码回收")]
            Recyle = 15,
            /// <summary>
            /// 条码移库冲销
            /// </summary>
            [Description("条码移库冲销")]
            BarcodeTORev = 20,
            /// <summary>
            /// 条码协同退回
            /// </summary>
            [Description("条码协同退回")]
            BarcodeTXReturn = 30,
            /// <summary>
            /// 条码协同退回接收
            /// </summary>
            [Description("条码协同退回接收")]
            BarcodeTXReturnRev = 31,
            /// <summary>
            /// 不合格评审过账
            /// </summary>
            [Description("不合格评审过账")]
            UnqualifiedReview = 40
        }

        /// <summary>
        /// 生产计划单状态
        /// </summary>
        public struct ProduceScheduleStatus
        {
            /// <summary>
            /// 开放
            /// </summary>
            public const string Open = "Open";
            /// <summary>
            /// 关闭
            /// </summary>
            public const string Close = "Close";
            /// <summary>
            /// 取消
            /// </summary>
            public const string Cancle = "Cancle";
        }
        #endregion

        #region 库存管理

        /// <summary>
        /// 库存管理状态码
        /// </summary>
        public struct StkMngStatusCode
        {
            /// <summary>
            /// 正常件
            /// </summary>
            public const string Normal = "0";
            /// <summary>
            /// 委外
            /// </summary>
            public const string Delegation = "1";
            /// <summary>
            /// 寄售
            /// </summary>
            public const string Consign = "2";


        }
        /// <summary>
        /// 库位类型
        /// </summary>
        public struct StkType
        {
            /// <summary>
            /// 委外
            /// </summary>
            public const string Delegation = "Delegation";
            /// <summary>
            /// 正常
            /// </summary>
            public const string Normal = "Normal";
            /// <summary>
            /// 在途
            /// </summary>
            public const string InTransit = "InTransit";
            /// <summary>
            /// 客户安全
            /// </summary>
            public const string CustSafe = "CustSafe";

        }
        /// <summary>
        /// 库存转移类型
        /// </summary>
        public struct StkTransType
        {
            /// <summary>
            /// BTO发运
            /// </summary>
            [Description("BTO发运")]
            public const string BTO = "BTO";
            /// <summary>
            /// 打磨
            /// </summary>
            [Description("打磨")]
            public const string Burnish = "Burnish";
            /// <summary>
            /// 成本中心领用
            /// </summary>
            [Description("成本中心领用")]
            public const string CostCenterConsume = "CostCenterConsume";
            /// <summary>
            /// 成本中心领用-冲销
            /// </summary>
            [Description("成本中心领用-冲销")]
            public const string CostCenterConsumeRev = "CostCenterConsumeRev";
            /// <summary>
            /// 盘点调整-盘亏
            /// </summary>
            [Description("盘点调整-盘亏")]
            public const string InvAdjustInvLoss = "InvAdjustInvLoss";
            /// <summary>
            /// 盘点调整-盘盈
            /// </summary>
            [Description("盘点调整-盘盈")]
            public const string InvAdjustInvProv = "InvAdjustInvProv";
            /// <summary>
            /// 管理状态调整(寄售->非寄售）
            /// </summary>
            [Description("管理状态调整(寄售->非寄售）")]
            public const string MngStatusConv = "MngStatusConv";
            /// <summary>
            /// 管理状态调整(寄售->非寄售)-冲销
            /// </summary>
            [Description("管理状态调整(寄售->非寄售)-冲销")]
            public const string MngStatusConvRev = "MngStatusConvRev";
            /// <summary>
            /// 零件号转换
            /// </summary>
            [Description("零件号转换")]
            public const string PartConv = "PartConv";
            /// <summary>
            /// 零件号转换-冲销
            /// </summary>
            [Description("零件号转换-冲销")]
            public const string PartConvRev = "PartConvRev";
            /// <summary>
            /// 采购收货
            /// </summary>
            [Description("采购收货")]
            public const string PO = "PO";
            /// <summary>
            /// 采购收货冲销
            /// </summary>
            [Description("采购收货冲销")]
            public const string PORev = "PORev";
            /// <summary>
            /// 采购退货
            /// </summary>
            [Description("采购退货")]
            public const string POReject = "POReject";
            /// <summary>
            /// 采购退货冲销
            /// </summary>
            [Description("采购退货冲销")]
            public const string PORejectRev = "PORejectRev";
            /// <summary>
            /// 工序报废
            /// </summary>
            [Description("工序报废")]
            public const string ProcScrap = "ProcScrap";
            /// <summary>
            /// 工序报废-冲销
            /// </summary>
            [Description("工序报废-冲销")]
            public const string ProcScrapRev = "ProcScrapRev";
            /// <summary>
            /// 生产汇报
            /// </summary>
            [Description("生产汇报")]
            public const string ProdDeclar = "ProdDeclar";
            /// <summary>
            /// 质量状态转汇报
            /// </summary>
            [Description("质量状态转汇报")]
            public const string QualityConv = "QualityConv";
            /// <summary>
            /// 排序出库
            /// </summary>
            [Description("排序出库")]
            public const string SeqSO = "SeqSO";
            /// <summary>
            /// 销售出库
            /// </summary>
            [Description("销售出库")]
            public const string SO = "SO";
            /// <summary>
            /// 销售退回
            /// </summary>
            [Description("销售退回")]
            public const string SOReject = "SOReject";
            /// <summary>
            /// 销售退回-冲销
            /// </summary>
            [Description("销售退回-冲销")]
            public const string SoRejectRev = "SoRejectRev"; 
            /// <summary>
            /// 公司间交易-Z003发货
            /// </summary>
            [Description("公司间交易-Z003发货")]
            public const string SynInterCompDev = "SynInterCompDev";
            /// <summary>
            /// 公司间交易-Z003发货冲销
            /// </summary>
            [Description("公司间交易-Z003发货冲销")]
            public const string SynInterCompDevRev = "SynInterCompDevRev";
            /// <summary>
            /// 库存报废
            /// </summary>
            [Description("库存报废")]
            public const string StkScrap = "StkScrap";
            /// <summary>
            /// 库存报废(项目费用)
            /// </summary>
            [Description("库存报废(项目费用)")]
            public const string STkScrapProject = "STkScrapProject";
            /// <summary>
            /// 库存报废(项目费用)-冲销
            /// </summary>
            [Description("库存报废(项目费用)-冲销")]
            public const string STkScrapProjectRev = "STkScrapProjectRev";
            /// <summary>
            /// 库存报废-冲销
            /// </summary>
            [Description("库存报废-冲销")]
            public const string StkScrapReverse = "StkScrapReverse";
            /// <summary>
            /// 一步法移库
            /// </summary>
            [Description("一步法移库")]
            public const string TO1Step = "TO1Step";
            /// <summary>
            /// 两步法移库
            /// </summary>
            [Description("两步法移库")]
            public const string TO2Step = "TO2Step";
            /// <summary>
            /// 一步法移库--冲销
            /// </summary>
            [Description("一步法移库冲销")]
            public const string TO1StepRev = "TO1StepRev";
            /// <summary>
            /// 两步法移库--冲销
            /// </summary>
            [Description("两步法移库冲销")]
            public const string TO2StepRev = "TO2StepRev";
            /// <summary>
            /// 加驳单出库
            /// </summary>
            [Description("加驳单出库")]
            public const string UnPlanedOrder = "UnPlanedOrder";

            /// <summary>
            /// 交货单出库
            /// </summary>
            [Description("交货单出库")]
            public const string PlanedOrder = "PlanedOrder";
            /// <summary>
            /// 交货确认
            /// </summary>
            [Description("交货确认")]
            public const string DeliveryConfirm = "DeliveryConfirm";
            /// <summary>
            /// 交货确认-冲销
            /// </summary>
            [Description("交货确认-冲销")]
            public const string DeliveryConfirmRev = "DeliveryConfirmRev";
            /// <summary>
            /// 退货调整
            /// </summary>
            [Description("退货调整")]
            public const string SRAdjust = "SRAdjust";
            /// <summary>
            /// 退货调整-冲销
            /// </summary>
            [Description("退货调整-冲销")]
            public const string SRAdjustRev = "SRAdjustRev";
            /// <summary>
            /// W2件转换
            /// </summary>
            [Description("W2件转换")]
            public const string W2 = "W2";
            /// <summary>
            /// 装配反冲（AsmBackFlush）
            /// </summary>
            [Description("装配反冲")]
            public const string AsmBackFlush = "AsmBackFlush";
            /// <summary>
            /// 装配反冲-冲销（AsmBackFlushRev）
            /// </summary>
            [Description("装配反冲-冲销")]
            public const string AsmBackFlushRev = "AsmBackFlushRev";
            /// <summary>
            /// 零件反冲投料（PartBackFlush)
            /// </summary>
            [Description("零件反冲投料")]
            public const string PartBackFlush = "PartBackFlush";
            /// <summary>
            /// 零件反冲投料-冲销(PartBackFlushRev)
            /// </summary>
            [Description("零件反冲投料-冲销")]
            public const string PartBackFlushRev = "PartBackFlushRev";
            /// <summary>
            /// 拆解(DisAsm)
            /// </summary>
            [Description("拆解")]
            public const string DisAsm = "DisAsm";
            /// <summary>
            /// 拆解-冲销(DisAsmRev)
            /// </summary>
            [Description("拆解-冲销")]
            public const string DisAsmRev = "DisAsmRev";
            /// <summary>
            /// 生产汇报-冲销
            /// </summary>
            [Description("生产汇报-冲销")]
            public const string ProdDeclarRev = "ProdDeclarRev";

            /// <summary>
            /// 生产订单收货
            /// </summary>
            [Description("生产订单收货")]
            public const string WOBackFlushRct = "WOBackFlushRct";

            /// <summary>
            /// 生产订单投料
            /// </summary>
            [Description("生产订单投料")]
            public const string WOBackFlushIss = "WOBackFlushIss";
            /// <summary>
            /// 手工移库事务一步法
            /// </summary>
            [Description("手工移库事务一步法")]
            public const string ManualTO1Step = "ManualTO1Step";
            /// <summary>
            /// 手工移库事务两步法
            /// </summary>
            [Description("手工移库事务两步法")]
            public const string ManualTO2Step = "ManualTO2Step";
            /// <summary>
            /// 手工移库事务一步法-冲销
            /// </summary>
            [Description("手工移库事务一步法-冲销")]
            public const string ManualTO1StepRev = "ManualTO1StepRev";
            /// <summary>
            /// 手工移库事务两步法-冲销
            /// </summary>
            [Description("手工移库事务两步法-冲销")]
            public const string ManualTO2StepRev = "ManualTO2StepRev";
            /// <summary>
            /// 不合格评审报废
            /// </summary>
            [Description("不合格评审报废")]
            public const string ReviewScrap = "ReviewScrap";
            /// <summary>
            /// 不合格评审退货
            /// </summary>
            [Description("不合格评审退货")]
            public const string ReviewReject = "ReviewReject";
            /// <summary>
            /// 维修备件领用
            /// </summary>
            [Description("维修备件领用")]
            public const string SparePartConsume = "SparePartConsume";
            /// <summary>
            /// 维修备件领用-冲销
            /// </summary>
            [Description("维修备件领用-冲销")]
            public const string SparePartConsumeRev = "SparePartConsumeRev";
            /// <summary>
            /// 工作流直接过账
            /// </summary>
            [Description("工作流直接过账")]
            public const string WFMDirectPost = "WFMDirectPost";
            /// <summary>
            /// 工作流直接过账-反冲
            /// </summary>
            [Description("工作流直接过账-反冲")]
            public const string WFMDirectPostRev = "WFMDirectPostRev";
            /// <summary>
            /// 工作流领料出库
            /// </summary>
            [Description("工作流领料出库")]
            public const string WFMMaterialReq = "WFMMaterialReq";

            /// <summary>
            ///寄售冲销
            /// </summary>
            [Description("寄售冲销")]
            public const string SORev = "SORev";
            /// <summary>
            /// 公司间内部交易（夸库在途账调整）
            /// </summary>
            public const string Intercompany = "Intercompany";
            /// <summary>
            /// 公司间工厂间退货的修改
            /// </summary>
            public const string SynReturn = "SynReturn";
        }

        /// <summary>
        /// BIN位改变类型
        /// </summary>
        public struct BinChangeType
        {
            /// <summary>
            /// 上架
            /// </summary>
            [Description("上架")]
            public const string UpBin = "UpBin";
            /// <summary>
            /// 下架
            /// </summary>
            [Description("下架")]
            public const string DownBin = "DownBin";

            /// <summary>
            /// TS上架
            /// </summary>
            [Description("TS上架")]
            public const string TSUpBin = "TSUpBin";
            /// <summary>
            /// TS下架
            /// </summary>
            [Description("TS下架")]
            public const string TSDownBin = "TSDownBin";
        }
        /// <summary>
        /// 上下架请求单状态
        /// </summary>
        public struct BinRequestStatus
        {
            /// <summary>
            /// 开放
            /// </summary>
            public const string Open = "Open";
            /// <summary>
            /// 关闭
            /// </summary>
            public const string Close = "Close";
            /// <summary>
            /// 异常取消
            /// </summary>
            public const string Cancel = "Cancel";

            /// <summary>
            /// 手工取消
            /// </summary>
            public const string ManualCancel = "MCancel";

        }
        /// <summary>
        /// 在途帐订单状态
        /// </summary>
        public struct InTransStatus
        {
            /// <summary>
            /// 开放
            /// </summary>
            public const string Open = "Open";
            /// <summary>
            /// 关闭
            /// </summary>
            public const string Close = "Close";
            /// <summary>
            /// 取消
            /// </summary>
            public const string Cancel = "Cancel";

        }
        /// <summary>
        /// 反冲类型
        /// </summary>
        public struct BackFlushType
        {
            /// <summary>
            /// 装配反冲
            /// 指生产汇报的时候对父零件做收货、对子零件做反冲、对该次汇报进行工时报工。
            /// </summary>
            public const string T01 = "01";
            /// <summary>
            /// 零件反冲
            /// 指生产汇报的时候仅对子零件做反冲。反冲类型为02。一般用于收集返工过程中额外的物料。
            /// </summary>
            public const string T02 = "02";
            /// <summary>
            /// 作业反冲
            /// 指生产汇报的时候仅对工时进行报工。反冲类型为03。一般用于收集返工过程中额外的工时。
            /// </summary>
            public const string T03 = "03";
            /// <summary>
            /// 冲销装配反冲
            /// 对01类型的冲销。涂装反喷或MASKING撕胶带的业务也可用该反冲类型来体现。
            /// </summary>
            public const string T04 = "04";
            /// <summary>
            /// 冲销零件反冲
            /// 对02类型的冲销。
            /// </summary>
            public const string T05 = "05";
            /// <summary>
            /// 冲销作业反冲，对03类型的冲销。反冲类型为06。 
            /// </summary>
            public const string T06 = "06";
            /// <summary>
            /// 拆解
            /// 指将成品分解成下一级的子零件，对01类型的冲销
            /// </summary>
            public const string T07 = "07";
            /// <summary>
            /// 工序报废
            /// 指将成品分解出的子零件进行报废，目前仅用于对涂装反喷冲回的油漆及MASKING撕胶带冲回的胶带进行报废
            /// </summary>
            public const string T08 = "08";
            /// <summary>
            /// 冲销反喷
            /// 对04类型的冲销。反冲类型为09。
            /// </summary>
            public const string T09 = "09";
            /// <summary>
            /// 冲销拆解
            /// 对07类型的冲销。反冲类型为10。
            /// </summary>
            public const string T10 = "10";
            /// <summary>
            /// 冲销工序报废
            /// 对08的冲销。反冲类型为11。
            /// </summary>
            public const string T11 = "11";
        }
        /// <summary>
        /// 库位名称
        /// </summary>
        public struct StkName
        {
            /// <summary>
            /// 货架区
            /// </summary>
            public const string HJQ = "货架区";
        }
        /// <summary>
        /// 配置信息表
        /// </summary>
        public struct BTOGlobalConfig
        {
            /// <summary>
            /// BTO
            /// </summary>
            public const string BTO = "BTO";
            /// <summary>
            /// ZTQKW在途区(通业)
            /// </summary>
            public const string ZTQKW = "ZTQKW";
            /// <summary>
            /// CPQKW成品区(通业)
            /// </summary>
            public const string CPQKW = "CPQKW";
            /// <summary>
            /// 订单自动生成
            /// </summary>
            public const string BTOAuto = "BTOAuto";
            /// <summary>
            /// BTO自动计算上次计算时间
            /// </summary>
            public const string BTOAutoCal = "BTOAutoCal";
            /// <summary>
            /// 系统当前所属地点
            /// </summary>
            public const string CurrentSys = "CurrentSys";
            /// <summary>
            /// BTO的107过点信息
            /// </summary>
            public const string SupGroupCode = "SupGroupCode";
            /// <summary>
            /// BTO的发货工厂
            /// </summary>
            public const string BTOFactory = "BTOFactory";
            /// <summary>
            /// BTO是否启动
            /// </summary>
            public const string IsEnable = "IsEnable";
            /// <summary>
            /// TS
            /// </summary>
            public const string TS = "TS";
            /// <summary>
            /// TSDown
            /// </summary>
            public const string TSDown = "TSDown";
            /// <summary>
            /// TSUp
            /// </summary>
            public const string TSUp = "TSUp";
            /// <summary>
            /// 不混放空BIN位(ParamCode为顺序)
            /// </summary>
            public const string BinNotMix = "BinNotMix";
            /// <summary>
            /// 取能放的空BIN位(根据入库优先级不考虑是否混放)
            /// </summary>
            public const string BinMix = "BinMix";
            /// <summary>
            /// 不混放未满BIN位(ParamCode为顺序)
            /// </summary>
            public const string BinNotMixNotFull = "BinNotMixNotFull";
            /// <summary>
            /// 混放未满BIN位(ParamCode为顺序)
            /// </summary>
            public const string BinMixNotFull = "BinMixNotFull";
            /// <summary>
            /// 注塑机联动是否清空当前条码
            /// </summary>
            public const string IMMScanLinkage = "IMMScanLinkage";
            /// <summary>
            /// 注塑机联动是否清空当前条码
            /// </summary>
            public const string IMMScan = "IMMScan";
        }
        /// <summary>
        /// BTO状态
        /// </summary>
        public struct BTOStatus
        {
            /// <summary>
            /// OPEN
            /// </summary>
            public const string OPEN = "OPEN";
            /// <summary>
            /// CANCEL
            /// </summary>
            public const string CANCEL = "CANCEL";
            /// <summary>
            /// CLOSE
            /// </summary>
            public const string CLOSE = "CLOSE";
            /// <summary>
            /// 等待
            /// </summary>
            public const string Wait = "等待";
            /// <summary>
            /// 结束
            /// </summary>
            public const string End = "结束";
            /// <summary>
            /// 确认
            /// </summary>
            public const string Confirm = "确认";
            /// <summary>
            /// Cancel
            /// </summary>
            public const string Canceled = "取消";
            /// <summary>
            /// 开放
            /// </summary>
            public const string ToOpenUp = "开放";
            /// <summary>
            /// 发运计划
            /// </summary>
            public const string DeliveryPlan = "发运计划";
            /// <summary>
            /// 装配计划
            /// </summary>
            public const string AssemblyPlan = "装配计划";
        }
        /// <summary>
        /// 小件管理方式
        /// </summary>
        public struct XJMngMode
        {
            /// <summary>
            /// 库存件
            /// </summary>
            public const string StockPart = "StockPart";
            /// <summary>
            /// 正常件
            /// </summary>
            public const string NormalPart = "NormalPart";
            /// <summary>
            /// 社会备件
            /// </summary>
            public const string SparePart = "SparePart";
        }
        #endregion

        #region 排序扫描
        /// <summary>
        /// 排序操作方式
        /// </summary>
        public struct SeqOpType
        {
            /// <summary>
            /// 装配
            /// </summary>
            public const string Assembly = "Assembly";
            /// <summary>
            /// 发运
            /// </summary>            
            public const string Ship = "Ship";
            /// <summary>
            /// 预排序
            /// </summary>
            public const string PreOrdering = "PreOrdering";
        }
        #endregion

        #region 排序类型
        /// <summary>
        /// 排序操作方式
        /// </summary>
        public struct SeqOrderType
        {
            /// <summary>
            /// 销售
            /// </summary>
            public const string Sale = "Sale";
            /// <summary>
            /// 移库
            /// </summary>            
            public const string To = "To";
        }
        #endregion

        #region 信息提示
        /// <summary>
        /// 提示信息
        /// </summary>
        public struct MessageInfo
        {
            /// <summary>
            /// 操作成功
            /// </summary>
            public const string E0001 = "操作成功";
            /// <summary>
            /// 操作失败
            /// </summary>
            public const string E0002 = "操作失败";
            /// <summary>
            /// 输入内容不能为空
            /// </summary>
            public const string E0003 = "输入内容不能为空";

        }

        #endregion

        #region 数据库基础信息
        /// <summary>
        /// 判定事件
        /// </summary>
        public struct MFG_ScanAction
        {
            /// <summary>
            /// 合格
            /// </summary>
            public const string IntoOK = "IntoOK";
            /// <summary>
            /// 待底漆合格
            /// </summary>
            public const string IntoDdqOK = "IntoDdqOK";
            /// <summary>
            /// 待底漆件冻结
            /// </summary>
            public const string IntoDdqFreeze = "IntoDdqFreeze";
            /// <summary>
            /// 冻结
            /// </summary>
            public const string IntoFreeze = "IntoFreeze";
            /// <summary>
            /// 来料冻结
            /// </summary>
            public const string IntoLLFreeze = "IntoLLFreeze";
            /// <summary>
            /// 报废
            /// </summary>
            public const string IntoScrap = "IntoScrap";
            /// <summary>
            /// 抛光
            /// </summary>
            public const string IntoPolish = "IntoPolish";
            /// <summary>
            /// 抛光合格
            /// </summary>
            public const string IntoPolishOK = "IntoPolishOK";
            /// <summary>
            /// 点修
            /// </summary>
            public const string IntoSpotRepair = "IntoSpotRepair";
            /// <summary>
            /// 点修合格
            /// </summary>
            public const string IntoSpotRepairOK = "IntoSpotRepairOK";

            /// <summary>
            /// 打磨
            /// </summary>
            public const string IntoBurnish = "IntoBurnish";
            /// <summary>
            /// 反报交
            /// </summary>
            public const string Unflush = "Unflush";
            /// <summary>
            /// 发运
            /// </summary>
            public const string Ship = "Ship";
            /// <summary>
            /// 收货
            /// </summary>
            public const string Recive = "Recive";
            /// <summary>
            /// 安全退回
            /// </summary>
            public const string CustSate = "CustSate";
            /// <summary>
            /// 变更
            /// </summary>
            public const string Modify = "Modify";

            /// <summary>
            /// W2
            /// </summary>
            public const string W2 = "W2";

            /// <summary>
            /// 退货
            /// </summary>
            public const string Return = "Return";

            /// <summary>
            /// 掏箱
            /// </summary>
            public const string UnStuffing = "UnStuffing";
            /// <summary>
            /// 盘点
            /// </summary>
            public const string Create = "Create";

            /// <summary>
            /// 标记已盘点
            /// </summary>
            public const string SetStock = "SetStock";

            /// <summary>
            /// 安全发运
            /// </summary>
            public const string ProCustSend = "ProCustSend";


            /// <summary>
            /// 拆解
            /// </summary>
            public const string Disam = "Disam";
            /// <summary>
            /// 打箱
            /// </summary>
            public const string PackageBox = "PackageBox";
            /// <summary>
            /// 无法处理
            /// </summary>
            public const string CannotHandle = "CannotHandle";
            /// <summary>
            /// 条码移库冲销
            /// </summary>
            public const string BarcodeTORev = "BarcodeTORev";
            /// <summary>
            /// 条码协同发运
            /// </summary>
            public const string BarcodeXTShip = "BarcodeXTShip";
            /// <summary>
            /// 条码协同收货
            /// </summary>
            public const string BarcodeXTRecive = "BarcodeXTRecive";
            /// <summary>
            /// 条码协同退货
            /// </summary>
            public const string BarcodeXTReturn = "BarcodeXTReturn";
            /// <summary>
            /// 条码协同退货接收
            /// </summary>
            public const string BarcodeXTReturnRev = "BarcodeXTReturnRev";
            /// <summary>
            /// 过账
            /// </summary>
            public const string Posting = "Posting";
        }
        /// <summary>
        /// 产品版本号
        /// </summary>
        public struct MFG_PartVersion
        {
            /// <summary>
            /// 空条码
            /// </summary>
            public const string EMPTY = "EMPTY";
            /// <summary>
            /// 正常件
            /// </summary>
            public const string NORMAL = "NORMAL";
            /// <summary>
            /// 待底漆
            /// </summary>
            public const string DDQ = "DDQ";
            /// <summary>
            /// 打磨件
            /// </summary>
            public const string DM = "DM";
            /// <summary>
            /// 从属件
            /// </summary>
            public const string AUX = "AUX";
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public struct OrderType
        {
            /// <summary>
            /// 移库单
            /// </summary>
            public const string TransferOrder = "TransferOrder";
            /// <summary>
            /// 销售退货单
            /// </summary>
            public const string SalesReturnOrder = "SalesReturnOrder";
            /// <summary>
            /// 采购订单
            /// </summary>
            public const string PurchaseOrder = "PurchaseOrder";
            /// <summary>
            /// 排序单
            /// </summary>
            public const string JISOrder = "JISOrder";
            /// <summary>
            /// 发货单
            /// </summary>
            public const string DeliverOrder = "DeliverOrder";
            /// <summary>
            /// 销售订单
            /// </summary>
            public const string SalesOrder = "SalesOrder";
            /// <summary>
            /// 上架需求
            /// </summary>
            public const string UpBinOrder = "UpBinRequest";
            /// <summary>
            /// 下架需求
            /// </summary>
            public const string DownBinOrder = "DownBinRequest";
            /// <summary>
            /// 不合格评审单（质量评审单）
            /// </summary>
            public const string QualityReviewOrder = "QualityReviewOrder";
            /// <summary>
            /// 出门证
            /// </summary>
            public const string OurDoorOrder = "OurDoorOrder";
            /// <summary>
            /// 货运单
            /// </summary>
            public const string ShippingOrder = "ShippingOrder";
            /// <summary>
            /// 交货确认单
            /// </summary>
            public const string DeliveryConfirmOrder = "DeliveryConfirmOrder";
            /// <summary>
            /// 维修工单
            /// </summary>
            public const string PMOrder = "PMOrder";
            /// <summary>
            /// PM通知单
            /// 实在想不通为什么叫制程检验单？
            /// </summary>
            public const string IPQCOrder = "IPQCOrder";
            /// <summary>
            /// BTO订单
            /// </summary>
            public const string BTOOrder = "BTOOrder";

            /// <summary>
            /// 手工加驳订单
            /// </summary>
            public const string ManalJBOrder = "ManalJBOrder";
            /// <summary>
            /// 福特ASN单号
            /// </summary>
            public const string FordASNOrder = "FordASNOrder";
            /// <summary>
            /// 自动化-涂装请求计划
            /// </summary>
            public const string PntWinCCRequest = "PntWinCCRequest";
            /// <summary>
            /// 拉动任务（长沙自动化）
            /// </summary>
            public const string PullTaskOrder = "PullTaskOrder";
            /// <summary>
            /// 用车申请单
            /// </summary>
            public const string CarOrder = "CarOrder";
        }
        #endregion

        #region <<采购单>>
        #region <<采购单类型>>
        public struct PurchaseOrderType
        {
            /// <summary>
            /// 生产物料采购
            /// </summary>
            [Description("生产物料采购")]
            public const string ZLPA = "ZLPA";
            /// <summary>
            /// 客供品
            /// </summary>
            [Description("客供品")]
            public const string ZLPC = "ZLPC";
            /// <summary>
            /// 总部代理采购
            /// </summary>
            [Description("总部代理采购")]
            public const string ZST1 = "ZST1";
            /// <summary>
            /// 公司间库存交易
            /// </summary>
            [Description("公司间库存交易")]
            public const string ZSTO = "ZSTO";
            /// <summary>
            /// 同公司不同工厂库存交易
            /// </summary>
            //[Description("同公司不同工厂库存交易")]
            //public const string ZST2 = "ZST2";
            /// <summary>
            /// 同公司不同工厂库存交易
            /// </summary>
            [Description("同公司不同工厂库存交易")]
            public const string LU = "LU";

        }

        #endregion

        #region <<行项目类型(SAP状态)>>
        public struct ItemType
        {
            /// <summary>
            /// 标准
            /// </summary>
            [Description("标准")]
            public const string EMPTY = "";
            /// <summary>
            /// 委外
            /// </summary>
            [Description("委外")]
            public const string L = "L";
            /// <summary>
            /// 寄售
            /// </summary>
            [Description("寄售")]
            public const string K = "K";
        }

        #endregion

        #region <<行项目状态>>
        /// <summary>
        /// 行项目状态
        /// </summary>
        public struct ItemStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            [Description("正常")]
            public const string EMPTY = "";
            /// <summary>
            /// 标记删除
            /// </summary>
            [Description("标记删除")]
            public const string D = "D";
            /// <summary>
            /// 冻结
            /// </summary>
            [Description("冻结")]
            public const string S = "S";
            /// <summary>
            /// 标记收货完成
            /// </summary>
            [Description("标记收货完成")]
            public const string X = "X";

        }
        /// <summary>
        /// 采购单配置类型
        /// </summary>
        public struct PurchaseOrderConfigType
        {
            /// <summary>
            /// 采购单
            /// </summary>
            [Description("采购单")]
            public const string PO = "CG";

            /// <summary>
            /// 采购单退货
            /// </summary>
            [Description("采购单退货")]
            public const string POReturn = "CGTH";
        }

        #endregion


        #endregion

        #region <<TS操作状态(WMS_BinReserveDet)>>

        public struct BinReserveStatus
        {
            /// <summary>
            /// 未处理
            /// </summary>
            [Description("未处理")]
            public const string Not = "0";
            /// <summary>
            /// 指令保存成功
            /// </summary>
            [Description("指令保存成功")]
            public const string Save = "1";
            /// <summary>
            /// 指令执行成功
            /// </summary>
            [Description("指令执行成功")]
            public const string Exec = "2";
            /// <summary>
            /// 取消
            /// </summary>
            [Description("取消")]
            public const string Cancel = "3";
        }

        #endregion

        #region WFM特殊领料状态
        public enum WFMMaterialReqBillStatus
        {
            /// <summary>
            /// 创建
            /// </summary>
            Create = 1000,
            /// <summary>
            /// 关闭
            /// </summary>
            Close = 2000,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel = 3000
        }
        #endregion


        public struct ErrorMsg
        {
            /// <summary>
            /// 数据异常，请与管理员联系
            /// </summary>
            public const string E0000 = "数据异常，请与管理员联系";
            /// <summary>
            /// 用户名不存在
            /// </summary>
            public const string E0001 = "用户名不存在";
            /// <summary>
            /// 密码错误
            /// </summary>
            public const string E0002 = "密码错误";
            /// <summary>
            /// 密码已过期，请及时更改
            /// </summary>
            public const string E0003 = "密码已过期，请及时更改";
            /// <summary>
            /// 您确定属于该区域吗？
            /// </summary>
            public const string E0004 = "确定所在该区域吗？";
            /// <summary>
            /// 请重新选择区域
            /// </summary>
            public const string E0005 = "请重新选择区域";
            /// <summary>
            /// 当前设备处于黑名单内，请联系管理员以解除锁定
            /// </summary>
            public const string E0006 = "当前设备处于黑名单内，请联系管理员以解除锁定";
            /// <summary>
            /// 程序版本已更新，请强制更新系统后重新登录
            /// </summary>
            public const string E0007 = "程序版本已更新，请强制更新系统后重新登录";
            /// <summary>
            /// 程序版本有更新，请及时退出后强制更新系统
            /// </summary>
            public const string E0008 = "程序版本有更新，请及时退出后强制更新系统";
            /// <summary>
            /// 911里有数据未上传，请重新进入911上传数据后重新登录
            /// </summary>
            public const string E0009 = "911里有数据未上传，请重新进入911上传数据后重新登录";
            /// <summary>
            /// 操作失败，请与管理员联系
            /// </summary>
            public const string E0010 = "操作失败，请与管理员联系";
            /// <summary>
            /// 操作成功
            /// </summary>
            public const string E0011 = "操作成功";
            /// <summary>
            /// 必须选择所在区域
            /// </summary>
            public const string E0012 = "必须选择所在区域";
            /// <summary>
            /// 密码长度必须大于等于8位
            /// </summary>
            public const string E0013 = "密码长度必须大于等于8位";
            /// <summary>
            /// 两遍密码不一致
            /// </summary>
            public const string E0014 = "两遍密码不一致";
            /// <summary>
            /// 不能同于上两次密码
            /// </summary>
            public const string E0015 = "不能同于上两次密码";
            /// <summary>
            /// 密码更改成功
            /// </summary>
            public const string E0016 = "密码更改成功";
            /// <summary>
            /// 密码更改失败
            /// </summary>
            public const string E0017 = "密码更改失败";
            /// <summary>
            /// 条码不可用（库位为空）
            /// </summary>
            public const string E0018 = "条码不可用（库位为空）";
            /// <summary>
            /// 条码不可用（临时库位）
            /// </summary>
            public const string E0019 = "条码不可用（临时库位）";
            /// <summary>
            /// 输入内容不能为空
            /// </summary>
            public const string E0020 = "输入内容不能为空";
            /// <summary>
            /// 确认该停机原因吗？
            /// </summary>
            public const string E0021 = "确认该停机原因吗？";
            /// <summary>
            /// 对不起，请选择零件号
            /// </summary>
            public const string E0022 = "对不起，请选择零件号";
            /// <summary>
            /// 对不起，请选择料道类型
            /// </summary>
            public const string E0023 = "对不起，请选择料道类型";
            /// <summary>
            /// 确认强制打印该料箱单吗？
            /// </summary>
            public const string E0024 = "确认强制打印该料箱单吗？";
            /// <summary>
            /// 确认重打前一张料箱单吗？
            /// </summary>
            public const string E0025 = "确认重打前一张料箱单吗？";
            /// <summary>
            /// 停机中，请稍后生产
            /// </summary>
            public const string E0026 = "停机中，请稍后生产";
            /// <summary>
            /// 请勿频繁扫描
            /// </summary>
            public const string E0027 = "请勿频繁操作";
            /// <summary>
            /// 扫描内容错误
            /// </summary>
            public const string E0028 = "扫描内容错误";
            /// <summary>
            /// 此条码下一扫描点为
            /// </summary>
            public const string E0029 = "此条码下一扫描点为";
            /// <summary>
            /// 请继续操作
            /// </summary>
            public const string E0030 = "请继续操作";
            /// <summary>
            /// 导出Excel出错，可能文件正被打开，请重试
            /// </summary>
            public const string E0031 = "导出Excel出错，可能文件正被打开，请先确保文件关闭";
            /// <summary>
            /// 没有找到匹配项
            /// </summary>
            public const string E0032 = "没有找到匹配项";
            /// <summary>
            /// 料箱与条码有关联
            /// </summary>
            public const string E0033 = "料箱与条码有关联";
            /// <summary>
            /// 料箱为冻结
            /// </summary>
            public const string E0034 = "料箱为冻结";
            /// <summary>
            /// 料箱为黄牌
            /// </summary>
            public const string E0035 = "料箱为黄牌";
            /// <summary>
            /// 料箱为无效
            /// </summary>
            public const string E0036 = "料箱为无效";
            /// <summary>
            /// 料箱不存在
            /// </summary>
            public const string E0037 = "料箱不存在";
            /// <summary>
            /// 料箱已满，不能翻箱
            /// </summary>
            public const string E0038 = "料箱已满，不能翻箱";
            /// <summary>
            /// 需先将当前工位装满箱：
            /// </summary>
            public const string E0039 = "需先将当前工位装满箱：";
            /// <summary>
            /// 翻箱成功
            /// </summary>
            public const string E0040 = "翻箱成功";
            /// <summary>
            /// VIN号不存在
            /// </summary>
            public const string E0041 = "VIN号不存在";
            /// <summary>
            /// 当前加驳的零件号与将要替换的零件号不一致
            /// </summary>
            public const string E0042 = "当前加驳的零件号与将要替换的零件号不一致";
            /// <summary>
            /// 盘点中，请联系仓管员
            /// </summary>
            public const string E0043 = "盘点中，请联系仓管员";
            /// <summary>
            /// 获取货架位置失败
            /// </summary>
            public const string E0044 = "获取货架位置失败";
            /// <summary>
            /// TO不存在
            /// </summary>
            public const string E0045 = "TO不存在";
            /// <summary>
            /// TO已关闭
            /// </summary>
            public const string E0046 = "TO已关闭";
            /// <summary>
            /// TO不可强制关闭
            /// </summary>
            public const string E0047 = "TO不可强制关闭";
            /// <summary>
            /// 订单号获取失败
            /// </summary>
            public const string E0048 = "订单号获取失败";
            /// <summary>
            /// 订单头创建失败
            /// </summary>
            public const string E0049 = "订单头创建失败";
            /// <summary>
            /// 订单明细并未创建：
            /// </summary>
            public const string E0050 = "订单明细并未创建：";
            /// <summary>
            /// 订单明细创建失败：
            /// </summary>
            public const string E0051 = "订单明细创建失败：";
            /// <summary>
            /// 处理异常：
            /// </summary>
            public const string E0052 = "处理异常：";
            /// <summary>
            /// 订单已结
            /// </summary>
            public const string E0053 = "订单已结";
            /// <summary>
            /// 订单明细行收货量修改失败：
            /// </summary>
            public const string E0054 = "订单明细行收货量修改失败：";
            /// <summary>
            /// 订单明细行单位不正确：
            /// </summary>
            public const string E0055 = "订单明细行单位不正确：";
            /// <summary>
            /// 订单明细行库存事务失败：
            /// </summary>
            public const string E0056 = "订单明细行库存事务失败：";
            /// <summary>
            /// 订单状态修改失败
            /// </summary>
            public const string E0057 = "订单状态修改失败";
            /// <summary>
            /// 事务成功
            /// </summary>
            public const string E0058 = "事务成功";
            /// <summary>
            /// 回滚异常
            /// </summary>
            public const string E0059 = "回滚异常";
            /// <summary>
            /// 料箱未上架
            /// </summary>
            public const string E0060 = "料箱未上架";
            /// <summary>
            /// 料箱在架上
            /// </summary>
            public const string E0061 = "料箱在架上";
            /// <summary>
            /// 有OPEN-TO关联
            /// </summary>
            public const string E0062 = "有OPEN-TO关联";
            /// <summary>
            /// 未入库
            /// </summary>
            public const string E0063 = "未入库";
            /// <summary>
            /// 请勿重复扫描
            /// </summary>
            public const string E0064 = "请勿重复操作";
            /// <summary>
            /// 扫描失败，条码状态已变更
            /// </summary>
            public const string E0065 = "失败，条码状态已变更";
            /// <summary>
            /// 你无权访问此功能
            /// </summary>
            public const string E0066 = "你无权访问此功能";
            /// <summary>
            /// 料箱不能存储当前零件
            /// </summary>
            public const string E0067 = "料箱不能存储当前零件";
            /// <summary>
            /// 条码不存在
            /// </summary>
            public const string E0068 = "条码不存在";
            /// <summary>
            /// 请重新扫描
            /// </summary>
            public const string E0069 = "请重新扫描";
            /// <summary>
            /// 此条码的上一扫描点为
            /// </summary>
            public const string E0070 = "此条码上一扫描点为";
            /// <summary>
            /// 上个条码尚未处理完毕
            /// </summary>
            public const string E0071 = "上个条码尚未处理完毕";
            /// <summary>
            /// 不允许异色重喷，操作取消
            /// </summary>
            public const string E0072 = "不允许异色重喷，操作取消";
            /// <summary>
            /// 导入文件格式有误
            /// </summary>
            public const string E0073 = "导入文件格式有误";
            /// <summary>
            /// 导入文件无法打开
            /// </summary>
            public const string E0074 = "导入文件无法打开";
            /// <summary>
            /// 没有选中任一行
            /// </summary>
            public const string E0075 = "没有选中任一行";
            /// <summary>
            /// 生效日期不正确
            /// </summary>
            public const string E0076 = "生效日期不正确";
            /// <summary>
            /// 料箱已被占用
            /// </summary>
            public const string E0077 = "料箱已被占用";
            /// <summary>
            /// 料箱号不存在
            /// </summary>
            public const string E0078 = "料箱号不存在";
            /// <summary>
            /// 开始打包成功
            /// </summary>
            public const string E0079 = "开始打包成功";
            /// <summary>
            /// 自动封箱成功
            /// </summary>
            public const string E0080 = "自动封箱成功";
            /// <summary>
            /// 强制封箱成功
            /// </summary>
            public const string E0081 = "强制封箱成功";
            /// <summary>
            /// 料箱尚未占用
            /// </summary>
            public const string E0082 = "料箱尚未占用";
            /// <summary>
            /// 请先确定零件号
            /// </summary>
            public const string E0083 = "请先确定零件号";
            /// <summary>
            /// 料箱已满箱：
            /// </summary>
            public const string E0084 = "料箱已满箱：";
            /// <summary>
            /// 此料箱还未下架，请先进行手工下架
            /// </summary>
            public const string E0085 = "此料箱还未下架，请先进行手工下架";
            /// <summary>
            /// 小件不允许做退回操作
            /// </summary>
            public const string E0086 = "小件不允许做退回操作";
            /// <summary>
            /// BIN位不存在
            /// </summary>
            public const string E0087 = "BIN位不存在";
            /// <summary>
            /// 未找到匹配的计划
            /// </summary>
            public const string E0088 = "未找到匹配的计划";
            /// <summary>
            /// 匹配失败
            /// </summary>
            public const string E0089 = "匹配失败";
            /// <summary>
            /// 成功
            /// </summary>
            public const string E0090 = "成功";
            /// <summary>
            /// 失败
            /// </summary>
            public const string E0091 = "失败";
            /// <summary>
            /// 条码无法匹配队列中涂装计划，是否继续？
            /// </summary>
            public const string E0092 = "条码无法匹配队列中涂装计划，是否继续？";
            /// <summary>
            /// 队列中已备料的该产品计划不能大于
            /// </summary>
            public const string E0093 = "队列中已备料的该产品计划不能大于";
            /// <summary>
            /// 请先选择输出的打印机
            /// </summary>
            public const string E0094 = "请先选择输出的打印机";
            /// <summary>
            /// 条码成功生成，请等待打印
            /// </summary>
            public const string E0095 = "条码成功生成，请等待打印";
            /// <summary>
            /// 对不起，打印时有错误发生，请稍候再试
            /// </summary>
            public const string E0096 = "对不起，打印时有错误发生，请重新尝试";
            /// <summary>
            /// 必须选择流转类型
            /// </summary>
            public const string E0097 = "必须选择流转类型";
            /// <summary>
            /// 是否接管打包：
            /// </summary>
            public const string E0098 = "是否接管打包：";
            /// <summary>
            /// 基础数据没有配置，请联系管理员
            /// </summary>
            public const string E0099 = "基础数据没有配置，请联系管理员";
            /// <summary>
            /// 是否强制封箱？
            /// </summary>
            public const string E0100 = "是否强制封箱？";
            /// <summary>
            /// 当前料箱已封
            /// </summary>
            public const string E0101 = "当前料箱已封";
            /// <summary>
            /// 当前只能扫描产品：
            /// </summary>
            public const string E0102 = "当前只能扫描产品：";
            /// <summary>
            /// 未获取合适料箱
            /// </summary>
            public const string E0103 = "未获取合适料箱";
            /// <summary>
            /// 当前条码已经在当前料箱中
            /// </summary>
            public const string E0104 = "当前条码已经在当前料箱中";
            /// <summary>
            /// 当前条码已经在其他料箱中
            /// </summary>
            public const string E0105 = "当前条码已经在其他料箱中";
            /// <summary>
            /// 散件打包失败
            /// </summary>
            public const string E0106 = "散件打包失败";
            /// <summary>
            /// 当前条码没有对应料箱可放
            /// </summary>
            public const string E0107 = "当前条码没有对应料箱可放";
            /// <summary>
            /// 不合格件不能拼箱
            /// </summary>
            public const string E0108 = "不合格件不能拼箱";
            /// <summary>
            /// 是否冻结：
            /// </summary>
            public const string E0109 = "是否冻结：";
            /// <summary>
            /// 冻结成功
            /// </summary>
            public const string E0110 = "冻结成功";
            /// <summary>
            /// 是否报废：
            /// </summary>
            public const string E0111 = "是否报废：";
            /// <summary>
            /// 报废成功
            /// </summary>
            public const string E0112 = "报废成功";
            /// <summary>
            /// 未定义报废科目和成本中心
            /// </summary>
            public const string E0113 = "未定义报废科目和成本中心";
            /// <summary>
            /// 是否转底漆：
            /// </summary>
            public const string E0114 = "是否转底漆：";
            /// <summary>
            /// 转底漆成功
            /// </summary>
            public const string E0115 = "转底漆成功";
            /// <summary>
            /// 合格数小于包装数，确定要进行零头装箱吗？
            /// </summary>
            public const string E0116 = "合格数小于包装数，确定要进行零头装箱吗？";
            /// <summary>
            /// 当前产品可用BIN位数：
            /// </summary>
            public const string E0117 = "当前产品可用BIN位数：";
            /// <summary>
            /// 最后件未判定
            /// </summary>
            public const string E0118 = "最后件未判定";
            /// <summary>
            /// 操作取消
            /// </summary>
            public const string E0119 = "操作取消";
            /// <summary>
            /// 料箱非小件
            /// </summary>
            public const string E0120 = "料箱非小件";
            /// <summary>
            /// 料箱产品与所选装箱产品不一致
            /// </summary>
            public const string E0121 = "料箱产品与所选装箱产品不一致";
            /// <summary>
            /// 料箱库位错
            /// </summary>
            public const string E0122 = "料箱库位错";
            /// <summary>
            /// 料箱是空箱
            /// </summary>
            public const string E0123 = "料箱是空箱";
            /// <summary>
            /// 料箱未满箱
            /// </summary>
            public const string E0124 = "料箱未满箱";
            /// <summary>
            /// 请选择要打印的零件号
            /// </summary>
            public const string E0125 = "请选择要打印的零件号";
            /// <summary>
            /// 包装数不正确
            /// </summary>
            public const string E0126 = "包装数不正确";
            /// <summary>
            /// 生产数不正确
            /// </summary>
            public const string E0127 = "生产数不正确";
            /// <summary>
            /// 合格数大于包装数，无法打箱
            /// </summary>
            public const string E0128 = "合格数大于包装数无法打箱";
            /// <summary>
            /// 社会备件不允许零头装箱
            /// </summary>
            public const string E0129 = "社会备件不允许零头装箱";
            /// <summary>
            /// 库存件不允许零头装箱
            /// </summary>
            public const string E0130 = "库存件不允许零头装箱";
            /// <summary>
            /// 事务失败
            /// </summary>
            public const string E0131 = "事务失败";
            /// <summary>
            /// 事务成功
            /// </summary>
            public const string E0132 = "事务成功";
            /// <summary>
            /// 只有导流板可以上架
            /// </summary>
            public const string E0133 = "只有导流板可以上架";
            /// <summary>
            /// 对不起，请确定零件号
            /// </summary>
            public const string E0134 = "对不起，请确定零件号";
            /// <summary>
            /// 是否直接报废
            /// </summary>
            public const string E0135 = "是否直接报废";
            /// <summary>
            /// 是否释放当前扫描的AGV号
            /// </summary>
            public const string E0136 = "是否释放当前扫描的AGV号？";
            /// <summary>
            /// AGV号不存在或者被占用
            /// </summary>
            public const string E0137 = "AGV号不存在或者被占用";
            /// <summary>
            /// AGV号不存在
            /// </summary>
            public const string E0138 = "AGV号不存在";
            //////////////////////////////////////////////////////---------朱伟力
            /// <summary>
            /// 包装数量不能为空或者为0
            /// </summary>
            public const string E0139 = "包装数量不能为空或为0";
            /// <summary>
            /// 生产数不能大于包装数量
            /// </summary>
            public const string E0140 = "生产数不能大于包装数量";
            /// <summary>
            /// 生产数不能小于等于0
            /// </summary>
            public const string E0141 = "生产数不能小于等于0";
            /// <summary>
            /// 入库库位不存在
            /// </summary>
            public const string E0142 = "入库库位不存在";
            /// <summary>
            /// 小件类型和涂装件不匹配
            /// </summary>
            public const string E0143 = "小件类型和涂装件不匹配";
            /// <summary>
            /// 取消单边打印
            /// </summary>
            public const string E0144 = "取消单边打印";
            /// <summary>
            /// 是否进行零头打印
            /// </summary>
            public const string E0145 = "是否进行零头打印";
            /// <summary>
            /// 取消零头打印
            /// </summary>
            public const string E0146 = "取消零头打印";
            /// <summary>
            /// 打印失败
            /// </summary>
            public const string E0147 = "打印失败";
            /// <summary>
            /// 是否重打印选择的料箱单
            /// </summary>
            public const string E0148 = "是否重打印选择的料箱单";
            /// <summary>
            /// 请选择产品类别或者产品名称
            /// </summary>
            public const string E0149 = "请选择产品类别或者产品名称";
            /// <summary>
            /// 该产品可双边打印，是否只打印单边料箱单
            /// </summary>
            public const string E0150 = "该产品可双边打印，是否只打印单边料箱单";
            /// <summary>
            /// 取消重打印
            /// </summary>
            public const string E0151 = "取消重打印";
            /// <summary>
            /// 已经有后续的事务，无法回冲
            /// </summary>
            public const string E0152 = "已经有后续的事务，无法回冲";
            /// <summary>
            /// 已打印入库申请单，无法回冲
            /// </summary>
            public const string E0153 = "已打印入库申请单，无法回冲";
            /// <summary>
            /// 回冲事务失败
            /// </summary>
            public const string E0154 = "回冲事务失败";
            /// <summary>
            /// 请先扫描一个AGV小车
            /// </summary>
            public const string E0155 = "请先扫描一个AGV小车";
            /// <summary>
            /// 已有相同零件的{0}正在进行打箱
            /// </summary>
            public const string E0156 = "已有相同零件的{0}正在进行打箱";
            /// <summary>
            /// 停机中，请稍后生产
            /// </summary>
            public const string E0157 = "停机中，请稍后生产";
            /// <summary>
            /// AGV扫描不同产品时，需将当前AGV强制打印料架单
            /// </summary>
            public const string E0158 = "AGV扫描不同产品时，需将当前AGV强制打印料架单";
            /// <summary>
            /// 此操作将清空该时间范围内的所有盘点记录，是否继续
            /// </summary>
            public const string E0159 = "此操作将清空该时间范围内的所有盘点记录，是否继续";
            /// <summary>
            /// 当前无待排的排序单
            /// </summary>
            public const string E0160 = "当前无待排的排序单";
            /// <summary>
            /// 已装配，是否直接匹配当前排序件
            /// </summary>
            public const string E0161 = "已装配，是否直接匹配当前排序件";
            /// <summary>
            /// 已装配，但是不能匹配当前排序件
            /// </summary>
            public const string E0162 = "已装配，但是不能匹配当前排序件";
            /// <summary>
            /// 校验不通过，请重新扫描总成条码
            /// </summary>
            public const string E0163 = "校验不通过，请重新扫描总成条码";
            /// <summary>
            /// 未匹配排序件，是否做冻结处理
            /// </summary>
            public const string E0164 = "未匹配排序件，是否做冻结处理";
            /// <summary>
            /// 订单不存在  swang5
            /// </summary>
            public const string E0165 = "订单不存在";
            /// <summary>
            /// 订单已关闭  swang5
            /// </summary>
            public const string E0166 = "订单已关闭";
            /// <summary>
            /// 订单已取消  swang5
            /// </summary>
            public const string E0167 = "订单已取消";
            /// <summary>
            /// 订单取消成功，但是对方协同失败。单号：" + XXXXX + "  swang5
            /// </summary>
            public const string E0168 = "订单取消成功，但是对方协同失败。单号：";
            /// <summary>
            /// 订单取消成功，但是ISV同步失败  swang5
            /// </summary>
            public const string E0169 = "订单取消成功，但是ISV同步失败";
            /// <summary>
            /// 提示  swang5
            /// </summary>
            public const string E0170 = "提示";
            /// <summary>
            /// 订单将被关闭，是否继续  swang5
            /// </summary>
            public const string E0171 = "订单将被关闭，是否继续";
            /// <summary>
            /// 订单将被取消，是否继续  swang5
            /// </summary>
            public const string E0172 = "订单将被取消，是否继续";
            /// <summary>
            /// 订单关闭成功，但是对方协同失败。单号：" + XXXXX + "  swang5
            /// </summary>
            public const string E0173 = "订单关闭成功，但是对方协同失败。单号：";
            /// <summary>
            /// 订单关闭成功，但是ISV同步失败  swang5
            /// </summary>
            public const string E0174 = "订单关闭成功，但是ISV同步失败";
            /// <summary>
            /// 订单  swang5
            /// </summary>
            public const string E0175 = "订单";
            /// <summary>
            /// ISV同步成功  swang5
            /// </summary>
            public const string E0176 = "ISV同步成功";
            /// <summary>
            /// ISV同步失败  swang5
            /// </summary>
            public const string E0177 = "ISV同步失败";
            /// <summary>
            /// 请先选择区域  swang5
            /// </summary>
            public const string E0178 = "请先选择区域";
            /// <summary>
            /// 订单下达成功，但是ISV同步失败  swang5
            /// </summary>
            public const string E0179 = "订单下达成功，但是ISV同步失败";
            /// <summary>
            /// 订单下达成功，但是对方协同失败。单号：" + XXXXX + "  swang5
            /// </summary>
            public const string E0180 = "订单下达成功，但是对方协同失败。单号：";
            /// <summary>
            /// 溢库，不允许入库  朱伟力
            /// </summary>
            public const string E0181 = "溢库，不允许入库";
            /// <summary>
            /// 请双击订单！  swang5
            /// </summary>
            public const string E0182 = "请双击订单！";
            /// <summary>
            /// 条码在架上
            /// </summary>
            public const string E0183 = "条码在架上";
            /// <summary>
            /// 确认该缺陷名称吗？
            /// </summary>
            public const string E0184 = "确认该缺陷名称吗？";
            /// <summary>
            /// 请自行更改条码起始流水号，以免多打
            /// </summary>
            public const string E0185 = "请自行更改条码起始流水号，以免多打";
            /// <summary>
            /// 区间不能为空
            /// </summary>
            public const string E0186 = "区间不能为空";
            /// <summary>
            /// 零件号必须相同     -------朱伟力
            /// </summary>
            public const string E0187 = "零件号必须相同";
            /// <summary>
            /// 涂装线内条码只有油漆下线和质量扫描能处理  ljin4
            /// </summary>
            public const string E0188 = "涂装线内条码只有油漆下线和质量扫描能处理";
            /// <summary>
            /// 非盘点模式  --王小乐
            /// </summary>
            public const string E0189 = "非盘点模式";
            /// <summary>
            /// 操作失败，条码异常  --王小乐
            /// </summary>
            public const string E0190 = "操作失败，条码异常";
            /// <summary>
            /// 操作失败，注塑零件号必须一致  --王小乐
            /// </summary>
            public const string E0191 = "操作失败，注塑零件号必须一致";
            /// <summary>
            /// 操作失败，  --王小乐
            /// </summary>
            public const string E0192 = "操作失败，";
            /// <summary>
            /// 条码已在其他库位进行过盘点  --王小乐
            /// </summary>
            public const string E0193 = "该条码在区域：{0} 进行过盘点,你确定要再次盘点该物料吗?";
            /// <summary>
            /// 请选择涂装线
            /// </summary>
            public const string E0194 = "请选择涂装线";
            /// <summary>
            /// 是否重打印选择的订单
            /// </summary>
            public const string E0195 = "是否重打印选择的订单";
            /// <summary>
            /// 请选择需要打印的订单
            /// </summary>
            public const string E0196 = "请选择需要打印的订单";
            /// <summary>
            /// 创建小件订单时失败
            /// </summary>
            public const string E0197 = "创建小件订单时失败";
            /// <summary>
            /// 请选择入库申请单号
            /// </summary>
            public const string E0198 = "请选择入库申请单号";
            /// <summary>
            /// 无法取得按灯信息
            /// </summary>
            public const string E0199 = "无法取得按灯信息";
            /// <summary>
            /// 料箱不存在或者料箱无绑定的条码  -王小乐
            /// </summary>
            public const string E0200 = "料箱不存在或者料箱无绑定的条码";
            /// <summary>
            /// {0}在料箱中无法退回  -王小乐
            /// </summary>
            public const string E0202 = "{0}在料箱中无法退回";
            /// <summary>
            /// 取下和替换的条码不能互换  -王小乐
            /// </summary>
            public const string E0205 = "取下和替换的条码不能互换";
            /// <summary>
            /// 替换的条码有误  -王小乐
            /// </summary>
            public const string E0206 = "替换的条码有误";
            /// <summary>
            /// 条码无法匹配当前涂装计划，是否继续
            /// </summary>
            public const string E0207 = "条码无法匹配当前涂装计划，是否继续";
            /// <summary>
            /// 取下的条码有误  -王小乐
            /// </summary>
            public const string E0208 = "取下的条码有误";
            /// <summary>
            /// 待底漆件不能上此涂装线  -王小乐
            /// </summary>
            public const string E0209 = "待底漆件不能上此涂装线";
            /// <summary>
            /// 当前产品不能上此涂装线  -王小乐
            /// </summary>
            public const string E0210 = "当前产品不能上此涂装线";
            /// <summary>
            /// 已经三过涂装线，是否继续  -王小乐
            /// </summary>
            public const string E0211 = "已经三过涂装线，是否继续";
            /// <summary>
            /// 控制油漆上线几次显示信息，与E0211字符串中的数字相对应
            /// </summary>
            public const string E0211_01 = "三";
            /// <summary>
            /// 当前AGV小车不能重复上线  -王小乐
            /// </summary>
            public const string E0212 = "当前AGV小车不能重复上线";
            /// <summary>
            /// AGV与计划匹配成功  -王小乐
            /// </summary>
            public const string E0213 = "AGV与计划匹配成功";
            /// <summary>
            /// AGV与计划匹配失败  -王小乐
            /// </summary>
            public const string E0214 = "AGV与计划匹配失败";
            /// <summary>
            /// 当前无涂装计划，停止上线  -王小乐
            /// </summary>
            public const string E0215 = "当前无涂装计划，停止上线";
            /// <summary>
            /// 返修件颜色无法匹配当前涂装计划，是否继续  -王小乐
            /// </summary>
            public const string E0216 = "返修件颜色无法匹配当前涂装计划，是否继续";
            /// <summary>
            /// 计划数量不能小于已上数量
            /// </summary>
            public const string E0217 = "计划数量不能小于已上数量";
            /// <summary>
            /// 计划数量不能大于挂具数量
            /// </summary>
            public const string E0218 = "计划数量不能大于挂具数量";
            /// <summary>
            /// 名称色漆信息有错误
            /// </summary>
            public const string E0219 = "名称色漆信息有错误";
            /// <summary>
            /// 挂具已上只能改色漆
            /// </summary>
            public const string E0220 = "挂具已上只能改色漆";
            /// <summary>
            /// 将自动跳过当前车号，是否继续
            /// </summary>
            public const string E0221 = "将自动跳过当前车号，是否继续";
            /// <summary>
            /// 找不到当前雪撬位置
            /// </summary>
            public const string E0222 = "找不到当前雪撬位置";
            /// <summary>
            /// 当前雪撬：
            /// </summary>
            public const string E0223 = "当前雪撬：";
            /// <summary>
            /// 找不到需要装箱的产品，请确认计划已导入并正在执行
            /// </summary>
            public const string E0224 = "找不到需要装箱的产品，请确认计划已导入并正在执行";
            /// <summary>
            /// 涂装小件退回  ----朱伟力
            /// </summary>
            public const string E0225 = "涂装小件退回";
            /// <summary>
            /// 缺陷名称必选
            /// </summary>
            public const string E0226 = "缺陷名称必选";
            /// <summary>
            /// 继续选择缺陷
            /// </summary>
            public const string E0227 = "继续选择缺陷";
            /// <summary>
            /// 缺陷为空，如果取消将退回重新选择，是否继续
            /// </summary>
            public const string E0228 = "缺陷为空，如果取消将退回重新选择，是否继续";
            /// <summary>
            /// 请选择缺陷位置，不选则为全部位置
            /// </summary>
            public const string E0229 = "请选择缺陷位置，不选则为全部位置";
            /// <summary>
            /// 资源不足，无法推荐
            /// </summary>
            public const string E0230 = "资源不足，无法推荐";
            /// <summary>
            /// 一次最多拉动五个料箱
            /// </summary>
            public const string E0231 = "一次最多拉动五个料箱";
            /// <summary>
            /// 已低于安全库存
            /// </summary>
            public const string E0232 = "已低于安全库存";
            /// <summary>
            /// 当前拉动请求无法接收
            /// </summary>
            public const string E0233 = "当前拉动请求无法接收";
            /// <summary>
            /// 当前条码不能在该位置上架
            /// </summary>
            public const string E0234 = "当前条码不能在该位置上架";
            /// <summary>
            /// 料箱不能为空
            /// </summary>
            public const string E0235 = "料箱不能为空";
            /// <summary>
            /// 料箱不能在当前工位接收
            /// </summary>
            public const string E0236 = "料箱不能在当前工位接收";
            /// <summary>
            /// 关闭多料道模式
            /// </summary>
            public const string E0237 = "关闭指定上架";
            /// <summary>
            /// 四位流水异常
            /// </summary>
            public const string E0238 = "四位流水异常";
            /// <summary>
            /// 零件信息不全
            /// </summary>
            public const string E0239 = "零件信息不全";
            /// <summary>
            /// 库位来源必选
            /// </summary>
            public const string E0240 = "库位来源必选";
            /// <summary>
            /// 所过涂装线必选
            /// </summary>
            public const string E0241 = "所过涂装线必选";
            /// <summary>
            /// 必须为备用条码
            /// </summary>
            public const string E0242 = "必须为备用条码";
            /// <summary>
            /// 条码已经被使用
            /// </summary>
            public const string E0243 = "条码已经被使用";
            /// <summary>
            /// 是否批量补条码
            /// </summary>
            public const string E0244 = "是否批量补条码";
            /// <summary>
            /// 有条码已被使用
            /// </summary>
            public const string E0245 = "有条码已被使用";
            /// <summary>
            /// 零件关系异常
            /// </summary>
            public const string E0246 = "零件关系异常";
            /// <summary>
            /// 是否是预装件条码
            /// </summary>
            public const string E0247 = "是否是预装件条码";
            /// <summary>
            /// 请选择入库库位   ----朱伟力
            /// </summary>
            public const string E0248 = "请选择入库库位";
            /// <summary>
            /// 指定上架   ---朱伟力
            /// </summary>
            public const string E0249 = "指定上架";
            /// <summary>
            /// 待底漆件的包装数据不完整   ---王小乐
            /// </summary>
            public const string E0250 = "待底漆件的包装数据不完整，请联系管理员！";
            /// <summary>
            /// 条码不在架上，请重新扫描   ---朱伟力
            /// </summary>
            public const string E0251 = "条码不在架上，请重新扫描";
            /// <summary>
            /// 不在拉动列表内是否强制下架   ---朱伟力
            /// </summary>
            public const string E0252 = "不在拉动列表内是否强制下架";
            /// <summary>
            /// 该产品不能强制下架   ---朱伟力
            /// </summary>
            public const string E0253 = "该产品不能强制下架";
            /// <summary>
            /// 下架取消,请重新扫描   ---朱伟力
            /// </summary>
            public const string E0254 = "下架取消,请重新扫描";
            /// <summary>
            /// 该条码不是涂装件
            /// </summary>
            public const string E0255 = "该条码不是涂装件";
            /// <summary>
            /// 该条码不是合格件
            /// </summary>
            public const string E0256 = "该条码不是合格件";
            /// <summary>
            /// 无装配计划匹配该装配件
            /// </summary>
            public const string E0257 = "无装配计划匹配该装配件";
            /// <summary>
            /// 当前条码不是258带雷达保险杠
            /// </summary>
            public const string E0258 = "当前条码不是258带雷达保险杠";
            /// <summary>
            /// 串口信息发送失败
            /// </summary>
            public const string E0259 = "串口信息发送失败";
            /// <summary>
            /// 无法匹配，请重新扫描
            /// </summary>
            public const string E0260 = "BOM匹配失败，请重新扫描";
            /// <summary>
            /// 条码错误，请重新扫描
            /// </summary>
            public const string E0261 = "条码错误，请重新扫描";
            /// <summary>
            /// 打包失败，将自动使用散件打包功能
            /// </summary>
            public const string E0262 = "打包失败，将自动使用散件打包功能";
            /// <summary>
            /// 正在打印
            /// </summary>
            public const string E0263 = "正在打印";
            /// <summary>
            /// 没有空的位置可用
            /// </summary>
            public const string E0264 = "没有空的位置可用";
            /// <summary>
            /// 此条码不能在此接收 ----------朱伟力
            /// </summary>
            public const string E0265 = "此条码不能在此接收";
            /// <summary>
            /// 所属料箱 {0} 在 {1}-{2} 上，请先下架 ----------王小乐
            /// </summary>
            public const string E0266 = "所属料箱 {0} 在 {1}-{2} 上，请先下架";
            /// <summary>
            /// 零件号不一致 ----------王小乐
            /// </summary>
            public const string E0270 = "零件号不一致";
            /// <summary>
            /// 产品类型不一致 ----------王小乐
            /// </summary>
            public const string E0267 = "产品类型不一致";
            /// <summary>
            /// 产品状态不一致 ----------王小乐
            /// </summary>
            public const string E0268 = "产品状态不一致";
            /// <summary>
            /// 超过包装数量，不能装箱！ ----------王小乐
            /// </summary>
            public const string E0269 = "超过包装数量，不能装箱！";
            /// <summary>
            /// 是否重新打印最后一张料箱单： ----------王小乐
            /// </summary>
            public const string E0271 = "是否重新打印最后一张料箱单：";
            /// <summary>
            /// 是否隔离清单中条码
            /// </summary>
            public const string E0272 = "是否隔离清单中条码？";
            /// <summary>
            /// 请选择拉动类型          -------朱伟力
            /// </summary>
            public const string E0273 = "请选择拉动类型";
            /// <summary>
            /// TS料道无该产品，是否切换成料箱拉动          -------朱伟力
            /// </summary>
            public const string E0274 = "TS料道无该产品，是否切换成料箱拉动";
            /// <summary>
            /// 当前产品可以双边打印，您确定要进行单边打印吗？
            /// </summary>
            public const string E0275 = "当前产品可以双边打印，您确定要进行单边打印吗？";
            /// <summary>
            /// 当前没有可供重打印的料箱单
            /// </summary>
            public const string E0276 = "当前没有可供重打印的料箱单";
            /// <summary>
            /// 当前日期与生产汇报日期不一致，您确定要继续吗？
            /// </summary>
            public const string E0277 = "当前日期与生产汇报日期不一致，您确定要继续吗？";
            /// <summary>
            /// 选择的多料道个数必须大于1
            /// </summary>
            public const string E0278 = "选择的多料道个数必须大于1";
            /// <summary>
            /// 此产品为冻结  ------朱伟力
            /// </summary>
            public const string E0279 = "此产品为冻结";
            /// <summary>
            /// 盘点实例状态异常或盘点实例不存在---yyang26
            /// </summary>
            public const string E0280 = "盘点实例状态异常或盘点实例不存在";
            /// <summary>
            /// 条码不能相同---朱伟力
            /// </summary>
            public const string E0281 = "条码不能相同";
            /// <summary>
            /// 扫描的不是推荐BIN位，是否强制下架    ----朱伟力
            /// </summary>
            public const string E0282 = "扫描的不是推荐BIN位，是否强制下架";
            /// <summary>
            /// TS组与其他电脑关联，是否释放TS组与其他电脑的关联    ----朱伟力
            /// </summary>
            public const string E0283 = "TS组与其他电脑关联，是否释放TS组与其他电脑的关联";
            /// <summary>
            /// 修改条件不能为空    ----朱伟力
            /// </summary>
            public const string E0284 = "修改条件不能为空";
            /// <summary>
            /// TS料道必须为空    ----朱伟力
            /// </summary>
            public const string E0285 = "TS料道必须为空";
            /// <summary>
            /// 涂装线库存    ----yyang26
            /// </summary>
            public const string E0286 = "涂装线库存";
            /// <summary>
            /// GB2312    ----yyang26
            /// </summary>
            public const string E0287 = "GB2312";
            /// <summary>
            /// csv导入标示*.csv|*.csv    ----yyang26
            /// </summary>
            public const string E0288 = "*.csv|*.csv";
            /// <summary>
            /// 手工盘点    ----yyang26
            /// </summary>
            public const string E0289 = "手工盘点";
            /// <summary>
            /// 按创建时间    ----yyang26
            /// </summary>
            public const string E0290 = "按创建时间";
            /// <summary>
            /// 按生效日期    ----yyang26
            /// </summary>
            public const string E0291 = "按生效日期";
            /// <summary>
            /// 手工导入    ----yyang26
            /// </summary>
            public const string E0292 = "手工导入";
            /// <summary>
            /// 是否初始化未盘到料箱及BIN位
            /// </summary>
            public const string E0293 = "是否初始化未盘到料箱及BIN位？";
            /// <summary>
            /// 是否调整系统库存
            /// </summary>
            public const string E0294 = "是否调整系统库存？";
            /// <summary>
            /// ONESIDE@INVADJ
            /// </summary>
            public const string E0295 = "ONESIDE@INVADJ";
            /// <summary>
            /// 请扫描料箱号    ----朱伟力
            /// </summary>
            public const string E0296 = "请扫描料箱号";
            /// <summary>
            /// 当前业务只适用于小件
            /// </summary>
            public const string E0297 = "当前业务只适用于小件";
            /// <summary>
            /// 必须为零头料箱 -------朱伟力
            /// </summary>
            public const string E0298 = "必须为零头料箱";
            /// <summary>
            /// 请先确认上架 -------朱伟力
            /// </summary>
            public const string E0299 = "请先确认上架";
            /// <summary>
            /// 是否撤销订单 -------朱伟力
            /// </summary>
            public const string E0300 = "是否撤销订单";
            /// <summary>
            /// 订单已撤销或者关闭 -------朱伟力
            /// </summary>
            public const string E0301 = "订单已撤销或者关闭";
            /// <summary>
            /// 请选择组号 -------朱伟力
            /// </summary>
            public const string E0302 = "请选择组号";
            /// <summary>
            /// 装箱条码中存在已经在其他地方使用的条码 -------朱伟力
            /// </summary>
            public const string E0303 = "装箱条码中存在已经在其他地方使用，是否取消绑定关系重新扫描";
            /// <summary>
            /// 工厂系统使用情况检查1 -------yyang26
            /// </summary>
            public const string E0304 = "工厂系统使用情况检查1";
            /// <summary>
            /// 工厂系统使用情况检查2 -------yyang26
            /// </summary>
            public const string E0349 = "工厂系统使用情况检查2";
            /// <summary>
            /// 工厂异常数据检查 -------yyang26
            /// </summary>
            public const string E0305 = "工厂异常数据检查";
            /// <summary>
            /// MES基础数据检查 -------yyang26
            /// </summary>
            public const string E0306 = "MES基础数据检查";
            /// <summary>
            /// MES系统逻辑检查 -------yyang26
            /// </summary>
            public const string E0307 = "MES系统逻辑检查";
            /// <summary>
            /// 当前空条码数 -------yyang26
            /// </summary>
            public const string E0308 = "当前空条码数";
            /// <summary>
            /// 时间段内注塑下线扫描数 -------yyang26
            /// </summary>
            public const string E0309 = "时间段内注塑下线扫描数";
            /// <summary>
            /// 时间段内注塑下线打包数 -------yyang26
            /// </summary>
            public const string E0310 = "时间段内注塑下线打包数";
            /// <summary>
            /// 时间段生效日内小件汇报数 -------yyang26
            /// </summary>
            public const string E0311 = "时间段生效日内小件汇报数";
            /// <summary>
            /// 时间段内油漆上线扫描数 -------yyang26
            /// </summary>
            public const string E0312 = "时间段内油漆上线扫描数";
            /// <summary>
            /// 待处理库位呆滞条码(下线超过4小时) -------yyang26
            /// </summary>
            public const string E0313 = "待处理库位呆滞条码(下线超过4小时)";
            /// <summary>
            /// 涂装质检区呆滞条码(下线超过4小时) -------yyang26
            /// </summary>
            public const string E0314 = "涂装质检区呆滞条码(下线超过4小时)";
            /// <summary>
            /// 时间段内下线扫描数 -------yyang26
            /// </summary>
            public const string E0315 = "时间段内下线扫描数";
            /// <summary>
            /// 油漆上线与油漆下线扫描时间超过5小时的不正常小于3小时的不正常 -------yyang26
            /// </summary>
            public const string E0316 = "油漆上线与油漆下线扫描时间超过5小时的不正常小于3小时的不正常";
            /// <summary>
            /// 时间段内TS使用情况 -------yyang26
            /// </summary>
            public const string E0317 = "时间段内TS使用情况";
            /// <summary>
            /// 涂装打磨区呆滞条码 -------yyang26
            /// </summary>
            public const string E0318 = "涂装打磨区呆滞条码";
            /// <summary>
            /// 涂装打磨区库存 -------yyang26
            /// </summary>
            public const string E0319 = "涂装打磨区库存";
            /// <summary>
            /// 涂装打磨件库位呆滞条码 -------yyang26
            /// </summary>
            public const string E0320 = "涂装打磨件库位呆滞条码";
            /// <summary>
            /// 涂装打磨件库位库存 -------yyang26
            /// </summary>
            public const string E0321 = "涂装打磨件库位库存";
            /// <summary>
            /// 时间段内涂装下线散件数 -------yyang26
            /// </summary>
            public const string E0322 = "时间段内涂装下线散件数";
            /// <summary>
            /// 时间段内装配扫描数 -------yyang26
            /// </summary>
            public const string E0323 = "时间段内装配扫描数";
            /// <summary>
            /// 时间段内Vincode报表匹配情况 -------yyang26
            /// </summary>
            public const string E0324 = "时间段内Vincode报表匹配情况";
            /// <summary>
            /// 点修库位的库存 -------yyang26
            /// </summary>
            public const string E0325 = "点修库位的库存";
            /// <summary>
            /// 时间段内涂装上线拉动TO数 -------yyang26
            /// </summary>
            public const string E0326 = "时间段内涂装上线拉动TO数";
            /// <summary>
            /// 时间段内强制转移数 -------yyang26
            /// </summary>
            public const string E0327 = "时间段内强制转移数";
            /// <summary>
            /// 时间段内强制变更数 -------yyang26
            /// </summary>
            public const string E0328 = "时间段内强制变更数";
            /// <summary>
            /// 时间段内扫描件手工汇报数 -------yyang26
            /// </summary>
            public const string E0329 = "时间段内扫描件手工汇报数";
            /// <summary>
            /// 时间段内Cancel TO数 -------yyang26
            /// </summary>
            public const string E0330 = "时间段内Cancel TO数";
            /// <summary>
            /// 呆滞Open TO数 -------yyang26
            /// </summary>
            public const string E0338 = "呆滞Open TO数";
            /// <summary>
            /// 时间段内补条码数 -------yyang26
            /// </summary>
            public const string E0331 = "时间段内补条码数";
            /// <summary>
            /// 时间段内班组长处理日志数 -------yyang26
            /// </summary>
            public const string E0332 = "时间段内班组长处理日志数";
            /// <summary>
            /// 负库存数 -------yyang26
            /// </summary>
            public const string E0333 = "负库存数";
            /// <summary>
            /// 库存过多数 -------yyang26
            /// </summary>
            public const string E0334 = "库存过多数";
            /// <summary>
            /// 超期未关闭订单数 -------yyang26
            /// </summary>
            public const string E0335 = "超期未关闭订单数";
            /// <summary>
            /// 条码隔离数 -------yyang26
            /// </summary>
            public const string E0336 = "条码隔离数";
            /// <summary>
            /// 空箱返回数 -------yyang26
            /// </summary>
            public const string E0337 = "空箱返回数";
            /// <summary>
            /// 条码已被其他用户进行过盘点  --王小乐
            /// </summary>
            public const string E0339 = "该条码由用户：{0} 进行过盘点,你确定要再次盘点该物料吗?";
            /// <summary>
            /// AGV包装数量未配置  --王小乐
            /// </summary>
            public const string E0340 = "产品{0}的AGV包装没有配置";
            /// <summary>
            /// 打包时候少了料箱配置数据 --王小乐
            /// </summary>
            public const string E0341 = "料箱数据没有配置";
            /// <summary>
            /// 请选择起始时间或者结束时间 --朱伟力
            /// </summary>
            public const string E0342 = "请选择起始时间或者结束时间";
            /// <summary>
            /// 是否删除看板时间段 --朱伟力
            /// </summary>
            public const string E0343 = "是否删除看板时间段";
            /// <summary>
            /// 产品已挂牌 --朱伟力
            /// </summary>
            public const string E0344 = "产品已挂牌";
            /// <summary>
            /// 请选择角色名称 --朱伟力
            /// </summary>
            public const string E0345 = "请选择角色名称";
            /// <summary>
            /// 请选择订单组 --朱伟力
            /// </summary>
            public const string E0346 = "请选择订单组";
            /// <summary>
            /// 请选择收/发 --朱伟力
            /// </summary>
            public const string E0347 = "请选择收";
            /// <summary>
            /// 找不到该配置选项  --lwu4 20130315 frm_Assembly用到
            /// </summary>
            public const string E0348 = "找不到该配置选项";
            /// <summary>
            /// 当前RK是无效RK，请确认您的输入正确 --lwu4 20130319 3D仓库用
            /// </summary>
            public const string E0350 = "当前托盘是无效RK，请确认您的输入正确";
            /// <summary>
            /// 当前托盘是出库作业，不允许作入库作业 --lwu4 20130319 3D仓库用
            /// </summary>
            public const string E0351 = "当前托盘是出库作业，不允许作入库作业";
            /// <summary>
            /// 没有物流订单权限 --朱伟力
            /// </summary>
            public const string E0352 = "没有物流订单权限";
            /// <summary>
            /// 小件不能用标准下架 --朱伟力
            /// </summary>
            public const string E0353 = "小件不能用标准下架";
            /// <summary>
            /// 小件不能用标准下架 --朱伟力
            /// </summary>
            public const string E0354 = "查询异常，可能是查询超时请缩小范围进行查询！";
            /// <summary>
            /// 必须是同一产品同一颜色的前后保才可以上架 --朱伟力
            /// </summary>
            public const string E0355 = "必须是同一产品同一颜色的前后保才可以上架";
            /// <summary>
            /// 涂装装箱不能扫描注塑件 --王小乐
            /// </summary>
            public const string E0356 = "涂装装箱不能扫描注塑件";
            /// <summary>
            /// PL不能为空 --朱伟力
            /// </summary>
            public const string E0357 = "PL不能为空";
            /// <summary>
            /// 没有配置对应的库位权限 --lwu4
            /// </summary>
            public const string E0358 = "没有配置对应的库位权限";
            /// <summary>
            /// 请输入称重设备代码 --zhuweili
            /// </summary>
            public const string E0359 = "请输入称重设备代码";
            /// <summary>
            /// 请输入称重产品代码 --zhuweili
            /// </summary>
            public const string E0360 = "请输入称重产品代码";
            /// <summary>
            /// 请输入物料号 --zhuweili
            /// </summary>
            public const string E0361 = "请输入物料号";
            /// <summary>
            /// 已存在产品类型 --zhuweili
            /// </summary>
            public const string E0362 = "已存在产品类型";
            /// <summary>
            /// 日期范围选择有误
            /// </summary>
            public const string E0363 = "日期范围选择有误";
            /// <summary>
            /// 当前零件号和加驳单零件号不一致
            /// </summary>
            public const string E0364 = "当前零件号和加驳单零件号不一致";
            /// <summary>
            /// 加驳单扫描成功
            /// </summary>
            public const string E0365 = "加驳单扫描成功";
            /// <summary>
            /// 请继续选择产品状态
            /// </summary>
            public const string E0366 = "请继续选择产品状态";
            /// <summary>
            /// 请选择库位
            /// </summary>
            public const string E0367 = "请选择库位";
            /// <summary>
            /// 请选择汇总方式
            /// </summary>
            public const string E0368 = "请选择汇总方式";
            /// <summary>
            /// 选项不存在
            /// </summary>
            public const string E0369 = "选项不存在";
            /// <summary>
            /// 确认要跳过此项目
            /// </summary>
            public const string E0370 = "确认要跳过此项目";
            /// <summary>
            /// 小件不能用质量扫描
            /// </summary>
            public const string E0371 = "小件不能用质量扫描";
            /// <summary>
            /// 外协件不能用质量扫描
            /// </summary>
            public const string E0372 = "外协件不能用质量扫描";
            /// <summary>
            /// 隔离状态不能使用质量扫描
            /// </summary>
            public const string E0373 = "隔离状态不能使用质量扫描";
            /// <summary>
            /// 已转底漆件不能再使用冻结
            /// </summary>
            public const string E0374 = "已转底漆件不能再使用冻结";
            /// <summary>
            /// 待底漆件不能再使用转底漆
            /// </summary>
            public const string E0375 = "待底漆件不能再使用转底漆";
            /// <summary>
            /// 半成品不能再使用质量扫描
            /// </summary>
            public const string E0376 = "半成品不能再使用质量扫描";
            /// <summary>
            /// 产生新料箱单需手工打印：
            /// </summary>
            public const string E0377 = "产生新料箱单需手工打印：";
            /// <summary>
            /// 请选择判定结果
            /// </summary>
            public const string E0378 = "请选择判定结果";
            /// <summary>
            /// 无法打印请确认基础资料配置无误
            /// </summary>
            public const string E0379 = "无法打印请确认基础资料配置无误";
            /// <summary>
            /// 涂装小件入库单
            /// </summary>
            public const string E0380 = "BZ.0.3";
            /// <summary>
            /// 涂装小件退库单
            /// </summary>
            public const string E0381 = "BZ.0.4";
            /// <summary>
            /// 您没有相关操作权限
            /// </summary>
            public const string E0382 = "您没有相关操作权限";
            /// <summary>
            /// 订单已被添加，请重新选择
            /// </summary>
            public const string E0383 = "订单已被添加，请重新选择";
            /// <summary>
            /// 是否作废最后件条码
            /// </summary>
            public const string E0384 = "是否作废最后件条码";
            /// <summary>
            /// 请点击最后件合格或者冻结
            /// </summary>
            public const string E0385 = "请点击最后件合格或者冻结";
            /// <summary>
            /// 条码没上过涂装线或不为所选涂装线
            /// </summary>
            public const string E0386 = "条码没上过涂装线或不为所选涂装线";
            /// <summary>
            /// 涂装上线时间异常
            /// </summary>
            public const string E0387 = "涂装上线时间异常";
            /// <summary>
            /// 父零件或打散数量异常
            /// </summary>
            public const string E0388 = "父零件或打散数量异常";
            /// <summary>
            /// 取客户零件号失败,请确认基础资料配置完成
            /// </summary>
            public const string E0389 = "取客户零件号失败,请确认基础资料配置完成";
            /// <summary>
            /// 托盘就绪
            /// </summary>
            public const string E0390 = "托盘就绪";
            /// <summary>
            /// 紧急拉动成功
            /// </summary>
            public const string E0391 = "紧急拉动成功";
            /// <summary>
            /// 条码或者料箱不存在
            /// </summary>
            public const string E0392 = "条码或者料箱不存在";
            /// <summary>
            /// 冻结状态不能使用隔离扫描
            /// </summary>
            public const string E0393 = "冻结状态不能使用隔离扫描";
            /// <summary>
            /// 小件不能用隔离扫描
            /// </summary>
            public const string E0394 = "小件不能用隔离扫描";
            /// <summary>
            /// 外协件不能用隔离扫描
            /// </summary>
            public const string E0395 = "外协件不能用隔离扫描";
            /// <summary>
            /// 重新上架操作异常
            /// </summary>
            public const string E0396 = "重新上架操作异常";
            /// <summary>
            /// 该小件条码尚未进行装配绑定
            /// </summary>
            public const string E0397 = "该小件条码尚未进行装配绑定";
            /// <summary>
            /// 已发运，无法回收
            /// </summary>
            public const string E0398 = "已发运，你确定要进行回收吗？";
            /// <summary>
            /// 订单删除失败
            /// </summary>
            public const string E0399 = "订单删除失败";
            /// <summary>
            /// 必须先出库大于14天的条码
            /// </summary>
            public const string E0400 = "必须先出库大于14天的条码";
            /// <summary>
            /// 必须扫描外协件条码
            /// </summary>
            public const string E0401 = "必须扫描外协件条码";
            /// <summary>
            /// 条码尚未发运，无法打印
            /// </summary>
            public const string E0402 = "条码尚未发运，无法打印";
            /// <summary>
            /// 打印成功
            /// </summary>
            public const string E0403 = "打印成功";
            /// <summary>
            /// 隔离扫描不能条码装箱
            /// </summary>
            public const string E0404 = "隔离扫描不能条码装箱";
            /// <summary>
            /// 点修状态不能使用质量扫描
            /// </summary>
            public const string E0405 = "点修状态不能使用质量扫描";
            /// <summary>
            /// 点修状态不能使用隔离扫描
            /// </summary>
            public const string E0406 = "点修状态不能使用隔离扫描";
            /// <summary>
            /// 冻结状态不能使用点修扫描
            /// </summary>
            public const string E0407 = "冻结状态不能使用点修扫描";
            /// <summary>
            /// 隔离状态不能使用点修扫描
            /// </summary>
            public const string E0408 = "隔离状态不能使用点修扫描";
            /// <summary>
            /// 是否重置自动条码
            /// </summary>
            public const string E0409 = "是否重置自动条码";
            /// <summary>
            /// 开始TS上架
            /// </summary>
            public const string E0410 = "开始TS";
            /// <summary>
            /// 关闭TS上架
            /// </summary>
            public const string E0411 = "关闭TS";
            /// <summary>
            /// 不允许同时打多个料箱
            /// </summary>
            public const string E0412 = "不允许同时打多个料箱";
            /// <summary>
            /// 立体仓库内不能进行隔离
            /// </summary>
            public const string E0413 = "立体仓库内不能进行隔离";
            /// <summary>
            /// 工位信息配置不全
            /// </summary>
            public const string E0414 = "工位信息配置不全";
            /// <summary>
            /// 没有配置运输方式
            /// </summary>
            public const string E0415 = "没有配置运输方式";
            /// <summary>
            /// 超过该口最大手工拉动数，请稍候再拉动
            /// </summary>
            public const string E0416 = "超过该口最大手工拉动数，请稍候再拉动";
            /// <summary>
            /// 料箱单生成失败
            /// </summary>
            public const string E0417 = "料箱单生成失败";
            /// <summary>
            /// 涂装线内区不能报废
            /// </summary>
            public const string E0418 = "涂装线内区不能报废";
            /// <summary>
            /// 请选择生产线
            /// </summary>
            public const string E0419 = "请选择生产线";
            /// <summary>
            /// 你所选择的产品料箱代码不一致，请分开生成两张入库申请单
            /// </summary>
            public const string E0420 = "你所选择的产品料箱代码不一致，请分开生成两张入库申请单";
            /// <summary>
            /// 入库申请单创建失败
            /// </summary>
            public const string E0421 = "入库申请单创建失败";
            /// <summary>
            /// 料箱入库自动收货失败，请手工进行收货确认
            /// </summary>
            public const string E0422 = "料箱入库自动收货失败，请手工进行收货确认";
            /// <summary>
            /// 请扫描看板卡后继续
            /// </summary>
            public const string E0423 = "请扫描看板卡后继续";
            /// <summary>
            /// 配料单下达成功
            /// </summary>
            public const string E0424 = "配料单下达成功";
            /// <summary>
            /// 对不起，只能扫描产品，
            /// </summary>
            public const string E0425 = "只能扫描产品为";
            /// <summary>
            /// 请选择分组描述
            /// </summary>
            public const string E0426 = "请选择分组描述";
            /// <summary>
            /// 看板卡扫描成功
            /// </summary>
            public const string E0427 = "看板卡扫描成功";
            /// <summary>
            /// 看板卡信息错误，请重新扫描
            /// </summary>
            public const string E0428 = "看板卡信息错误，请重新扫描";
            /// <summary>
            /// 配料单不存在或已关闭，无法收货，请重新扫描
            /// </summary>
            public const string E0429 = "配料单不存在或已关闭，无法收货，请重新扫描";
            /// <summary>
            /// 请关闭称重后再扫描
            /// </summary>
            public const string E0430 = "请关闭称重后再扫描";
            /// <summary>
            /// 托盘已被标记为异常，你要恢复成正常状态吗？
            /// </summary>
            public const string E0431 = "托盘已被标记为异常，你要恢复成正常状态吗？";
            /// <summary>
            /// 出门证生成成功，但打印失败。请检查打印机及打印模板是否正确。？
            /// </summary>
            public const string E0432 = "出门证生成成功，但打印失败。请检查打印机及打印模板是否正确。";
            /// <summary>
            /// 找不到同步信息，请核实。
            /// </summary>
            public const string E0433 = "找不到同步信息，请核实。";
            /// <summary>
            /// WMS库位地址(BIN)不正确，请核实。
            /// </summary>
            public const string E0434 = "WMS库位地址(BIN)不正确，请核实。";
            /// <summary>
            /// 取不到{0}表数据
            /// </summary>
            public const string E0435 = "取不到{0}表数据";
            /// <summary>
            /// 找不到WMS库存资料
            /// </summary>
            public const string E0436 = "找不到WMS库存资料";
            /// <summary>
            /// 该条码正在其他操作，请先处理
            /// </summary>
            public const string E0437 = "该条码正在其他操作，请先处理";
            /// <summary>
            /// 找不到WMS出入库资料
            /// </summary>
            public const string E0438 = "找不到WMS出入库资料";
            /// <summary>
            /// 无需拉动
            /// </summary>
            public const string E0439 = "无需拉动";
            /// <summary>
            /// 没有定义配料单打印参数
            /// </summary>
            public const string E0440 = "没有定义配料单打印参数";
            /// <summary>
            /// 托盘离库
            /// </summary>
            public const string E0441 = "托盘离库";
            /// <summary>
            /// 请输入工位器具编号
            /// </summary>
            public const string E0442 = "请输入工位器具编号";
            /// <summary>
            /// 请输入工位器具描述
            /// </summary>
            public const string E0443 = "请输入工位器具描述";
            /// <summary>
            /// 改工位器具编号已存在
            /// </summary>
            public const string E0444 = "改工位器具编号已存在";
            /// <summary>
            /// 预计发运时间
            /// </summary>
            public const string E0445 = "预计发运时间";
            /// <summary>
            /// 料箱与条码无关联
            /// </summary>
            public const string E0446 = "料箱与条码无关联";
            /// <summary>
            /// 料箱不是待底漆件
            /// </summary>
            public const string E0447 = "料箱不是待底漆件";
            /// <summary>
            /// 料箱不能和谐扫描
            /// </summary>
            public const string E0448 = "料箱不能和谐扫描";
            /// <summary>
            /// 条码不是待底漆件
            /// </summary>
            public const string E0449 = "条码不是待底漆件";
            /// <summary>
            /// 条码不能和谐扫描
            /// </summary>
            public const string E0450 = "条码不能和谐扫描";
            /// <summary>
            /// 当前产品不能注塑下线
            /// </summary>
            public const string E0451 = "当前产品不能注塑下线";
            /// <summary>
            /// 请扫描看板后打印
            /// </summary>
            public const string E0452 = "请扫描看板后打印";
            /// <summary>
            /// 配料单已打印
            /// </summary>
            public const string E0453 = "配料单已打印";
            /// <summary>
            /// 配料单已完成送货，无法重打印
            /// </summary>
            public const string E0454 = "配料单已完成送货，无法重打印";
            /// <summary>
            /// 请选择配料单后发货
            /// </summary>
            public const string E0455 = "请选择配料单后发货";
            /// <summary>
            /// 没有可发货零件，请重新扫描
            /// </summary>
            public const string E0456 = "没有可发货零件，请重新扫描";
            /// <summary>
            /// 配料单无内容
            /// </summary>
            public const string E0457 = "配料单无内容";
            /// <summary>
            ///料箱清空
            /// </summary>
            public const string E0458 = "料箱清空";
            /// <summary>
            ///CANCEL拉动信息
            /// </summary>
            public const string E0459 = "CANCEL拉动信息";
            /// <summary>
            ///数量为0不能进行隔离扫描
            /// </summary>
            public const string E0460 = "数量为0不能进行隔离扫描";
            /// <summary>
            ///已经退货，不能再扫描
            /// </summary>
            public const string E0461 = "已经退货，不能再扫描";
            /// <summary>
            ///隔离失败
            /// </summary>
            public const string E0462 = "隔离失败";
            /// <summary>
            ///放行失败
            /// </summary>
            public const string E0463 = "放行失败";
            /// <summary>
            ///TransHist原库位不存在
            /// </summary>
            public const string E0464 = "TransHist原库位不存在";
            /// <summary>
            ///来源库位与产品库位不一致，不允许出库
            /// </summary>
            public const string E0465 = "来源库位与产品库位不一致，不允许出库";

            /// <summary>
            /// 出库扫描-强制出库 --lwu4 20140108
            /// </summary>
            public const string E0466 = "强制出库";
            /// <summary>
            /// 挂黄牌不能发运
            /// </summary>
            public const string E0467 = "挂电子黄牌的条码不能发运";
            /// <summary>
            /// 3D仓库出库
            /// </summary>
            public const string E0468 = "3D仓库出库";
            /// <summary>
            /// 3D仓库出库-托盘清空
            /// </summary>
            public const string E0469 = "托盘清空";
            /// <summary>
            /// 3D仓库出库-整箱出库但不移库
            /// </summary>
            public const string E0470 = "整箱出库";
            /// <summary>
            /// 已发运条码不能装箱
            /// </summary>
            public const string E0471 = "已发运条码不能装箱";
            /// <summary>
            /// 返修失败
            /// </summary>
            public const string E0472 = "返修失败";
            /// <summary>
            /// 没有选择涂装线
            /// </summary>
            public const string E0473 = "没有选择涂装线";
            /// <summary>
            /// BIN位获取失败，请进行手工上架。
            /// </summary>
            public const string E0474 = "BIN位获取失败，但库存已转移，请进行手工上架";
            /// <summary>
            /// BIN位数量不满足
            /// </summary>
            public const string E0475 = "BIN位数量不满足";
            /// <summary>
            /// 只能扫描TS小车RK
            /// </summary>
            public const string E0476 = "只能扫描TS小车RK";
            /// <summary>
            /// 不能扫描TS小车RK
            /// </summary>
            public const string E0477 = "不能扫描TS小车RK";
            /// <summary>
            /// 重新插入数据失败
            /// </summary>
            public const string E0478 = "重新插入数据失败";
            /// <summary>
            /// 不符合拉动数量
            /// </summary>
            public const string E0479 = "不符合拉动数量";
            /// <summary>
            /// TS手工拉动数量不能大于21
            /// </summary>
            public const string E0480 = "TS手工拉动数量不能大于21";
            /// <summary>
            /// 托盘已质量隔离，请使用“托盘清空”功能进行操作
            /// </summary>
            public const string E0481 = "托盘已质量隔离，请使用“托盘清空”功能进行操作";
            /// <summary>
            /// 条码上次扫描时间已超过X天，是否仍上线
            /// </summary>
            public const string E0482 = "条码上次扫描时间已超过X天，是否仍上线？";
            /// <summary>
            /// 条码库位和正在打包同产品库位不一致，不能进行打箱
            /// </summary>
            public const string E0483 = "条码库位{0}和正在打包同产品库位{1}不一致，不能进行打箱";
            /// <summary>
            /// 找不到控件
            /// </summary>
            public const string E0484 = "找不到控件";
            /// <summary>
            /// 客户零件号标签
            /// </summary>
            public const string E0485 = "客户零件号标签";
            /// <summary>
            /// 工厂系统使用情况
            /// </summary>
            public const string E0486 = "工厂系统使用情况";
            /// <summary>
            /// 校验通过
            /// </summary>
            public const string E0487 = "校验通过";
            /// <summary>
            /// 是否重新扫描条码
            /// </summary>
            public const string E0488 = "是否重新扫描条码";
            /// <summary>
            /// 涂装装箱强制封箱
            /// </summary>
            public const string E0489 = "涂装装箱强制封箱";
            /// <summary>
            /// 评价体系明细
            /// </summary>
            public const string E0490 = "评价体系明细";
            /// <summary>
            /// 没有定义该采集表的数据采集方式
            /// </summary>
            public const string E0491 = "没有定义该采集表的数据采集方式";
            /// <summary>
            /// 数据尚未取得，无法保存。
            /// </summary>
            public const string E0492 = "数据尚未取得，无法保存。";
            /// <summary>
            /// 你有尚未填写的项目，请确认是否数据采集已结束?
            /// </summary>
            public const string E0493 = "你有尚未填写的项目，请确认是否数据采集已结束?";
            /// <summary>
            /// 产品类型不能为空
            /// </summary>
            public const string E0494 = "产品类型不能为空";
            /// <summary>
            /// 没有定义自动扫描设备的设备编号
            /// </summary>
            public const string E0495 = "没有定义自动扫描设备的设备编号";
            /// <summary>
            /// 没有做过前道工序
            /// </summary>
            public const string E0496 = "没有做过前道工序";
            /// <summary>
            /// 没有配置该产品的静置时间
            /// </summary>
            public const string E0497 = "没有配置该产品的静置时间";
            /// <summary>
            /// 静置时间还没到，当前静置时间
            /// </summary>
            public const string E0498 = "静置时间还没到，当前静置时间";
            /// <summary>
            /// 已超过静置有效时间，当前静置时间
            /// </summary>
            public const string E0499 = "已超过静置有效时间，当前静置时间";
            /// <summary>
            /// 已隔离条码不能进行强制变更
            /// </summary>
            public const string E0500 = "已隔离条码不能进行强制变更";
            /// <summary>
            /// 该产品的TOConfig配置有错.
            /// </summary>
            public const string E0501 = "该产品的TOConfig配置有错.";
            /// <summary>
            /// 找不到barindet_mstr配置
            /// </summary>
            public const string E0502 = "找不到下道工序配置(barindet_mstr)";
            /// <summary>
            /// 找不到当前工序的汇报零件号
            /// </summary>
            public const string E0503 = "找不到当前工序的汇报零件号";
            /// <summary>
            /// 条码与日志变更失败(HalfConfig)
            /// </summary>
            public const string E0504 = "条码与日志变更失败(HalfConfig)";
            /// <summary>
            /// 找不到上道工序配置(barindet_mstr)
            /// </summary>
            public const string E0505 = "找不到上道工序配置(barindet_mstr)";
            /// <summary>
            /// 零件类型没有维护正确(Next PartType)
            /// </summary>
            public const string E0506 = "零件类型没有维护正确(Next PartType)";
            /// <summary>
            /// 超过两个匹配零件，请检查配置
            /// </summary>
            public const string E0507 = "超过两个匹配零件，请检查配置";
            /// <summary>
            /// 开启称重
            /// </summary>
            public const string E0508 = "开启称重";
            /// <summary>
            /// 关闭称重
            /// </summary>
            public const string E0509 = "关闭称重";
            /// <summary>
            /// 开启自动
            /// </summary>
            public const string E0510 = "开启自动";
            /// <summary>
            /// 关闭自动
            /// </summary>
            public const string E0511 = "关闭自动";
            /// <summary>
            /// 取产品有效期失败
            /// </summary>
            public const string E0512 = "取加料产品有效期失败";
            /// <summary>
            /// 已过期
            /// </summary>
            public const string E0513 = "料筒内产品已过期";
            /// <summary>
            /// 未开封
            /// </summary>
            public const string E0514 = "料筒产品未开封";
            /// <summary>
            /// 产品类型不匹配，请确认前道扫描是否汇报
            /// </summary>
            public const string E0515 = "产品类型不匹配，请确认前道扫描是否汇报成功";
            /// <summary>
            /// 是否打印条码
            /// </summary>
            public const string E0516 = "是否打印条码";
            /// <summary>
            /// 找不到你所输入的装配单
            /// </summary>
            public const string E0517 = "找不到你所输入的装配单";
            /// <summary>
            /// 以下项目未装配
            /// </summary>
            public const string E0518 = "以下项目未装配";
            /// <summary>
            /// 超过打包数量，请重新扫描
            /// </summary>
            public const string E0519 = "超过打包数量，请重新扫描";
            /// <summary>
            /// 资源不足
            /// </summary>
            public const string E0520 = "资源不足";
            /// <summary>
            /// 不排序预装
            /// </summary>
            public const string E0521 = "不排序预装";
            /// <summary>
            /// 条码已归档且已被隔离，无法继续使用
            /// </summary>
            public const string E0522 = "条码已归档且已被隔离，无法继续使用";
            /// <summary>
            /// 注塑缺陷
            /// </summary>
            public const string E0523 = "注塑缺陷";
            /// <summary>
            /// 涂装缺陷
            /// </summary>
            public const string E0524 = "涂装缺陷";
            /// <summary>
            /// 装配缺陷
            /// </summary>
            public const string E0525 = "装配缺陷";
            /// <summary>
            /// 订单不存在或者已关闭 -------朱伟力
            /// </summary>
            public const string E0526 = "扫描的小车号不存在";
            /// <summary>
            /// 请按照排序顺序扫描 -------朱伟力
            /// </summary>
            public const string E0527 = "请按照排序顺序扫描";
            /// <summary>
            /// 找不到指定的排序项
            /// </summary>
            public const string E0528 = "找不到指定的排序项";
            /// <summary>
            /// 你没有选择班次，请确认选择了正确的区域。
            /// </summary>
            public const string E0529 = "你没有选择班次，请确认选择了正确的区域。";
            /// <summary>
            /// 你没有选择排序装配线。
            /// </summary>
            public const string E0530 = "你没有选择排序装配线。";
            /// <summary>
            /// 该产品条码已经绑定了其它装配单号
            /// </summary>
            public const string E0531 = "该产品条码已经绑定了其它装配单号";
            /// <summary>
            /// 该装配单已经完成，无法再次扫描装配
            /// </summary>
            public const string E0532 = "该装配单已经完成，无法再次扫描装配";
            /// <summary>
            /// 该装配单没有装配明细
            /// </summary>
            public const string E0533 = "该装配单没有装配明细";
            /// <summary>
            /// 该产品无法匹配当前装配单，请核实后重试。
            /// </summary>
            public const string E0534 = "该产品无法匹配当前装配单，请核实后重试。";
            /// <summary>
            /// 您还没有配置防错设备清单，无法进行防错预绑定
            /// </summary>
            public const string E0535 = "您还没有配置防错设备清单，无法进行防错预绑定";
            /// <summary>
            /// 没有接收到装配单信息，请确认该排序信息已经生成装配单
            /// </summary>
            public const string E0536 = "没有接收到装配单信息，请确认该排序信息已经生成装配单";
            /// <summary>
            /// 装配单没有输入，请重试
            /// </summary>
            public const string E0537 = "装配单没有输入，请重试";
            /// <summary>
            /// 条码没有预绑定过，请核实后重试!
            /// </summary>
            public const string E0538 = "条码没有预绑定过，请核实后重试!";
            /// <summary>
            /// 请输入新条码
            /// </summary>
            public const string E0539 = "请输入新条码";
            /// <summary>
            /// 找不到订单明细，请确认后重试.
            /// </summary>
            public const string E0540 = "找不到订单明细，请确认后重试.";
            /// <summary>
            /// 当前无装配任务
            /// </summary>
            public const string E0541 = "当前无装配任务";
            /// <summary>
            /// 料箱类别
            /// </summary>
            public const string E0542 = "料箱类别";
            /// <summary>
            /// 零件类别
            /// </summary>
            public const string E0543 = "零件类别";
            /// <summary>
            /// ctsd_property3 + ' ' + ctsd_property2 = ct_property不匹配
            /// </summary>
            public const string E0544 = "ctsd_property3 + ' ' + ctsd_property2 = ct_property不匹配";
            /// <summary>
            /// 已缓存
            /// </summary>
            public const string E0545 = "已缓存";
            /// <summary>
            /// 你没有选择班次与扫描点，请确认选择了正确的区域。
            /// </summary>
            public const string E0546 = "你没有选择班次与扫描点，请确认选择了正确的区域。";
            /// <summary>
            /// 基础资料未维护(ctsd_det)
            /// </summary>
            public const string E0547 = "基础资料未维护(ctsd_det)";
            /// <summary>
            /// {0}方法处理失败
            /// </summary>
            public const string E0548 = "{0}方法处理失败";
            /// <summary>
            /// {0}方法报错\n异常信息：{1}
            /// </summary>
            public const string E0549 = "{0}方法报错\n异常信息：{1}";
            /// <summary>
            /// 要处理的ID号不为数值
            /// </summary>
            public const string E0550 = "要处理的ID号不为数值";
            /// <summary>
            /// 多条ID: [ {0} ]数据被【{1}】处理,请检查
            /// </summary>
            public const string E0551 = "多条ID: [ {0} ]数据被【{1}】处理,请检查";
            /// <summary>
            /// 【{0}】操作失败，此ID：[ {1} ]不存在[ {2} ]中或尚未【标记】处理
            /// </summary>
            public const string E0552 = "【{0}】操作失败，此ID：[ {1} ]不存在[ {2} ]中或尚未【标记】处理";
            /// <summary>
            /// 【{0}】成功
            /// </summary>
            public const string E0553 = "【{0}】成功";
            /// <summary>
            /// lc_mstr中找不到iss-asm库位
            /// </summary>
            public const string E0554 = "lc_mstr中找不到iss-asm库位";
            /// <summary>
            /// 当前订单数：{0}，整单数为：{1}的倍数，无法匹配。有可能排序信息尚未接收完，请确认是否继续添加？
            /// </summary>
            public const string E0555 = "当前订单数：{0}，整单数为：{1}的倍数，无法匹配。有可能排序信息尚未接收完，请确认是否继续添加？";
            /// <summary>
            /// 装配单号未输入或前道工序未绑定装配单号。
            /// </summary>
            public const string E0556 = "装配单号未输入或前道工序未绑定装配单号。";
            /// <summary>
            /// 该条码未绑定装配单
            /// </summary>
            public const string E0557 = "该条码未绑定装配单";
            /// <summary>
            /// 未检测到工装反馈信号，请先完成工装防错操作！
            /// </summary>
            public const string E0558 = "未检测到工装反馈信号，请先完成工装防错操作！";
            /// <summary>
            /// 通断检测结果不合格，请重新检测！
            /// </summary>
            public const string E0559 = "通断检测结果不合格，请重新检测！";
            /// <summary>
            /// "条码已隔离，不允许进行工序扫描."
            /// </summary>
            public const string E0560 = "条码已隔离，不允许进行工序扫描.";
            /// <summary>
            /// 条码已发运，不允许进行工序扫描.
            /// </summary>
            public const string E0561 = "条码已发运，不允许进行工序扫描.";
            /// <summary>
            /// 条码已挂黄牌，不允许进行工序扫描.
            /// </summary>
            public const string E0562 = "条码已挂黄牌，不允许进行工序扫描.";
            /// <summary>
            /// 已取消此次绑定
            /// </summary>
            public const string E0563 = "已取消此次绑定";
            /// <summary>
            /// 该装配单已预绑定过，是否重新绑定?
            /// </summary>
            public const string E0564 = "该装配单已预绑定过，是否重新绑定?";
            /// <summary>
            /// 请确认包装或货架信息配置正确
            /// </summary>
            public const string E0565 = "请确认包装或货架信息配置正确";
            /// <summary>
            /// 找不到预排序信息，请进行手工加驳!
            /// </summary>
            public const string E0566 = "找不到预排序信息，请进行手工加驳!";
            /// <summary>
            /// 非排序装配单，请手工加驳！
            /// </summary>
            public const string E0567 = "非排序装配单，请手工加驳！";
            /// <summary>
            /// 该条码对应的装配单号不唯一
            /// </summary>
            public const string E0568 = "该条码对应的装配单号不唯一";
            /// <summary>
            /// 没有找到该条码对应的装配单号
            /// </summary>
            public const string E0569 = "没有找到该条码对应的装配单号";
            /// <summary>
            /// 该功能尚示实现
            /// </summary>
            public const string E0570 = "该功能尚示实现";
            /// <summary>
            /// 流转类型
            /// </summary>
            public const string E0571 = "流转类型";
            /// <summary>
            /// 条码已发运或已报废，不能做此操作
            /// </summary>
            public const string E0572 = "条码已发运或已报废，不能做此操作";
            /// <summary>
            /// 排班早班ArrangeID
            /// </summary>
            public const string E0573 = "Morning";
            /// <summary>
            /// 排班晚班ArrangeID
            /// </summary>
            public const string E0574 = "Night";
            /// <summary>
            /// 车辆恢复正常，是否选择小车？
            /// </summary>
            public const string E0575 = "车辆恢复正常，是否选择小车？";
            /// <summary>
            /// 找到不止一条barindet_mstr配置
            /// </summary>
            public const string E0576 = "找到不止一条下道工序配置(barindet_mstr)，请检查！";
            /// <summary>
            /// 注塑下线扫描只能扫描注塑件
            /// </summary>
            public const string E0577 = "注塑下线扫描只能扫描注塑件";

        }
        /// <summary>
        /// 盘点模式
        /// </summary>
        public struct StockTakingMode
        {
            /// <summary>
            ///正常模式
            /// </summary>
            public const int Nomal = 1;
            /// <summary>
            /// 外协件小件
            /// </summary>
          public const int XJWXJ =2;
        }
        /// <summary>
        /// 日志类型
        /// </summary>
        public struct LogType
        {
            /// <summary>
            ///负库存
            /// </summary>
            public const string StockError = "StockError";
            /// <summary>
            /// 不合格评审撤销
            /// </summary>
            public const string UnqualifiedCancel = "UnqualifiedCancel";
            /// <summary>
            /// 以提交不合格评审撤销
            /// </summary>
            public const string UnqualifiedSubmitCancel = "UnqualifiedSubmitCancel";

            /// <summary>
            /// 创建上架指令失败
            /// </summary>
            public const string CreateWordFaild = "CreateWordFaild";
        }
        public struct LogLevel
        {
            /// <summary>
            /// 提示信息
            /// </summary>
            public const string Info = "Info";
            /// <summary>
            /// 调试信息
            /// </summary>
            public const string Debug = "Debug";
            /// <summary>
            /// 警告信息
            /// </summary>
            public const string Warn = "Warn";
            /// <summary>
            /// 错误信息
            /// </summary>
            public const string Error = "Error";
            /// <summary>
            /// 致命信息
            /// </summary>
            public const string Fatal = "Fatal";
        }

        /// <summary>
        /// 设备通信过程中返回的状态码
        /// </summary>
        public struct ActionMessageStatusCode
        {
            /// <summary>
            /// 正常
            /// </summary>
            public const short Normal = 200;
            /// <summary>
            /// 错误
            /// </summary>
            public const short Error = 201;
        }

        /// <summary>
        /// 返回的业务状态
        /// </summary>
        public struct ActionMessageStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            public const string Normal = "正常";
            /// <summary>
            /// 错误
            /// </summary>
            public const string Error = "业务异常";
        }

        /// <summary>
        /// 料道出入口编码
        /// </summary>
        public struct StoragePosition
        {
            /// <summary>
            /// 料道出口
            /// </summary>
            public const int F  = 1;
            /// <summary>
            /// 料道入口
            /// </summary>
            public const int R = 2;
        }

        /// <summary>
        /// 自动化AGV小车拉动任务类型
        /// </summary>
        public struct TaskType
        {
            /// <summary>
            /// 入库任务类型
            /// </summary>
            public const int In = 2;
            /// <summary>
            /// 出库任务类型
            /// </summary>
            public const int Out = 1;
        }

        /// <summary>
        /// 自动化AGV小车拉动任务进行状态
        /// </summary>
        public struct TaskStatus
        {
            /// <summary>
            /// 创建拉动任务
            /// </summary>
            public const int Create = 0;
            /// <summary>
            /// 设备已接收任务
            /// </summary>
            public const int Accept = 1;
            /// <summary>
            /// 任务执行中
            /// </summary>
            public const int Executing = 2;
            /// <summary>
            /// 任务已完成
            /// </summary>
            public const int Finish = 3;
            /// <summary>
            /// 任务被取消
            /// </summary>
            public const int Cancel = 4;
        }

        /// <summary>
        /// 先进先出排序规则
        /// </summary>
        public struct ReCommendType
        {
            /// <summary>
            /// 生产时间
            /// </summary>
            public const string EarliestProdTime = "EarliestProdTime";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string CreateTime = "CreateTime";
            /// <summary>
            /// 收货时间
            /// </summary>
            public const string POReceivedTime = "POReceivedTime";
        }
        /// <summary>
        /// 扫描点集合
        /// </summary>
        public struct ScanSite
        {
            /// <summary>
            /// 注塑
            /// </summary>
            public const string ImmScan = "ImmScan";
            /// <summary>
            /// 油漆上线
            /// </summary>
            public const string PaintOnLineScan = "PaintOnLineScan";
            /// <summary>
            /// 油漆下线
            /// </summary>
            public const string PaintOffLineScan = "PaintOffLineScan";
            /// <summary>
            /// 装配扫描
            /// </summary>
            public const string ASMScan = "ASMScan";
            /// <summary>
            /// 客户安全退回
            /// </summary>
            public const string ProCustReturn = "ProCustReturn";
            /// <summary>
            /// 客户安全发运
            /// </summary>
            public const string ProCustSend = "ProCustSend";
           
        }


        public struct EquipReqRespMsg
        {
            /// <summary>
            /// 默认
            /// </summary>
            public const int ReprocessingResult0 = 0;
            /// <summary>
            /// 重处理成功
            /// </summary>
            public const int ReprocessingResult1 = 1;
            /// <summary>
            /// 重处理取消
            /// </summary>
            public const int ReprocessingResult2 = 2;

        }

        private static Dictionary<int, string> _errorMsgList;
        public static Dictionary<int, string> ErrorMsgList
        {
            get
            {
                _errorMsgList = new Dictionary<int, string>();
                _errorMsgList.Add(101, "无生产计划");
                _errorMsgList.Add(102, "负库存");
                _errorMsgList.Add(103, "库位不存在");
                _errorMsgList.Add(104, "上一扫描点未扫描"); 
                return _errorMsgList;
            }
        }

    } 
}
/// <summary>
/// 盘点信息变更集合
/// </summary>
public enum StockTakingChangeType
{
    /// <summary>
    /// 未找到该条码
    /// </summary>
    NotFound = 0,
    /// <summary>
    /// 条码零件号变更
    /// </summary>
    BarCodeParNoChange = 1,
    /// <summary>
    /// 条码零件版本号变更
    /// </summary>
    BarCodePartVersion = 2,
    /// <summary>
    /// 条码质量状态变更
    /// </summary>
    BarCodeQualityStatusChange = 4,
    /// <summary>
    /// 条码控制状态变更
    /// </summary>
    BarCodeControlStatusChange = 8,
    /// <summary>
    /// 条码库位变更
    /// </summary>
    BarCodeStkCodeChange = 16,
    /// <summary>
    /// 条码类型变更
    /// </summary>
    BarCodeCategoryChange = 32,
    /// <summary>
    /// 条码HU变更
    /// </summary>
    BarCodeHUChange = 64,
    /// <summary>
    /// HU的条码异常
    /// 一个HU内的条码在料箱外扫到
    /// </summary>
    HUBarCodeException = 128,
    /// <summary>
    /// HU零件号变更（基本不会出现，预留）
    /// </summary>
    HUPartNoChange = 256,
    /// <summary>
    /// HU零件版本号变更
    /// </summary>
    HUPartVersionChange = 512,
    /// <summary>
    /// HU质量状态变更
    /// </summary>
    HUQualityStatusChange = 1024,
    /// <summary>
    /// HU数量变更
    /// </summary>
    HUAmountChange = 2048,
    /// <summary>
    /// HU所包含的条码有变更
    /// </summary>
    HUBarcodeChange = 4096,
    /// <summary>
    /// HU包装状态变更（暂不使用，预留）
    /// </summary>
    HUPackegeChange = 8192,
    /// <summary>
    /// HU库位变更
    /// </summary>
    HUStkCodeChange = 16384,
    /// <summary>
    /// HU的BIN位变更
    /// </summary>
    HUBinChange = 32768,
    /// <summary>
    /// 库存数量变更
    /// </summary>
    StkAmountChange = 65536,
    /// <summary>
    /// 新增
    /// </summary>
    New = 4194304,
    /// <summary>
    /// 无变化
    /// </summary>
    NoChange = 8388608,
    ///<summary>
    ///条码状态变更
    ///<summary>
    OrderStatus=741
}
