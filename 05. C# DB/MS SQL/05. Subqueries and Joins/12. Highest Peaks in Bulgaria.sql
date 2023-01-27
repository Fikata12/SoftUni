SELECT c.CountryCode, MountainRange, PeakName, Elevation
FROM Countries AS c
    JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    JOIN Mountains AS m ON mc.MountainId = m.Id
    JOIN Peaks AS p ON m.Id = p.MountainId
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY Elevation DESC;