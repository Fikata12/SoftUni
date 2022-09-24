function toggle() {
    let text = document.getElementsByClassName("button")[0];
    let extra = document.getElementById("extra");
    if (text.textContent == 'More') {
        text.textContent = "Less";
        extra.style = "display:block";
    } else {
        text.textContent = 'More';
        extra.style = "display:none";
    }
}