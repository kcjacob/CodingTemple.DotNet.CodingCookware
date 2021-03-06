﻿CREATE TABLE [dbo].[Customer] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (100) NULL,
    [Email] NVARCHAR (256) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_CustomerEmail]
    ON [dbo].[Customer]([Email] ASC);

