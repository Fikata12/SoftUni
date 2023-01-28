SELECT TOP 10
    FirstName, LastName, e.DepartmentID
FROM Employees AS e
    JOIN (SELECT DepartmentID, AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID) AS DepAvgSal ON e.DepartmentID = DepAvgSal.DepartmentID
WHERE Salary > DepAvgSal.AverageSalary
ORDER BY DepartmentID;