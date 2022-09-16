function func(inputArray) {
    let array = [...inputArray];
    array.sort((a, b) => a.localeCompare(b)).sort((a, b) => a.length - b.length);
    console.log(array.join('\n'));
}