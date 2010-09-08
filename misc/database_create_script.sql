CREATE TABLE [dbo].[test_table_2] (
  [id] int CONSTRAINT [DF_test_table_2_id] DEFAULT -1 NOT NULL,
  [test] varchar(50) COLLATE Czech_CI_AS CONSTRAINT [DF_test_table_2_test] DEFAULT '' NOT NULL,
  [id2] int CONSTRAINT [DF_test_table_2_id2] DEFAULT -1 NOT NULL,
  CONSTRAINT [IX_test_table_2] UNIQUE ([test], [id2]),
  CONSTRAINT [PK_test_table_2] PRIMARY KEY CLUSTERED ([test])
)
ON [PRIMARY]
GO

CREATE TABLE [dbo].[test_table] (
  [id] int IDENTITY(1, 1) NOT NULL,
  [test] varchar(50) COLLATE Czech_CI_AS CONSTRAINT [DF_test_table_test] DEFAULT getdate() NOT NULL,
  [test2] nchar(10) COLLATE Czech_CI_AS CONSTRAINT [DF_test_table_test2] DEFAULT '' NOT NULL,
  [id2] int CONSTRAINT [DF_test_table_id2] DEFAULT -1 NOT NULL,
  CONSTRAINT [PK_test_table] PRIMARY KEY CLUSTERED ([id], [test2] DESC, [test]),
  CONSTRAINT [UK_test_table] UNIQUE ([test]),
  CONSTRAINT [CK_test_table] CHECK NOT FOR REPLICATION ([id]>(0)),
  CONSTRAINT [CK_test_table_2] CHECK ([id]<(1000000)),
  CONSTRAINT [FK_test_table_test_table_2] FOREIGN KEY ([test], [id2]) 
  REFERENCES [dbo].[test_table_2] ([test], [id2]) 
  ON UPDATE CASCADE
  ON DELETE SET DEFAULT
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[test_table]
NOCHECK CONSTRAINT [CK_test_table]
GO

ALTER TABLE [dbo].[test_table]
NOCHECK CONSTRAINT [FK_test_table_test_table_2]
GO

EXEC sp_addextendedproperty 'MS_Description', N'test description', 'schema', 'dbo', 'table', 'test_table', 'constraint', 'CK_test_table'
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_test] ON [dbo].[test_table]
  ([test] DESC, [id])
WITH (
  PAD_INDEX = OFF,
  FILLFACTOR = 50,
  IGNORE_DUP_KEY = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

CREATE TRIGGER [dbo].[test_trigger] ON [dbo].[test_table]
WITH EXECUTE AS CALLER
FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON;
END
GO

DISABLE TRIGGER [test_trigger] ON [dbo].[test_table]
GO

CREATE VIEW [dbo].[test_view]
AS
SELECT * FROM dbo.test_table
GO

CREATE TRIGGER [dbo].[test_view_trigger] ON [dbo].[test_view]
WITH EXECUTE AS CALLER
INSTEAD OF INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON;
END
GO

CREATE PROCEDURE test_stored_procedure 
	@id int
AS
BEGIN
	SET NOCOUNT ON;
END
GO

CREATE FUNCTION [dbo].[test_fcn]
  ( @x int )
RETURNS int
AS

BEGIN
	RETURN @x;
END
GO

CREATE TYPE [dbo].[aa]
FROM bigint NULL
GO

CREATE TYPE [dbo].[aaa]
FROM decimal(34, 33) NOT NULL
GO

CREATE TYPE [dbo].[SSN]
FROM nvarchar(11) NOT NULL
GO

CREATE TYPE [dbo].[SSN1]
FROM sql_variant NOT NULL
GO

CREATE TYPE [dbo].[SSN2]
FROM real NOT NULL
GO

CREATE TYPE [dbo].[SSN3]
FROM real NOT NULL
GO

CREATE TYPE [dbo].[SSN4]
FROM real NOT NULL
GO

CREATE TYPE [dbo].[SSN5]
FROM float NOT NULL
GO

CREATE TYPE [dbo].[test_type]
FROM nvarchar(4000) NOT NULL
GO

CREATE USER [dbtracer]
  FOR LOGIN  [dbtracer]
  WITH DEFAULT_SCHEMA = [dbo]
GO

CREATE USER [dbtracker]
  WITH DEFAULT_SCHEMA = [dbo]
GO

EXEC sp_addapprole 'test_role', ''
GO

CREATE SCHEMA [test_schema]
  AUTHORIZATION [dbo]
GO
