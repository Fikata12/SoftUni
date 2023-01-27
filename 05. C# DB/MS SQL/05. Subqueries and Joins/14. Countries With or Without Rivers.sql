SELECT TOP 5
    CountryName, RiverName
FROM Countries AS c
    LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
    LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
    WHERE c.ContinentCode = 'AF'
ORDER BY CountryName;