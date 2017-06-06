CREATE TABLE [dbo].[Purchase]
(
	[ID] INT IDENTITY(1,1) NOT NULL, 
    [OrderIdentifier] NVARCHAR(20) NOT NULL,
	[SubmittedDate] DATETIME NOT NULL,
	[FulfilledDate] DATETIME NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
	CONSTRAINT [UQ_OrderIdentifier] UNIQUE (OrderIdentifier), 
    CONSTRAINT [PK_Purchase] PRIMARY KEY ([ID])
)
