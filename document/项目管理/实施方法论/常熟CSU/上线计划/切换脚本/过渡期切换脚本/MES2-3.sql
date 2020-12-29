
-----------��3.0�д�����ʱ��-------------

----------------End-------------------


--��������
insert into imes3.dbo.bar_mstr (bar_code, bar_wod_nbr, bar_printed, bar_part, bar_next_site, bar_part_imm, bar_part_pnt, bar_part_asm,bar_prt_date, bar_imm_date, bar_upl_date, bar_dwn_date, bar_asm_date, bar_shp_date, bar_loc, bar_firstok,bar_cust_gano, bar_printer, bar_ordernbr, bar_part_pre, bar_custlot) 
select bar_code, bar_wod_nbr, bar_printed, bar_part, bar_next_site, bar_part_imm, bar_part_pnt, bar_part_asm, bar_prt_date, bar_imm_date, bar_upl_date, bar_dwn_date, bar_asm_date, bar_shp_date, bar_loc, bar_firstok, bar_cust_gano, bar_printer, bar_ordernbr, bar_part_pre, bar_custlot 
from imes.dbo.bar_mstr WITH(NOLOCK) where bar_loc in (select code from imes.idaq.location WITH(NOLOCK) where region = 'ES19') and bar_code not in (select bar_code from imes3.dbo.bar_mstr)
--��Ϳװ��������
insert into imes3.dbo.MFG_ProductBarcode (Barcode,CurrentPartNo,currentpartversion,QualityStatus,ControlStatus,IsIsolated,IsPrinted,BarcodeStatus,CreateUserAccount,CreateMachine,CreateTime) select bar_code,bar_part,'NORMAL','1','PntUpLine','0','1','20','lwang65','lwang65','2016-12-31' 
from imes3.dbo.bar_mstr where bar_loc = 'Ϳװ������' and bar_code not in (select barcode from imes3.dbo.MFG_ProductBarcode with (nolock))
--���ϸ�����������
insert into imes3.dbo.MFG_ProductBarcode (Barcode,CurrentPartNo,currentpartversion,QualityStatus,ControlStatus,IsIsolated,IsPrinted,BarcodeStatus,CreateUserAccount,CreateMachine,CreateTime) select bar_code,bar_part,'DDQ','1','','0','1','20','lwang65','lwang65','2016-12-31' 
from imes3.dbo.bar_mstr where bar_cust_gano = '�������' and bar_loc not like '%����%' and bar_code not in (select barcode from imes3.dbo.MFG_ProductBarcode with (nolock))
--����������������
insert into imes3.dbo.MFG_ProductBarcode (Barcode,CurrentPartNo,currentpartversion,QualityStatus,ControlStatus,IsIsolated,IsPrinted,BarcodeStatus,CreateUserAccount,CreateMachine,CreateTime) select bar_code,bar_part,'DDQ','2','','0','1','20','lwang65','lwang65','2016-12-31' 
from imes3.dbo.bar_mstr where bar_cust_gano = '�������' and bar_loc like '%����%' and bar_code not in (select barcode from imes3.dbo.MFG_ProductBarcode with (nolock))
--����ĥ������
insert into imes3.dbo.MFG_ProductBarcode (Barcode,CurrentPartNo,currentpartversion,QualityStatus,ControlStatus,IsIsolated,IsPrinted,BarcodeStatus,CreateUserAccount,CreateMachine,CreateTime) select bar_code,bar_part,'DM','1','','0','1','20','lwang65','lwang65','2016-12-31' 
from imes3.dbo.bar_mstr where bar_loc = 'Ϳװ��ĥ��' and bar_code not in (select barcode from imes3.dbo.MFG_ProductBarcode with (nolock))
--�����������
insert into imes3.dbo.MFG_ProductBarcode (Barcode,CurrentPartNo,currentpartversion,QualityStatus,ControlStatus,IsIsolated,IsPrinted,BarcodeStatus,CreateUserAccount,CreateMachine,CreateTime) select bar_code,bar_part,'NORMAL','2','','0','1','20','lwang65','lwang65','2016-12-31' 
from imes3.dbo.bar_mstr where bar_loc like '%����%' and bar_code not in (select barcode from imes3.dbo.MFG_ProductBarcode with (nolock))
--���ϸ������
insert into imes3.dbo.MFG_ProductBarcode (Barcode,CurrentPartNo,currentpartversion,QualityStatus,ControlStatus,IsIsolated,IsPrinted,BarcodeStatus,CreateUserAccount,CreateMachine,CreateTime) select bar_code,bar_part,'NORMAL','1','','0','1','20','lwang65','lwang65','2016-12-31' 
from imes3.dbo.bar_mstr where bar_loc not like '%����%' and bar_code not in (select barcode from imes3.dbo.MFG_ProductBarcode with (nolock))

--�����װ
insert into imes3.dbo.ct_mstr1 (ct_code, ct_scode, ct_part, ct_qty, ct_createtime, ct_receivetime, ct_delivertime, ct_property, ct_status, ct_type, machine, ct_rackcode, ct_location, ct_isopen, ct_seqtime, ct_ordernbr, ct_suggestbin, ct_comments, ct_print, ct_maxqty, ct_lotnumber, ct_lotnumber1, ct_punching, FormName, ct_openBottle) select ct_code, ct_scode, ct_part, ct_qty, ct_createtime, ct_receivetime, ct_delivertime, ct_property, ct_status, ct_type, machine, ct_rackcode, ct_location, ct_isopen, ct_seqtime, ct_ordernbr, ct_suggestbin, ct_comments, ct_print, ct_maxqty, ct_lotnumber, ct_lotnumber1, ct_punching, FormName, ct_openBottle 
from imes.dbo.ct_mstr where ct_rackcode <> '' and ct_location in (select code from imes.idaq.location where region = 'ES19') and ct_code not in (select ct_code from imes3.dbo.ct_mstr)
--������Э����װ(ԭʼ)
insert into imes3.dbo.ct_mstr1 (ct_code, ct_scode, ct_part, ct_qty, ct_createtime, ct_receivetime, ct_delivertime, ct_property, ct_status, ct_type, machine, ct_rackcode, ct_location, ct_isopen, ct_seqtime, ct_ordernbr, ct_suggestbin, ct_comments, ct_print, ct_maxqty, ct_lotnumber, ct_lotnumber1, ct_punching, FormName, ct_openBottle) select ct_code, ct_scode, ct_part, ct_qty, ct_createtime, ct_receivetime, ct_delivertime, ct_property, ct_status, ct_type, machine, ct_rackcode, ct_location, ct_isopen, ct_seqtime, ct_ordernbr, ct_suggestbin, ct_comments, ct_print, ct_maxqty, ct_lotnumber, ct_lotnumber1, ct_punching, FormName, ct_openBottle 
from imes.dbo.ct_mstr where ct_rackcode = '' and ct_property = ' ��Э��' and ct_qty <> 0 and ct_location in (select code from imes.idaq.location where region = 'ES19') and ct_code not in (select ct_code from imes3.dbo.ct_mstr)
--������Э����װ
insert into imes3.dbo.LGS_HUPkgMstr 
(hucode,FactoryCode,rackcode,PkgTypeCode,partno,PartVersion,QualityStatusCode,HUQty,HUMaxQty,IsSealed,CreateUserAccount,CreateMachine,CreateTime,ProdPlaceCode,huid,PackageStatus) 
select ct_code,'1140','','SupTurnOverBox',ct_part,'NORMAL','1',ct_qty,ct_qty,'1','lwang65','lwang65','2016-12-31','',ct_code,'20' from imes3.dbo.ct_mstr1 where 
 ct_rackcode = '' and ct_property = ' ��Э��' and ct_qty <> 0 and ct_code not in (select hucode from imes3.dbo.LGS_HUPkgMstr with (nolock))
--����HU--���������
insert into imes3.dbo.LGS_HUPkgMstr 
(hucode,FactoryCode,rackcode,PkgTypeCode,partno,PartVersion,QualityStatusCode,HUQty,HUMaxQty,IsSealed,CreateUserAccount,CreateMachine,CreateTime,ProdPlaceCode,huid,PackageStatus) 
select ct_code,'1140',ct_rackcode,'3LayerRack',ct_part,'DDQ','2',ct_qty,ct_qty,'1','lwang65','lwang65','2016-12-31','',ct_code,'20' from imes3.dbo.ct_mstr1 where 
 ct_property like '%������%' and ct_location like '%����%' and ct_code not in (select hucode from imes3.dbo.LGS_HUPkgMstr with (nolock))
--����HU--�ϸ������
insert into imes3.dbo.LGS_HUPkgMstr 
(hucode,FactoryCode,rackcode,PkgTypeCode,partno,PartVersion,QualityStatusCode,HUQty,HUMaxQty,IsSealed,CreateUserAccount,CreateMachine,CreateTime,ProdPlaceCode,huid,PackageStatus) 
select ct_code,'1140',ct_rackcode,'3LayerRack',ct_part,'DDQ','1',ct_qty,ct_qty,'1','lwang65','lwang65','2016-12-31','',ct_code,'20' from imes3.dbo.ct_mstr1 where 
 ct_property like '%������%' and ct_location not like '%����%'  and ct_code not in (select hucode from imes3.dbo.LGS_HUPkgMstr with (nolock))
--����HU--����������
insert into imes3.dbo.LGS_HUPkgMstr 
(hucode,FactoryCode,rackcode,PkgTypeCode,partno,PartVersion,QualityStatusCode,HUQty,HUMaxQty,IsSealed,CreateUserAccount,CreateMachine,CreateTime,ProdPlaceCode,huid,PackageStatus) 
select ct_code,'1140',ct_rackcode,'3LayerRack',ct_part,'NORMAL','2',ct_qty,ct_qty,'1','lwang65','lwang65','2016-12-31','',ct_code,'20' from imes3.dbo.ct_mstr1 where 
 ct_property not like '%������%' and ct_location like '%����%' and ct_code not in (select hucode from imes3.dbo.LGS_HUPkgMstr with (nolock))
--����HU--�ϸ�������
insert into imes3.dbo.LGS_HUPkgMstr 
(hucode,FactoryCode,rackcode,PkgTypeCode,partno,PartVersion,QualityStatusCode,HUQty,HUMaxQty,IsSealed,CreateUserAccount,CreateMachine,CreateTime,ProdPlaceCode,huid,PackageStatus) 
select ct_code,'1140',ct_rackcode,'3LayerRack',ct_part,'NORMAL','1',ct_qty,ct_qty,'1','lwang65','lwang65','2016-12-31','',ct_code,'20' from imes3.dbo.ct_mstr1 where 
 ct_property not like '%������%' and ct_location not like '%����%'  and ct_code not in (select hucode from imes3.dbo.LGS_HUPkgMstr with (nolock))
--TSС����װ����
UPDATE imes3.dbo.LGS_HUPkgMstr SET pkgtypecode = 'tsrack' where RackCode like 'TSXC%'
--��TSС����װ����
CREATE VIEW pkgview
as
select a.PkgTypeCode aa,b.RackType ab,c.pkgtypename ac,c.pkgtypecode ad from imes3.dbo.LGS_HUPkgMstr a,imes.dbo.rack_mstr b,imes3.dbo.LGS_PackageType c where a.RackCode = b.RackCode and c.pkgtypename = b.racktype

select * from pkgview
update pkgview set aa = ad
DROP VIEW pkgview
--ֽ���RKɾ��
update imes3.dbo.LGS_HUPkgMstr set rackcode = '' where rackcode like 'zx%'

--**********************************************************************************************************
--����HU��BAR��Ӧ��ϵ(ԭʼ)
insert into imes3.dbo.ctd_det1 (ctcode, barcode, prodate, emp, machine, RackType, [program_name], project, method_name)
select ctcode, barcode, prodate, emp, machine, RackType, [program_name], project, method_name from imes.dbo.ctd_det
where ctcode in (select ct_code from imes.dbo.ct_mstr where ct_rackcode <> '' )
and ctcode not in (select ctcode from imes3.dbo.ctd_det1 with (nolock))
--����HU��BAR��Ӧ��ϵ
insert into imes3.dbo.LGS_HUPkgDet (HUCode,barcode,pkgtime,PkgUserAccount,PkgMachine,huid,CreateUserAccount,CreateMachine,CreateTime) 
select ctcode,barcode,prodate,emp,machine,'','lwang65','lwang65','2016-12-31' from imes3.dbo.ctd_det1 
where ctcode in (select hucode from imes3.dbo.LGS_HUPkgMstr where factorycode = '1140') and ctcode + barcode not in (select hucode + barcode from imes3.dbo.LGS_HUPkgDet )
--************************************************************************************************************************
--�����װ��BINλ��Ӧ��ϵ(ԭʼ)
insert into imes3.dbo.hjd_det (hjd_row, hjd_nbr, hjd_key)
select hjd_row, hjd_nbr, hjd_key from imes.dbo.hjd_det

--�����װ��BINλ��Ӧ��ϵ
insert into imes3.dbo.WMS_ProductBinDet (bincode,GridNum,BarcodeType,Barcode,CreateUserAccount,CreateMachine,CreateTime)
select convert(varchar(100),hjd_row)+'-'+ convert(varchar(100),hjd_nbr),'1','HU',hjd_key,'lwang65','lwang65','2016-12-31' from imes3.dbo.hjd_det
where convert(varchar(100),hjd_row)+'-'+ convert(varchar(100),hjd_nbr) not in (select bincode from imes3.dbo.WMS_ProductBinDet)


--------------------------����ר��--------------------------

--����2.0��ɨ����־��¼
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

--����2.0��������Ԥװ����Ԥװ��Ϣ
--һ������������
--a.�ҳ���������װ��ɨ���������
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

--b.��3.0��Checkһ��������������Ҫ�����Բ���
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
				  
--c.��3.0�и����������������
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

--d.3.0�в������������MFG_ProdBarCodeCCRComps
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



---------------------------End------------------------------





