SELECT SUM(SumDifference) AS SumDifference
FROM (SELECT DepositAmount - (SELECT DepositAmount
        FROM WizzardDeposits AS wd2
        WHERE wd1.Id + 1 = wd2.Id) AS SumDifference
    FROM WizzardDeposits AS wd1) AS AllSumDiffs;