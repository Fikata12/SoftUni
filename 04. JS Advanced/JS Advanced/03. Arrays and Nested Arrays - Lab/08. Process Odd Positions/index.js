function sort(input) {
    let array = [...input];
    let sortedArray = array.filter((item, index) => index % 2 != 0).map(item => item *2);
    console.log(sortedArray.reverse().join(' '));
}