--LGS_CustomerAssemblyLine�пͻ����øĳ�SAP��
SELECT *, REPLACE(SQLSelectStr,'''CJLR''','''80648''')  FROM  dbo.LGS_CustomerAssemblyLine 
update LGS_CustomerAssemblyLine set customercode = '80648',sqlselectstr = REPLACE(SQLSelectStr,'''CJLR''','''80648''')  where customercode = 'CJLR' 

--LGS_CustomerPlant�пͻ����øĳ�SAP��
SELECT * FROM  dbo.LGS_CustomerPlant 

update LGS_CustomerPlant set CustomerCode = '80648' where CustomerCode = 'CJLR'

SELECT * FROM  dbo.LGS_CustomerStkConfig

--LGS_CustomerStkConfig�пͻ����øĳ�SAP�ģ�71����Ҫ�ĳɷǼ���ģʽ�Ŀͻ���Ҫ����ORDERTYPE
update LGS_CustomerStkConfig set CustomerCode = '80648' where CustomerCode = 'CJLR' --------------��ȷ��

--!!!LGS_PurchaseOrderConfig���ڲ���˾��Ӧ�̴�����Ҫ���ĳɹ�������,�ɹ����еĲɹ��ų�Ҫ�ĳ�SAP��

SELECT * FROM  dbo.LGS_PurchaseOrderConfig 
update LGS_PurchaseOrderConfig set suppliercode = '2010' where SupplierCode = 'YFPOAT'

SELECT * FROM  dbo.LGS_SalesAgreementConfig 
--LGS_SalesAgreementConfig�пͻ����øĳ�SAP��
update LGS_SalesAgreementConfig set CustomerCode = '80648' where CustomerCode = 'CJLR'

--LGS_JISPointInfo�еĿͻ����øĳ�SAP��
SELECT * FROM  dbo.LGS_JISPointInfo 
update LGS_JISPointInfo set customercode = '80648' where CustomerCode = 'CJLR'

----LGS_CustBriefPartMap�пͻ����øĳ�SAP��
--update [LGS_CustBriefPartMap] set customercode = '80103' where CustomerCode = 'SGM'

--LGS_CustBriefPartMap�пͻ����øĳ�SAP��
--update LGS_CustBriefPartMap set CustomerCode = '80104' where CustomerCode = 'SGMDY'
----LGS_JISPointInfo�еĿͻ����øĳ�SAP��
--update LGS_JISPointInfo set customercode = '80104' where CustomerCode = 'SGMDY'

--����MES���
select a.partno,a.FactoryCode,'','',a.stkcode,a.NonRtctNormal,b.unit from wms_stkdet a,mfg_partdetail b with (nolock) where a.PartNo = b.PartNo
and a.NonRtctNormal <> 0 AND a.FactoryCode = b.FactoryCode  --���û�и�������������Ҫά�ޱ��������ӯ���루ά�ޱ������ܴ���SAP����

--�ɹ����Эͬ��ϵ��ҪУ��

--���۶������й�˾�佻�׵Ķ������͸ĵ�
update LGS_SalesAgreementConfig set SaleDocType = 'ZSTO' where CustomerCode in ('1040','1041','2010','2011')

--���۷��˴�ɢ
SELECT * FROM  dbo.SYS_GlobalMapConfig WHERE ConfigName = 'ClearRKStk'
--UPDATE SYS_GlobalMapConfig SET CfgValue = '80104' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMDY' AND ID = '89'

--��պ˶Կ���
--TRUNCATE TABLE WMS_SapStkCompareHist 

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

--������еĿͻ�������Ҫȫ���ĵ�

--LGS_JISOrder���򵥸��µ�
SELECT * FROM  dbo.LGS_JISOrder 
--UPDATE dbo.LGS_JISOrder SET   CustCode = '80648' WHERE CustCode = 'CJLR'

SELECT * FROM  dbo.LGS_PreAssembly 
UPDATE dbo.LGS_PreAssembly SET CustCode = '80648' WHERE CustCode = 'CJLR'


--4�����ϵĵ�λת��
-- �����		Ʒ��				QAD��λ		SAP��λ
-- 11931142	K413��ϴ��			��			ML
-- 25200003	K413AXSONH6257B��	KG			G
-- 25200002	K413AXSONH6257A��l	KG			G
-- 25200001	L538Axson5069��Ϳ(	��			ML
-- 1.	����QAD��SAP�ĵ�λת����ϵ����ϵͳ�����п�漰���䡢����װ�����õȸ���ת����ϵ��ͳһת����Ȼ���ٽ���ʼ������SAP�Ϳ����ˡ�
-- 2.	�����������Ķ��������л���ʱ����Ҫ��֤��QAD�Ķ�ȫ�����ꡣȻ���ٵȵ�1����ɺ����ɵ�����ֻ����SAP��
-- 3.	�ɹ������������л�ǰ��ȫ��������л���������µĶ�����

--a.���
UPDATE dbo.WMS_StkDet SET NonRtctNormal  = NonRtctNormal * 1000 WHERE PartNo = '11931142'
UPDATE dbo.WMS_StkDet SET NonRtctNormal  = NonRtctNormal * 1000 WHERE PartNo = '25200003'
UPDATE dbo.WMS_StkDet SET NonRtctNormal  = NonRtctNormal * 1000 WHERE PartNo = '25200002'
UPDATE dbo.WMS_StkDet SET NonRtctNormal  = NonRtctNormal * 1000 WHERE PartNo = '25200001'
--b.HUPkgMstr
SELECT * FROM  dbo.LGS_HUPkgMstr WHERE PartNo IN ('11931142',
'25200003',
'25200002',
'25200001')
 
UPDATE dbo.LGS_HUPkgMstr SET HUQty = HUQty * 1000, HUMaxQty = HUMaxQty * 1000 WHERE PartNo = '11931142'
UPDATE dbo.LGS_HUPkgMstr SET HUQty = HUQty * 1000, HUMaxQty = HUMaxQty * 1000 WHERE PartNo = '25200003'
UPDATE dbo.LGS_HUPkgMstr SET HUQty = HUQty * 1000, HUMaxQty = HUMaxQty * 1000 WHERE PartNo = '25200002'
UPDATE dbo.LGS_HUPkgMstr SET HUQty = HUQty * 1000, HUMaxQty = HUMaxQty * 1000 WHERE PartNo = '25200001' and HYQty < 250

--��װ����
--��ǰ�����⼸�����û��ά�������Բ��ô���

--ȥ��˫������λDOUBLE
DELETE FROM dbo.WMS_StkMstr WHERE StkCode = 'DOUBLE'

--���½ӿڵ�SAP��ʽ����
SELECT * FROM  dbo.SYS_SapIFCfg 
UPDATE dbo.SYS_SapIFCfg SET IfWsdl = REPLACE( IfWsdl, 'yfpopiqas', 'yfpopiprd')

--��δ���ܵ����񶼱�ǵ�
SELECT * FROM  dbo.SYS_SAPTransaction WHERE IsGather = 0 
UPDATE dbo.SYS_SAPTransaction SET IsGather = 1 , GatherGUID = NEWID() WHERE IsGather = 0 

--��QAD�׶����ɵĻ�������ȫ��ɾ��
TRUNCATE TABLE dbo.SYS_SAPTransactionGather 

--����SAP�ӿ�
SELECT * FROM  dbo.InterfaceRelation WHERE GroupName = 'MES_TO_ISV'
SELECT * FROM  dbo.RelationSort WHERE GroupName = 'MES_TO_ISV'
UPDATE dbo.InterfaceRelation SET IsActive = 0 WHERE GroupName = 'MES_TO_ISV'
UPDATE dbo.InterfaceRelation SET IsActive = 1 WHERE GroupName = 'SAP_TO_MES'
UPDATE dbo.RelationSort SET IsActive = 0 WHERE GroupName = 'MES_TO_ISV'
UPDATE dbo.RelationSort SET IsActive = 1 WHERE GroupName = 'SAP_TO_MES'

--EDM������Ϣ�Ŀͻ�����
UPDATE dbo.LGS_CCRComponents SET CustCode = '80648'

UPDATE dbo.LGS_JISOrderInterim SET  CustCode = '80648'

--���˵��ر�
UPDATE dbo.LGS_ShippingFreight SET IsSyncSAP =1, TaskId = NEWID() WHERE IsSyncSAP = 0 


