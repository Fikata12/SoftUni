function draw(a = 5) {
     
    for (let i = 0; i < a; i++) {
        let row = '';
        for (let i = 0; i < a; i++) {
            row += '* ';
        }
        console.log(row);
    }
}