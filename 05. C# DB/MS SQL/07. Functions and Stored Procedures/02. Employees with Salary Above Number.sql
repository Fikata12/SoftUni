CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
    @Number DECIMAL(18,4)
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @Number;