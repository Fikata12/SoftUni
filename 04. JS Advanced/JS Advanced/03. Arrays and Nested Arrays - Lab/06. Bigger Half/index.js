function sort(input) {
    let array = [...input];
    array.sort((a, b) => a - b);
    return array.slice(Math.floor(array.length / 2));
}