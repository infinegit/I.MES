1. 增加两个接口表

--发货同步表
CREATE TABLE [dbo].[IFS_InterCompRcvSyncPending](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[POFactoryCode] [nvarchar](20) NOT NULL,
	[SOFactoryCode] [nvarchar](20) NOT NULL,
	[PartNo] [nvarchar](20) NOT NULL,
	[Qty] [decimal](18, 8) NOT NULL,
	[PONo] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateMachine] [nvarchar](50) NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[IsSyncSAP] [bit] NOT NULL,
	[TaskId] [nvarchar](50) NOT NULL,
	[RecTime] [datetime] NULL,
 CONSTRAINT [PK_IFS_InterCompRcvSyncPending] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[IFS_InterCompRcvSyncPending] ADD  CONSTRAINT [DF_IFS_InterCompRcvSyncPending_IsSyncSAP]  DEFAULT ((0)) FOR [IsSyncSAP]

ALTER TABLE [dbo].[IFS_InterCompRcvSyncPending] ADD  CONSTRAINT [DF_IFS_InterCompRcvSyncPending_TaskId]  DEFAULT ('') FOR [TaskId]

--同步发货日志表
CREATE TABLE [dbo].[IFS_InterCompRcvSyncLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[POFactoryCode] [nvarchar](20) NOT NULL,
	[SOFactoryCode] [nvarchar](20) NOT NULL,
	[PartNo] [nvarchar](20) NOT NULL,
	[Qty] [decimal](18, 8) NOT NULL,
	[PONo] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateMachine] [nvarchar](50) NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[IsSyncSAP] [bit] NOT NULL,
	[TaskId] [nvarchar](50) NOT NULL,
	[RecTime] [datetime] NULL,
 CONSTRAINT [PK_IFS_InterCompRcvSyncLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


2. dbo.SYS_SAPGatherConfig增加配置

ID	TransCode	NeedSum	SumInterval	LatestSumTime	GroupByName	BizScene	SceneDesc	RelationCode	MovementType	RelationMovementType
583	MM_41_ISS	1	1	2017-04-10 18:48:18.903	BusinessType,FactoryCode,PartNo,OrderNo,ItemNumber,StockStatus,Unit,AccountingDate,VoucherDate,SupplierCode,ReceiveType,MESOrderNo	公司间内部交易(订单)-发货到Z003	发货方发货		Z31	
583	MM_41X_ISSBF	1	1	48:19.	BusinessType,FactoryCode,PartNo,OrderNo,ItemNumber,StockStatus,Unit,AccountingDate,VoucherDate,SupplierCode,ReceiveType,MESOrderNo	公司间内部交易(订单)-发货到Z003	发货方发货-冲销		Z32	


ID	TransCode	NeedSum	SumInterval	LatestSumTime	GroupByName	BizScene	SceneDesc	RelationCode	MovementType	RelationMovementType
1495	MM_42_ISS	1	1	2017-04-14 19:15:00.000	BusinessType,FactoryCode,PartNo,OrderNo,ItemNumber,StockStatus,Unit,AccountingDate,VoucherDate,MesOrderNo	同公司工厂间两步转储(有订单)	发货	MM_42X_ISSBF	Z31	Z32
1496	MM_42X_ISSBF	0	1	NULL	BusinessType,FactoryCode,PartNo,OrderNo,ItemNumber,StockStatus,Unit,AccountingDate,VoucherDate,MesOrderNo	同公司工厂间两步转储(有订单)	发货-冲销			


3 接口表增加同步配置
ID	IfCode	IfDesc	IfWsdl	IfUser	IfPwd	ServiceName	ParamName	MethodName	RespObjectName	SapIfCode	SapSender	SapReceiver	ReqClass	MstrClass	MstrTable	MstrCondition	DetClass	DetTable	DetCondition	CreateTime	IFType
67	LGS0002	公司间交易同步-安亭	http://localhost:10133/BaseService.svc?singleWsdl			BaseService	IFS_InterCompRcvSyncReq	SyncZSTODelivery		LG003	MES	MES	MEStoSAP.Models.IFS_InterCompRcvSyncReq	MEStoSAP.Models.IFS_InterCompRcvSyncPending	IFS_InterCompRcvSyncPending	SOFactoryCode in ('销售方工厂代码')				2017-04-10 00:00:00.000	2





