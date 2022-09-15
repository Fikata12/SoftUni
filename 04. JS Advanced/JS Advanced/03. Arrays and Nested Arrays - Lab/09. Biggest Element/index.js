function maxValue(input) {
    let matrix = [...input];
    let maxValue = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if ( matrix[i][j] > maxValue) {
                maxValue = matrix[i][j];
            }
        }
    }
    console.log(maxValue);
}