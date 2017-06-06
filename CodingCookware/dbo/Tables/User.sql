CREATE TABLE [dbo].[User]
(
	[ID] INT IDENTITY NOT NULL, 
	[EmailAddress] NVARCHAR(256) NOT NULL,
	[DisplayName] NVARCHAR(100) NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_User] PRIMARY KEY ([ID]),
	CONSTRAINT [UQ_User_EmailAddress] UNIQUE (EmailAddress),
	CONSTRAINT [UQ_User_DisplayName] UNIQUE (DisplayName)
)
