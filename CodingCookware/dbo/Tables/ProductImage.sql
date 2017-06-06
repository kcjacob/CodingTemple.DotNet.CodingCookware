CREATE TABLE [dbo].[ProductImage]
(
	[ID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
	[URL] NVARCHAR(1000) NOT NULL,
	[AlternateText] NVARCHAR(1000) NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_ProductImage] PRIMARY KEY ([ID]), 
    CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY (ProductID) REFERENCES Product(ID) ON DELETE CASCADE

)
