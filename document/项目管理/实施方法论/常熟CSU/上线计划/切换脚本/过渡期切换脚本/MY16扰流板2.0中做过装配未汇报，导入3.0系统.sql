--一：扰流板条码
--找出所有做了装配扫描的扰流板
SELECT *
FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
JOIN IMES.dbo.bar_mstr WITH(NOLOCK) ON bar_code = barlog_code 
LEFT JOIN IMES.dbo.AssemblySheet WITH(NOLOCK) ON PreBindBarcode = barlog_code
WHERE   barlog_part IN ( SELECT barindet_part
                         FROM   IMES.dbo.barindet_det WITH ( NOLOCK )
                         WHERE  barindet_custloc = 'MY16扰流板' )
        AND barlog_fromsite = '装配扫描' AND barlog_result = '合格'
		AND barlog_date >= '2016-01-01 00:00:00.000'
		AND bar_next_site NOT LIKE '%已发运%'
		ORDER BY barlog_id

--在3.0中Check一遍条码数量，不要有明显差异
SELECT  *
FROM    IMES3.dbo.MFG_ProductBarcode a WITH(NOLOCK)
        JOIN ( SELECT  *
                    FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
                            JOIN IMES.dbo.bar_mstr WITH ( NOLOCK ) ON bar_code = barlog_code
                            LEFT JOIN IMES.dbo.AssemblySheet WITH ( NOLOCK ) ON PreBindBarcode = barlog_code
                    WHERE   barlog_part IN (
                            SELECT  barindet_part
                            FROM    IMES.dbo.barindet_det WITH ( NOLOCK )
                            WHERE   barindet_custloc = 'MY16扰流板' )
                            AND barlog_fromsite = '装配扫描'  AND barlog_result = '合格'
                            AND barlog_date >= '2016-01-01 00:00:00.000'
                            AND bar_next_site NOT LIKE '%已发运%'
                  ) b ON a.Barcode = b.bar_code
				  
--在3.0中更新这批条码的配置
UPDATE a SET a.ISCCR = 1 , a.StdOrdCfg = b.RefOrder FROM    IMES3.dbo.MFG_ProductBarcode a 
        JOIN ( SELECT  *
                    FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
                            JOIN IMES.dbo.bar_mstr WITH ( NOLOCK ) ON bar_code = barlog_code
                            LEFT JOIN IMES.dbo.AssemblySheet WITH ( NOLOCK ) ON PreBindBarcode = barlog_code
                    WHERE   barlog_part IN (
                            SELECT  barindet_part
                            FROM    IMES.dbo.barindet_det WITH ( NOLOCK )
                            WHERE   barindet_custloc = 'MY16扰流板' )
                            AND barlog_fromsite = '装配扫描'  AND barlog_result = '合格'
                            AND barlog_date >= '2016-01-01 00:00:00.000'
                            AND bar_next_site NOT LIKE '%已发运%'
                  ) b ON a.Barcode = b.bar_code

--3.0中插入这批条码的MFG_ProdBarCodeCCRComps

INSERT  INTO IMES3.dbo.MFG_ProdBarCodeCCRComps
        ( BarCode ,
          StdOrdCfg ,
          IsActive ,
          PartNo ,
          CustPartNo ,
          ReqQty ,
          AssembliedQty ,
          CreateTime
        )
        SELECT  Barcode, a.StdOrdCfg, IsActive, dbo.LGS_CustStdOrdDet.PartNo, CustPartNo, Qty, 0, GETDATE()
        FROM    IMES3.dbo.MFG_ProductBarcode a WITH ( NOLOCK )
                JOIN ( SELECT   *
                       FROM     IMES.dbo.barlog_det WITH ( NOLOCK )
                                JOIN IMES.dbo.bar_mstr WITH ( NOLOCK ) ON bar_code = barlog_code
                                LEFT JOIN IMES.dbo.AssemblySheet WITH ( NOLOCK ) ON PreBindBarcode = barlog_code
                       WHERE    barlog_part IN (
                                SELECT  barindet_part
                                FROM    IMES.dbo.barindet_det WITH ( NOLOCK )
                                WHERE   barindet_custloc = 'MY16扰流板' )
                                AND barlog_fromsite = '装配扫描'
                                AND barlog_result = '合格'
                                AND barlog_date >= '2016-01-01 00:00:00.000'
                                AND bar_next_site NOT LIKE '%已发运%'
                     ) b ON a.Barcode = b.bar_code
                JOIN IMES3.dbo.LGS_CustStdOrdDet ON a.StdOrdCfg = dbo.LGS_CustStdOrdDet.StdOrdCfg 




--二：保险杠条码
--找出所有扫了装配预排序但还没有发运出去的保险杠条码

