CREATE TABLE [dbo].[Shipment]
(
	[ID] INT NOT NULL, 
    [ShipDate] DATETIME NULL, 
    [DeliveryDate] DATETIME NULL, 
    [EstimatedDeliveryDate] DATETIME NULL, 
    [TrackingNumber] NVARCHAR(500) NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(), 
    CONSTRAINT [PK_Shipment] PRIMARY KEY ([ID])
)
