CREATE TABLE [dbo].[Basket]
(
	[ID] INT IDENTITY(1,1) NOT NULL, 
    [AccountID] INT NULL, 
    [Name] NVARCHAR(100) NULL, 
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_Basket] PRIMARY KEY ([ID]), 
    CONSTRAINT [FK_Basket_Account] FOREIGN KEY (AccountID) REFERENCES Account([ID])
)
