function Generator(n, k) {
    let array = [1];
    for (let j = 0; j < n - 1; j++) {
        let sum = 0;
        for (let i = j; i > j - k; i--) {
            if (i < 0) {
                break;
            }
            sum += array[i];
        }
        array.push(sum);
    }
    return array;
}