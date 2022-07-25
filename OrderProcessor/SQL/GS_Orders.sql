
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GS_Orders](
	[OPID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Symbol] [varchar](32) NOT NULL,
	[Quanity] [dbo].[ShareAmount] NOT NULL,
	[Price] [dbo].[PriceAmount] NOT NULL,
	[CalCumQty] [dbo].[ShareAmount] NOT NULL,
	[CalExecValue] [dbo].[PriceAmount] NOT NULL,
 CONSTRAINT [PK_GS_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


