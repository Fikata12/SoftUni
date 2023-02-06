CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(38, 4), @rate FLOAT, @years INT)
RETURNS DECIMAL(38, 4)
AS 
BEGIN 
    DECLARE @result DECIMAL(38, 4) = @sum * POWER(1 + @rate, @years);
    RETURN @result;
END