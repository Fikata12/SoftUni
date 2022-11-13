async function lockedProfile() {
    let main = document.getElementById('main');
    let allPeople = await (await fetch("http://localhost:3030/jsonstore/advanced/profiles")).json();
    
    let i = 0;
    for (const person of Object.values(allPeople)) {
        main.innerHTML += `<div class="profile">
                           <img src="./iconProfile2.png" class="userIcon" />
                           <label>Lock</label>
                           <input type="radio" name="user${++i}Locked" value="lock" checked>
                           <label>Unlock</label>
                           <input type="radio" name="user${i}Locked" value="unlock"><br>
                           <hr>
                           <label>Username</label>
                           <input type="text" name="user${i}Username" value="${person.username}" disabled readonly />
                           <div class="user1Username" style="display: none">
                           <hr>
                           <label>Email:</label>
                           <input type="email" name="user${i}Email" value="${person.email}" disabled readonly />
                           <label>Age:</label>
                           <input type="email" name="user${i}Age" value="${person.age}" disabled readonly />
                           </div>
                           <button>Show more</button>
                           </div>`;
    }

    let allProfiles = document.getElementsByClassName('profile');
    for (const profile of allProfiles) {
        let btn = profile.getElementsByTagName("button")
        btn.addEventListener('click', () => {
            let lockCheckBox = btn.parentElement.querySelector('input[value=lock]');
            let hiddenInfo = btn.parentElement.getElementsByTagName('div')[0];
            if (lockCheckBox.checked == false) {
                if (btn.textContent == 'Show more') {
                    hiddenInfo.style.display = "";
                    btn.textContent = 'Hide it';
                }
                else if (btn.textContent == 'Hide it') {
                    hiddenInfo.style.display = "none";
                    btn.textContent = 'Show more';
                }
            }
        });
    }
}