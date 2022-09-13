function sum(input1, input2) {
    let number1 = Number(input1);
    let number2 = Number(input2);
    let sum = 0;
    for (let i = number1; i <= number2; i++) {
        sum += i;
    }
    return sum;
}