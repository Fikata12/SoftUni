SELECT e.EmployeeID, FirstName, p.Name
FROM Employees AS e
    JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
    LEFT JOIN Projects AS p ON p.ProjectID = ep.ProjectID AND YEAR(p.StartDate) < '2005'
WHERE e.EmployeeID = 24
ORDER BY EmployeeID;