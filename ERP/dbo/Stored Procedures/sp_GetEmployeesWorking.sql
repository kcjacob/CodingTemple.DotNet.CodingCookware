CREATE PROCEDURE sp_GetEmployeesWorking 
@date DATETIME, 
@store INT
AS
SELECT 
	Employee.Name, 
	Shift.StartDateTime, 
	Shift.EndDateTime 
FROM
	Store 
INNER JOIN 
	[Shift] ON Store.ID = [Shift].StoreID
INNER JOIN 
	Employee ON [Shift].EmployeeID = Employee.ID
WHERE 
	Store.ID = @store AND 
	(Shift.StartDateTime BETWEEN (@date) AND DATEADD(DAY, 1, @date) OR
	Shift.EndDateTime BETWEEN (@date) AND DATEADD(DAY, 1, @date))