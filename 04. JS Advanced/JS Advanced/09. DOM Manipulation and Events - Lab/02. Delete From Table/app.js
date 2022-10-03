function deleteByEmail() {
    let input = document.getElementsByTagName('input')[0].value;
    let people = Array.from(document.querySelectorAll('tbody tr'));
    let result = document.getElementById('result');
    let isFound = false;
    for (let i = 0; i < people.length; i++) {
        if (people[i].children[1].textContent == input) {
            isFound = true;
            people[i].remove();
            result.textContent = 'Deleted.';
        }
    }
    if (!isFound) {
        result.textContent = 'Not found.';
    }
}