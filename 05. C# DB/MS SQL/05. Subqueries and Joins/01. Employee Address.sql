SELECT TOP 5
    EmployeeId, JobTitle, Employees.AddressID, AddressText
FROM Employees JOIN Addresses ON Employees.AddressID = Addresses.AddressID
ORDER BY AddressID;