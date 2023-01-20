SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('Sa', FirstName) = 1;