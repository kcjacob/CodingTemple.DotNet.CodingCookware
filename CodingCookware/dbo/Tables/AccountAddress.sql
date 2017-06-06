CREATE TABLE [dbo].[AccountAddress]
(
	[AccountID] INT NOT NULL,
	[AddressID] INT NOT NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(), 
    CONSTRAINT [PK_AccountAddress] PRIMARY KEY ([AddressID], [AccountID]), 
    CONSTRAINT [FK_AccountAddress_Account] FOREIGN KEY (AccountID) REFERENCES Account([ID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AccountAddress_Address] FOREIGN KEY (AddressID) REFERENCES [Address]([ID]) ON DELETE CASCADE
)
