CREATE TABLE [dbo].[BasketProduct]
(
	[BasketID] int NOT NULL,
	[ProductID] int NOT NULL,
	[Quantity] int NOT NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [PK_BasketProduct] PRIMARY KEY ([ProductID], [BasketID]), 
    CONSTRAINT [FK_BasketProduct_Basket] FOREIGN KEY (BasketID) REFERENCES Basket([ID]) ON DELETE CASCADE,
	CONSTRAINT [FK_BasketProduct_Product] FOREIGN KEY (ProductID) REFERENCES Product([ID]) ON DELETE CASCADE
)
