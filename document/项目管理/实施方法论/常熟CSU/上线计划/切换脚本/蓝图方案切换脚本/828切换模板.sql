--LGS_CustomerAssemblyLine�пͻ����øĳ�SAP��
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT CAST(RackNo AS INT) AS  BoxSerialNo, * FROM dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC3A1'''+ ' AND B.CustAssemblyLine = '+ '''TFC3A1'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC3A1'
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT CAST(RackNo AS INT) AS  BoxSerialNo, * FROM    dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC3A2'''+ ' AND B.CustAssemblyLine = '+ '''TFC3A2'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC3A2'
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT  * FROM dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC1A'''+ ' AND B.CustAssemblyLine = '+ '''TFC1A'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC1A'
update LGS_CustomerAssemblyLine set customercode = '80112',sqlselectstr = 'SELECT CAST(RackNo AS INT) AS  BoxSerialNo, * FROM    dbo.LGS_JISOrderDet A INNER JOIN dbo.LGS_JISOrder B ON A.SeqGuid = B.[Guid] WHERE   B.CustCode = '+'''80112'''+ ' AND B.CustPlant = '+'''TFC2A'''+ ' AND B.CustAssemblyLine = '+ '''TFC2A'''
where customercode = 'SVW-NEW' and customerplantcode = 'TFC2A'
--!!!LGS_CustomerPartAssistDelivery�пͻ����øĳ�SAP�ģ�ִ������SQL����Ҫ������ά����LGS_CustomerPart��
update LGS_CustomerPartAssistDelivery set customercode = '80112' where customercode = 'SVW-NEW'
--LGS_CustomerPlant�пͻ����øĳ�SAP��
update LGS_CustomerPlant set CustomerCode = '80112' where CustomerCode = 'SVW-NEW'
--LGS_CustomerStkConfig�пͻ����øĳ�SAP�ģ�71����Ҫ�ĳɷǼ���ģʽ�Ŀͻ���Ҫ����ORDERTYPE
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
update LGS_CustomerStkConfig set CustomerCode = '1040' where CustomerCode = 'YFPOPD' --����Ҫ��һ��1041��
insert into LGS_CustomerStkConfig (CustomerCode,PartNo,FactoryCode,OrderType,StkCode,CreateUserAccount,CreateMachine,CreateTime) 
values ('1041','','2010','02','20103000','admin','admin-pc','2016/1/1')
update LGS_CustomerStkConfig set CustomerCode = '1050' where CustomerCode = 'YFPOSY'
update LGS_CustomerStkConfig set CustomerCode = '1110' where CustomerCode = 'YFPOYT'
update LGS_CustomerStkConfig set CustomerCode = '2080' where CustomerCode = 'YFPOYZ'
update LGS_CustomerStkConfig set CustomerCode = 'YZJS' where CustomerCode = 'YZJS01'
--!!!LGS_PurchaseOrderConfig���ڲ���˾��Ӧ�̴�����Ҫ���ĳɹ�������,�ɹ����еĲɹ��ų�Ҫ�ĳ�SAP��
update LGS_PurchaseOrderConfig set suppliercode = '1000' where SupplierCode = 'YFPO'
--LGS_SalesAgreementConfig�пͻ����øĳ�SAP��
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
----LGS_CustBriefPartMap�пͻ����øĳ�SAP��
--update [LGS_CustBriefPartMap] set customercode = '80103' where CustomerCode = 'SGM'

--LGS_JISPointInfo�еĿͻ����øĳ�SAP��
update LGS_JISPointInfo set customercode = '80112' where CustomerCode = 'SVW-NEW'

--����MES���
select a.partno,a.FactoryCode,'','',a.stkcode,a.NonRtctNormal,b.unit from wms_stkdet a,mfg_partdetail b with (nolock) where a.PartNo = b.PartNo
and a.NonRtctNormal <> 0

--LGS_JISOrder���򵥸��µ�
UPDATE dbo.LGS_JISOrder SET   CustCode = '80112' WHERE CustCode = 'SVW-NEW'

--�ɹ����Эͬ��ϵ��ҪУ��

--���۶������й�˾�佻�׵Ķ������͸ĵ�
update LGS_SalesAgreementConfig set SaleDocType = 'ZSTO' where CustomerCode in ('1040','1041')


--�����ɹ��µ�Ȩ��
--������SQL
update [RPT_UserRolePriv] set menuid = menuid + 'X' where menuid in (select MenuID from [dbo].[RPT_Menu] where url = '/PurchaseOrder')
--�����SQL
update [RPT_Menu] set parentid = '999999' where url = '/PurchaseOrder'

--�����µ�Ȩ��
--������SQL
update [RPT_UserRolePriv] set menuid = menuid + 'X' where menuid in (select MenuID from [dbo].[RPT_Menu] where url = '/SalesAgreement')
--�����SQL
update [RPT_Menu] set parentid = '999999' where url = '/SalesAgreement'






--SYS_GlobalMapConfig�﷢��������Ŀͻ��������
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


