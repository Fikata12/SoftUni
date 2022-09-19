function func(inputArray) {
    let matrix = [];
    inputArray.forEach(element => {
        matrix.push(String(element).split(' ').map(e => Number(e)));
    });
    let mDiagonal = 0;
    let sDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix.length; j++) {
            if (i == j) {
                mDiagonal += matrix[i][j];
            }
            if (i == matrix.length - 1 - j) {
                sDiagonal += matrix[i][j];
            }
        }
    }
    if (mDiagonal == sDiagonal) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                if (i != matrix.length - 1 - j && i != j) {
                    matrix[i][j] = mDiagonal;
                }
            }
        }
    }
    for (const item of matrix) {
        console.log(item.join(' '));
    }
}