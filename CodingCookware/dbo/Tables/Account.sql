CREATE TABLE [dbo].[Account]
(
	[ID] INT IDENTITY(1,1) NOT NULL, 
    [Name] NVARCHAR(100) NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_Account] PRIMARY KEY ([ID]),
	CONSTRAINT [UQ_Account_Name] UNIQUE ([Name])
)
