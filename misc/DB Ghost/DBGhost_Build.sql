
/*******************************************************************************************************************************
*
*        File created by DB Ghost Database Builder (www.dbghost.com) 5.0.0.1148 - 23.1.2010 1:23:28
*
*******************************************************************************************************************************/

SET TEXTSIZE 2147483647
GO

SET LANGUAGE US_ENGLISH
GO

SET DATEFORMAT MDY
GO

SET DATEFIRST 7
GO

SET LOCK_TIMEOUT -1
GO

SET QUOTED_IDENTIFIER ON
GO

SET NOCOUNT ON
GO

SET ANSI_NULL_DFLT_ON ON
GO

SET ANSI_WARNINGS ON
GO

SET ANSI_PADDING ON
GO

SET ANSI_NULLS ON
GO

SET CONCAT_NULL_YIELDS_NULL ON
GO

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO

USE master
GO

IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'test_20100123012328')
DROP DATABASE [test_20100123012328]
GO

/********************************************************************************************************************************************************************

   The create database and the alter database statements are created using the settings from the database [test] on the server [STROJ\CZPRG3K10_DEV1].

   It is necessary to change some settings to enable the build to progress smoothly. The following settings are commented out and or changed.

   SIZE - This attribute of the database and log files will not be used so the minimum amount of disk space is used as generally the build
           does not require any more disk space than the default setting.
   MAXSIZE - This attribute of the database and log files is not used so the database and log files can expand when necessary.
   FILEGROWTH - This attribute of the database and log files is not used so the database and log files can expand using as minimal space as is necessary.
   RECOVERY - The recovery mode will always be set to SIMPLE so log space is not used up for this process.
   READ_ONLY - This setting will always be READ_WRITE and the original setting will be commented out so the build can proceed.
   READONLY FILEGROUP - File groups will not have this setting as we may there may be tables and or indexes that are associated with the filegroup before the filegroup was set to READONLY.

********************************************************************************************************************************************************************/

CREATE DATABASE [test_20100123012328] ON PRIMARY
( NAME = N'test_20100123012328', FILENAME = N'D:\SQL2005\test_20100123012328_Data.mdf'/*, SIZE = 3072KB, MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB*/)
 LOG ON
( NAME = N'test_20100123012328_log', FILENAME = N'D:\SQL2005\test_20100123012328_Log.ldf'/*, SIZE = 1024KB, MAXSIZE = 2097152MB, FILEGROWTH = 10%*/)
 COLLATE Czech_CI_AS
GO

IF(SELECT is_default FROM [test_20100123012328].sys.filegroups WHERE [name]=N'PRIMARY')=0
	ALTER DATABASE [test_20100123012328] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
	EXEC [test_20100123012328].[dbo].[sp_fulltext_database] @action = 'disable'
END
GO

ALTER DATABASE [test_20100123012328] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [test_20100123012328] SET ANSI_NULLS OFF
GO

ALTER DATABASE [test_20100123012328] SET ANSI_PADDING OFF
GO

ALTER DATABASE [test_20100123012328] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [test_20100123012328] SET ARITHABORT OFF
GO

ALTER DATABASE [test_20100123012328] SET AUTO_CLOSE OFF
GO

ALTER DATABASE [test_20100123012328] SET AUTO_CREATE_STATISTICS ON
GO

ALTER DATABASE [test_20100123012328] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [test_20100123012328] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [test_20100123012328] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [test_20100123012328] SET CURSOR_DEFAULT GLOBAL
GO

ALTER DATABASE [test_20100123012328] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [test_20100123012328] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [test_20100123012328] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [test_20100123012328] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [test_20100123012328] SET ENABLE_BROKER
GO

ALTER DATABASE [test_20100123012328] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [test_20100123012328] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [test_20100123012328] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [test_20100123012328] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [test_20100123012328] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [test_20100123012328] SET READ_WRITE
GO

/*********************************************************************
   Original setting based on template database has been commented out.
ALTER DATABASE [test_20100123012328] SET RECOVERY FULL
*********************************************************************/
ALTER DATABASE [test_20100123012328] SET RECOVERY SIMPLE
GO

ALTER DATABASE [test_20100123012328] SET MULTI_USER
GO

ALTER DATABASE [test_20100123012328] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [test_20100123012328] SET DB_CHAINING OFF
GO

/*** Starting batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Logins\CZPRG3K10-footcha.sql ***/
GO

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'CZPRG3K10\footcha')
CREATE LOGIN [CZPRG3K10\footcha] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO

EXEC master..sp_addsrvrolemember @loginame = N'CZPRG3K10\footcha', @rolename = N'sysadmin'
GO

/*** Ending batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Logins\CZPRG3K10-footcha.sql ***/
GO

USE [test_20100123012328]
GO

/*** Starting batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Users\guest.sql ***/
GO

REVOKE CONNECT TO [guest]
GO

/*** Ending batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Users\guest.sql ***/
GO

BEGIN TRANSACTION
GO

/*** Starting batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Tables\dbo.aaa.sql ***/
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aaa]') AND type in (N'U'))
DROP TABLE [dbo].[aaa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[aaa](
	[xxx] [nchar] (10) NULL
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

/*** Ending batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Tables\dbo.aaa.sql ***/
GO

COMMIT TRANSACTION
GO

SET ANSI_PADDING ON
GO

BEGIN TRANSACTION
GO

/*** Starting batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Triggers\dbo.xxx.sql ***/
GO

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[xxx]'))
DROP TRIGGER [dbo].[xxx]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER xxx
   ON  aaa
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here

END
GO

/*** Ending batch from C:\Documents and Settings\footcha\Dokumenty\Corel User Files\Triggers\dbo.xxx.sql ***/
GO

COMMIT TRANSACTION
GO

