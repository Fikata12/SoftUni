function func(inputArray, num) {
    let array = [];
    for (let i = 0; i < inputArray.length; i+=num) {
        array.push(inputArray[i]);
    }
    return array;
}