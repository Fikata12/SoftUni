function area(input) {
    if (typeof input == 'number') {
        let area = input ** 2 * Math.PI;
        console.log(area.toFixed(2));
        return;
    }
    return `We can not calculate the circle area, because we receive a ${typeof input}.`;
}
