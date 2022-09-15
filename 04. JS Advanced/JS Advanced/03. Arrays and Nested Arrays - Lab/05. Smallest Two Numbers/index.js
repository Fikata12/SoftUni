function print(input) {
    let array = [...input];
    array.sort((a, b) => a - b);
    console.log(array.splice(0, 2).join(' '));
}