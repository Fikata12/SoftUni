function func(inputArray) {
    let array = [...inputArray];
    let sum = 0;
    for (let i = 0; i < array.length; i++) {
        if (i == 0) {
            sum = Sum(array[i]);
        }
        else if (sum != Sum(array[i])) {
            console.log('false');
            return;
        }
    }
    for (let i = 0; i < array.length; i++) {
        let currentSum = 0;
        for (let j = 0; j < array.length; j++) {
            currentSum += array[j][i];
        }
        if (sum != currentSum) {
            console.log('false');
            return;
        }
    }
    console.log('true');
    function Sum(array) {
        return array.reduce((total, current) => { return total += current });
    }
}