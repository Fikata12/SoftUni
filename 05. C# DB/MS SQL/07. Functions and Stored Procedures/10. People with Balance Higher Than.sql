CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan
    @number MONEY
AS
BEGIN
    SELECT
        FirstName AS [First Name],
        LastName AS [Last Name]
    FROM AccountHolders AS ah JOIN
        (SELECT AccountHolderId, SUM(Balance) AS TotalMoney
        FROM Accounts
        GROUP BY AccountHolderId) AS a ON ah.Id = a.AccountHolderId
    WHERE a.TotalMoney > @number
    ORDER BY FirstName, LastName;
END;