SELECT TOP 10
    *
FROM [Projects]
WHERE ([StartDate] < GETDATE())
ORDER BY [StartDate] ASC, [Name] ASC;