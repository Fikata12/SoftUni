SELECT Id, FirstName + ' ' + LastName AS CreatorName, Email
FROM Creators AS c LEFT JOIN CreatorsBoardgames AS bc ON c.Id = bc.CreatorId
WHERE bc.BoardgameId IS NULL;