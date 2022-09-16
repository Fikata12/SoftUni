function func(inputArray) {
    let array = [];
    for (let i = 0; i < inputArray.length; i++) {
        if ( inputArray[i] == 'add') {
            array.push(i + 1);
        }
        else
        {
            array.pop();
        }
    }
    if (array.length > 0) {
        console.log(array.join('\n'));
    } 
    else {
        console.log('Empty');
    }
}
