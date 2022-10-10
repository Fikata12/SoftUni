function solve() {
    let a = 0;
    let b = 1;
    let result = 0;
    return function () {
        result = a + b;
        a = b;
        b = result;
        return a;
    }
}