--LGS_CustomerAssemblyLine中客户配置改成SAP的
SELECT *, REPLACE(SQLSelectStr,'''CJLR''','''80648''')  FROM  dbo.LGS_CustomerAssemblyLine 
update LGS_CustomerAssemblyLine set customercode = '80648',sqlselectstr = REPLACE(SQLSelectStr,'''CJLR''','''80648''')  where customercode = 'CJLR' 

--LGS_CustomerPlant中客户配置改成SAP的
SELECT * FROM  dbo.LGS_CustomerPlant 

update LGS_CustomerPlant set CustomerCode = '80648' where CustomerCode = 'CJLR'

SELECT * FROM  dbo.LGS_CustomerStkConfig

--LGS_CustomerStkConfig中客户配置改成SAP的，71后需要改成非寄售模式的客户需要更改ORDERTYPE
update LGS_CustomerStkConfig set CustomerCode = '80648' where CustomerCode = 'CJLR' --------------待确认

--!!!LGS_PurchaseOrderConfig中内部公司供应商代码需要更改成工厂代码,采购组中的采购排程要改成SAP的

SELECT * FROM  dbo.LGS_PurchaseOrderConfig 
update LGS_PurchaseOrderConfig set suppliercode = '2010' where SupplierCode = 'YFPOAT'

SELECT * FROM  dbo.LGS_SalesAgreementConfig 
--LGS_SalesAgreementConfig中客户配置改成SAP的
update LGS_SalesAgreementConfig set CustomerCode = '80648' where CustomerCode = 'CJLR'

--LGS_JISPointInfo中的客户配置改成SAP的
SELECT * FROM  dbo.LGS_JISPointInfo 
update LGS_JISPointInfo set customercode = '80648' where CustomerCode = 'CJLR'

----LGS_CustBriefPartMap中客户配置改成SAP的
--update [LGS_CustBriefPartMap] set customercode = '80103' where CustomerCode = 'SGM'

--LGS_CustBriefPartMap中客户配置改成SAP的
--update LGS_CustBriefPartMap set CustomerCode = '80104' where CustomerCode = 'SGMDY'
----LGS_JISPointInfo中的客户配置改成SAP的
--update LGS_JISPointInfo set customercode = '80104' where CustomerCode = 'SGMDY'

--导出MES库存
select a.partno,a.FactoryCode,'','',a.stkcode,a.NonRtctNormal,b.unit from wms_stkdet a,mfg_partdetail b with (nolock) where a.PartNo = b.PartNo
and a.NonRtctNormal <> 0 AND a.FactoryCode = b.FactoryCode  --输出没有负数（和邢晓君要维修备件库存盘盈导入（维修备件不能传给SAP））

--采购组的协同关系需要校验

--销售订单组中公司间交易的订单类型改掉
update LGS_SalesAgreementConfig set SaleDocType = 'ZSTO' where CustomerCode in ('1040','1041','2010','2011')

--销售发运打散
SELECT * FROM  dbo.SYS_GlobalMapConfig WHERE ConfigName = 'ClearRKStk'
--UPDATE SYS_GlobalMapConfig SET CfgValue = '80104' WHERE ConfigName = 'ClearRKStk' AND CfgValue = 'SGMDY' AND ID = '89'

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

--排序表中的客户代码需要全部改掉

--LGS_JISOrder排序单更新掉
SELECT * FROM  dbo.LGS_JISOrder 
--UPDATE dbo.LGS_JISOrder SET   CustCode = '80648' WHERE CustCode = 'CJLR'

SELECT * FROM  dbo.LGS_PreAssembly 
UPDATE dbo.LGS_PreAssembly SET CustCode = '80648' WHERE CustCode = 'CJLR'


--4个物料的单位转换
-- 零件号		品名				QAD单位		SAP单位
-- 11931142	K413清洗剂			升			ML
-- 25200003	K413AXSONH6257B胶	KG			G
-- 25200002	K413AXSONH6257A胶l	KG			G
-- 25200001	L538Axson5069底涂(	升			ML
-- 1.	根据QAD与SAP的单位转换关系，将系统中已有库存及料箱、单包装数配置等根据转换关系做统一转换，然后再将初始库存给到SAP就可以了。
-- 2.	对于事务这块的东西，在切换的时候，需要保证给QAD的都全部传完。然后再等第1项完成后，生成的事务只传给SAP。
-- 3.	采购物料在上线切换前，全部清掉。切换完后再下新的订单。

--a.库存
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

--包装类型
--当前常熟这几个零件没有维护，所以不用处理

--去掉双经销库位DOUBLE
DELETE FROM dbo.WMS_StkMstr WHERE StkCode = 'DOUBLE'

--更新接口到SAP正式环境
SELECT * FROM  dbo.SYS_SapIFCfg 
UPDATE dbo.SYS_SapIFCfg SET IfWsdl = REPLACE( IfWsdl, 'yfpopiqas', 'yfpopiprd')

--将未汇总的事务都标记掉
SELECT * FROM  dbo.SYS_SAPTransaction WHERE IsGather = 0 
UPDATE dbo.SYS_SAPTransaction SET IsGather = 1 , GatherGUID = NEWID() WHERE IsGather = 0 

--将QAD阶段生成的汇总事务全部删除
TRUNCATE TABLE dbo.SYS_SAPTransactionGather 

--开启SAP接口
SELECT * FROM  dbo.InterfaceRelation WHERE GroupName = 'MES_TO_ISV'
SELECT * FROM  dbo.RelationSort WHERE GroupName = 'MES_TO_ISV'
UPDATE dbo.InterfaceRelation SET IsActive = 0 WHERE GroupName = 'MES_TO_ISV'
UPDATE dbo.InterfaceRelation SET IsActive = 1 WHERE GroupName = 'SAP_TO_MES'
UPDATE dbo.RelationSort SET IsActive = 0 WHERE GroupName = 'MES_TO_ISV'
UPDATE dbo.RelationSort SET IsActive = 1 WHERE GroupName = 'SAP_TO_MES'

--EDM接入信息改客户代码
UPDATE dbo.LGS_CCRComponents SET CustCode = '80648'

UPDATE dbo.LGS_JISOrderInterim SET  CustCode = '80648'

--货运单关闭
UPDATE dbo.LGS_ShippingFreight SET IsSyncSAP =1, TaskId = NEWID() WHERE IsSyncSAP = 0 


