SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '01-01-1999' AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate;