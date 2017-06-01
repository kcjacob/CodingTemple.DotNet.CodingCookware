CREATE PROCEDURE sp_GetPurchasesByEmail
	@email NVARCHAR(256)
AS
SELECT Purchase.Date, Product.Name FROM 
	Customer INNER JOIN
	Purchase ON CustomerID = Purchase.CustomerID INNER JOIN
	Product ON Purchase.ProductID = Product.ID
WHERE Customer.Email = @email