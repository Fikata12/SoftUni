SELECT FirstName + ' ' + LastName AS FullName, Email, r.Rating
FROM Creators AS c
JOIN (SELECT cb.CreatorId, MAX(b.Rating) AS Rating
FROM CreatorsBoardgames AS cb JOIN Boardgames AS b ON cb.BoardgameId = b.Id
GROUP BY cb.CreatorId) AS r ON c.Id = r.CreatorId WHERE RIGHT(Email, 4) = '.com'
ORDER by FullName;