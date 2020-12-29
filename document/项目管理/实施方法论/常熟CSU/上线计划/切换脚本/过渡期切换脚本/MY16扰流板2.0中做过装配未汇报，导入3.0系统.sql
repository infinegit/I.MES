--һ������������
--�ҳ���������װ��ɨ���������
SELECT *
FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
JOIN IMES.dbo.bar_mstr WITH(NOLOCK) ON bar_code = barlog_code 
LEFT JOIN IMES.dbo.AssemblySheet WITH(NOLOCK) ON PreBindBarcode = barlog_code
WHERE   barlog_part IN ( SELECT barindet_part
                         FROM   IMES.dbo.barindet_det WITH ( NOLOCK )
                         WHERE  barindet_custloc = 'MY16������' )
        AND barlog_fromsite = 'װ��ɨ��' AND barlog_result = '�ϸ�'
		AND barlog_date >= '2016-01-01 00:00:00.000'
		AND bar_next_site NOT LIKE '%�ѷ���%'
		ORDER BY barlog_id

--��3.0��Checkһ��������������Ҫ�����Բ���
SELECT  *
FROM    IMES3.dbo.MFG_ProductBarcode a WITH(NOLOCK)
        JOIN ( SELECT  *
                    FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
                            JOIN IMES.dbo.bar_mstr WITH ( NOLOCK ) ON bar_code = barlog_code
                            LEFT JOIN IMES.dbo.AssemblySheet WITH ( NOLOCK ) ON PreBindBarcode = barlog_code
                    WHERE   barlog_part IN (
                            SELECT  barindet_part
                            FROM    IMES.dbo.barindet_det WITH ( NOLOCK )
                            WHERE   barindet_custloc = 'MY16������' )
                            AND barlog_fromsite = 'װ��ɨ��'  AND barlog_result = '�ϸ�'
                            AND barlog_date >= '2016-01-01 00:00:00.000'
                            AND bar_next_site NOT LIKE '%�ѷ���%'
                  ) b ON a.Barcode = b.bar_code
				  
--��3.0�и����������������
UPDATE a SET a.ISCCR = 1 , a.StdOrdCfg = b.RefOrder FROM    IMES3.dbo.MFG_ProductBarcode a 
        JOIN ( SELECT  *
                    FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
                            JOIN IMES.dbo.bar_mstr WITH ( NOLOCK ) ON bar_code = barlog_code
                            LEFT JOIN IMES.dbo.AssemblySheet WITH ( NOLOCK ) ON PreBindBarcode = barlog_code
                    WHERE   barlog_part IN (
                            SELECT  barindet_part
                            FROM    IMES.dbo.barindet_det WITH ( NOLOCK )
                            WHERE   barindet_custloc = 'MY16������' )
                            AND barlog_fromsite = 'װ��ɨ��'  AND barlog_result = '�ϸ�'
                            AND barlog_date >= '2016-01-01 00:00:00.000'
                            AND bar_next_site NOT LIKE '%�ѷ���%'
                  ) b ON a.Barcode = b.bar_code

--3.0�в������������MFG_ProdBarCodeCCRComps

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
                                WHERE   barindet_custloc = 'MY16������' )
                                AND barlog_fromsite = 'װ��ɨ��'
                                AND barlog_result = '�ϸ�'
                                AND barlog_date >= '2016-01-01 00:00:00.000'
                                AND bar_next_site NOT LIKE '%�ѷ���%'
                     ) b ON a.Barcode = b.bar_code
                JOIN IMES3.dbo.LGS_CustStdOrdDet ON a.StdOrdCfg = dbo.LGS_CustStdOrdDet.StdOrdCfg 




--�������ո�����
--�ҳ�����ɨ��װ��Ԥ���򵫻�û�з��˳�ȥ�ı��ո�����

