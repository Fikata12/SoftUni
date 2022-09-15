function sort(input) {
    let array = [];
    for (let i = 0; i < input.length; i++) {
        if (input[i] < 0) {
            array.unshift(input[i]);
        }
        else {
            array.push(input[i]);
        }
    }
    console.log(array.join('\n'));
}