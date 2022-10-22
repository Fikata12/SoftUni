window.addEventListener("load", solve);

function solve() {
  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');
  let previewList = document.getElementById('preview-list');
  let publishBtn = document.getElementById('form-btn');
  
  publishBtn.addEventListener('click', (e) => {
    e.preventDefault();

    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let storyTitleValue = storyTitle.value;
    let genreValue = genre.value;
    let storyValue = story.value;

    if (firstNameValue === "" || lastNameValue === "" || ageValue === "" || storyTitleValue === "" || genreValue === "" || storyValue === "") {
      return;
    }

    let li = document.createElement('li');
    li.className = 'story-info';

    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = `Name: ${firstNameValue} ${lastNameValue}`;
    article.appendChild(h4);
    let pAge = document.createElement('p');
    pAge.textContent = `Age: ${ageValue}`;
    article.appendChild(pAge);
    let pTitle = document.createElement('p');
    pTitle.textContent = `Title: ${storyTitleValue}`;
    article.appendChild(pTitle);
    let pGenre = document.createElement('p');
    pGenre.textContent = `Genre: ${genreValue}`;
    article.appendChild(pGenre);
    let pStory = document.createElement('p');
    pStory.textContent = storyValue;
    article.appendChild(pStory);

    li.appendChild(article);

    let saveBtn = document.createElement('button');
    saveBtn.className = "save-btn";
    saveBtn.textContent = 'Save Story';
    saveBtn.addEventListener('click', () => {
      let main = document.getElementById('main');
      main.getElementsByClassName('form-wrapper')[0].remove();
      document.getElementById('side-wrapper').remove();
      let h1 = document.createElement('h1');
      h1.textContent = "Your scary story is saved!";
      main.appendChild(h1);
    });
    li.appendChild(saveBtn);

    let editBtn = document.createElement('button');
    editBtn.className = "edit-btn";
    editBtn.textContent = 'Edit Story';
    editBtn.addEventListener('click', () => {
      firstName.value = firstNameValue;
      lastName.value = lastNameValue;
      age.value = ageValue;
      storyTitle.value = storyTitleValue;
      genre.value = genreValue;
      story.value = storyValue;
      publishBtn.disabled = false;
      editBtn.parentElement.remove();
    });
    li.appendChild(editBtn);

    let deleteBtn = document.createElement('button');
    deleteBtn.className = "delete-btn";
    deleteBtn.textContent = 'Delete Story';
    deleteBtn.addEventListener('click', () => {
      publishBtn.disabled = false;
      deleteBtn.parentElement.remove();
    });
    li.appendChild(deleteBtn);

    previewList.appendChild(li);

    firstName.value = '';
    lastName.value = '';
    age.value = '';
    storyTitle.value = '';
    genre.value = 'Disturbing';
    story.value = '';

    publishBtn.disabled = true;
  });
}