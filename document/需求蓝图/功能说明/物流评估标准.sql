--------------����������׼----------------------

------------------1.������ֹ�������-------------------------
--���ӣ�������ֹ���������
SELECT  COUNT(*)
FROM    dbo.LGS_SpecialStkTransOrderDet specialTrans WITH ( NOLOCK )
WHERE   CreateTime > = '2016-12-01 00:00:00'
        AND CreateTime <= '2017-01-01 00:00:00'
        AND NOT EXISTS ( SELECT *
                         FROM   dbo.WMS_Stocktaking_Plan p WITH ( NOLOCK )
                         WHERE  p.PlanID = ApprovalOrderNo )
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = specialTrans.PartNo
                            AND part.IsSelfMade = 1
                            AND part.HasBarcode = 1 )


--��ĸ��������ܵ���������
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = trans.PartNo
                            AND part.IsSelfMade = 1
                            AND part.HasBarcode = 1 )


---------------2.С���ֹ�������--------------------
--���ӣ�С���ֹ���������
SELECT  COUNT(*)
FROM    dbo.LGS_SpecialStkTransOrderDet specialTrans WITH ( NOLOCK )
WHERE   CreateTime > = '2016-12-01 00:00:00'
        AND CreateTime < '2017-01-01 00:00:00'
        AND NOT EXISTS ( SELECT *
                         FROM   dbo.WMS_Stocktaking_Plan p WITH ( NOLOCK )
                         WHERE  p.PlanID = ApprovalOrderNo )
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = specialTrans.PartNo
                            AND part.IsSelfMade = 1
                            AND part.HasBarcode = 0 )


--��ĸ��С���ܵ���������
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime <= '2016-12-31'
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = trans.PartNo
                            AND part.IsSelfMade = 1
                            AND part.HasBarcode = 0 )


------------3.��Э���ֹ�������-----------------
--���ӣ���Э���ֹ���������
SELECT  COUNT(*)
FROM    dbo.LGS_SpecialStkTransOrderDet specialTrans WITH ( NOLOCK )
WHERE   CreateTime > = '2016-12-01 00:00:00'
        AND CreateTime < '2017-01-01 00:00:00'
        AND NOT EXISTS ( SELECT *
                         FROM   dbo.WMS_Stocktaking_Plan p WITH ( NOLOCK )
                         WHERE  p.PlanID = ApprovalOrderNo )
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = specialTrans.PartNo
                            AND part.IsSelfMade = 0 )

--��ĸ����Э���ܵ���������
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = trans.PartNo
                            AND part.IsSelfMade = 0 )



-------------4.����ʱ������-----------------
----��ĸ����������-------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'


----���ӣ��ֹ�����-------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'
        AND ABS(DATEDIFF(day, AccountingDate, CreateTime)) > 1


-------------------5.ע�����ߴ����------------------------
----���ӣ�ע�����ߴ����-------
SELECT  COUNT(*)
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'IMMScan'
        AND ActionCode = 'IntoOK'
        AND ( FlowType = '���' )

----��ĸ��ע�����ߴ��+ɢ����--------

SELECT  COUNT(*)
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'IMMScan'
        AND ActionCode = 'IntoOK'
        AND ( FlowType = '���'
              OR FlowType = 'ɢ��'
            )


--------------------6.Ϳװ���ߴ����(��׼��)-------------------------
-----���ӣ�Ϳװ���ߴ����-------
SELECT  *
FROM    dbo.LGS_HUPkgLog a
WHERE   EXISTS ( SELECT Barcode
                 FROM   dbo.MFG_BarcodeScanLog b
                 WHERE  ScanSiteCode = 'PaintOffLineScan'
                        AND ActionCode = 'IntoOK'
                        AND CreateTime >= '2017-1-1'
                        AND CreateTime <= '2017-1-31'
                        AND a.Barcode = b.Barcode
                        AND a.PartNo = b.NewPartNo )
        AND a.CreateTime >= '2017-1-1'
        AND a.CreateTime <= '2017-1-31'
        AND a.OpType = 1 

-----��ĸ��Ϳװ��������-------
SELECT  COUNT(*)
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'PaintOffLineScan'
        AND ActionCode = 'IntoOK'
 --+ʱ�䷶Χ



-----------------7.�¼�׼ȷ��(��׼��)---------------------
----�¼��Ƽ�BINλû�н��м�¼����Ҫ���¼��Ƽ�BINλ��¼��WMS_ProductBinChangeLog����


-----------------8.�������˳���֤ʹ����---------------
SELECT  OrderCMZCount AS �й�����֤��¼�Ķ����� ,
        OrderCount AS ���ж����� ,
        CASE OrderCount
          WHEN 0 THEN +'0.00%'
          ELSE CONVERT(VARCHAR(20), CAST(OrderCMZCount * 1.00 / OrderCount AS DECIMAL(18,
                                                              4)) * 100) + '%'
        END AS ����֤ʹ����
FROM    ( SELECT    COUNT(DISTINCT ( OrderNo )) AS OrderCMZCount
          FROM      dbo.LGS_CMZOrderMstr
          WHERE     ( OrderType = 'SO'
                      OR OrderType = 'JB'
                      OR OrderType = 'CompanyReturn'
                      OR OrderType = 'POReturn'
                    )
        ) AS A ,
        ( SELECT    AllOrderCount AS OrderCount
          FROM      ( SELECT    COUNT(DISTINCT ( RefOrderGuid )) AS AllOrderCount
                      FROM      dbo.WMS_StkOutMstr
                      WHERE     TransTypeCode = 'UnPlanedOrder'
                                OR TransTypeCode = 'PlanedOrder'
                                OR TransTypeCode = 'SO'
                    ) AS AllOrde
        ) AS B;
		


-----------------9.����֤ʹ����(������)---------------------
----���ӣ��й�����֤��¼��������Ϣ��

----��ĸ������������Ϣ��



----------10.ǿ�Ʊ������---------------
----�̶�ʱ�������ǿ�Ʊ��������
SELECT  *
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'BarcodeModify'
        AND ActionCode = 'Modify'

----------11.��3��������������������������δɨ�赽�����룩----------

SELECT  *
FROM    dbo.MFG_ProductBarcode AS barcode
WHERE   BarcodeStatus <> '30'
        AND BarcodeStatus <> '99'
        AND QualityStatus NOT IN ( 3, 4, 8, 9 )
        AND CreateTime >= DATEADD(m, -12, GETDATE())
        AND NOT EXISTS ( SELECT *
                         FROM   dbo.MFG_BarcodeScanLog b
                         WHERE  b.Barcode = barcode.Barcode
                                AND b.CreateTime BETWEEN DATEADD(m, -3,
                                                              GETDATE())
                                                 AND     GETDATE() )


----------12.COGI����-------------
----���ӣ�COGI������---------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
WHERE   COGIGuid <> ''
        AND CreateTime BETWEEN '2017-2-1 00:00:00'
                       AND     '2017-2-28 23:59:59'
----��ĸ������������---------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
WHERE   CreateTime BETWEEN '2017-2-1 00:00:00'
                   AND     '2017-2-28 23:59:59'


---------13.�ֹ�ת��������---------
SELECT  COUNT(*) ,
        TransTypeCode
FROM    dbo.WMS_StkRctMstr
        LEFT JOIN dbo.WMS_StkRctDet ON dbo.WMS_StkRctMstr.RctBillGuid = dbo.WMS_StkRctDet.RctBillGuid
WHERE   TransTypeCode IN ( 'TO1Step', 'TO2Step', 'ManualTO1Step',
                           'ManualTO2Step' )
        AND IsTransDone = 1
        AND CloseReason = 0
        AND dbo.WMS_StkRctDet.CreateTime BETWEEN '2017-2-1 00:00:00'
                                         AND     '2017-2-28 23:59:59'
GROUP BY TransTypeCode

SELECT  COUNT(*) ,
        TransTypeCode
FROM    dbo.WMS_StkOutMstr
        LEFT JOIN dbo.WMS_StkOutDet ON dbo.WMS_StkOutMstr.OutBillGuid = dbo.WMS_StkOutDet.OutBillGuid
WHERE   TransTypeCode IN ( 'TO2Step', 'ManualTO2Step' )
        AND IsTransDone = 1
        AND CloseReason = 0
        AND dbo.WMS_StkOutDet.CreateTime BETWEEN '2017-2-1 00:00:00'
                                         AND     '2017-2-28 23:59:59'
GROUP BY TransTypeCode


----����:�ֹ�ת����������,���������������������Manual�Ķ����ֹ���-----------


----��ĸ:�����ƿ������������������������ݻ���----


------------14.�����ջ���(����ע�����ӡ����ᡢ��Э�����ջ��ھ�ͳ��)-----------------

----���ӣ�û��ͨ��ɨ������е�����������----
SELECT  *
FROM    dbo.WMS_StkRctDet
        LEFT JOIN dbo.WMS_StkRctMstr ON dbo.WMS_StkRctDet.RctBillGuid = dbo.WMS_StkRctMstr.RctBillGuid
WHERE   TransTypeCode = 'PO'
        AND Barcode = '' --û��ͨ��ɨ��Ϳ�Barcode�Ƿ�Ϊ��
        AND dbo.WMS_StkRctDet.CreateTime BETWEEN '2017-2-1 00:00:00'
                                         AND     '2017-2-28 23:59:59'

----��ĸ�����вɹ��ջ�����¼����----
SELECT  COUNT(*)
FROM    dbo.WMS_StkRctDet
        LEFT JOIN dbo.WMS_StkRctMstr ON dbo.WMS_StkRctDet.RctBillGuid = dbo.WMS_StkRctMstr.RctBillGuid
WHERE   TransTypeCode = 'PO'
        AND dbo.WMS_StkRctDet.CreateTime BETWEEN '2017-2-1 00:00:00'
                                         AND     '2017-2-28 23:59:59'

------15.������������(����������ɨ�������������ޱ仯)-----------

SELECT  COUNT(DISTINCT ( a.Barcode ))
FROM    dbo.MFG_BarcodeScanLog a WITH ( NOLOCK )
        LEFT JOIN dbo.MFG_ProductBarcode WITH ( NOLOCK ) ON a.Barcode = dbo.MFG_ProductBarcode.Barcode
WHERE   QualityStatus NOT IN ( 3, 4, 8, 9 )
        AND BarcodeStatus <> '30'
        AND BarcodeStatus <> '99'
        AND a.CreateTime BETWEEN DATEADD(m, -3, GETDATE())
                         AND     GETDATE()
        AND ScanSiteCode NOT IN ( 'BarcodePrint', 'BarcodeModify' ) --��������ɨ���������
        AND NOT EXISTS (
		--3������ɨ�������������й��仯������
        SELECT  Barcode
        FROM    dbo.MFG_BarcodeScanLog b WITH ( NOLOCK )
        WHERE   b.CreateTime BETWEEN DATEADD(m, -3, GETDATE())
                             AND     GETDATE()
                AND b.ScanSiteCode NOT IN ( 'BarcodePrint', 'BarcodeModify' )
                AND b.Barcode = a.Barcode
                AND ( b.OrigPartNo != b.NewPartNo
                      OR ( b.OrigPartVersion = 'EMPTY'
                           AND b.NewPartVersion <> 'EMPTY'
                         )
                    ) )

