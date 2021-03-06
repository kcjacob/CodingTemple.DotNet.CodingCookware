﻿CREATE TABLE [dbo].[Review]
(
	[ID] INT NOT NULL,
	[ProductID] INT NOT NULL,
	[ParentID] INT NULL,
	[AspNetUserID] NVARCHAR(128) NOT NULL,
	[Approved] BIT NULL DEFAULT(0),
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_Review] PRIMARY KEY ([ID]), 
    CONSTRAINT [FK_Review_Review] FOREIGN KEY (ParentID) REFERENCES Review(ID), 
    CONSTRAINT [FK_Review_Product] FOREIGN KEY (ProductID) REFERENCES Product(ID) ON DELETE CASCADE, 
    CONSTRAINT [FK_Review_User] FOREIGN KEY (AspNetUserID) REFERENCES AspNetUsers(Id) ON DELETE CASCADE,

)
