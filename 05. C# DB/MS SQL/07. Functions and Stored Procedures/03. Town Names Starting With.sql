CREATE PROCEDURE usp_GetTownsStartingWith
    @String VARCHAR(50)
AS
SELECT [Name] AS Town
FROM Towns
WHERE [Name] LIKE @String + '%';