function lockedProfile() {
    let profiles = document.getElementsByClassName('profile');
    for (const profile of Array.from(profiles)) {
        let button = profile.getElementsByTagName('button')[0];
        button.addEventListener('click', function(){
            let lockCheckBox = profile.querySelector('input[value=lock]');
            let hiddenInfo = profile.getElementsByTagName('div')[0];
            if (lockCheckBox.checked == false && button.textContent == 'Show more') {
                hiddenInfo.style = 'display:block';
                button.textContent = 'Hide it'; 
            } 
            else if (lockCheckBox.checked == false && button.textContent == 'Hide it') {
                hiddenInfo.style = 'display:none';
                button.textContent = 'Show more'; 
            }
        });
    }
}