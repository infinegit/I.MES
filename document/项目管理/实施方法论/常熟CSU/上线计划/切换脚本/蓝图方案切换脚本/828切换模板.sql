--LGS_CustomerAssemblyLine中客户配置改成SAP的
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT CAST(RackNo AS INT) AS  BoxSerialNo, * FROM dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC3A1'''+ ' AND B.CustAssemblyLine = '+ '''TFC3A1'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC3A1'
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT CAST(RackNo AS INT) AS  BoxSerialNo, * FROM    dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC3A2'''+ ' AND B.CustAssemblyLine = '+ '''TFC3A2'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC3A2'
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT  * FROM dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC1A'''+ ' AND B.CustAssemblyLine = '+ '''TFC1A'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC1A'
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT CAST(RackNo AS INT) AS  BoxSerialNo, * FROM    dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC2A'''+ ' AND B.CustAssemblyLine = '+ '''TFC2A'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC2A'
--!!!LGS_CustomerPartAssistDelivery中客户配置改成SAP的，执行下述SQL后需要将内容维护进LGS_CustomerPart表
update LGS_CustomerPartAssistDelivery set customercode = '80112' where customercode = 'SVW-NEW'
--LGS_CustomerPlant中客户配置改成SAP的
update LGS_CustomerPlant set CustomerCode = '80112' where CustomerCode = 'SVW-NEW'
--LGS_CustomerStkConfig中客户配置改成SAP的，71后需要改成非寄售模式的客户需要更改ORDERTYPE
update LGS_CustomerStkConfig set CustomerCode = '80648' where CustomerCode = 'CJLR'
update LGS_CustomerStkConfig set CustomerCode = '80103' where CustomerCode = 'SGM'
update LGS_CustomerStkConfig set CustomerCode = '80110' where CustomerCode = 'SGMSC'
update LGS_CustomerStkConfig set CustomerCode = '80112' where CustomerCode = 'svw'
update LGS_CustomerStkConfig set CustomerCode = '80001' where CustomerCode = 'svw2'
update LGS_CustomerStkConfig set CustomerCode = '80657' where CustomerCode = 'svw3'
update LGS_CustomerStkConfig set CustomerCode = '80176' where CustomerCode = 'SVWAJ'
delete from LGS_CustomerStkConfig where CustomerCode = 'SVW-NEW' and ordertype = '02'
update LGS_CustomerStkConfig set CustomerCode = '80112' where CustomerCode = 'SVW-NEW'
update LGS_CustomerStkConfig set CustomerCode = '80658' where CustomerCode = 'VOLVO'
update LGS_CustomerStkConfig set CustomerCode = '1000' where CustomerCode = 'YFPO'
update LGS_CustomerStkConfig set CustomerCode = '1160' where CustomerCode = 'YFPOCS'
update LGS_CustomerStkConfig set CustomerCode = '1140' where CustomerCode = 'YFPOCSU'
update LGS_CustomerStkConfig set CustomerCode = '2120' where CustomerCode = 'YFPONB'
update LGS_CustomerStkConfig set CustomerCode = '1060' where CustomerCode = 'YFPONJ'
update LGS_CustomerStkConfig set CustomerCode = '1040' where CustomerCode = 'YFPOPD' --还需要加一条1041的
insert into LGS_CustomerStkConfig (CustomerCode,PartNo,FactoryCode,OrderType,StkCode,CreateUserAccount,CreateMachine,CreateTime) 
values ('1041','','2010','02','20103000','admin','admin-pc','2016/1/1')
update LGS_CustomerStkConfig set CustomerCode = '1050' where CustomerCode = 'YFPOSY'
update LGS_CustomerStkConfig set CustomerCode = '1110' where CustomerCode = 'YFPOYT'
update LGS_CustomerStkConfig set CustomerCode = '2080' where CustomerCode = 'YFPOYZ'
update LGS_CustomerStkConfig set CustomerCode = 'YZJS' where CustomerCode = 'YZJS01'
--!!!LGS_PurchaseOrderConfig中内部公司供应商代码需要更改成工厂代码,采购组中的采购排程要改成SAP的
update LGS_PurchaseOrderConfig set suppliercode = '1000' where SupplierCode = 'YFPO'
--LGS_SalesAgreementConfig中客户配置改成SAP的
update LGS_SalesAgreementConfig set CustomerCode = '1041' where CustomerCode = 'YFPOPD'
update LGS_SalesAgreementConfig set CustomerCode = '1040' where SUPGROUPCODE = 'DEL01'
update LGS_SalesAgreementConfig set CustomerCode = '80648' where CustomerCode = 'CJLR'
update LGS_SalesAgreementConfig set CustomerCode = '80103' where CustomerCode = 'SGM'
update LGS_SalesAgreementConfig set CustomerCode = '80110' where CustomerCode = 'SGMSC'
update LGS_SalesAgreementConfig set CustomerCode = '80112' where CustomerCode = 'SVW'
update LGS_SalesAgreementConfig set CustomerCode = '80658' where CustomerCode = 'VOLVO'
update LGS_SalesAgreementConfig set CustomerCode = '1160' where CustomerCode = 'YFPOCS'
update LGS_SalesAgreementConfig set CustomerCode = '1140' where CustomerCode = 'YFPOCSU'
update LGS_SalesAgreementConfig set CustomerCode = '2120' where CustomerCode = 'YFPONB'
update LGS_SalesAgreementConfig set CustomerCode = '1060' where CustomerCode = 'YFPONJ'
update LGS_SalesAgreementConfig set CustomerCode = '1050' where CustomerCode = 'YFPOSY'
update LGS_SalesAgreementConfig set CustomerCode = '1110' where CustomerCode = 'YFPOYT'
update LGS_SalesAgreementConfig set CustomerCode = '2080' where CustomerCode = 'YFPOYZ'
----LGS_CustBriefPartMap中客户配置改成SAP的
--update [LGS_CustBriefPartMap] set customercode = '80103' where CustomerCode = 'SGM'

--LGS_JISPointInfo中的客户配置改成SAP的
update LGS_JISPointInfo set customercode = '80112' where CustomerCode = 'SVW-NEW'

--导出MES库存
select a.partno,a.FactoryCode,'','',a.stkcode,a.NonRtctNormal,b.unit from wms_stkdet a,mfg_partdetail b with (nolock) where a.PartNo = b.PartNo
and a.NonRtctNormal <> 0

--LGS_JISOrder排序单更新掉
UPDATE dbo.LGS_JISOrder SET   CustCode = '80112' WHERE CustCode = 'SVW-NEW'

--采购组的协同关系需要校验

--销售订单组中公司间交易的订单类型改掉
update LGS_SalesAgreementConfig set SaleDocType = 'ZSTO' where CustomerCode in ('1040','1041')


--拉掉采购下单权限
--正常的SQL
update [RPT_UserRolePriv] set menuid = menuid + 'X' where menuid in (select MenuID from [dbo].[RPT_Menu] where url = '/PurchaseOrder')
--特殊的SQL
update [RPT_Menu] set parentid = '999999' where url = '/PurchaseOrder'

--销售下单权限
--正常的SQL
update [RPT_UserRolePriv] set menuid = menuid + 'X' where menuid in (select MenuID from [dbo].[RPT_Menu] where url = '/SalesAgreement')
--特殊的SQL
update [RPT_Menu] set parentid = '999999' where url = '/SalesAgreement'






--SYS_GlobalMapConfig里发运清料箱的客户代码更新
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '80648' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'CJLR'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '80103' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGM'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '80110' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMSC'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '80112' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SVW'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '80658' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'VOLVO'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '1160' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPOCS'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '1140' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPOCSU'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '2120' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPONB'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '1060' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPONJ'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '1040' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPOPD'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '1050' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPOSY'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '1110' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPOYT'
UPDATE  dbo.SYS_GlobalMapConfig SET CfgValue = '2080' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'YFPOYZ'


