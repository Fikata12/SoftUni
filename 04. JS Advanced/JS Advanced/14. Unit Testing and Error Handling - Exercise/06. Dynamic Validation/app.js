function validate() {
    let emailValidator = new RegExp(/[\w]+@[\w]+.[\w]+/g);
    let input = document.getElementById('email');
    input.addEventListener('change', function(e) {
        if (!input.value.match(emailValidator)) {
            input.classList.add('error');
        }
        else {
            input.classList.remove('error');
        }
    });
}