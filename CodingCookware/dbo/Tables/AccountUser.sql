CREATE TABLE [dbo].[AccountUser]
(
	[UserID] INT NOT NULL,
	[AccountID] INT NOT NULL,
	[PrimaryUser] BIT NOT NULL DEFAULT(0),
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(), 
    CONSTRAINT [PK_AccountUser] PRIMARY KEY ([UserID], [AccountID]), 
    CONSTRAINT [FK_AccountUser_Account] FOREIGN KEY (AccountID) REFERENCES Account([ID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AccountUser_User] FOREIGN KEY (UserID) REFERENCES [User]([ID]) ON DELETE CASCADE,
)
