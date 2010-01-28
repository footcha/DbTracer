CREATE TABLE [dbo].[DatabaseUpdates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ScriptName] [nvarchar](4000) NOT NULL,
	[Hash] [varbinary](64) NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[ErrorMessage] [ntext] NULL,
	[Tag] [nvarchar](4000) NOT NULL,
	CONSTRAINT [PK_DatabaseUpdates] PRIMARY KEY CLUSTERED (
		[ID] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_DatabaseUpdates_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_DatabaseUpdates_SelectAll]
GO
CREATE PROCEDURE dbo.usp_DatabaseUpdates_SelectAll
AS
 BEGIN
	SELECT * FROM dbo.DatabaseUpdates
 END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_DatabaseUpdate_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_DatabaseUpdate_Add]
GO
CREATE PROCEDURE dbo.usp_DatabaseUpdate_Add (
	@ScriptName nvarchar(256),
	@Hash varbinary(64),
	@UpdateDate datetime,
	@Tag ntext = '',
	@ErrorMessage ntext = null
) AS
 BEGIN
	IF EXISTS (SELECT ID FROM dbo.DatabaseUpdates WHERE ScriptName = @ScriptName)
	 BEGIN
		UPDATE dbo.DatabaseUpdates 
		SET [Hash] = @Hash, UpdateDate = @UpdateDate, ErrorMessage = @ErrorMessage
		WHERE ScriptName = @ScriptName
	 END
	ELSE
	 BEGIN
		INSERT INTO dbo.DatabaseUpdates (
			ScriptName, [Hash], UpdateDate, ErrorMessage, Tag
		) VALUES (
			@ScriptName, @Hash, @UpdateDate, @ErrorMessage, @Tag
		)
	 END
 END
GO