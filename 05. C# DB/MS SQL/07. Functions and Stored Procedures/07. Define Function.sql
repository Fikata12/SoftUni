CREATE or ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
BEGIN
    DECLARE @i INT = 1;
    WHILE (@i <= LEN(@word))
    BEGIN
        IF(CHARINDEX(SUBSTRING(@word, @i, 1), @setOfLetters, 1) = 0)
        BEGIN
            RETURN 0
        END

        SET @i= @i + 1
    END
    RETURN 1
END;