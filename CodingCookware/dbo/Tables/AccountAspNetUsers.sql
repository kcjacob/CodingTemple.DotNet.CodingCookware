CREATE TABLE [dbo].[AccountAspNetUsers]
(
	[AspNetUserID] NVARCHAR(128) NOT NULL,
	[AccountID] INT NOT NULL,
    CONSTRAINT [PK_AccountUser] PRIMARY KEY ([AspNetUserID], [AccountID]), 
    CONSTRAINT [FK_AccountUser_Account] FOREIGN KEY (AccountID) REFERENCES Account([ID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AccountUser_User] FOREIGN KEY (AspNetUserID) REFERENCES AspNetUsers([Id]) ON DELETE CASCADE,
)
