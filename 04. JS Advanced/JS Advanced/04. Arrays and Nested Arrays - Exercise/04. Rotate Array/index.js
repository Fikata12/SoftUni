function func(inputArray, num) {
    let array = [...inputArray];
    for (let i = 0; i < num; i++) {
        array.unshift(array.pop());
    }
    console.log(array.join(' '));
}