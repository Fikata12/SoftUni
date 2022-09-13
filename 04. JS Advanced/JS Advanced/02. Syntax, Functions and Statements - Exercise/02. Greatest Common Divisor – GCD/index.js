function GetGreatestDivisor(num1, num2) {
    let greatestDivisor = 1;
    for (let i = 1; i <= Math.min(num1, num2); i++) {
        if (num1 % i == 0 && num2 % i == 0) {
            greatestDivisor = i;
        }
    }
    console.log(greatestDivisor);
}