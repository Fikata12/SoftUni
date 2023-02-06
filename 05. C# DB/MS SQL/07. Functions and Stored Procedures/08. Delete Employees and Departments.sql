CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
    @departmentId INT
AS
BEGIN
    DECLARE @delEmployees TABLE(Id INT);
    INSERT INTO @delEmployees
    SELECT EmployeeID
    FROM Employees
    WHERE DepartmentID = @departmentId;

    DELETE FROM EmployeesProjects 
    WHERE EmployeeID IN (SELECT * FROM @delEmployees);

    UPDATE Employees
    SET ManagerID = NULL
    WHERE ManagerID IN (SELECT * FROM @delEmployees);

    ALTER TABLE Departments ALTER COLUMN ManagerID INT NULL;
    UPDATE Departments
    SET ManagerID = NULL
    WHERE ManagerID IN (SELECT * FROM @delEmployees);

    DELETE FROM Employees
    WHERE EmployeeID IN (SELECT * FROM @delEmployees);

    DELETE FROM Departments 
    WHERE DepartmentID = @departmentId;

    SELECT COUNT(*)
    FROM Employees
    WHERE DepartmentID = @departmentId;
END;