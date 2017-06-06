CREATE TABLE [dbo].[CategoryProduct]
(
	[CategoryID] NVARCHAR(100) NOT NULL,
	[ProductID] INT NOT NULL,
    CONSTRAINT [PK_CategoryProduct] PRIMARY KEY ([ProductID], [CategoryID]), 
    CONSTRAINT [FK_CategoryProduct_Category] FOREIGN KEY (CategoryID) REFERENCES Category([ID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_CategoryProduct_Product] FOREIGN KEY (ProductID) REFERENCES Product([ID]) ON DELETE CASCADE
)
