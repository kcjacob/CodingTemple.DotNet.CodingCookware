﻿CREATE TABLE [dbo].[AddressAspNetUsers]
(
	[AspNetUserID] NVARCHAR(128) NOT NULL,
	[AddressID] INT NOT NULL,
    CONSTRAINT [PK_AccountAddress] PRIMARY KEY ([AddressID], [AspNetUserID]), 
    CONSTRAINT [FK_AccountAddress_AspNetUsers] FOREIGN KEY (AspNetUserID) REFERENCES AspNetUsers([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AccountAddress_Address] FOREIGN KEY (AddressID) REFERENCES [Address]([ID]) ON DELETE CASCADE
)
