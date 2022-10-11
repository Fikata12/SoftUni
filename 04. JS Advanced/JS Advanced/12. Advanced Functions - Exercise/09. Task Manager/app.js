function solve() {
    let openSection = document.getElementsByTagName('section')[1].children[1];
    let inProgressSection = document.getElementsByTagName('section')[2].children[1];
    let completeSection = document.getElementsByTagName('section')[3].children[1];
    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let task = document.getElementById('task');
        let description = document.getElementById('description');
        let date = document.getElementById('date');
        if (task.value && description.value && date.value) {
            openSection.appendChild(CreateTask(task, description, date));
        }
    });
    function CreateTask(task, description, date) {
        let article = document.createElement('article');
        article.innerHTML += `<h3>${task.value}</h3><p>Description: ${description.value}</p><p>Due Date: ${date.value}</p>
        <div class="flex"></div>`;
        article.getElementsByTagName('div')[0].appendChild(CreateStart());
        article.getElementsByTagName('div')[0].appendChild(CreateDelete());
        return article;
    }
    function CreateDelete() {
        let button = document.createElement('button');
        button.textContent = 'Delete';
        button.classList.add('red');
        button.addEventListener('click', (e) => {
            e.preventDefault();
            button.parentElement.parentElement.remove();
        });
        return button;
    }
    function CreateStart() {
        let button = document.createElement('button');
        button.textContent = 'Start';
        button.classList.add('green');
        button.addEventListener('click', (e) => {
            e.preventDefault();
            inProgressSection.appendChild(e.currentTarget.parentElement.parentElement);
            e.target.parentElement.appendChild(CreateFinish());
            e.target.remove();
        });
        return button;
    }
    function CreateFinish() {
        let button = document.createElement('button');
        button.textContent = 'Finish';
        button.classList.add('orange');
        button.addEventListener('click', (e) => {
            e.preventDefault();
            completeSection.appendChild(e.currentTarget.parentElement.parentElement);
            e.target.parentElement.remove();
        });
        return button;
    }
}