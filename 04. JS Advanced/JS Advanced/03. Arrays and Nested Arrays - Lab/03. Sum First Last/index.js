function SumFirstAndLast(input) {
    let array = [...input];
    return Number(array.shift()) + Number(array.pop());
}