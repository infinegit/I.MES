--�ӿڣ�GRC_WFM2MES_004  
--MES���ڽ���ɫ/Ȩ���嵥������������					

--0.�ȷ�����WCF���͡�MES2SAP��


--1.���½�ɫ-Ȩ����ͼ
ALTER VIEW [dbo].[V_RolePriv]
AS
    SELECT  RoleID ,
            RoleDesc ,
            PrivID ,
            PrivDesc ,
            'MES' AS SysCode ,
            FactoryCode
    FROM    dbo.SYS_Role WITH ( NOLOCK )
            JOIN dbo.SYS_RoleProgPriv WITH ( NOLOCK ) ON dbo.SYS_Role.RoleCode = dbo.SYS_RoleProgPriv.RoleCode
            JOIN dbo.SYS_ProgPriv ON dbo.SYS_RoleProgPriv.PrivCode = dbo.SYS_ProgPriv.PrivCode
            JOIN dbo.SYS_Factory WITH ( NOLOCK ) ON 1 = 1 

--2.���½�ɫID��RoleID��
--SELECT * FROM  dbo.SYS_Role

DECLARE @SAPCompanyCode AS NVARCHAR(4)
SELECT @SAPCompanyCode = SAPCompanyCode FROM dbo.SYS_Company --ÿ��ִ�ж�Ҫ������������һ�¹�˾���� 
UPDATE dbo.SYS_Role   SET RoleID = 'ZZ_' + @SAPCompanyCode + '_ME_' + RoleCode


CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20170705-100400] ON [dbo].[SYS_Role] --RoleID����һ��Ψһ�����������ظ�
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


--3.����Ȩ��ID��PrivID��
--SELECT * FROM  dbo.SYS_ProgPriv 
UPDATE  dbo.SYS_ProgPriv SET PrivID = 'ZZME' + PrivCode 

CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20170705-100732] ON [dbo].[SYS_ProgPriv] --PrivID����һ��Ψһ�����������ظ�
(
	[PrivID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


--4.�ӿ�����SAPIFCFG
INSERT INTO dbo.SYS_SapIFCfg 
        ( IfCode ,
          IfDesc ,
          IfWsdl ,
          IfUser ,
          IfPwd ,
          ServiceName ,
          ParamName ,
          MethodName ,
          RespObjectName ,
          SapIfCode ,
          SapSender ,
          SapReceiver ,
          ReqClass ,
          MstrClass ,
          MstrTable ,
          MstrCondition ,
          DetClass ,
          DetTable ,
          DetCondition ,
          CreateTime ,
          IFType
        )
VALUES  ( N'GRC0001' , -- IfCode - nvarchar(20)
          N'Ȩ��������������' , -- IfDesc - nvarchar(50)
          N'http://yfpowfm/base_Sys_getRoleData.asmx?op=GetMESRole&wsdl' , -- IfWsdl - nvarchar(100)
          N'' , -- IfUser - nvarchar(20)
          N'' , -- IfPwd - nvarchar(20)
          N'base_Sys_getRoleData' , -- ServiceName - nvarchar(50)
          N'MES_Role_List' , -- ParamName - nvarchar(50)
          N'GetMESRole' , -- MethodName - nvarchar(50)
          N'' , -- RespObjectName - nvarchar(50)
          N'FI001' , -- SapIfCode - nvarchar(20)
          N'MES' , -- SapSender - nvarchar(20)
          N'WFM' , -- SapReceiver - nvarchar(20)
          N'MEStoSAP.Models.IFS_RolePrivReq' , -- ReqClass - nvarchar(100)
          N'MEStoSAP.Models.IFS_RolePriv' , -- MstrClass - nvarchar(100)
          N'V_RolePriv' , -- MstrTable - nvarchar(50)
          N'1=1' , -- MstrCondition - nvarchar(1000)
          N'' , -- DetClass - nvarchar(100)
          N'' , -- DetTable - nvarchar(50)
          N'' , -- DetCondition - nvarchar(1000)
          '2017-07-05 01:48:31' , -- CreateTime - datetime
          4  -- IFType - int
        )
