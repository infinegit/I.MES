
--1. CustStdOrdMstr表中增加一列 StdOrdCfg30

--2.对于3.0条码的属性变更： 使用以下语句从AssemblySheet->MainBarcode为主条码，更新3.0库的StdOrdCfg、IsCCR字段。

SELECT TOP 1000
        *
FROM    dbo.AssemblySheet
        LEFT JOIN ipos.CustStdOrdMstr ON PartDesc = Description
WHERE   MainBarcode IS NOT NULL
ORDER BY ASID DESC 


--3. 对于3.0 CCR件条码明细的插入：使用如下语句把装配明细找出来，插入到MFG_ProdBarCodeCCRComps

SELECT TOP 1000
        *
FROM    dbo.AssemblySheet
        LEFT JOIN ipos.CustStdOrdMstr ON PartDesc = Description
		LEFT JOIN ipos.CustStdOrdDet ON ipos.CustStdOrdMstr.StdOrdCfg = ipos.CustStdOrdDet.StdOrdCfg
WHERE   MainBarcode IS NOT NULL
ORDER BY ASID DESC 



