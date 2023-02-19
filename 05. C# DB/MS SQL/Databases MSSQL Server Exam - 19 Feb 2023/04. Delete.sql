DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (SELECT b.Id
FROM Boardgames AS b
    JOIN Publishers AS p ON b.PublisherId = p.Id
    JOIN Addresses AS a ON p.AddressId = a.Id
WHERE LEFT(a.Town, 1) = 'L');

DELETE FROM Boardgames WHERE PublisherId IN (SELECT p.Id
FROM Publishers AS p
    JOIN Addresses AS a ON p.AddressId = a.Id
WHERE LEFT(a.Town, 1) = 'L');

DELETE FROM Publishers WHERE AddressId IN (SELECT Id
FROM Addresses
WHERE LEFT(Town, 1) = 'L');

DELETE FROM Addresses WHERE LEFT(Town, 1) = 'L';