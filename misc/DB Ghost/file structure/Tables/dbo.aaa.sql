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

