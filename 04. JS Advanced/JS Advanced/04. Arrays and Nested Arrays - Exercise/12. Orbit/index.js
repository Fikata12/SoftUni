function func(array) {
    let matrix = [];
    array.map(e => Number(e));
    for (let i = 0; i < array[1]; i++) {
        matrix.push([]);
    }
    let x = array[2];
    let y = array[3];
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix.length; j++) {
            matrix[i][j] = Math.max(Math.abs(i - x), Math.abs(j - y)) + 1;
        }
    }
    for (const item of matrix) {
        console.log(item.join(' '));
    }
}