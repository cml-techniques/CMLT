
/****** Object:  Table [dbo].[Doc_Time_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Doc_Time_Tbl](
	[Folder_id] [int] NULL,
	[Duration] [int] NULL,
	[First_Rem] [int] NULL,
	[Second_Rem] [int] NULL,
	[Third_Rem] [int] NULL,
	[Prj_code] [varchar](6) NULL,
	[Remind] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CREATING_PROJECTDB]    Script Date: 06/28/2011 12:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREATING_PROJECTDB]
	(@DB_NAME NVARCHAR(50))
AS
BEGIN
	/*DECLARE @NAME NVARCHAR(50)
	DECLARE @DATA NVARCHAR(50)
	DECLARE @LOG NVARCHAR(50)*/
	
	
--USE [master]
	/*select @NAME=@DB_NAME + '_LOG'
	SELECT @DATA='C:\MSSQLDATA\' + @DB_NAME + '.mdf'
	SELECT @LOG='C:\MSSQLDATA\' + @DB_NAME + '_log.ldf'
	declare @QUERY VARCHAR(2000)
	SELECT @QUERY='CREATE DATABASE [' + @DB_NAME + '] ON  PRIMARY (NAME =N'''+@DB_NAME + ''',FILENAME=N''' + @DATA + ''',MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )     LOG ON     ( NAME =N'''+@NAME + ''',FILENAME=N''' + @LOG + ''',MAXSIZE = UNLIMITED, FILEGROWTH = 10%)'
--PRINT @QUERY	
EXEC(@QUERY)*/
create database mydb1
            
	
END
GO
/****** Object:  Table [dbo].[documenttypemaster_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[documenttypemaster_tbl](
	[doctype_code] [varchar](6) NOT NULL,
	[doctype_description] [varchar](50) NULL,
	[possition] [tinyint] NULL,
 CONSTRAINT [PK_documenttypemaster_tbl] PRIMARY KEY CLUSTERED 
(
	[doctype_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[documentmaster_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[documentmaster_tbl](
	[doc_id] [int] IDENTITY(1,1) NOT NULL,
	[service_code] [int] NULL,
	[package_code] [int] NULL,
	[doctype_code] [int] NULL,
	[doc_title] [varchar](50) NULL,
	[doc_name] [varchar](100) NULL,
	[uploaded] [bit] NULL,
	[uploaded_date] [smalldatetime] NULL,
	[file_size] [varchar](15) NULL,
	[folder_id] [int] NULL,
	[project_code] [varchar](6) NULL,
	[possition] [int] NULL,
	[Enabled] [bit] NULL,
	[version] [int] NULL,
	[Status] [varchar](25) NULL,
	[manual] [bit] NULL,
	[uid] [varchar](50) NULL,
 CONSTRAINT [PK_documentmaster_tbl] PRIMARY KEY CLUSTERED 
(
	[doc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Document_Review_Log]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document_Review_Log](
	[dr_id] [int] IDENTITY(1,1) NOT NULL,
	[dr_no] [nvarchar](15) NULL,
	[dr_reviewed] [nvarchar](50) NULL,
	[issue_date] [smalldatetime] NULL,
	[issued_to] [nvarchar](50) NULL,
	[dr_status] [bit] NULL,
	[responds] [bit] NULL,
	[project_code] [nvarchar](6) NULL,
	[uid] [nvarchar](50) NULL,
	[over_due] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Document_Review_Log] PRIMARY KEY CLUSTERED 
(
	[dr_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document_Review_Details]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document_Review_Details](
	[dr_itm_id] [int] IDENTITY(1,1) NOT NULL,
	[dr_id] [int] NULL,
	[details] [nvarchar](500) NULL,
	[response] [nvarchar](500) NULL,
	[_date] [smalldatetime] NULL,
	[uid] [nvarchar](50) NULL,
 CONSTRAINT [PK_Document_Review_Details] PRIMARY KEY CLUSTERED 
(
	[dr_itm_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOG_TBL]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOG_TBL](
	[_log_id] [int] IDENTITY(1,1) NOT NULL,
	[_uid] [nvarchar](50) NULL,
	[_ipaddress] [nvarchar](50) NULL,
	[_location] [nvarchar](50) NULL,
	[_login] [nvarchar](50) NULL,
	[_logout] [nvarchar](50) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_LOG_TBL] PRIMARY KEY CLUSTERED 
(
	[_log_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cassheet_testing_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cassheet_testing_tbl](
	[cas_test_id] [int] IDENTITY(1,1) NOT NULL,
	[cas_id] [int] NULL,
	[devices1] [nvarchar](25) NULL,
	[devices2] [nvarchar](25) NULL,
	[devices3] [nvarchar](25) NULL,
	[test1] [nvarchar](25) NULL,
	[test2] [nvarchar](25) NULL,
	[test3] [nvarchar](25) NULL,
	[test4] [nvarchar](25) NULL,
	[test5] [nvarchar](25) NULL,
	[test6] [nvarchar](25) NULL,
	[test7] [nvarchar](25) NULL,
	[test8] [nvarchar](25) NULL,
	[test9] [nvarchar](25) NULL,
	[test10] [nvarchar](25) NULL,
	[complete] [nvarchar](25) NULL,
	[tested1] [nvarchar](25) NULL,
	[tested2] [nvarchar](25) NULL,
	[per_com1] [decimal](18, 2) NULL,
	[per_com2] [decimal](18, 2) NULL,
	[per_com3] [decimal](18, 2) NULL,
	[sys_id] [int] NULL,
	[project] [nvarchar](6) NULL,
 CONSTRAINT [PK_Cassheet_testing_tbl] PRIMARY KEY CLUSTERED 
(
	[cas_test_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cassheet_master_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cassheet_master_tbl](
	[C_id] [int] IDENTITY(1,1) NOT NULL,
	[Cas_schedule] [int] NULL,
	[P_code] [nvarchar](6) NULL,
	[Uid] [nvarchar](50) NULL,
	[Sys_id] [int] NULL,
	[E_b_ref] [nvarchar](50) NULL,
	[B_Z] [nvarchar](50) NULL,
	[Cat] [nvarchar](50) NULL,
	[F_Lvl] [nvarchar](50) NULL,
	[Sq_No] [nvarchar](50) NULL,
	[Des] [nvarchar](100) NULL,
	[Loc] [nvarchar](50) NULL,
	[P_P_to] [nvarchar](50) NULL,
	[F_from] [nvarchar](50) NULL,
	[Substation] [nvarchar](50) NULL,
	[S_c_m] [nvarchar](50) NULL,
	[Pwr_on] [nvarchar](25) NULL,
	[Con_Acce] [nvarchar](25) NULL,
	[T_S_Filed] [nvarchar](25) NULL,
	[Comm] [nvarchar](500) NULL,
	[Act_by] [nvarchar](50) NULL,
	[Act_Date] [nvarchar](25) NULL,
 CONSTRAINT [PK_Cassheet_master_tbl] PRIMARY KEY CLUSTERED 
(
	[C_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cas_Testing_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cas_Testing_Tbl](
	[test_id] [int] IDENTITY(1,1) NOT NULL,
	[cas_id] [int] NULL,
	[torque_] [nvarchar](25) NULL,
	[ir_] [nvarchar](25) NULL,
	[pressure_] [nvarchar](25) NULL,
	[sec_injection_] [nvarchar](25) NULL,
	[con_resistance_] [nvarchar](25) NULL,
	[functional_] [nvarchar](25) NULL,
	[completed_] [decimal](18, 2) NULL,
	[ttl_circuits] [int] NULL,
	[ttl_cold_tested] [int] NULL,
	[cold_complete] [nvarchar](25) NULL,
	[ttl_live_tested] [int] NULL,
	[live_complete] [nvarchar](25) NULL,
	[pre_com_test] [nvarchar](25) NULL,
	[c_f_test] [nvarchar](25) NULL,
	[load_test] [nvarchar](25) NULL,
	[full_run_test] [nvarchar](25) NULL,
	[wir_test] [nvarchar](25) NULL,
	[ratio_test] [nvarchar](25) NULL,
	[wr_test] [nvarchar](25) NULL,
	[vg_test] [nvarchar](25) NULL,
	[lv_ir_test_gen] [nvarchar](25) NULL,
	[hv_test] [nvarchar](25) NULL,
	[comm_test] [nvarchar](25) NULL,
	[obt_vol] [nvarchar](25) NULL,
	[obt_duty] [nvarchar](25) NULL,
	[wit_duty] [nvarchar](25) NULL,
	[wit_date] [nvarchar](25) NULL,
	[con_acce1] [nvarchar](25) NULL,
	[filed1] [bit] NULL,
	[cml_signoff] [bit] NULL,
	[con_acce2] [nvarchar](25) NULL,
	[filed2] [nvarchar](25) NULL,
	[cml_signoff2] [nvarchar](25) NULL,
 CONSTRAINT [PK_Cas_Testing_Tbl] PRIMARY KEY CLUSTERED 
(
	[test_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cas_Test_Names]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cas_Test_Names](
	[test_name] [nvarchar](100) NULL,
	[sch_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cas_main_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cas_main_tbl](
	[cas_id] [int] IDENTITY(1,1) NOT NULL,
	[itm_no] [int] NOT NULL,
	[sys_id] [int] NULL,
	[reff_] [nvarchar](255) NULL,
	[desc_] [nvarchar](255) NULL,
	[loca_] [nvarchar](255) NULL,
	[p_power_to] [nvarchar](255) NULL,
	[fed_from] [nvarchar](255) NULL,
	[power_on] [nvarchar](25) NULL,
	[comm_] [nvarchar](255) NULL,
	[act_by] [nvarchar](255) NULL,
	[act_date] [nvarchar](25) NULL,
	[uid] [nvarchar](50) NULL,
	[date_] [smalldatetime] NULL,
	[srv_id] [int] NULL,
	[sch_id] [int] NULL,
	[prj_code] [nvarchar](6) NULL,
	[con_acce] [nvarchar](25) NULL,
	[filed] [bit] NULL,
	[des_vol] [nvarchar](50) NULL,
	[des_flow_rate] [nvarchar](50) NULL,
	[devices] [int] NULL,
	[sys_monitored] [nvarchar](50) NULL,
	[fa_interfaces] [int] NULL,
 CONSTRAINT [PK_cas_main_tbl] PRIMARY KEY CLUSTERED 
(
	[cas_id] ASC,
	[itm_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cas_ele_pnl_eqi_test_tbl]    Script Date: 06/28/2011 12:32:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cas_ele_pnl_eqi_test_tbl](
	[test_id] [int] IDENTITY(1,1) NOT NULL,
	[cas_id] [int] NULL,
	[torque_] [smalldatetime] NULL,
	[ir_] [smalldatetime] NULL,
	[pressure_] [smalldatetime] NULL,
	[sec_injection_] [smalldatetime] NULL,
	[con_resistance_] [smalldatetime] NULL,
	[functional_] [smalldatetime] NULL,
	[completed_] [decimal](18, 2) NULL,
 CONSTRAINT [PK_cas_ele_pnl_eqi_test_tbl] PRIMARY KEY CLUSTERED 
(
	[test_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cas_ele_out_cir_test_tbl]    Script Date: 06/28/2011 12:32:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cas_ele_out_cir_test_tbl](
	[test_id] [int] IDENTITY(1,1) NOT NULL,
	[cas_id] [int] NULL,
	[ttl_circuits] [int] NULL,
	[ttl_cold_tested] [int] NULL,
	[cold_complete] [smalldatetime] NULL,
	[ttl_live_tested] [int] NULL,
	[live_complete] [smalldatetime] NULL,
 CONSTRAINT [PK_cas_ele_out_cir_test_tbl] PRIMARY KEY CLUSTERED 
(
	[test_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cas_asset_code_tbl]    Script Date: 06/28/2011 12:32:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cas_asset_code_tbl](
	[asc_id] [int] IDENTITY(1,1) NOT NULL,
	[cas_id] [int] NULL,
	[cate_] [nvarchar](255) NULL,
	[b_zone] [nvarchar](255) NULL,
	[f_level] [nvarchar](50) NULL,
	[seq_no] [nvarchar](50) NULL,
 CONSTRAINT [PK_cas_asset_code_tbl] PRIMARY KEY CLUSTERED 
(
	[asc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contractor_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contractor_tbl](
	[con_code] [int] IDENTITY(1,1) NOT NULL,
	[con_name] [varchar](50) NULL,
	[prj_code] [varchar](6) NULL,
 CONSTRAINT [PK_Contractor_tbl] PRIMARY KEY CLUSTERED 
(
	[con_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CommentBasket]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CommentBasket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](1000) NULL,
	[Page] [varchar](5) NULL,
	[Sec] [varchar](5) NULL,
	[uid] [nvarchar](50) NULL,
	[prj_code] [nvarchar](6) NULL,
	[module] [nvarchar](3) NULL,
	[type] [int] NULL,
	[doc_id] [int] NULL,
 CONSTRAINT [PK_CommentBasket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[comment_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comment_tbl](
	[comm_id] [int] IDENTITY(1,1) NOT NULL,
	[sec_no] [varchar](10) NULL,
	[page_no] [varchar](10) NULL,
	[comment] [varchar](200) NULL,
	[com_date] [smalldatetime] NULL,
	[userid] [varchar](50) NULL,
	[doc_id] [int] NULL,
	[status] [varchar](10) NULL,
	[resp] [nvarchar](2000) NULL,
	[cml_res] [bit] NULL,
 CONSTRAINT [PK_comment_tbl] PRIMARY KEY CLUSTERED 
(
	[comm_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cms_srv_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_srv_tbl](
	[srv_id] [int] IDENTITY(1,1) NOT NULL,
	[srv_desc] [nvarchar](255) NULL,
	[prj_code] [nvarchar](6) NULL,
 CONSTRAINT [PK_cms_srv_tbl] PRIMARY KEY CLUSTERED 
(
	[srv_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_Document_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_Document_Tbl](
	[doc_id] [int] IDENTITY(1,1) NOT NULL,
	[doc_name] [nvarchar](255) NULL,
	[file_name] [nvarchar](255) NULL,
	[module_name] [nvarchar](255) NULL,
	[upload_date] [smalldatetime] NULL,
	[uid] [nvarchar](50) NULL,
	[project_code] [nvarchar](6) NULL,
	[status] [bit] NULL,
	[folder_id] [int] NULL,
	[module_id] [int] NULL,
 CONSTRAINT [PK_CMS_Document_Tbl] PRIMARY KEY CLUSTERED 
(
	[doc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_cas_sys_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_cas_sys_tbl](
	[sys_id] [int] IDENTITY(1,1) NOT NULL,
	[sys_name] [nvarchar](255) NULL,
	[sch_id] [int] NULL,
	[cate_name] [nvarchar](50) NULL,
	[project] [nvarchar](6) NULL,
 CONSTRAINT [PK_cms_cas_sys_tbl] PRIMARY KEY CLUSTERED 
(
	[sys_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_cas_sch_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_cas_sch_tbl](
	[cas_sch_id] [int] IDENTITY(1,1) NOT NULL,
	[cas_sch_code] [nvarchar](255) NULL,
	[cas_sch_desc] [nvarchar](255) NULL,
	[srv_id] [int] NULL,
 CONSTRAINT [PK_cms_cas_sch_tbl] PRIMARY KEY CLUSTERED 
(
	[cas_sch_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cms_cas_cat_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cms_cas_cat_tbl](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_name] [nvarchar](255) NULL,
	[sys_id] [int] NULL,
 CONSTRAINT [PK_cms_cas_cat_tbl] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ele_Sum_Temp]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ele_Sum_Temp](
	[Euip] [nvarchar](100) NULL,
	[qty] [nvarchar](50) NULL,
	[per_com] [decimal](18, 2) NULL,
	[per_cold] [decimal](18, 2) NULL,
	[per_live] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoupMaster_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GoupMaster_Tbl](
	[Group_code] [varchar](6) NOT NULL,
	[Group_description] [varchar](50) NULL,
	[Doctype_id] [varchar](6) NULL,
	[possition] [tinyint] NULL,
 CONSTRAINT [PK_GoupMaster_Tbl] PRIMARY KEY CLUSTERED 
(
	[Group_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[projectmaster_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[projectmaster_tbl](
	[prj_code] [varchar](6) NOT NULL,
	[prj_name] [varchar](50) NULL,
	[company] [varchar](50) NULL,
	[date_created] [smalldatetime] NULL,
	[description] [varchar](1000) NULL,
	[status] [bit] NULL,
	[userid] [varchar](50) NULL,
	[dms] [bit] NULL,
	[cms] [bit] NULL,
	[tms] [bit] NULL,
 CONSTRAINT [PK_projectmaster_tbl] PRIMARY KEY CLUSTERED 
(
	[prj_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[servicemaster_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[servicemaster_tbl](
	[service_code] [varchar](6) NOT NULL,
	[service_description] [varchar](50) NULL,
	[possition] [tinyint] NULL,
 CONSTRAINT [PK_servicemaster_tbl] PRIMARY KEY CLUSTERED 
(
	[service_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScheduleMaster_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduleMaster_tbl](
	[Sch_id] [int] IDENTITY(1,1) NOT NULL,
	[service_code] [int] NULL,
	[package_code] [int] NULL,
	[doctype_code] [int] NULL,
	[doc_title] [varchar](50) NULL,
	[doc_name] [varchar](100) NULL,
	[date_tobeuploaded] [smalldatetime] NULL,
	[Folder_id] [int] NULL,
	[Project_code] [varchar](6) NULL,
 CONSTRAINT [PK_ScheduleMaster_tbl] PRIMARY KEY CLUSTERED 
(
	[Sch_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SO_Dir_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SO_Dir_Tbl](
	[so_id] [int] IDENTITY(1,1) NOT NULL,
	[so_no] [nvarchar](50) NULL,
	[so_date] [smalldatetime] NULL,
	[package] [nvarchar](50) NULL,
	[doc_name] [nvarchar](50) NULL,
	[issued_date] [smalldatetime] NULL,
	[issued_to] [nvarchar](50) NULL,
	[status] [bit] NULL,
	[remarks] [nvarchar](500) NULL,
	[project_code] [nvarchar](6) NULL,
	[uid] [nvarchar](50) NULL,
 CONSTRAINT [PK_SO_Dir_Tbl] PRIMARY KEY CLUSTERED 
(
	[so_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SO_Details_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SO_Details_Tbl](
	[so_itm_id] [int] IDENTITY(1,1) NOT NULL,
	[so_id] [int] NULL,
	[details] [nvarchar](2000) NULL,
	[response] [nvarchar](2000) NULL,
	[_date] [smalldatetime] NULL,
	[uid] [nvarchar](50) NULL,
 CONSTRAINT [PK_SO_Details] PRIMARY KEY CLUSTERED 
(
	[so_itm_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TreeFolder_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TreeFolder_Tbl](
	[Folder_id] [int] IDENTITY(1,1) NOT NULL,
	[Folder_code] [varchar](6) NOT NULL,
	[Folder_description] [varchar](100) NULL,
	[Folder_type] [int] NULL,
	[Folder_possition] [int] NULL,
	[Parent_folder] [int] NULL,
	[Project_code] [varchar](6) NULL,
	[Enabled] [bit] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_TreeFolder_Tbl_1] PRIMARY KEY CLUSTERED 
(
	[Folder_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-service,2-package,3-doctype,4-group,5-subgroup,6-lastlevel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TreeFolder_Tbl', @level2type=N'COLUMN',@level2name=N'Folder_type'
GO
/****** Object:  Table [dbo].[TreeFolder_CMS]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreeFolder_CMS](
	[folder_id] [int] IDENTITY(1,1) NOT NULL,
	[folder_description] [nvarchar](100) NULL,
	[folder_type] [int] NULL,
	[folder_possition] [int] NULL,
	[parent_folder] [int] NULL,
	[project_code] [nvarchar](6) NULL,
	[enabled] [bit] NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_TreeFolder_CMS] PRIMARY KEY CLUSTERED 
(
	[folder_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_Rpt_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_Rpt_Tbl](
	[package] [nvarchar](255) NULL,
	[manual] [nvarchar](50) NULL,
	[uploaded_date] [smalldatetime] NULL,
	[status] [nvarchar](50) NULL,
	[document_type] [nvarchar](255) NULL,
	[scheduled] [int] NULL,
	[uploaded] [int] NULL,
	[percentage] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usermaster_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usermaster_tbl](
	[userid] [varchar](50) NOT NULL,
	[password] [varchar](15) NULL,
	[username] [varchar](50) NULL,
	[user_group] [nvarchar](15) NULL,
	[CMS] [bit] NULL,
	[DMS] [bit] NULL,
	[TMS] [bit] NULL,
	[CP] [bit] NULL,
	[CU] [bit] NULL,
	[PM] [bit] NULL,
 CONSTRAINT [PK_usermaster_tbl] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Service_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Service_Tbl](
	[Service_id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [varchar](50) NULL,
	[service] [int] NULL,
	[project_code] [varchar](6) NULL,
 CONSTRAINT [PK_User_Service_Tbl] PRIMARY KEY CLUSTERED 
(
	[Service_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Prj_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Prj_Tbl](
	[userid] [varchar](50) NULL,
	[prj_code] [varchar](6) NULL,
	[access_level] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Permission_Tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Permission_Tbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [nvarchar](50) NULL,
	[access] [nvarchar](50) NULL,
	[permission] [nvarchar](150) NULL,
	[project] [nvarchar](6) NULL,
	[module] [nvarchar](50) NULL,
 CONSTRAINT [PK_User_Permission_Tbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacture_tbl]    Script Date: 06/28/2011 12:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manufacture_tbl](
	[Manufacture_code] [int] IDENTITY(1,1) NOT NULL,
	[Manufacture_Name] [varchar](50) NULL,
	[Project_code] [varchar](6) NULL,
 CONSTRAINT [PK_Manufacture_tbl] PRIMARY KEY CLUSTERED 
(
	[Manufacture_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Delete_Document]    Script Date: 06/28/2011 12:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_Document]
	
	(
	@doc_id int
	)
	
AS
	Delete from documentmaster_tbl where doc_id=@doc_id
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[create_package]    Script Date: 06/28/2011 12:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_package]
 (@package nvarchar(50)
 ,@category nvarchar(10)
 ,@sch_id int
 ,@project nvarchar(6))
AS
BEGIN
	insert into cms_cas_sys_tbl(sys_name,sch_id,cate_name,project)values(@package,@sch_id,@category,@project)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Manage_document]    Script Date: 06/28/2011 12:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Manage_document]
	
	(
	@doc_id int,
	@folder_id int,
	@possition int,
	@move varchar(5)
	)
	
AS
	declare @count int
	select @count=count(*) from documentmaster_tbl where folder_id=@folder_id
	if @move='up'
	begin
	if @possition>1
	begin
	update documentmaster_tbl set possition=@possition where folder_id=@folder_id and possition=@possition-1
	update documentmaster_tbl set possition=@possition-1 where doc_id=@doc_id	
	end
	end
	else if @move='down'
	begin
	if @possition<@count
	begin
	update documentmaster_tbl set possition=@possition where folder_id=@folder_id and possition=@possition+1
	update documentmaster_tbl set possition=@possition+1 where doc_id=@doc_id	
	end
	end
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[USER_LOG]    Script Date: 06/28/2011 12:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USER_LOG]
	(@_uid nvarchar(50)
	,@_ipaddress nvarchar(50)
	,@_location nvarchar(50)
	,@_login nvarchar(50)
	)
	
AS
BEGIN
delete from LOG_TBL where [_uid]=@_uid
	Insert into LOG_TBL
	([_uid]
	,[_ipaddress]
	,[_location]
	,[_login]
	,[_logout]
	,[status])
	values
	(@_uid
	,@_ipaddress
	,@_location
	,@_login
	,0
	,1)
	
END
GO
/****** Object:  StoredProcedure [dbo].[updatecomment]    Script Date: 06/28/2011 12:32:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updatecomment]
	
	(
	@comm_id int,
	@status varchar(10)
	)
	
AS
	update comment_tbl set status=@status where comm_id=@comm_id
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[StoredProcedure2]    Script Date: 06/28/2011 12:32:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoredProcedure2]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select service_code,service_description from servicemaster_tbl
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[StoredProcedure1]    Script Date: 06/28/2011 12:32:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoredProcedure1]
	
	(
	@sec_no varchar(10),
	@page_no varchar(10),
	@comment varchar(200),
	@com_date smalldatetime,
	@user_id varchar(50)
	)
	
AS
	insert into comment_tbl(sec_no,page_no,comment,com_date,userid)values(@sec_no,@page_no,@comment,@com_date,@user_id)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[SetReminder]    Script Date: 06/28/2011 12:32:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetReminder]
	(
	@Folder_id int,
	@Remind int
	
	)
AS
update Doc_Time_Tbl set [Remind]=@Remind where [Folder_id]=@Folder_id
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[SetDocStatus]    Script Date: 06/28/2011 12:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetDocStatus]
	(
	@doc_id int,
	@status varchar(25)
	)
AS
if @status<>'ACCEPTED'
begin
update documentmaster_tbl set Enabled=1,Status=@status where doc_id=@doc_id
end
else if @status='ACCEPTED'
begin
update documentmaster_tbl set Enabled=1,Status=@status where doc_id=@doc_id
/*delete from Doc_Time_Tbl where [Folder_id]=(select [folder_id] from documentmaster_tbl where [doc_id]=@doc_id)*/
end
RETURN
GO
/****** Object:  StoredProcedure [dbo].[SetDocDuration]    Script Date: 06/28/2011 12:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetDocDuration]
	(
	@Folder_id int,
	@Duration int,
	@First int,
	@Second int,
	@Third int,
	@prj_code varchar(6)
	)
AS
--declare @doc_id int
--select @doc_id=max(doc_id) from documentmaster_tbl
insert into Doc_Time_Tbl(Folder_id,Duration,First_Rem,Second_Rem,Third_Rem,Prj_code,Remind)values(@Folder_id,@Duration,@First,@Second,@Third,@prj_code,0)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[SetAutoComplete]    Script Date: 06/28/2011 12:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetAutoComplete]
	(
	@uid varchar(50),
	@autocomplete bit
	)
AS
update usermaster_tbl set autocomplete=@autocomplete where userid=@uid
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Set_UserService]    Script Date: 06/28/2011 12:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Set_UserService]
	
	(
	@userid varchar(50),
	@project_code varchar(6),
	@service int
	)
	
AS
insert into User_Service_Tbl(userid,service,project_code)values(@userid,@service,@project_code)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[set_user_permission]    Script Date: 06/28/2011 12:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[set_user_permission]
	(@uid nvarchar(50)
	,@access nvarchar(50)
	,@permission nvarchar(150)
	,@project nvarchar(6))
	
AS
BEGIN
	delete from User_Permission_Tbl where [uid]=@uid
	insert into User_Permission_Tbl
	([uid],[access],[permission],[project],[module])values
	(@uid,@access,@permission,@project,'CMS')
	
END
GO
/****** Object:  StoredProcedure [dbo].[ReportOMManual]    Script Date: 06/28/2011 12:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportOMManual]
	
	(
	/*@package int,*/
	@Project_code varchar(6)
	)
	
AS
	/*select a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id)comments,a.status,(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID =( SELECT PARENT_FOLDER FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.FOLDER_ID))PACKAGE  from documentmaster_tbl a where a.doctype_code='3' and a.Enabled=1 order by a.version desc*/
	
	/*select a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id)comments,a.status,(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID =( SELECT PARENT_FOLDER FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.FOLDER_ID))PACKAGE  from documentmaster_tbl a where a.manual=1 and a.Enabled=1 order by package */

/*select a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id)comments,a.status,(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID =a.package_code)PACKAGE  from documentmaster_tbl a where a.manual=1 and a.Enabled=1 and a.package_code=@package*/	
select a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id )comments,(select count(comm_id) from comment_tbl where doc_id=a.doc_id and cml_res=0 )comments_out,a.status,b.Folder_description from documentmaster_tbl a, Treefolder_Tbl b where a.manual=1 and a.Enabled=1 and b.Folder_id=a.package_code and b.Project_code=@Project_code order by b.Folder_description
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[remove_comment_basket]    Script Date: 06/28/2011 12:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[remove_comment_basket] 
	(@id int)
AS
BEGIN
	delete from CommentBasket where [ID]=@id
END
GO
/****** Object:  StoredProcedure [dbo].[Package_Auto]    Script Date: 06/28/2011 12:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Package_Auto]
	(
	@project_code varchar(6)
	
	)
AS
/*Declare @count int
Declare @idx int
Declare @Doctype varchar(50)
declare @Folder_code varchar(6)
declare @Folder_possition int
declare @parent int
select @parent=max(Folder_id) from TreeFolder_Tbl
Declare _AutoCur cursor for select Distinct Folder_description from TreeFolder_Tbl where Folder_Type=3 and Project_code=@project_code
Select @count=count(Distinct Folder_id) from TreeFolder_Tbl where Folder_Type=3 and Project_code=@project_code
select @idx=1

Open _AutoCur
Fetch Next from _AutoCur into @Doctype
While @@Fetch_status=0
Begin
select @Folder_code=isnull(Max(Folder_code),0)+ 1 from TreeFolder_Tbl where Parent_folder=@parent
select @Folder_possition=isnull(Max(Folder_possition),0) + 1 from TreeFolder_Tbl where Parent_folder=@parent
Insert into TreeFolder_Tbl (Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code,Enabled) values(@Folder_code,@Doctype,3,@Folder_possition ,@parent,@Project_code ,1 )

Fetch Next from _AutoCur into @Doctype

End
Close _AutoCur
deallocate _AutoCur*/


Declare @count int
Declare @idx int
Declare @Doctype varchar(50)
Declare @possition int
declare @Folder_code varchar(6)
declare @Folder_possition int
declare @parent int
select @parent=max(Folder_id) from TreeFolder_Tbl
Declare _AutoCur cursor for select Distinct doctype_description,possition from documenttypemaster_tbl 

Open _AutoCur
Fetch Next from _AutoCur into @Doctype,@possition
While @@Fetch_status=0
Begin
select @Folder_code=@possition 
select @Folder_possition=@possition
Insert into TreeFolder_Tbl (Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code,[Enabled],[Type]) values(@Folder_code,@Doctype,3,@Folder_possition ,@parent,@Project_code ,1,@possition )

Fetch Next from _AutoCur into @Doctype,@possition

End
Close _AutoCur
deallocate _AutoCur

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[OandM_Manual_Summary_Report]    Script Date: 06/28/2011 12:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OandM_Manual_Summary_Report]
(@package int)
	
AS

	
	SELECT A.DOC_NAME,A.DOC_TITLE,A.UPLOADED_DATE,(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.FOLDER_ID AND FOLDER_TYPE=3 )FOLDER,
	(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID =( SELECT PARENT_FOLDER FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.FOLDER_ID))PACKAGE,A.STATUS,A.VERSION FROM DOCUMENTMASTER_TBL A WHERE A.ENABLED=1 	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Move_TreeFolder]    Script Date: 06/28/2011 12:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Move_TreeFolder]
	
	(
	@Folder_id int,
	@Folder_possition int
	)
	
AS
declare @c_possition int
declare @Parent_code varchar(6)
declare @Folder_type int
select @c_possition=Folder_possition,@Parent_code=Parent_folder,@Folder_type=Folder_type from  TreeFolder_Tbl where Folder_id=@Folder_id
--select @Parent_code=Folder_code from TreeFolder_Tbl where  Folder_id=@Parent_id
if @c_possition > @Folder_possition
begin
update TreeFolder_Tbl set Folder_possition=Folder_possition+1 where Folder_possition>=@Folder_possition and Folder_possition<=@c_possition and Parent_folder=@Parent_code and Folder_type=@Folder_type
end
else if @c_possition < @Folder_possition
begin 
update TreeFolder_Tbl set Folder_possition=Folder_possition-1 where Folder_possition<=@Folder_possition and Folder_possition>=@c_possition and Parent_folder=@Parent_code and Folder_type=@Folder_type
end
update TreeFolder_Tbl set Folder_possition=@Folder_possition where Folder_id=@Folder_id

RETURN
GO
/****** Object:  StoredProcedure [dbo].[getUserGroup]    Script Date: 06/28/2011 12:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getUserGroup]
	(
	@uid varchar(50),
	@pwd varchar(15),
	@usergroup varchar(15) output
	)
AS
	select @usergroup=[user_group]  from usermaster_tbl where userid=@uid and password=@pwd
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[getpassword]    Script Date: 06/28/2011 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getpassword]
	(
	@uid varchar(50),
	@pwd varchar(15) output
	)
AS
	select @pwd=password  from usermaster_tbl where userid=@uid 
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetAutoPassword]    Script Date: 06/28/2011 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAutoPassword]
	
	(
	@uid varchar(50),
	@pwd varchar(15) output		
	)
	
AS
	select @pwd=[password]  from usermaster_tbl where userid=@uid /*and autocomplete=1*/
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[get_module_access]    Script Date: 06/28/2011 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_module_access] 
	(@uid nvarchar(50)
	,@module int
	,@access bit output)
AS
BEGIN
	if @module=1
	begin
	select @access=[DMS] from usermaster_tbl where [userid]=@uid
	end
	else if @module=2
	begin
	select @access=[CMS] from usermaster_tbl where [userid]=@uid
	end if @module=3
	begin
	select @access=[TMS] from usermaster_tbl where [userid]=@uid
	end 
END
GO
/****** Object:  StoredProcedure [dbo].[Get_DocId]    Script Date: 06/28/2011 12:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_DocId]
	-- Add the parameters for the stored procedure here
	(@Folder_id int,@doc_id int output)
AS
select @doc_id=[doc_id] from documentmaster_tbl where [folder_id]=@Folder_id and [manual]=1 and [Enabled]=1
GO
/****** Object:  StoredProcedure [dbo].[FileUploading]    Script Date: 06/28/2011 12:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FileUploading]
	
	(
	@service int,
	@package int,
	@doctype int,
	@doc_title varchar(50),
	@doc_name varchar(100),
	@uploaded bit,
	@uploaded_date smalldatetime,
	@file_size varchar(15),
	@schid int,
	@folder_id int,
	@type varchar(50),
	@uid varchar(50)
	)
	
AS
	/*declare @service_code varchar(6)
	declare @package_code varchar(6)
	declare @doctype_code varchar(6)
	--select @service_code=service_code from servicemaster_tbl where service_description=@service_name
		

	select @package_code=package_code from packagemaster_tbl where package_description=@package_name
	select @doctype_code=doctype_code from documenttypemaster_tbl where doctype_description=@doctype_name
	select @service_code=SUBSTRING(@package_code,1,1)
	insert into documentmaster_tbl(service_code,package_code,doctype_code,doc_title,doc_name,uploaded,uploaded_date,file_size)values(@service_code,@package_code,@doctype_code,@doc_title,@doc_name,@uploaded,@uploaded_date,@file_size)*/
	declare @possition int
	declare @version int
	declare @status varchar(15)
	declare @manual bit
	select @status='REVIEW'
select @version=1
select @manual=0
	select @possition=isnull(max(possition),0)+1 from documentmaster_tbl where folder_id=@folder_id
	if @type='O & M Manual'
	Begin
	select @manual=1
	update documentmaster_tbl set Enabled=0 where folder_id=@folder_id
	select @version=isnull(max(version),0) + 1 from documentmaster_tbl where folder_id=@folder_id
	if @version > 1
	begin
	select @status='REVISED'
	end
	End
	select @service=service_code,@package=package_code,@doctype=doctype_code from schedulemaster_tbl where Sch_id=@schid
	insert into documentmaster_tbl(service_code,package_code,doctype_code,doc_title,doc_name,uploaded,uploaded_date,file_size,folder_id,possition,Enabled,Version,Status,manual,uid)values(@service,@package,@doctype,@doc_title,@doc_name,@uploaded,@uploaded_date,@file_size,@folder_id,@possition,1,@Version,@status,@manual,@uid)
	
	delete from ScheduleMaster_tbl where Sch_id=@schid
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Ele_Cas_test_Summary]    Script Date: 06/28/2011 12:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Ele_Cas_test_Summary] 
	(@Prj_code varchar(6),
	@sch_id int,
	@sys_id int)
AS
truncate table Ele_Sum_Temp
Declare @id int
Declare @sysname nvarchar(50)
Declare _AutoCur cursor for select [test_name]  from Cas_Test_Names where [sch_id]=@sch_id  
Open _AutoCur
Fetch Next from _AutoCur into @sysname
While @@Fetch_status=0
Begin
	declare @qty decimal
	select @qty=0
	declare @tested decimal
	select @tested=0
	declare @per_tested decimal(18,2)

	Declare _AutoCur1 cursor for select [Sys_id] from cms_cas_sys_tbl where [sch_id]=@sch_id  
	Open _AutoCur1
	Fetch Next from _AutoCur1 into @id
	While @@Fetch_status=0
	Begin
	if @sch_id=12
	begin
		select @qty=@qty + COUNT([C_id]) from Cassheet_master_tbl where [Sys_id]=@id and [P_code]=@Prj_code
		if @sysname='Room / System Integrity Test'
		begin
		select @tested=@tested + count(test1) from Cassheet_testing_tbl where [sys_id]=@id and [test1]<>''
		end
		else if @sysname='Stand Alone Commission'
		begin
		select @tested=@tested + count(test2) from Cassheet_testing_tbl where [sys_id]=@id and [test2]<>''
		end
		else if @sysname='FA Interface Test'
		begin
		select @tested=@tested + count(test3) from Cassheet_testing_tbl where [sys_id]=@id and [test3]<>''
		end
		else if @sysname='Witnessed'
		begin
		select @tested=@tested + count(test4) from Cassheet_testing_tbl where [sys_id]=@id and [test4]<>''
		end
	End
	else if @sch_id=14
	begin
		select @qty=@qty + [devices1]  from Cassheet_testing_tbl where [Sys_id]=@id and [project]=@Prj_code
		if @sysname='Cable IR Test'
		begin
		select @tested=@tested + test2 from Cassheet_testing_tbl where [sys_id]=@id and [test2]<>''
		end
		else if @sysname='Point to Point Test'
		begin
		select @tested=@tested + test3 from Cassheet_testing_tbl where [sys_id]=@id and [test3]<>''
		end
		else if @sysname='Seq.of Op Test'
		begin
		select @tested=@tested + test4 from Cassheet_testing_tbl where [sys_id]=@id and [test4]<>''
		end
		else if @sysname='Graphics Test'
		begin
		select @tested=@tested + test5 from Cassheet_testing_tbl where [sys_id]=@id and [test5]<>''
		end
	End
Fetch Next from _AutoCur1 into @id
End
Close _AutoCur1
deallocate _AutoCur1
if @qty>0
begin
select @per_tested=(@tested/@qty )*100
insert into Ele_Sum_Temp(Euip,qty,per_com,per_cold,per_live,total)values(@sysname,@qty,@tested,0,0,@per_tested)
end

Fetch Next from _AutoCur into @sysname
End
Close _AutoCur
deallocate _AutoCur
select * from Ele_Sum_Temp
GO
/****** Object:  StoredProcedure [dbo].[Ele_Cas_Summary]    Script Date: 06/28/2011 12:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Ele_Cas_Summary] 
	(@Prj_code varchar(6),
	@sch_id int,
	@sys_id int)
AS
truncate table Ele_Sum_Temp
Declare @id int
Declare @sysname nvarchar(50)
Declare _AutoCur cursor for select [Sys_id],[Sys_name]  from cms_cas_sys_tbl where [sch_id]=@sch_id order by [Sys_name]  
Open _AutoCur
Fetch Next from _AutoCur into @id,@sysname
While @@Fetch_status=0
Begin
declare @cas_id int
Declare @qty varchar(50)
Declare @per_total decimal(18,2)
Declare @per_com decimal(18,2)
Declare @per_cold decimal(18,2)
Declare @per_live decimal(18,2)

select @qty=COUNT([C_id]) from Cassheet_master_tbl where [Sys_id]=@id and [P_code]=@Prj_code
if @qty>0
begin
if @sch_id=10
begin
select @per_com=SUM(isnull(per_com1,0))/@qty from Cassheet_testing_tbl where [sys_id]=@id
select @per_live=SUM(isnull(per_com2,0))/@qty,@per_cold=SUM(isnull(per_com3,0))/@qty from Cassheet_testing_tbl where [sys_id]=@id
select @per_total=(@per_com + @per_live + @per_cold)/3 
insert into Ele_Sum_Temp(Euip,qty,per_com,per_cold,per_live,total)values(@sysname,@qty,@per_com,@per_cold,@per_live,@per_total)
end
else if @sch_id=11
begin
declare @_precomm decimal(18,2)
declare @_comm decimal(18,2)
declare @_wit decimal(18,2)
select @_precomm=count(test1) from cassheet_testing_tbl where [sys_id]=@id and test1 <>''
select @_comm=count(test2) from cassheet_testing_tbl where [sys_id]=@id and test2 <>''
select @_wit=count(test3) from cassheet_testing_tbl where [sys_id]=@id and test3 <>''
select @per_total=(@_precomm + @_comm + @_wit)/3 *100

insert into Ele_Sum_Temp(Euip,qty,per_com,per_cold,per_live,total)values(@sysname,@qty,@_precomm,@_comm,@_wit,@per_total)

end
end
Fetch Next from _AutoCur into @id,@sysname

End
Close _AutoCur
deallocate _AutoCur
select * from Ele_Sum_Temp
GO
/****** Object:  StoredProcedure [dbo].[EditUserAccess]    Script Date: 06/28/2011 12:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUserAccess]
	(
	@uid varchar(50),
	@prj_code varchar(6),
	@access_level varchar(20)
	)
AS
update User_Prj_Tbl set access_level=@access_level where userid=@uid and prj_code=@prj_code
delete from User_Service_Tbl where userid=@uid and project_code=@prj_code
RETURN
GO
/****** Object:  StoredProcedure [dbo].[EditService]    Script Date: 06/28/2011 12:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditService]
	
	(
	@code varchar(6),
	@possition tinyint,	
	@description varchar(100),
	@service varchar(50),
	@mode int
	)
	
AS
declare @c_possition int
	if @mode=1
	begin
		--update servicemaster_tbl set service_code=@description
		select @c_possition=possition from servicemaster_tbl where service_code=@code
		if @c_possition > @possition
		begin
			update servicemaster_tbl set possition=possition+1 where possition>=@possition
		end
		else if @c_possition < @possition
		begin 
			update servicemaster_tbl set possition=possition-1 where possition<=@possition
		end
		update servicemaster_tbl set possition=@possition where service_code=@code
	end

	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[EditPackage]    Script Date: 06/28/2011 12:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditPackage]
	
	(
	@code varchar(6),
	@possition tinyint,	
	@description varchar(100),
	@service varchar(50),
	@mode int
	)
	
AS
declare @c_possition int
declare @service_code varchar(6)
select @service_code=service_code from servicemaster_tbl where service_description=@service
	if @mode=1
	begin
		select @c_possition=possition from packagemaster_tbl where package_code=@code
		if @c_possition > @possition
		begin
			update packagemaster_tbl set possition=possition+1 where possition<=@c_possition and service_code=@service_code
		end
		else if @c_possition < @possition
		begin 
			update packagemaster_tbl set possition=possition-1 where possition>=@c_possition and service_code=@service_code
		end
		update packagemaster_tbl set possition=@possition where package_code=@code
	end

	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Edit_TreeFolder]    Script Date: 06/28/2011 12:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Edit_TreeFolder]
	
	(
	@Folder_id int,
	@Folder_description varchar(100),
	@mode varchar(10)
	)
	
AS
	if @mode='rename'
	begin
	update TreeFolder_Tbl set Folder_description=@Folder_description where Folder_id=@Folder_id
	end
	else
	begin
	--delete from TreeFolder_Tbl where Parent_folder =( select Parent_folder from TreeFolder_Tbl where Folder_id=@Folder_id )
	delete from TreeFolder_Tbl where Folder_id=@Folder_id
	end
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Edit_asset_code]    Script Date: 06/28/2011 12:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Edit_asset_code]
(@cas_id int
,@cate_ nvarchar(255)
,@b_zone nvarchar(255)
,@f_level nvarchar(50)
,@seq_no nvarchar(50))
AS
BEGIN	
	Update cas_asset_code_tbl set
	[cate_]=@cate_
	,[b_zone]=@b_zone
	,[f_level]=@f_level
	,[seq_no]=@seq_no
	where [cas_id]=@cas_id
		
END
GO
/****** Object:  StoredProcedure [dbo].[ClearBasket]    Script Date: 06/28/2011 12:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ClearBasket]
	
	(
	@id int	
	)
	
AS
	delete CommentBasket where Id=@id
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[ChkUserLogin]    Script Date: 06/28/2011 12:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChkUserLogin]
	
	(
	@uid varchar(50),
	@pwd varchar(15),
	@validuser varchar(50) output
	)
	
AS
	select @validuser=userid  from usermaster_tbl where userid=@uid and password=@pwd
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[ChkUserLoggedIN]    Script Date: 06/28/2011 12:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChkUserLoggedIN]
	
	(
	@uid varchar(50),
	@ip nvarchar(50) output,
	@login nvarchar(50) output
	)
	
AS
	select @ip=[_ipaddress],@login=[_login]  from LOG_TBL where _uid=@uid and [status]=1
		RETURN
GO
/****** Object:  StoredProcedure [dbo].[CheckOMExist]    Script Date: 06/28/2011 12:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckOMExist]
	
	(
	@Folder_id int,
	@Project nvarchar(6) output
	)
	
AS
	select @Project=[Prj_code] from Doc_Time_Tbl where [Folder_id]=@Folder_id
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 06/28/2011 12:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangePassword]
	(
	
	@uid varchar(50),
	@pwd varchar(15)
	)
AS
update usermaster_tbl set password=@pwd where userid=@uid
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[cassheet_updation]    Script Date: 06/28/2011 12:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cassheet_updation] 
	(@cas_id int
	,@pwron nvarchar(25)
	,@conacce nvarchar(25)
	,@tsfiled nvarchar(25)
	,@comm nvarchar(500)
	,@actby nvarchar(50)
	,@actdate nvarchar(25)
	,@tested1 nvarchar(25)
	,@tested2 nvarchar(25)
	,@test1 nvarchar(25)
	,@test2 nvarchar(25)
	,@test3 nvarchar(25)
	,@test4 nvarchar(25)
	,@test5 nvarchar(25)
	,@test6 nvarchar(25)
	,@test7 nvarchar(25)
	,@test8 nvarchar(25)
	,@test9 nvarchar(25)
	,@test10 nvarchar(25)
	,@complete nvarchar(25)
	,@per_com1 decimal(18,2)
	,@per_com2 decimal(18,2)
	,@per_com3 decimal(18,2))
AS
BEGIN
	update Cassheet_master_tbl set
	[Pwr_on]=@pwron,
	[Con_Acce]=@conacce,
	[T_S_Filed]=@tsfiled,
	[Comm]=@comm,
	[Act_by]=@actby,
	[Act_Date]=@actdate
	where [C_id]=@cas_id

	update Cassheet_testing_tbl set
	[tested1]=@tested1,
	[tested2]=@tested2,
	[test1]=@test1,
	[test2]=@test2,
	[test3]=@test3,
	[test4]=@test4,
	[test5]=@test5,
	[test6]=@test6,
	[test7]=@test7,
	[test8]=@test8,
	[test9]=@test9,
	[test10]=@test10,
	[complete]=@complete,
	[per_com1]=@per_com1,
	[per_com2]=@per_com2,
	[per_com3]=@per_com3
	where [cas_id]=@cas_id
	
END
GO
/****** Object:  StoredProcedure [dbo].[addtocommentbasket]    Script Date: 06/28/2011 12:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addtocommentbasket]
	
	(
	@comment varchar(1000),
	@page varchar(5),
	@sec varchar(5),
	@uid nvarchar(50),
	@prj_code nvarchar(6),
	@module nvarchar(3),
	@type int,
	@doc_id int	
	)
	
AS
	insert into CommentBasket(comment,Page,Sec,[uid],[prj_code],[module],[type],[doc_id]) values(@comment,@page,@sec,@uid,@prj_code,@module,
@type,@doc_id)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[addcomment]    Script Date: 06/28/2011 12:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addcomment]
	
	(
	@sec_no varchar(10),
	@page_no varchar(10),
	@comment varchar(200),
	@com_date smalldatetime,
	@user_id varchar(50),
	@doc_id int
	)
	
AS
--declare @doc_id int
--select @doc_id=doc_id from documentmaster_tbl where doc_name=@doc_name
if @sec_no='&nbsp;'
begin
select @sec_no='';
end
if @page_no='&nbsp;'
begin
select @page_no='';
end

	insert into comment_tbl(sec_no,page_no,comment,com_date,userid,doc_id,cml_res)values(@sec_no,@page_no,@comment,@com_date,@user_id,@doc_id,0)
delete from CommentBasket where [doc_id]=@doc_id
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[add_so_photo]    Script Date: 06/28/2011 12:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_so_photo]
	(@photo nvarchar(100))
AS
BEGIN
declare @so_itm_id int
select @so_itm_id=MAX([so_itm_id]) from SO_Details_Tbl
	insert into So_Photo_Tbl
	([so_itm_id]
	,[photo])values
	(@so_itm_id
	,@photo)
END
GO
/****** Object:  StoredProcedure [dbo].[add_ele_pnl_eqi_test]    Script Date: 06/28/2011 12:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_ele_pnl_eqi_test]
(@cas_id int
,@torque_ smalldatetime
,@ir_ smalldatetime
,@pressure_ smalldatetime
,@sec_injection_ smalldatetime
,@con_resistance smalldatetime
,@functional_ smalldatetime
,@completed_ decimal(18,2))
AS
BEGIN
	update cas_ele_pnl_eqi_test_tbl set
	[torque_]=@torque_
	,[ir_]=@ir_
	,[pressure_]=@pressure_
	,[sec_injection_]=@sec_injection_
	,[con_resistance_]=@con_resistance
	,[functional_]=@functional_
	,[completed_]=@completed_
	where [cas_id]=@cas_id
		
END
GO
/****** Object:  StoredProcedure [dbo].[add_ele_out_cir_test]    Script Date: 06/28/2011 12:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_ele_out_cir_test]
(@cas_id int
,@ttl_cold_tested int
,@cold_complete smalldatetime
,@ttl_live_tested int
,@live_complete smalldatetime)
AS
BEGIN
	Update cas_ele_out_cir_test_tbl set
	[ttl_cold_tested]=@ttl_cold_tested
	,[cold_complete]=@cold_complete
	,[ttl_live_tested]=@ttl_live_tested
	,[live_complete]=@live_complete
	where [cas_id]=@cas_id		
END
GO
/****** Object:  StoredProcedure [dbo].[Add_CMS_Document]    Script Date: 06/28/2011 12:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Add_CMS_Document] 
	(@doc_name nvarchar(255)
	,@file_name nvarchar(255)
	,@module_name nvarchar(255)
	,@upload_date smalldatetime
	,@uid nvarchar(50)
	,@project_code nvarchar(6)
	,@folder_id int
	,@module_id int)
AS
BEGIN
	Insert into CMS_Document_Tbl
	([doc_name]
	,[file_name]
	,[module_name]
	,[upload_date]
	,[uid]
	,[project_code]
	,[status]
	,[folder_id]
	,[module_id])values
	(@doc_name
	,@file_name
	,@module_name
	,@upload_date
	,@uid
	,@project_code
	,1
	,@folder_id
	,@module_id)
END
GO
/****** Object:  StoredProcedure [dbo].[Add_cms_comments]    Script Date: 06/28/2011 12:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Add_cms_comments]
	(@comment varchar(5000)
	,@doc_id int
	,@prj_code nvarchar(6)
	,@module_name nvarchar(50)
	,@uid nvarchar(50)
	,@comment_date smalldatetime)	 
AS
BEGIN
	insert into CMs_Comment_Tbl
	([comment]
	,[doc_id]
	,[prj_code]
	,[module_name]
	,[uid]
	,[comment_date])values
	(@comment
	,@doc_id
	,@prj_code
	,@module_name
	,@uid
	,@comment_date)
	delete from CommentBasket where [doc_id]=@doc_id

END
GO
/****** Object:  StoredProcedure [dbo].[add_asset_code]    Script Date: 06/28/2011 12:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[add_asset_code]
(@cate_ nvarchar(255)
,@b_zone nvarchar(255)
,@f_level nvarchar(50)
,@seq_no nvarchar(50))
AS
BEGIN
	
	declare @cas_id int
	select @cas_id=MAX([cas_id]) from cas_main_tbl
	insert into cas_asset_code_tbl
	([cas_id]
	,[cate_]
	,[b_zone]
	,[f_level]
	,[seq_no])values
	(@cas_id
	,@cate_
	,@b_zone
	,@f_level
	,@seq_no)
		
END
GO
/****** Object:  StoredProcedure [dbo].[ad_resp]    Script Date: 06/28/2011 12:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ad_resp]
(@comm_id int,@resp nvarchar(2000))
AS
BEGIN
	UPDATE comment_tbl SET [resp]=@resp,[cml_res]=1 WHERE [comm_id]=@comm_id
END
GO
/****** Object:  StoredProcedure [dbo].[log_off]    Script Date: 06/28/2011 12:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[log_off]
(@_uid nvarchar(50)
,@_logout nvarchar(50))
AS
BEGIN
	update LOG_TBL set [_logout]=@_logout,[status]=0 where [_uid]=@_uid
END
GO
/****** Object:  StoredProcedure [dbo].[LoadUsers]    Script Date: 06/28/2011 12:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadUsers]
	(
	@Project_code varchar(6)
	)
AS
select a.userid,a.username,b.access_level,a.[CMS],a.[DMS],a.[TMS] from usermaster_tbl a,User_Prj_Tbl b where a.userid=b.userid and b.prj_code=@Project_code 
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadUser_Services]    Script Date: 06/28/2011 12:32:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadUser_Services]
	(
	@Project_code varchar(6),
	@userid varchar(50)
	)
AS
select [service] from User_Service_Tbl where [userid]=@userid and [project_code]=@Project_code
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loadsubgroup1]    Script Date: 06/28/2011 12:32:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[loadsubgroup1]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	--select Group_code,Group_description,Doctype_id,possition from GoupMaster_tbl order by possition
	Select Folder_id,Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code
	from TreeFolder_tbl where Folder_type=6 and Enabled=1 order by Folder_possition
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loadsubgroup]    Script Date: 06/28/2011 12:32:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[loadsubgroup]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	--select Group_code,Group_description,Doctype_id,possition from GoupMaster_tbl order by possition
	Select Folder_id,Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code
	from TreeFolder_tbl where Folder_type=5 and Enabled=1 order by Folder_possition
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loadservice]    Script Date: 06/28/2011 12:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loadservice]
	
	(
	@Project_code varchar(6),
	@userid varchar(50)
	)
	
AS
	--select service_code,service_description,possition from servicemaster_tbl order by possition
	/*Select a.Folder_id,a.Folder_code,a.Folder_description,a.Folder_type,a.Folder_possition,a.Parent_folder,a.Project_code from TreeFolder_tbl a where a.Folder_type=1 and a.Enabled=1 and a.Project_code=@Project_code varchar(6) order by Folder_possition*/
if @userid = 'nothing'
begin
Select a.Folder_id,a.Folder_code,a.Folder_description,a.Folder_type,a.Folder_possition,a.Parent_folder,a.Project_code from TreeFolder_tbl a where a.Folder_type=1 and a.Enabled=1 and a.Project_code=@Project_code  order by Folder_possition
end
else
begin
Select a.Folder_id,a.Folder_code,a.Folder_description,a.Folder_type,a.Folder_possition,a.Parent_folder,a.Project_code from TreeFolder_tbl a where a.Folder_id in (select service from User_Service_Tbl where userid=@userid and project_code=@Project_code)  order by Folder_possition
end
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadSchedule]    Script Date: 06/28/2011 12:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadSchedule]
	
	(
	@Project_code varchar(6)
	)
AS
	select 
	a.Sch_id,
	a.package_code,
	a.doc_title,
	a.doc_name,
	a.date_tobeuploaded,
	a.Folder_id,
	(select Folder_description from TreeFolder_Tbl where Folder_id=a.Folder_id)Folder,
	a.service_code
	from ScheduleMaster_tbl a  where a.Project_code=@Project_code
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadProject]    Script Date: 06/28/2011 12:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadProject]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select [prj_code],[prj_name],[company],[description],
	(case when [dms]=0 then 'NO' else 'YES' end)dms,
	(case when [cms]=0 then 'NO' else 'YES' end)cms,
	(case when [tms]=0 then 'NO' else 'YES' end)tms
	from projectmaster_tbl order by [prj_name]
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loadpackage]    Script Date: 06/28/2011 12:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loadpackage]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	--select package_code,package_description,service_code,possition from packagemaster_tbl order by possition
	Select Folder_id,Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code
	from TreeFolder_tbl where Folder_type=2 and Enabled=1 order by Folder_possition

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadManufacture]    Script Date: 06/28/2011 12:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadManufacture]
	
	(
	@Project_code varchar(6)
	)
	
AS
	
	Select Manufacture_code,Manufacture_name from Manufacture_tbl where Project_code=@Project_code
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loadgroup]    Script Date: 06/28/2011 12:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loadgroup]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	--select Group_code,Group_description,Doctype_id,possition from GoupMaster_tbl order by possition
	Select Folder_id,Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code,[Type]
	from TreeFolder_tbl where Folder_type=4 and Enabled=1 order by Folder_possition
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loaddocumentsALL]    Script Date: 06/28/2011 12:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loaddocumentsALL]

AS

	select a.folder_id,a.Enabled,a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id)comments,a.status  from documentmaster_tbl a order by a.possition 

	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loaddocuments]    Script Date: 06/28/2011 12:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loaddocuments]
	
	(
	@folder_id int,
	@Enabled bit
	)

AS
if @Enabled=1
begin
	select a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id)comments,a.status  from documentmaster_tbl a where a.folder_id=@folder_id and a.Enabled=@Enabled order by a.possition 
	end
else if @Enabled=0
Begin
select a.doc_id,a.doc_title,a.doc_name,a.uploaded,a.uploaded_date,a.file_size,a.possition,a.version,(select count(comm_id) from comment_tbl where doc_id=a.doc_id)comments,a.status  from documentmaster_tbl a where a.folder_id=@folder_id and a.Enabled=@Enabled order by a.version desc
End	
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadDocumentDetails]    Script Date: 06/28/2011 12:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadDocumentDetails]
	(
	@docname varchar(255)
	)
AS
	select a.doc_id,a.uploaded_date,(select Duration from Doc_Time_Tbl where Folder_id=a.folder_id)Duration,a.Status from documentmaster_tbl a where a.doc_name=@docname and Enabled=1
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loaddoctype]    Script Date: 06/28/2011 12:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loaddoctype]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	--select doctype_code,doctype_description,possition from documenttypemaster_tbl order by possition
	Select Folder_id,Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code,[Type]  from TreeFolder_tbl where Folder_type=3 and Enabled=1 order by Folder_possition

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadContractor]    Script Date: 06/28/2011 12:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadContractor]
	(
	@Project_code varchar(6)
	)
AS
select con_code,con_name from Contractor_tbl where prj_code=@Project_code
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[loadcomments]    Script Date: 06/28/2011 12:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loadcomments]

	(
	--@doc_name varchar(50)
	@doc_id int
	
	)

AS
	/*declare @doc_id int
select @doc_id=doc_id from documentmaster_tbl where doc_name=@doc_name
select comm_id,sec_no,page_no,comment,com_date,userid from comment_tbl where doc_id=@doc_id and status='Pending'*/
declare @folder_id int
select @folder_id=Folder_id from documentmaster_tbl where doc_id=@doc_id

/*select a.comm_id,a.sec_no,a.page_no,a.comment,a.com_date,a.userid,(select version from documentmaster_tbl where folder_id=@folder_id )version from comment_tbl a where a.doc_id in (select doc_id from documentmaster_tbl where folder_id=@folder_id ) order by com_date*/
select a.comm_id,a.sec_no,a.page_no,a.comment,a.com_date,a.userid,(select version from documentmaster_tbl where doc_id=a.doc_id)version,resp   from comment_tbl a where a.doc_id in (select doc_id from documentmaster_tbl where folder_id=@folder_id ) order by a.com_date desc
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Loadbasket]    Script Date: 06/28/2011 12:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Loadbasket]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select id,comment from CommentBasket
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadALLUsers]    Script Date: 06/28/2011 12:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[LoadALLUsers]
	
AS
select 
[userid],
[username],
[user_group],
[CMS],
[DMS],
[TMS],
[CP],
[CU],
[PM]
 from usermaster_tbl order by [userid]
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Load_User_Permission]    Script Date: 06/28/2011 12:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_User_Permission]
	(@uid nvarchar(50)
	,@project nvarchar(6))
AS
BEGIN
	select [access],[permission]  from User_Permission_Tbl where [uid]=@uid and [project]=@project
END
GO
/****** Object:  StoredProcedure [dbo].[Load_User_Log]    Script Date: 06/28/2011 12:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_User_Log]
	
AS
BEGIN
	select [_uid],[_ipaddress],[_location],[_login]  from LOG_TBL where [status]=1
END
GO
/****** Object:  StoredProcedure [dbo].[load_so_photo]    Script Date: 06/28/2011 12:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[load_so_photo]
	(@so_id int	)
AS
BEGIN
	select [photo] from So_Photo_Tbl where [so_itm_id]=@so_id
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[load_so_dir]    Script Date: 06/28/2011 12:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_so_dir] 
	(@Project_code nvarchar(6))
AS
BEGIN
	select a.[so_id],a.[so_no],a.[so_date],a.[package],a.[doc_name],a.[issued_date],a.[issued_to],a.[remarks],a.[status],
	(select count([so_itm_id]) from SO_Details_Tbl where [so_id]=a.[so_id])comment,
	(select count([so_itm_id]) from SO_Details_Tbl where [so_id]=a.[so_id] and [response]<>'' )response	
	 from SO_Dir_Tbl a where a.[project_code]=@Project_code
END
GO
/****** Object:  StoredProcedure [dbo].[load_so_details]    Script Date: 06/28/2011 12:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_so_details] 
	(@so_id int)
AS
BEGIN
	select [so_itm_id],[details],[response] from SO_Details_Tbl where [so_id]=@so_id
END
GO
/****** Object:  StoredProcedure [dbo].[load_projecthome]    Script Date: 06/28/2011 12:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[load_projecthome]
	(
	@uid varchar(50)
	)
AS
/*	select a.prj_code,a.prj_name,a.company,b.category from Projectmaster_tbl a,usermaster_tbl b where a.prj_code=b.project_code and b.userid=@uid*/
	select a.prj_code,a.prj_name,a.company,b.access_level,(select username from usermaster_tbl where userid=@uid )username,a.[dms],a.[cms],a.[tms],(select user_group from usermaster_tbl where userid=@uid )usergroup from Projectmaster_tbl a,User_Prj_Tbl b where b.Prj_code=a.prj_code and b.userid=@uid
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Load_OMManualDetailsRPT]    Script Date: 06/28/2011 12:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Load_OMManualDetailsRPT]
	(
	@DOC_ID int
	)
AS
	SELECT A.DOC_NAME,A.FILE_SIZE,A.PROJECT_CODE,A.VERSION,A.STATUS,(A.DOC_TITLE)CONTRACTOR,A.UPLOADED_DATE,
	(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.SERVICE_CODE)SERVICE,
	(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.PACKAGE_CODE)PACKAGE,
	(SELECT FOLDER_DESCRIPTION FROM TREEFOLDER_TBL WHERE FOLDER_ID=A.DOCTYPE_CODE)DOCTYPE,A.UID
	FROM DOCUMENTMASTER_TBL A WHERE A.DOC_ID=@DOC_ID order by PACKAGE 
	
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[load_EngReff]    Script Date: 06/28/2011 12:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_EngReff]
(@sch_id int
,@prj_code nvarchar(6))
AS
BEGIN
	select [reff_],[sys_id],[cas_id] from cas_main_tbl where [sch_id]=@sch_id and [prj_code]=@prj_code order by [reff_]
END
GO
/****** Object:  StoredProcedure [dbo].[Load_ele_out_cir_test]    Script Date: 06/28/2011 12:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_ele_out_cir_test]
	(@cas_id int)
AS
BEGIN
	select 
	[test_id],
	[ttl_cold_tested],
	[cold_complete],
	[ttl_live_tested],
	[live_complete]
	from cas_ele_out_cir_test_tbl where [cas_id]=@cas_id
END
GO
/****** Object:  StoredProcedure [dbo].[Load_doc_review_log]    Script Date: 06/28/2011 12:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_doc_review_log]

	(@project_code nvarchar(6))
	
AS
BEGIN
	select  
	a.[dr_no]
	,a.[dr_reviewed]
	,a.[issue_date]
	,a.[issued_to]
	,a.[dr_status]
	,a.[uid],a.[dr_id] 
	,(select isnull(COUNT([dr_itm_id]),0) from Document_Review_Details where [dr_id]=a.[dr_id])comments
	,(select isnull(COUNT([dr_itm_id]),0) from Document_Review_Details where [dr_id]=a.[dr_id] and [response]<>'')response	
	from Document_Review_Log a where [project_code]=@project_code
END
GO
/****** Object:  StoredProcedure [dbo].[Load_doc_review_details]    Script Date: 06/28/2011 12:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_doc_review_details]
	(@dr_id int	)
AS
BEGIN
	select  
	[dr_itm_id]
	,[details]
	,[response]
	,[_date]
	,[uid] from Document_Review_Details where [dr_id]=@dr_id
END
GO
/****** Object:  StoredProcedure [dbo].[Load_Doc_Dur]    Script Date: 06/28/2011 12:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_Doc_Dur]
	
AS
BEGIN
select 
a.[doc_id],
a.[package_code],
(select [Folder_description] from TreeFolder_Tbl where [folder_id]=a.[package_code] )package,
a.[doc_name],
a.[uploaded_date],
b.[Duration],
b.[First_Rem],
b.[Second_Rem],
b.[Third_Rem],
b.[Prj_code],
(select [prj_name] from projectmaster_tbl where [prj_code]=b.[Prj_code])project,
b.[Folder_id],
b.[Remind],
a.[service_code]
from documentmaster_tbl a,Doc_Time_Tbl b where a.[manual]=1 and a.[Enabled]=1 and b.[Folder_id]=a.[folder_id] and a.[Status]='REVIEW'
END
GO
/****** Object:  StoredProcedure [dbo].[load_comment_basket]    Script Date: 06/28/2011 12:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_comment_basket] 
	(@uid nvarchar(50)
	,@prj_code nvarchar(6)
	,@module nvarchar(3)
	,@type int,
	@doc_id int)
AS
BEGIN
	select [Comment],[Page],[Sec],[ID] from CommentBasket where [uid]=@uid and [prj_code]=@prj_code and [module]=@module and [type]=@type and [doc_id]=@doc_id
END
GO
/****** Object:  StoredProcedure [dbo].[Load_CMS_Users]    Script Date: 06/28/2011 12:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Load_CMS_Users]
	(
	@Project_code varchar(6)
	)
AS
select a.[userid],a.[user_group] from usermaster_tbl a,User_Prj_Tbl b where a.[CMS]=1 and a.[userid]=b.userid and b.prj_code=@Project_code 
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[load_cms_TreeFolder]    Script Date: 06/28/2011 12:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_cms_TreeFolder]
	(@folder_type int)
AS
BEGIN
	select 
	[folder_id],
	[folder_description],
	[parent_folder]	
	 from TreeFolder_CMS where [folder_type]=@folder_type
END
GO
/****** Object:  StoredProcedure [dbo].[load_cms_srv]    Script Date: 06/28/2011 12:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_cms_srv]
	(@project_code nvarchar(6))
AS
BEGIN
	select [srv_id],[srv_desc] from cms_srv_tbl where [prj_code]=@project_code
END
GO
/****** Object:  StoredProcedure [dbo].[Load_CMS_Document]    Script Date: 06/28/2011 12:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_CMS_Document] 
	(@Project_code nvarchar(6)
	,@folder_id int)
AS
BEGIN
	/*Select 
	[doc_id]
	,[doc_name]
	,[file_name]
	,[upload_date]
	,[uid] from CMS_Document_Tbl where [project_code]=@Project_code and [module_name]=@module*/
	select [doc_id],[doc_name],[file_name],[module_name],[upload_date],[uid]from CMS_Document_Tbl where [folder_id]=@folder_id and [project_code]=@Project_code
END
GO
/****** Object:  StoredProcedure [dbo].[Load_cms_comments]    Script Date: 06/28/2011 12:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_cms_comments]
	(@id int)
AS
BEGIN
	select [com_id],[comment],[cml_responds],[module_name],[uid],[comment_date],[resp_date] from CMS_Comment_Tbl where [doc_id]=@id
END
GO
/****** Object:  StoredProcedure [dbo].[load_cms_cas_sys]    Script Date: 06/28/2011 12:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_cms_cas_sys]
(@sch int)
	
AS
BEGIN
DECLARE @srv int
select @srv=srv_id from cms_cas_sch_tbl where cas_sch_id=@sch
	select [sys_id] ,[sys_name], [cate_name],[project] from cms_cas_sys_tbl  where [sch_id]=@sch
END
GO
/****** Object:  StoredProcedure [dbo].[load_cms_cas_sch]    Script Date: 06/28/2011 12:32:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_cms_cas_sch]
	
AS
BEGIN
	select [cas_sch_id],[cas_sch_code],[cas_sch_desc],[srv_id] from cms_cas_sch_tbl  
END
GO
/****** Object:  StoredProcedure [dbo].[load_casMain_Edit]    Script Date: 06/28/2011 12:32:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_casMain_Edit]
(@sch_id int
,@prj_code nvarchar(6)
,@sys_id int)
AS
BEGIN
	/*select 
	a.[cas_id],
	a.[itm_no],
	a.[reff_],
	a.[desc_],
	a.[loca_],
	a.[p_power_to],
	a.[fed_from],
	a.[power_on],
	a.[comm_],
	a.[act_by],
	a.[act_date],
	a.[uid],
	a.[date_],
	a.[srv_id],
	a.[sch_id],
	a.[prj_code],
	a.[con_acce],
	a.[filed],
	a.[des_vol],
	a.[des_flow_rate],
	a.[devices],
	a.[sys_monitored],
	a.[fa_interfaces],
	b.[cate_],
	b.[b_zone],
	b.[f_level],
	b.[seq_no],	
	a.[sys_id],
	(select [sys_name] from cms_cas_sys_tbl where [sys_id]=a.[sys_id])sys_name,
	c.[torque_],
	c.[ir_],
	c.[pressure_],
	c.[sec_injection_],
	c.[con_resistance_], 
	c.[functional_],
	c.[completed_],
	c.[ttl_cold_tested],
	c.[cold_complete],
	c.[ttl_live_tested],
	c.[live_complete],
	c.pre_com_test,
	c.c_f_test,
	c.load_test,
	c.full_run_test,
	c.wir_test,
	c.ratio_test,
	c.wr_test,
	c.vg_test,
	c.lv_ir_test_gen,
	c.hv_test	
	from cas_main_tbl a,cas_asset_code_tbl b,Cas_Testing_Tbl c where b.[cas_id]=a.[cas_id] and c.[cas_id]=a.[cas_id]  and a.[sch_id]=@sch_id and a.[prj_code]=@prj_code and a.[sys_id]=@sys_id order by a.reff_*/
	select
	a.[C_id],
	a.[Uid],
	a.[Sys_id],
	(select [sys_name] from cms_cas_sys_tbl where sys_id=a.[Sys_id])Sys_name,	
	a.[E_b_ref],
	a.[B_Z],
	a.[Cat],
	a.[F_Lvl],
	a.[Sq_No],
	a.[Des],
	a.[Loc],
	a.[P_P_to],
	a.[F_from],
	a.[Substation],
	a.[Pwr_on],
	a.[S_c_m],
	a.[Con_Acce],
	a.[T_S_Filed],
	a.[Comm],
	a.[Act_by],
	a.Act_Date,
	b.[devices1],
	b.[devices2],
	b.[devices3],
	b.[test1],
	b.[test2],
	b.[test3],
	b.[test4],
	b.[test5],
	b.[test6],
	b.[test7],
	b.[test8],
	b.[test9],
	b.[test10],
	b.[per_com1],
	b.[tested1],
	b.[tested2]
	from Cassheet_master_tbl a, Cassheet_testing_tbl b where a.[P_code]=@prj_code and a.[Cas_schedule]=@sch_id and b.[cas_id]=a.C_id
END
GO
/****** Object:  StoredProcedure [dbo].[load_casMain]    Script Date: 06/28/2011 12:32:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_casMain]
(@sch_id int
,@prj_code nvarchar(6))
AS
BEGIN
	select 
	a.[cas_id],
	a.[itm_no],
	a.[reff_],
	a.[desc_],
	a.[loca_],
	a.[p_power_to],
	a.[fed_from],
	a.[power_on],
	a.[comm_],
	a.[act_by],
	a.[act_date],
	a.[uid],
	a.[date_],
	a.[srv_id],
	a.[sch_id],
	a.[prj_code],
	a.[con_acce],
	a.[filed],
	a.[des_vol],
	a.[des_flow_rate],
	a.[devices],
	a.[sys_monitored],
	a.[fa_interfaces],
	b.[cate_],
	b.[b_zone],
	b.[f_level],
	b.[seq_no],
	a.[sys_id],
	(select [sys_name] from cms_cas_sys_tbl where [sys_id]=a.[sys_id])sys_name,
	c.[torque_],
	c.[ir_],
	c.[pressure_],
	c.[sec_injection_],
	c.[con_resistance_],
	c.[functional_],
	c.[completed_],
	c.[ttl_cold_tested],
	c.[cold_complete],
	c.[ttl_live_tested],
	c.[live_complete]		
	from cas_main_tbl a,cas_asset_code_tbl b,Cas_Testing_Tbl c where b.[cas_id]=a.[cas_id] and c.[cas_id]=a.[cas_id]  and a.[sch_id]=@sch_id and a.[prj_code]=@prj_code order by sys_name
END
GO
/****** Object:  StoredProcedure [dbo].[load_cas_service]    Script Date: 06/28/2011 12:32:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_cas_service]
 
AS
BEGIN
	select folder_id,folder_description from TreeFolder_CMS where parent_folder=1
	
END
GO
/****** Object:  StoredProcedure [dbo].[Load_cas_ele_pnl_eqi_test]    Script Date: 06/28/2011 12:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Load_cas_ele_pnl_eqi_test]
	(@cas_id int)
AS
BEGIN
	select 
	[test_id],
	[torque_],
	[pressure_],
	[ir_],
	[con_resistance_],
	[sec_injection_],
	[functional_],
	[completed_]
	from cas_ele_pnl_eqi_test_tbl where [cas_id]=@cas_id
END
GO
/****** Object:  StoredProcedure [dbo].[load_avl_sys]    Script Date: 06/28/2011 12:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[load_avl_sys]
	(@sch_id int
	,@prj_code nvarchar(6))
AS
BEGIN
	select distinct a.sys_id,(select sys_name from cms_cas_sys_tbl where sys_id=a.sys_id)sys_name from cas_main_tbl a where a.[sch_id]=@sch_id and a.[prj_code]=@prj_code
END
GO
/****** Object:  StoredProcedure [dbo].[Load_AvailablePackages]    Script Date: 06/28/2011 12:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Load_AvailablePackages]
	
	(
	@Project_code varchar(6)
	)
	
AS
	select distinct a.package_code,(select Folder_id from TreeFolder_Tbl where Folder_id=a.package_code)package_id,(select Folder_description from TreeFolder_Tbl where Folder_id=a.package_code)package_description from ScheduleMaster_Tbl a where a.Project_code=@Project_code
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Insert_UserPrj_Tbl]    Script Date: 06/28/2011 12:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_UserPrj_Tbl]
	(
	@userid varchar(50),
	@prj_code varchar(6)
	)
AS
if not exists (select access_level from User_Prj_Tbl where userid=@userid and prj_code=@prj_code)
begin
insert into User_Prj_Tbl(userid,prj_code,access_level)values(@userid,@prj_code,'Review/Comments')
end
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[insert_SO_dir]    Script Date: 06/28/2011 12:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_SO_dir]
	(@so_id int
	,@so_date smalldatetime
	,@package nvarchar(50)
	,@doc_name nvarchar(50)
	,@issued_date smalldatetime
	,@issued_to nvarchar(50)
	,@remarks nvarchar(500)
	,@project_code nvarchar(6)
	,@uid nvarchar(50)
	,@status bit
	,@mode tinyint)
AS
BEGIN
if @mode=1
begin
declare
	@so_no nvarchar(15)
	select @so_no='SO' + convert(nvarchar(5), count([so_no])+1) from SO_Dir_Tbl where [project_code]=@project_code
	insert into SO_Dir_Tbl
	([so_no]
	,[so_date]
	,[package]
	,[doc_name]
	,[issued_date]
	,[issued_to]
	,[status]
	,[remarks]
	,[project_code]
	,[uid])values
	(@so_no
	,@so_date
	,@package
	,@doc_name
	,@issued_date
	,@issued_to
	,1
	,@remarks
	,@project_code
	,@uid)
	end
	else if @mode=0
	begin
	update SO_Dir_Tbl set [status]=@status where [so_id]=@so_id
	end
END
GO
/****** Object:  StoredProcedure [dbo].[insert_so_details]    Script Date: 06/28/2011 12:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_so_details]
	(@so_itm_id int
	,@so_id int
	,@details nvarchar(2000)
	,@response nvarchar(2000)
	,@date smalldatetime
	,@uid nvarchar(50)
	,@mode tinyint )
AS
BEGIN
if @mode=1
begin
	insert into SO_Details_Tbl 
	([so_id]
	,[details]
	,[response]
	,[_date]
	,[uid])values
	(@so_id
	,@details
	,@response
	,@date
	,@uid)
end
else if @mode=0
begin
update SO_Details_Tbl set [response]=@response,[_date]=@date where [so_itm_id]=@so_itm_id
end	
END
GO
/****** Object:  StoredProcedure [dbo].[insert_doc_review_log]    Script Date: 06/28/2011 12:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_doc_review_log]

	(@dr_id int
	,@dr_reviewed nvarchar(50)
	,@issued_date smalldatetime
	,@issued_to nvarchar(50)
	,@project_code nvarchar(6)
	,@uid nvarchar(50)
	,@dr_status bit
	,@mode tinyint)
AS
BEGIN
if @mode=1
begin
declare
	@drno nvarchar(15)
	select @drno='DR' + convert(nvarchar(5), count([dr_no])+1) from Document_Review_Log where [project_code]=@project_code
	insert into Document_Review_Log
	([dr_no]
	,[dr_reviewed]
	,[issue_date]
	,[issued_to]
	,[dr_status]
	,[responds]
	,[project_code]
	,[uid])values
	(@drno
	,@dr_reviewed
	,@issued_date
	,@issued_to
	,1
	,0
	,@project_code
	,@uid)
end
else if @mode=0
begin
	update Document_Review_Log
	set 
	[dr_status]=@dr_status
	where [dr_id]=@dr_id
	
end	
END
GO
/****** Object:  StoredProcedure [dbo].[insert_doc_review_details]    Script Date: 06/28/2011 12:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_doc_review_details]
	(@dr_itm_id int
	,@dr_id int
	,@details nvarchar(500)
	,@response nvarchar(500)
	,@date nvarchar(50)
	,@uid nvarchar(50)
	,@mode tinyint)
AS
BEGIN
if @mode=1
begin
	insert into Document_Review_Details
	([dr_id]
	,[details]
	,[response]
	,[_date]
	,[uid])values
	(@dr_id
	,@details
	,@response
	,@date
	,@uid)
end
else if @mode=0
begin
update Document_Review_Details set [response]=@response,[_date]=@date where [dr_itm_id]=@dr_itm_id
end	
END
GO
/****** Object:  StoredProcedure [dbo].[insert_Cassheet_master]    Script Date: 06/28/2011 12:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_Cassheet_master]
	(@c_s_id int
	,@p_code nvarchar(6)
	,@uid nvarchar(50)
	,@sys_id int
	,@e_b_ref nvarchar(50)
	,@b_z nvarchar(50)
	,@cat nvarchar(50)
	,@f_lvl nvarchar(50)
	,@sq_no nvarchar(50)
	,@des nvarchar(100)
	,@loc nvarchar(50)
	,@p_p_to nvarchar(50)
	,@f_from nvarchar(50)
	,@sub_st nvarchar(50)
	,@s_c_m nvarchar(50)
	,@dev1 nvarchar(25)
	,@dev2	nvarchar(25)
	,@dev3	nvarchar(25)
	/*,@pwr_on smalldatetime
	,@con_acce smalldatetime
	,@t_s_filed smalldatetime
	,@comm nvarchar(500)
	,@act_by nvarchar(50)
	,@act_date smalldatetime*/
	,@mode tinyint
	,@cas_id int)	
AS
BEGIN
if @mode=1
begin
	insert into Cassheet_master_tbl
	([Cas_schedule],[P_code],[Uid],[Sys_id],[E_b_ref],[B_Z],[Cat],[F_Lvl],[Sq_No],[Des],[Loc],[P_P_to],[F_from],[Substation],[S_c_m])values
(@c_s_id,@p_code,@uid,@sys_id ,@e_b_ref,@b_z,@cat,@f_lvl,@sq_no,@des,@loc,@p_p_to,@f_from,@sub_st,@s_c_m)
	
	select @cas_id=MAX([C_id]) from Cassheet_master_tbl	
	insert into Cassheet_testing_tbl([cas_id],[devices1],[devices2],[devices3],[sys_id],[project])values(@cas_id,@dev1,@dev2,@dev3,@sys_id,@p_code)
end	
else if @mode=0
begin
Update Cassheet_master_tbl set
[E_b_ref]=@e_b_ref,
[B_Z]=@b_z,
[Cat]=@cat,
[F_Lvl]=@f_lvl,
[Sq_No]=@sq_no,
[Des]=@des,
[Loc]=@loc,
[P_P_to]=@p_p_to,
[F_from]=@f_from,
[Substation]=@sub_st,
[S_c_m]=@s_c_m
where [C_id]=@cas_id
update Cassheet_testing_tbl set
[devices1]=@dev1,[devices2]=@dev2,[devices3]=@dev3 where [cas_id]=@cas_id
end
else if @mode=2
begin
delete from Cassheet_testing_tbl where [cas_id]=@cas_id
delete from Cassheet_master_tbl where [C_id]=@cas_id
end
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Cas_Testing]    Script Date: 06/28/2011 12:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Cas_Testing]
(@cas_id int
,@torque_ nvarchar(25)
,@ir_ nvarchar(25)
,@pressure_ nvarchar(25)
,@sec_injection_ nvarchar(25)
,@con_resistance nvarchar(25)
,@functional_ nvarchar(25)
,@completed_ decimal(18,2)
,@ttl_cold_tested int
,@cold_complete nvarchar(25)
,@ttl_live_tested int
,@live_complete nvarchar(25)
,@pre_com_test nvarchar(25)
,@c_f_test nvarchar(25)
,@load_test nvarchar(25)
,@full_run_test nvarchar(25)
,@wir_test nvarchar(25)
,@ratio_test nvarchar(25)
,@wr_test nvarchar(25)
,@vg_test nvarchar(25)
,@hv_test nvarchar(25)
,@lv_ir_test_gen nvarchar(25))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	delete from Cas_Testing_Tbl where [cas_id]=@cas_id
	insert into Cas_Testing_Tbl
	([cas_id]
	,[torque_]
	,[ir_]
	,[pressure_]
	,[sec_injection_]
	,[con_resistance_]
	,[functional_]
	,[completed_]
	,[ttl_cold_tested]
	,[cold_complete]
	,[ttl_live_tested]
	,[live_complete]
	,[pre_com_test]
	,[c_f_test]
	,[load_test]
	,[full_run_test]
	,[wir_test]
	,[ratio_test]
	,[wr_test]
	,[vg_test]
	,[hv_test]
	,[lv_ir_test_gen])
	values
	(@cas_id
	,@torque_
	,@ir_
	,@pressure_
	,@sec_injection_
	,@con_resistance
	,@functional_
	,@completed_
	,@ttl_cold_tested
	,@cold_complete
	,@ttl_live_tested
	,@live_complete
	,@pre_com_test
	,@c_f_test
	,@load_test
	,@full_run_test
	,@wir_test
	,@ratio_test
	,@wr_test
	,@vg_test
	,@hv_test
	,@lv_ir_test_gen)
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Doctype_Auto]    Script Date: 06/28/2011 12:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Doctype_Auto]
	(
	@doctype varchar(50),
	@project_code varchar(6),
	@exist int
	
	)
AS
Declare @count int
Declare @idx int
Declare @parent varchar(6)
declare @Folder_code varchar(6)
declare @Folder_possition int
declare @possition int
Declare _AutoCur cursor for select Folder_id from TreeFolder_Tbl where Folder_Type=2 and Project_code=@project_code
Select @count=count(Folder_id) from TreeFolder_Tbl where Folder_Type=2 and Project_code=@project_code
select @idx=1

Open _AutoCur
Fetch Next from _AutoCur into @parent
While @@Fetch_status=0
Begin
if @exist<>@parent
begin
select @Folder_code=isnull(Max(Folder_code),0)+ 1 from TreeFolder_Tbl where Parent_folder=@parent
select @Folder_possition=isnull(Max(Folder_possition),0) + 1 from TreeFolder_Tbl where Parent_folder=@parent
select @possition=ISNULL(max([Type]),0)+1 from TreeFolder_Tbl where Parent_folder=@parent
Insert into TreeFolder_Tbl (Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code,Enabled,[Type]) values(@Folder_code,@doctype,3,@Folder_possition ,@parent,@Project_code ,1,@possition )
end
Fetch Next from _AutoCur into @parent

End
Close _AutoCur
deallocate _AutoCur

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 06/28/2011 12:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
	
	(
	@userid varchar(50),
	@password varchar(15),
	@username varchar(50),
	@user_group varchar(15),
	@CMS bit,
	@DMS bit,
	@TMS bit,
	@CU bit,
	@CP bit,
	@PM bit,
	@mode int
	)
	
AS
if @mode=1
begin
insert into usermaster_tbl([userid],[password],[username],[user_group],[CMS] ,[DMS],[TMS],[CU],[CP],[PM])
values(@userid,@password,@username,@user_group,@CMS,@DMS,@TMS,@CU,@CP,@PM)
end
else if @mode=0
begin
update usermaster_tbl set
[username]=@username,
[user_group]=@user_group,
[CMS]=@CMS,
[DMS]=@DMS,
[TMS]=@TMS,
[CU]=@CU,
[CP]=@CP,
[PM]=@PM where [userid]=@userid
delete from User_Prj_Tbl where userid=@userid 
end
RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateService]    Script Date: 06/28/2011 12:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateService]
	
	(
	@description varchar(50),
	@service varchar(50),
	@possition tinyint
	)
	
AS
	declare @service_code varchar(6)
	declare @c_possition tinyint
	declare @count int
	select @service_code=isnull(Max(service_code),0) from servicemaster_tbl
	--select @c_possition= max(@possition) +1 from servicemaster_tbl
	select @c_possition= @possition +1 

	if(@possition>0)
	begin
		update servicemaster_tbl set possition=possition +1 where possition > @possition		
	end
	insert into servicemaster_tbl(service_code,service_description,possition) values(@service_code + 1 ,@description,@c_possition)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateSchedule]    Script Date: 06/28/2011 12:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateSchedule]
	(
	@service int,
	@package int,
	@doctype int,
	@doc_title varchar(50),
	@doc_name varchar(100),
	@date_tobeuploaded smalldatetime,
	@Folder_id int,
	@Project_code varchar(6)
	)
AS
	/*declare @service_code varchar(6)
	declare @package_code varchar(6)
	declare @doctype_code varchar(6)
	select @service_code=service_code from servicemaster_tbl where service_description=@service_name
	select @package_code=package_code from packagemaster_tbl where package_description=@package_name
	select @doctype_code=doctype_code from documenttypemaster_tbl where doctype_description=@doctype_name
	
	insert into ScheduleMaster_tbl(service_code,package_code,doctype_code,doc_title,doc_name,date_tobeuploaded)values(@service_code,@package_code,@doctype_code,@doc_title,@doc_name,@date_tobeuploaded)*/
	insert into ScheduleMaster_tbl(service_code,package_code,doctype_code,doc_title,doc_name,date_tobeuploaded,Folder_id,Project_code)values(@service,@package,@doctype,@doc_title,@doc_name,@date_tobeuploaded,@Folder_id,@Project_code)
	--exec FileUploading @service_name,@package_name,@doctype_name,@doc_title,@doc_name,0,null,null
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateProject]    Script Date: 06/28/2011 12:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateProject]
	
	(
	@project_code varchar(6),
	@project_name varchar(50),
	@company varchar(50),
	@description varchar(1000),
	@user varchar(50),
	@dms bit,
	@cms bit,
	@tms bit,
	@mode tinyint
	)
	
AS
if @mode=1
begin
	insert into projectmaster_tbl([prj_code],[prj_name],[company],[description],[userid],[dms],[cms],[tms]) values(@project_code,@project_name,@company,@description,@user,@dms,@cms,@tms)
	end
	else if @mode=0
	begin
	update projectmaster_tbl set [prj_name]=@project_name,[company]=@company,[description]=@description,[dms]=@dms,[cms]=@cms,[tms]=@tms where [prj_code]=@project_code
	end	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreatePackage]    Script Date: 06/28/2011 12:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreatePackage]
	
	(
	@description varchar(100),
	@service varchar(50),
	@possition tinyint
	)
	
AS
declare @service_code varchar(6)
declare @package_code varchar(6)
declare @c_possition tinyint

declare @count int
select @service_code=service_code from servicemaster_tbl where service_description=@service
select @count=count(*) from Packagemaster_tbl where service_code=@service_code
select @package_code=@service_code + '.0' + Convert(varchar(5),(@count +1))

--select @c_possition= @possition +1 
if(@possition>0)
begin
update packagemaster_tbl set possition=possition +1 where possition>@possition and service_code=@service_code
select @c_possition=@possition + 1 
end
else 
begin
select @c_possition=isnull(Max(possition),0) + 1 from packagemaster_tbl where  service_code=@service_code
end

insert into packagemaster_tbl(package_code,package_description,service_code,possition) values(@package_code,@description,@service_code,@c_possition)
RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateManufacture]    Script Date: 06/28/2011 12:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateManufacture]
	
	(
	@Manufacture_name varchar(50),
	@Project_code varchar(6)
	)
	
AS
	
	insert into Manufacture_tbl(Manufacture_name,Project_code)values(@Manufacture_name,@Project_code)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateGroup]    Script Date: 06/28/2011 12:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateGroup]
	
	(
	@description varchar(50),
	@service varchar(50),
	@possition tinyint
	)
	
AS
	declare @group_code varchar(6)
	declare @c_possition tinyint
	declare @doctype_code varchar(6)
	select @group_code=isnull(Max(group_code),0)+ 1 from GoupMaster_Tbl
	select @doctype_code=doctype_code from documenttypemaster_tbl where doctype_description=@service
	--select @c_possition= max(@possition) +1 from servicemaster_tbl
	select @c_possition= @possition +1 

	if(@possition>0)
	begin
		update GoupMaster_Tbl set possition=possition +1 where possition > @possition	
		select @c_possition=@possition + 1 
	end
	else
	begin
		select @c_possition=isnull(Max(possition),0) + 1 from GoupMaster_Tbl 
	end
	insert into GoupMaster_Tbl(Group_code,Group_description,Doctype_id,possition) values(@group_code ,@description,@doctype_code,@c_possition)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateDocType]    Script Date: 06/28/2011 12:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateDocType]
	
	(
	@Description varchar(50),
	@service varchar(50),
	@possition tinyint
	)
	
AS
	declare @doctype_code varchar(6)
	declare @c_possition tinyint
	declare @count int
	select @doctype_code=isnull(Max(doctype_code),0)+1 from documenttypemaster_tbl
	--select @c_possition= max(@possition) +1 from servicemaster_tbl

	if(@possition>0)
	begin
		update documenttypemaster_tbl set possition=possition +1 where possition > @possition	
		select @c_possition=@possition + 1 
	end
	else
	begin
		select @c_possition=isnull(Max(possition),0) + 1 from documenttypemaster_tbl 
	end
		
insert into documenttypemaster_tbl(doctype_code,doctype_description,possition) values(@doctype_code,@Description,@c_possition)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[CreateContractor]    Script Date: 06/28/2011 12:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateContractor]
	(
	@con_name varchar(50),
	@prj_code varchar(6)
	)
AS
insert into Contractor_tbl(con_name,prj_code)values(@con_name,@prj_code)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Doc_Summary_Report]    Script Date: 06/28/2011 12:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Doc_Summary_Report] 
	(@Project_code varchar(6))
AS
truncate table Tmp_Rpt_Tbl
Declare @package nvarchar(255)
Declare @id int
Declare @manual_id int
Declare _AutoCur cursor for select [Folder_description],[Folder_id] from TreeFolder_Tbl where Folder_Type=2 and Project_code=@Project_code and [Enabled]=1
Open _AutoCur
Fetch Next from _AutoCur into @package,@id
While @@Fetch_status=0
Begin
select @manual_id=isnull(Folder_id,0) from TreeFolder_Tbl where [Type]=1 and [Parent_folder]=@id
declare @exist nvarchar(50)
declare @date smalldatetime
declare @status nvarchar(50)
if exists (select * from documentmaster_tbl where [folder_id]=@manual_id)
begin
select @exist='YES'
select @date=isnull([uploaded_date],0),@status=[Status] from documentmaster_tbl where [folder_id]=@manual_id 
end
else
begin
select @exist='NO UPLOAD'
select @date=null
select @status='-'
end
insert into Tmp_rpt_tbl([package],[manual],[uploaded_date],[status]) values(@package,@exist,@date,@status)
declare @doctype varchar(50)
declare @folder int
declare @Type int
Declare _AutoCur1 cursor for select [Folder_description],[Folder_id],[Type] from TreeFolder_Tbl where Folder_Type=3 and Parent_folder=@id
Open _AutoCur1
Fetch Next from _AutoCur1 into @doctype,@folder,@Type
While @@Fetch_status=0
Begin
declare @schedule money
declare @upload money
declare @percentage money
if @Type <>1
Begin
select @schedule=isnull(COUNT(Sch_id),0) from ScheduleMaster_tbl where Folder_id=@folder 
select @upload=isnull(COUNT(doc_id),0) from documentmaster_tbl where folder_id=@folder 
if(@upload>0)
begin
select @percentage=(@upload/(@schedule + @upload))*100
end
else
begin
select @percentage=0
end
insert into Tmp_Rpt_tbl(document_type,scheduled,uploaded,percentage) values(@doctype,@schedule + @upload ,@upload,@percentage )
End
Fetch Next from _AutoCur1 into @doctype,@folder,@Type
End
Close _AutoCur1
deallocate _AutoCur1


Fetch Next from _AutoCur into @package,@id

End
Close _AutoCur
deallocate _AutoCur
select * from Tmp_rpt_tbl
GO
/****** Object:  StoredProcedure [dbo].[dml_cas_main]    Script Date: 06/28/2011 12:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[dml_cas_main]
(@cas_id int
,@sys_id int
,@reff_ nvarchar(255)
,@desc_ nvarchar(255)
,@loca_ nvarchar(255)
,@p_power_to nvarchar(255)
,@fed_from varchar(255)
,@power_on nvarchar(25)
,@comm_ nvarchar(255)
,@act_by nvarchar(255)
,@act_date nvarchar(25)
,@uid nvarchar(50)
,@date_ smalldatetime
,@srv_id int
,@sch_id int
,@prj_code nvarchar(6)
,@con_acce nvarchar(25)
,@filed bit
,@des_vol nvarchar(50)
,@des_flow_rate nvarchar(50)
,@devices int
,@sys_monitored nvarchar(50)
,@fa_interfaces int 
,@mode int)
AS
BEGIN
if @mode=1
Begin
	declare @itm_no int
	select @itm_no=ISNULL(max([itm_no]),0)+1 from cas_main_tbl where [sch_id]=@sch_id and [prj_code]=@prj_code
	
	insert into cas_main_tbl
	([itm_no]
	,[sys_id]
	,[reff_]
	,[desc_]
	,[loca_]
	,[p_power_to]
	,[fed_from]
	,[power_on]
	,[comm_]
	,[act_by]
	,[act_date]
	,[uid]
	,[date_]
	,[srv_id]
	,[sch_id]
	,[prj_code]
	,[con_acce]
	,[filed]
	,[des_vol]
	,[des_flow_rate]
	,[devices]
	,[sys_monitored]
	,[fa_interfaces])values
	(@itm_no
	,@sys_id
	,@reff_
	,@desc_
	,@loca_
	,@p_power_to
	,@fed_from
	,@power_on
	,@comm_
	,@act_by
	,@act_date
	,@uid
	,@date_
	,@srv_id
	,@sch_id
	,@prj_code
	,@con_acce
	,@filed
	,@des_vol
	,@des_flow_rate
	,@devices
	,@sys_monitored
	,@fa_interfaces)
	
	declare @_defaultDate varchar(5)
	set @_defaultDate= ''
	select @cas_id=MAX([cas_id]) from cas_main_tbl 
	exec Insert_Cas_Testing @cas_id,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,0,0,@_defaultDate,0,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate,@_defaultDate End	
else if @mode=0
Begin
	Update cas_main_tbl set
	[reff_]=@reff_,
	[desc_]=@desc_,
	[loca_]=@loca_,
	[fed_from]=@fed_from,
	[p_power_to]=@p_power_to,
	[power_on]=@power_on,
	[devices]=@devices,
	[con_acce]=@con_acce,
	[filed]=@filed,
	[comm_]=@comm_,
	[act_by]=@act_by,
	[act_date]=@act_date
	where [cas_id]=@cas_id
End	
END
GO
/****** Object:  StoredProcedure [dbo].[Create_Treefolder]    Script Date: 06/28/2011 12:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Create_Treefolder]
	(
		--@Folder_code varchar(6),
		@Folder_description varchar(100),
		@Folder_type int,
		@Folder_possition int,
		@Parent_folder int,
		@Project_code varchar(6),
		@Enabled bit	
	)
	
AS
declare @Folder_code varchar(6)

/*if @Parent_folder<>'0'
--begin
--select @Parent_folder=isnull(@Folder_code,1)
--end
--else
begin
select @Parent_folder=Folder_code from TreeFolder_Tbl where Project_code=@Project_code and Folder_description=@Parent_folder
end*/

if @Folder_type=2
begin
declare @count int
select @count=count(*) from TreeFolder_Tbl where Folder_type=@Folder_type and Project_code=@Project_code and Parent_folder=@Parent_folder
select @Folder_code=Folder_code from TreeFolder_Tbl where Project_code=@Project_code and Folder_id=@Parent_folder
Select @Folder_code=@Folder_code + '.0' + Convert(varchar(5),(@count +1))
end
else
begin
Select @Folder_code=isnull(max(Folder_code),0)+ 1 from TreeFolder_Tbl where Folder_type=@Folder_type and Project_code=@Project_code --and Parent_folder=@Parent_folder
end
Declare @possition int
Select @possition=0
if @Folder_type=3
Begin
select @possition=ISNULL(max([Type]),0)+1 from TreeFolder_Tbl where Folder_type=3 and Project_code=@Project_code
End
else



if @Folder_possition >0
begin
update TreeFolder_Tbl set Folder_possition=Folder_possition + 1 where Folder_type=@Folder_type and Project_code=@Project_code and Folder_possition>@Folder_possition --and Parent_folder=@Parent_folder
select @Folder_possition=@Folder_possition+1
end
else
begin
Select @Folder_possition=isnull(max(Folder_possition),0)+ 1 from TreeFolder_Tbl where Folder_type=@Folder_type and Project_code=@Project_code --and Parent_folder=@Parent_folder
end




	Insert into TreeFolder_Tbl (Folder_code,Folder_description,Folder_type,Folder_possition,Parent_folder,Project_code,Enabled,[Type]) values(@Folder_code,@Folder_description,@Folder_type,@Folder_possition ,@Parent_folder,@Project_code ,@Enabled,@possition )
	
if @Folder_type=3	
Begin
exec Doctype_Auto @Folder_description,@Project_code,@Parent_folder
End
if @Folder_type=2	
Begin
exec Package_Auto @Project_code
End
	RETURN
GO
