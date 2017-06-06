CREATE TABLE [dbo].[Product]
(
	[ID] INT IDENTITY (1,1)NOT NULL, 
    [Name] NVARCHAR(500) NULL, 
    [Price] MONEY NULL, 
    [Description] NTEXT NULL, 
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate()
    CONSTRAINT [PK_Product] PRIMARY KEY ([ID])
)
