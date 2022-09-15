function sum(input) {
    let matrix = [...input];
    let mainDiagonal = 0;
    let secondaryDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (i == j) {
                mainDiagonal += matrix[i][j];
            }
            if (i + j == matrix[i].length - 1) {
                secondaryDiagonal += matrix[i][j];
            }
        }
    }
    console.log(`${mainDiagonal} ${secondaryDiagonal}`);
}