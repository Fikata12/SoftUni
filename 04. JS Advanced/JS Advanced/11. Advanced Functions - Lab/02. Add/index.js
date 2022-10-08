function solve(input) {
    let sum = input;
    return function (arg) {
        return sum + arg;
    }
}
