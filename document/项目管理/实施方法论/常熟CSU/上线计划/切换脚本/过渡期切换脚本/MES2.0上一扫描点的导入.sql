
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
                CASE WHEN barlog_fromsite = 'Bonding…®√Ë' THEN 'BondingScan'
                     WHEN barlog_fromsite = '«Âœ¥…®√Ë' THEN 'CleanScan'
                     WHEN barlog_fromsite = 'µ◊Õø…®√Ë' THEN 'PrimeScan'
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
        WHERE   barlog_fromsite IN ( '«Âœ¥…®√Ë', 'Bonding…®√Ë', 'µ◊Õø…®√Ë' )
                AND bar_next_site NOT LIKE '%“—∑¢‘À%'
        ORDER BY barlog_id 


