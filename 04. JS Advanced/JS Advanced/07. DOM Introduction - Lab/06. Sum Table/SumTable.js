function sumTable() {
    let table = document.querySelectorAll("table tr");
    let total = 0;
    for (let i = 1; i < table.length; i++) {
        total += Number(table[i].children[1].textContent);
    }
    document.getElementById('sum').textContent = total;
}