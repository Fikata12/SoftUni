function sort(input) {
    let array = [...input];
    array.sort((a, b) => a - b);
    return array.splice(Math.floor(array.length / 2), array.length - 1);
}