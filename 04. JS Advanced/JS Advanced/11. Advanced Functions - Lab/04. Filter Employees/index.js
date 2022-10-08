function sort(data, data2) {
    let allEmployees = JSON.parse(data);
    let criteria = data2.split('-');
    let sortedEmployees = [];
    for (const key in allEmployees) {
        if (allEmployees[key][criteria[0]] == criteria[1]) {
            sortedEmployees.push(allEmployees[key]);
        } 
        else if (criteria[0] == 'all') {
            sortedEmployees = allEmployees;
            break;
        }
    }
    for (const key in sortedEmployees) {
        console.log(`${key}. ${sortedEmployees[key].first_name} ${sortedEmployees[key].last_name} - ${sortedEmployees[key].email}`);
    }
}