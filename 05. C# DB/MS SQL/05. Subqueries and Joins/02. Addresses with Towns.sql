SELECT TOP 50
    FirstName, LastName, [Name] AS Town, AddressText
FROM Employees JOIN Addresses ON Employees.AddressID = Addresses.AddressID JOIN Towns ON Addresses.TownID = Towns.TownID
ORDER BY FirstName, LastName;