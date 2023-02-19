SELECT b.Id, b.Name, YearPublished, c.Name AS CategoryName
FROM Boardgames AS b JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY YearPublished DESC;