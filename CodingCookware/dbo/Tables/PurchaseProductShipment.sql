CREATE TABLE [dbo].[PurchaseProductShipment]
(
	[ShipmentID] INT NOT NULL,
	[PurchaseProductID] INT NOT NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(), 
    CONSTRAINT [PK_PurchaseProductShipment] PRIMARY KEY ([PurchaseProductID], [ShipmentID]), 
    CONSTRAINT [FK_PurchaseProductShipment_PurchaseProduct] FOREIGN KEY (PurchaseProductID) REFERENCES PurchaseProduct(ID) ON DELETE CASCADE, 
    CONSTRAINT [FK_PurchaseProductShipment_Shipment] FOREIGN KEY (ShipmentID) REFERENCES Shipment(ID) ON DELETE CASCADE,
)
