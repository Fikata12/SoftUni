SELECT TOP 5
    p.CountryName, Elevation AS HighestPeakElevation, [Length] AS LongestRiverLength
FROM (SELECT CountryName, Elevation
    FROM (SELECT c.CountryName, p.Elevation, DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS ElevationRank
        FROM Countries AS c
            LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
            LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
            LEFT JOIN Peaks AS p ON m.Id = p.MountainId) AS RankedPeaksSubquery
    WHERE ElevationRank = 1) AS p
    JOIN (SELECT CountryName, [Length]
    FROM (SELECT c.CountryName, r.Length, DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY r.Length DESC) AS LengthRank
        FROM Countries AS c
            LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
            LEFT JOIN Rivers AS r ON cr.RiverId = r.Id) AS RankedRiversSubquery
    WHERE LengthRank = 1) AS r ON p.CountryName = r.CountryName
ORDER BY Elevation DESC, [Length] DESC;