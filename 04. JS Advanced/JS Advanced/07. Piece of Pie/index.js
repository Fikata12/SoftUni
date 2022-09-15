function sort(inputArr, arg1, arg2) {
    let array = [...inputArr];
    return array.slice(array.indexOf(arg1), array.indexOf(arg2) + 1);
}
