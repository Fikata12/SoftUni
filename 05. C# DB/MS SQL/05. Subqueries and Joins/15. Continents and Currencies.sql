SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM (SELECT ContinentCode, CurrencyCode, CurrencyUsage, DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS CurrencyRank
    FROM (SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage
        FROM Countries
        GROUP BY ContinentCode, CurrencyCode
        HAVING COUNT(CurrencyCode) > 1) AS CurrencyUsageSubquery) AS RankedCurrencyCodeSubquery
WHERE CurrencyRank = 1;