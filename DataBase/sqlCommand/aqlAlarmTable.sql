-- Create AlarmDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alarm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](10) NULL,
	[Description] [nchar](50) NULL,
	[Group] [nchar](10) NULL,
	[Message] [nchar](50) NULL,
	[Type] [nchar](10) NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_Alarm] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SELECT * FROM Alarm;
GO

