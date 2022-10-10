function add(num) {
    let sum = num;
    calc.toString = function () { return sum };
    return calc;
    function calc(num2) {
        sum += num2;
        return calc;
    }
}