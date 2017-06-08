CREATE TABLE [dbo].[PurchaseProduct]
(
	[ID] INT IDENTITY(1,1),
	[PurchaseID] INT NOT NULL,
	[ProductID] INT NULL,
	[ProductName] NVARCHAR(500) NULL, 
    [ProductPrice] MONEY NULL, 
	[Quantity] INT NOT NULL, 
	[ShipmentID] INT NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(),
    CONSTRAINT [FK_PurchaseProduct_Purchase] FOREIGN KEY (PurchaseID) REFERENCES Purchase([ID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_PurchaseProduct_Product] FOREIGN KEY (ProductID) REFERENCES Product([ID]) ON DELETE SET NULL, 
	CONSTRAINT [FK_PurchaseProduct_Shipment] FOREIGN KEY (ShipmentID) REFERENCES Shipment(ID) ON DELETE SET NULL,
    CONSTRAINT [PK_PurchaseProduct] PRIMARY KEY ([ID])
    
)
