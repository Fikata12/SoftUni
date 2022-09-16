function func(inputArray) {
    let arrayAsc = [...inputArray.sort((a, b) => a - b)];
    let array = [];
    for (let i = 0; i < Math.ceil(arrayAsc.length / 2); i++) {
        array.push(arrayAsc[i]);
        if(i != arrayAsc.length - 1 && i != arrayAsc.length - 1 - i) {
        array.push(arrayAsc[arrayAsc.length - 1 - i]);
        }
    }
    return array;
}