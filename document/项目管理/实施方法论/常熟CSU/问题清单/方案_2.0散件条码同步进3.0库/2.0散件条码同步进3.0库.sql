
--1. CustStdOrdMstr��������һ�� StdOrdCfg30

--2.����3.0��������Ա���� ʹ����������AssemblySheet->MainBarcodeΪ�����룬����3.0���StdOrdCfg��IsCCR�ֶΡ�

SELECT TOP 1000
        *
FROM    dbo.AssemblySheet
        LEFT JOIN ipos.CustStdOrdMstr ON PartDesc = Description
WHERE   MainBarcode IS NOT NULL
ORDER BY ASID DESC 


--3. ����3.0 CCR��������ϸ�Ĳ��룺ʹ����������װ����ϸ�ҳ��������뵽MFG_ProdBarCodeCCRComps

SELECT TOP 1000
        *
FROM    dbo.AssemblySheet
        LEFT JOIN ipos.CustStdOrdMstr ON PartDesc = Description
		LEFT JOIN ipos.CustStdOrdDet ON ipos.CustStdOrdMstr.StdOrdCfg = ipos.CustStdOrdDet.StdOrdCfg
WHERE   MainBarcode IS NOT NULL
ORDER BY ASID DESC 



