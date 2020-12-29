
INSERT  INTO IMES3.dbo.MFG_BarcodeScanLog
        ( Barcode ,
          OrigPartNo ,
          OrigPartVersion ,
          OrigQualityStatus ,
          NewPartNo ,
          NewPartVersion ,
          NewQualityStatus ,
          ScanSiteCode ,
          ActionCode ,
          RctStk ,
          IssStk ,
          ControlStatus ,
          RctBOM ,
          FactoryCode ,
          WCCode ,
          ProdLineCode ,
          CreateTime ,
          CreateMachine ,
          CreateUserAccount ,
          IsDel ,
          IsDelAfter ,
          FlowType ,
          LogGUID ,
          ClientTraceInfo ,
          ServerTraceInfo ,
          OpType ,
          WorkingHours
        )
        SELECT  barlog_code ,
                barlog_reference ,
                'NORMAL' ,
                1 ,
                barlog_part ,
                'NORMAL' ,
                1 ,
                CASE WHEN barlog_fromsite = 'Bondingɨ��' THEN 'BondingScan'
                     WHEN barlog_fromsite = '��ϴɨ��' THEN 'CleanScan'
                     WHEN barlog_fromsite = '��Ϳɨ��' THEN 'PrimeScan'
                END ,
                'IntoOK' ,
                '' ,
                '' ,
                '' ,
                '' ,
                '1140' ,
                '' ,
                '' ,
                barlog_date ,
                barlog_machine ,
                barlog_userid ,
                0 ,
                0 ,
                '' ,
                'MES2.0Import' ,
                'MES2.0Import' ,
                'MES2.0Import' ,
                '' ,
                0
        FROM    IMES.dbo.barlog_det WITH ( NOLOCK )
                JOIN IMES.dbo.bar_mstr WITH(NOLOCK) ON bar_code = barlog_code
        WHERE   barlog_fromsite IN ( '��ϴɨ��', 'Bondingɨ��', '��Ϳɨ��' )
                AND bar_next_site NOT LIKE '%�ѷ���%'
        ORDER BY barlog_id 


