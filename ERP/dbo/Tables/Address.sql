CREATE TABLE [dbo].[Address] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Line1] NVARCHAR (100) NULL,
    [Line2] NVARCHAR (100) NULL,
    [State] NVARCHAR (50)  NULL,
    [Zip]   NVARCHAR (12)  NULL,
    [City]  NVARCHAR (100) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO

CREATE TRIGGER TR_AddressChanges ON [Address] AFTER INSERT, UPDATE
as
begin
  insert into AddressHistory 
  (ID, TimeStamp, Line1, Line2, City, State, Zip )
  select i.ID, GetDate(), i.Line1, i.Line2, i.City, i.State, i.Zip 
  from  inserted i
end