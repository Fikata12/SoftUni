function generateReport() {
    let checkBoxes = Array.from(document.querySelectorAll('input'));
    let checkBoxIndexes = [];
    for (const checkBox of checkBoxes) {
        if (checkBox.checked) {
            checkBoxIndexes.push(checkBoxes.indexOf(checkBox))
        }
    }
    let report = [];
    let rows = Array.from(document.querySelectorAll('tbody tr'));
    for (const row of rows) {
        let col = Array.from(row.children);
        let currentObj = {};
        for (let i = 0; i < col.length; i++) {
            if (checkBoxIndexes.includes(i)) {
                currentObj[checkBoxes[i].name] = col[i].textContent;
            }
        }
        report.push(currentObj);
    }
    document.getElementById('output').value = JSON.stringify(report);

}