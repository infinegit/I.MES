--LGS_CustomerPlant中客户配置改成SAP的
update LGS_CustomerPlant set CustomerCode = '80104' where CustomerCode = 'SGMDY'
--LGS_CustomerStkConfig中客户配置改成SAP的，71后需要改成非寄售模式的客户需要更改ORDERTYPE
update LGS_CustomerStkConfig set CustomerCode = 'BGWD' where CustomerCode = 'BGWD' --------------待确认
update LGS_CustomerStkConfig set CustomerCode = 'BQFT' where CustomerCode = 'BQFT'
update LGS_CustomerStkConfig set CustomerCode = '80104' where CustomerCode = 'SGMDY'
update LGS_CustomerStkConfig set CustomerCode = '80110' where CustomerCode = 'SGMSC'
update LGS_CustomerStkConfig set CustomerCode = 'YFJH' where CustomerCode = 'YFJH'
update LGS_CustomerStkConfig set CustomerCode = 'HTMSYT' where CustomerCode = 'HTMSYT'--------------待确认

--!!!LGS_PurchaseOrderConfig中内部公司供应商代码需要更改成工厂代码,采购组中的采购排程要改成SAP的
update LGS_PurchaseOrderConfig set suppliercode = '1050' where SupplierCode = 'YFPOSY'
--LGS_SalesAgreementConfig中客户配置改成SAP的
update LGS_SalesAgreementConfig set CustomerCode = 'BQFT' where CustomerCode = 'BQFT'
update LGS_SalesAgreementConfig set CustomerCode = '80104' where CustomerCode = 'SGMDY'
update LGS_SalesAgreementConfig set CustomerCode = '80110' where CustomerCode = 'SGMSC'
update LGS_SalesAgreementConfig set CustomerCode = 'YFJH' where CustomerCode = 'YFJH'
update LGS_SalesAgreementConfig set CustomerCode = 'YJZJ' where CustomerCode = 'YJZJ'  --------------待确认
----LGS_CustBriefPartMap中客户配置改成SAP的
--update [LGS_CustBriefPartMap] set customercode = '80103' where CustomerCode = 'SGM'

--LGS_CustBriefPartMap中客户配置改成SAP的
update LGS_CustBriefPartMap set CustomerCode = '80104' where CustomerCode = 'SGMDY'
--LGS_JISPointInfo中的客户配置改成SAP的
update LGS_JISPointInfo set customercode = '80104' where CustomerCode = 'SGMDY'

--导出MES库存
select a.partno,a.FactoryCode,'','',a.stkcode,a.NonRtctNormal,b.unit from wms_stkdet a,mfg_partdetail b with (nolock) where a.PartNo = b.PartNo
and a.NonRtctNormal <> 0 AND a.FactoryCode = b.FactoryCode  --输出没有负数（和邢晓君要维修备件库存盘盈导入（维修备件不能传给SAP））

--采购组的协同关系需要校验

--销售订单组中公司间交易的订单类型改掉
update LGS_SalesAgreementConfig set SaleDocType = 'ZSTO' where CustomerCode in ('1040','1041','2010','2011')

--销售发运打散
UPDATE SYS_GlobalMapConfig SET CfgValue = '80104' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMDY' AND ID = '89'
UPDATE SYS_GlobalMapConfig SET CfgValue = '80104' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMDY' AND ID = '90'
UPDATE SYS_GlobalMapConfig SET CfgValue = '80110' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMSC' AND ID = '91'
UPDATE SYS_GlobalMapConfig SET CfgValue = '80110' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMSC' AND ID = '92'

--清空核对库存表
--TRUNCATE TABLE WMS_SapStkCompareHist 

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






