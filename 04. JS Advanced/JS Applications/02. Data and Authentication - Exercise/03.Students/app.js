    init();
document.getElementById('form').addEventListener('submit', onSubmit);

function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(document.getElementById('form'));
    try {
        let data = {
            firstName: formData.get('firstName'),
            lastName: formData.get('lastName'),
            facultyNumber: formData.get('facultyNumber'),
            grade: Number(formData.get('grade'))
        };
        if (!Object.values(data).some(e => e == '')
        && typeof data.firstName == 'string' && typeof data.lastName == 'string'
        && typeof data.facultyNumber == 'string' && typeof data.grade == 'number' && !isNaN(data.grade)) {

            fetch("http://localhost:3030/jsonstore/collections/students", {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)
            });
        }
        else {
            throw new Error("Invalid input");
        }
    }
    catch (error) {
        console.log(error.message);
    }
}

async function init() {
    let data = await (await fetch('http://localhost:3030/jsonstore/collections/students')).json();
    let table = document.querySelector('#results tbody');
    let fragment = new DocumentFragment();

    for (const student of Object.values(data)) {
        let tr = document.createElement('tr');
        fragment.appendChild(tr);

        let firstName = document.createElement('th');
        firstName.textContent = student.firstName;
        tr.appendChild(firstName);

        let lastName = document.createElement('th');
        lastName.textContent = student.lastName;
        tr.appendChild(lastName);

        let facultyNumber = document.createElement('th');
        facultyNumber.textContent = student.facultyNumber;
        tr.appendChild(facultyNumber);

        let grade = document.createElement('th');
        grade.textContent = student.grade;
        tr.appendChild(grade);
    }
    table.appendChild(fragment);
}