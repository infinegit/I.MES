--LGS_CustomerPlant�пͻ����øĳ�SAP��
update LGS_CustomerPlant set CustomerCode = '80104' where CustomerCode = 'SGMDY'
--LGS_CustomerStkConfig�пͻ����øĳ�SAP�ģ�71����Ҫ�ĳɷǼ���ģʽ�Ŀͻ���Ҫ����ORDERTYPE
update LGS_CustomerStkConfig set CustomerCode = 'BGWD' where CustomerCode = 'BGWD' --------------��ȷ��
update LGS_CustomerStkConfig set CustomerCode = 'BQFT' where CustomerCode = 'BQFT'
update LGS_CustomerStkConfig set CustomerCode = '80104' where CustomerCode = 'SGMDY'
update LGS_CustomerStkConfig set CustomerCode = '80110' where CustomerCode = 'SGMSC'
update LGS_CustomerStkConfig set CustomerCode = 'YFJH' where CustomerCode = 'YFJH'
update LGS_CustomerStkConfig set CustomerCode = 'HTMSYT' where CustomerCode = 'HTMSYT'--------------��ȷ��

--!!!LGS_PurchaseOrderConfig���ڲ���˾��Ӧ�̴�����Ҫ���ĳɹ�������,�ɹ����еĲɹ��ų�Ҫ�ĳ�SAP��
update LGS_PurchaseOrderConfig set suppliercode = '1050' where SupplierCode = 'YFPOSY'
--LGS_SalesAgreementConfig�пͻ����øĳ�SAP��
update LGS_SalesAgreementConfig set CustomerCode = 'BQFT' where CustomerCode = 'BQFT'
update LGS_SalesAgreementConfig set CustomerCode = '80104' where CustomerCode = 'SGMDY'
update LGS_SalesAgreementConfig set CustomerCode = '80110' where CustomerCode = 'SGMSC'
update LGS_SalesAgreementConfig set CustomerCode = 'YFJH' where CustomerCode = 'YFJH'
update LGS_SalesAgreementConfig set CustomerCode = 'YJZJ' where CustomerCode = 'YJZJ'  --------------��ȷ��
----LGS_CustBriefPartMap�пͻ����øĳ�SAP��
--update [LGS_CustBriefPartMap] set customercode = '80103' where CustomerCode = 'SGM'

--LGS_CustBriefPartMap�пͻ����øĳ�SAP��
update LGS_CustBriefPartMap set CustomerCode = '80104' where CustomerCode = 'SGMDY'
--LGS_JISPointInfo�еĿͻ����øĳ�SAP��
update LGS_JISPointInfo set customercode = '80104' where CustomerCode = 'SGMDY'

--����MES���
select a.partno,a.FactoryCode,'','',a.stkcode,a.NonRtctNormal,b.unit from wms_stkdet a,mfg_partdetail b with (nolock) where a.PartNo = b.PartNo
and a.NonRtctNormal <> 0 AND a.FactoryCode = b.FactoryCode  --���û�и�������������Ҫά�ޱ��������ӯ���루ά�ޱ������ܴ���SAP����

--�ɹ����Эͬ��ϵ��ҪУ��

--���۶������й�˾�佻�׵Ķ������͸ĵ�
update LGS_SalesAgreementConfig set SaleDocType = 'ZSTO' where CustomerCode in ('1040','1041','2010','2011')

--���۷��˴�ɢ
UPDATE SYS_GlobalMapConfig SET CfgValue = '80104' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMDY' AND ID = '89'
UPDATE SYS_GlobalMapConfig SET CfgValue = '80104' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMDY' AND ID = '90'
UPDATE SYS_GlobalMapConfig SET CfgValue = '80110' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMSC' AND ID = '91'
UPDATE SYS_GlobalMapConfig SET CfgValue = '80110' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMSC' AND ID = '92'

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






