CREATE TABLE [dbo].[Shipment]
(
	[ID] INT IDENTITY(1,1) NOT NULL, 
    [ShipDate] DATETIME NULL, 
    [DeliveryDate] DATETIME NULL, 
    [EstimatedDeliveryDate] DATETIME NULL, 
    [TrackingNumber] NVARCHAR(500) NULL,
	[Created] DATETIME NULL DEFAULT GetUtcDate(),
	[Modified] DATETIME NULL DEFAULT GetUtcDate(), 
	[Recipient] NVARCHAR(500) NULL,
    [AddressLine1] NVARCHAR(500) NULL, 
    [AddressLine2] NVARCHAR(500) NULL, 
    [City] NVARCHAR(500) NULL, 
    [State] NVARCHAR(500) NULL, 
    [PostalCode] NVARCHAR(20) NULL, 
    [Country] NVARCHAR(500) NULL,
    CONSTRAINT [PK_Shipment] PRIMARY KEY ([ID])
)
