--PP--

TRUNCATE TABLE [dbo].[MFG_PartDetail]  --ok 导入进来
TRUNCATE TABLE [dbo].[MFG_Bom]		--22081  导入进来
TRUNCATE TABLE [dbo].[MFG_WorkCenter]   --ok   需要手工维护
TRUNCATE TABLE [dbo].[MFG_ProcRoute] 	--ok   需要手工维护
TRUNCATE TABLE [dbo].[MFG_WorkVersion] 		--ok 需要手工维护
TRUNCATE TABLE [dbo].[MFG_WorkSchedule] 	--866  需要手工维护
TRUNCATE TABLE [dbo].[MFG_WorkOrder] --需要手工维护
TRUNCATE TABLE [dbo].[MFG_WorkOrderDet]  --需要手工维护
TRUNCATE TABLE [dbo].[MFG_WorkOrderRoute] --需要手工维护
--SD--
TRUNCATE TABLE [dbo].[LGS_Customer] --需要手工维护
TRUNCATE TABLE [dbo].[LGS_CustomerPart]--需要手工维护
TRUNCATE TABLE [dbo].[LGS_SalesAgreement]    --无--需要手工维护
TRUNCATE TABLE[dbo].[LGS_SalesAgreementDet]  --无--需要手工维护
--MM--
TRUNCATE TABLE [dbo].[LGS_Supplier]  --无   导入进来

TRUNCATE TABLE [dbo].[LGS_PurchaseAgreement]   --无--需要手工维护
TRUNCATE TABLE [dbo].[LGS_CostObject]   --导入进来