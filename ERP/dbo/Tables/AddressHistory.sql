CREATE TABLE [dbo].[AddressHistory] (
    [ID]        INT            NOT NULL,
    [TimeStamp] DATETIME       NOT NULL,
    [Line1]     NVARCHAR (100) NULL,
    [Line2]     NVARCHAR (100) NULL,
    [State]     NVARCHAR (50)  NULL,
    [Zip]       NVARCHAR (12)  NULL,
    [City]      NVARCHAR (100) NULL,
    CONSTRAINT [PK_AddressHistory] PRIMARY KEY CLUSTERED ([ID] ASC, [TimeStamp] ASC),
    CONSTRAINT [FK_AddressHistory_Address] FOREIGN KEY ([ID]) REFERENCES [dbo].[Address] ([ID])
);

