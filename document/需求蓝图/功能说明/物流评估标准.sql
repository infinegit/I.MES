--------------物流评估标准----------------------

------------------1.条码件手工事务率-------------------------
--分子：条码件手工事务数量
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


--分母：条码件总的事务数量
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = trans.PartNo
                            AND part.IsSelfMade = 1
                            AND part.HasBarcode = 1 )


---------------2.小件手工事务率--------------------
--分子：小件手工事务数量
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


--分母：小件总的事务数量
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime <= '2016-12-31'
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = trans.PartNo
                            AND part.IsSelfMade = 1
                            AND part.HasBarcode = 0 )


------------3.外协件手工事务率-----------------
--分子：外协件手工事务数量
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

--分母：外协件总的事务数量
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'
        AND EXISTS ( SELECT *
                     FROM   dbo.MFG_Part AS part WITH ( NOLOCK )
                     WHERE  part.PartNo = trans.PartNo
                            AND part.IsSelfMade = 0 )



-------------4.不及时事务率-----------------
----分母：所有事务-------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'


----分子：手工事务-------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction trans WITH ( NOLOCK )
WHERE   CreateTime >= '2016-12-01'
        AND CreateTime < '2017-1-1'
        AND ABS(DATEDIFF(day, AccountingDate, CreateTime)) > 1


-------------------5.注塑下线打包率------------------------
----分子：注塑下线打包数-------
SELECT  COUNT(*)
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'IMMScan'
        AND ActionCode = 'IntoOK'
        AND ( FlowType = '打包' )

----分母：注塑下线打包+散件数--------

SELECT  COUNT(*)
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'IMMScan'
        AND ActionCode = 'IntoOK'
        AND ( FlowType = '打包'
              OR FlowType = '散件'
            )


--------------------6.涂装下线打包率(标准版)-------------------------
-----分子：涂装下线打包数-------
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

-----分母：涂装下线总数-------
SELECT  COUNT(*)
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'PaintOffLineScan'
        AND ActionCode = 'IntoOK'
 --+时间范围



-----------------7.下架准确率(标准版)---------------------
----下架推荐BIN位没有进行记录。需要将下架推荐BIN位记录到WMS_ProductBinChangeLog表中


-----------------8.订单发运出门证使用率---------------
SELECT  OrderCMZCount AS 有过出门证记录的订单数 ,
        OrderCount AS 所有订单数 ,
        CASE OrderCount
          WHEN 0 THEN +'0.00%'
          ELSE CONVERT(VARCHAR(20), CAST(OrderCMZCount * 1.00 / OrderCount AS DECIMAL(18,
                                                              4)) * 100) + '%'
        END AS 出门证使用率
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
		


-----------------9.出门证使用率(排序发运)---------------------
----分子：有过出门证记录的排序信息数

----分母：所有排序信息数



----------10.强制变更数量---------------
----固定时间段里面强制变更的数量
SELECT  *
FROM    dbo.MFG_BarcodeScanLog
WHERE   ScanSiteCode = 'BarcodeModify'
        AND ActionCode = 'Modify'

----------11.近3个月死条码数量（近三个月内未扫描到的条码）----------

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


----------12.COGI比率-------------
----分子：COGI事务数---------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
WHERE   COGIGuid <> ''
        AND CreateTime BETWEEN '2017-2-1 00:00:00'
                       AND     '2017-2-28 23:59:59'
----分母：所有事务数---------
SELECT  COUNT(*)
FROM    dbo.SYS_SAPTransaction WITH ( NOLOCK )
WHERE   CreateTime BETWEEN '2017-2-1 00:00:00'
                   AND     '2017-2-28 23:59:59'


---------13.手工转储事务率---------
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


----分子:手工转储事务数量,在上面查出来的数据里面带Manual的都是手工的-----------


----分母:所有移库事务数量，上面查出来的数据汇总----


------------14.条码收货率(包含注塑粒子、油漆、外协件，收货口径统计)-----------------

----分子：没有通过扫描而进行的入库操作笔数----
SELECT  *
FROM    dbo.WMS_StkRctDet
        LEFT JOIN dbo.WMS_StkRctMstr ON dbo.WMS_StkRctDet.RctBillGuid = dbo.WMS_StkRctMstr.RctBillGuid
WHERE   TransTypeCode = 'PO'
        AND Barcode = '' --没有通过扫描就看Barcode是否为空
        AND dbo.WMS_StkRctDet.CreateTime BETWEEN '2017-2-1 00:00:00'
                                         AND     '2017-2-28 23:59:59'

----分母：所有采购收货入库记录笔数----
SELECT  COUNT(*)
FROM    dbo.WMS_StkRctDet
        LEFT JOIN dbo.WMS_StkRctMstr ON dbo.WMS_StkRctDet.RctBillGuid = dbo.WMS_StkRctMstr.RctBillGuid
WHERE   TransTypeCode = 'PO'
        AND dbo.WMS_StkRctDet.CreateTime BETWEEN '2017-2-1 00:00:00'
                                         AND     '2017-2-28 23:59:59'

------15.呆滞条码数量(近三个月内扫描过，但零件号无变化)-----------

SELECT  COUNT(DISTINCT ( a.Barcode ))
FROM    dbo.MFG_BarcodeScanLog a WITH ( NOLOCK )
        LEFT JOIN dbo.MFG_ProductBarcode WITH ( NOLOCK ) ON a.Barcode = dbo.MFG_ProductBarcode.Barcode
WHERE   QualityStatus NOT IN ( 3, 4, 8, 9 )
        AND BarcodeStatus <> '30'
        AND BarcodeStatus <> '99'
        AND a.CreateTime BETWEEN DATEADD(m, -3, GETDATE())
                         AND     GETDATE()
        AND ScanSiteCode NOT IN ( 'BarcodePrint', 'BarcodeModify' ) --近三个月扫描过的条码
        AND NOT EXISTS (
		--3个月内扫描过，但零件号有过变化的条码
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

