CREATE TABLE [dbo].[Category]
(
	[ID] NVARCHAR(100) NOT NULL, 
	[ParentID] NVARCHAR(100) NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_Category] PRIMARY KEY ([ID]), 
    CONSTRAINT [FK_Category_Category] FOREIGN KEY (ParentID) REFERENCES Category([ID])
)
