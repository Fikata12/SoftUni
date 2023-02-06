CREATE FUNCTION ufn_CashInUsersGames(@name VARCHAR(50))
RETURNS TABLE
AS
RETURN
    SELECT SUM(Cash) AS SumCash
FROM (SELECT ug.Cash, ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS Rank
    FROM UsersGames AS ug
        JOIN Games AS g ON ug.GameId = g.Id
    WHERE g.Name = @name) AS RankedQuery
WHERE Rank % 2 <> 0;