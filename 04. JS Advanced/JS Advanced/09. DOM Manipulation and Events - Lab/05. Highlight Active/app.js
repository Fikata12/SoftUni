function focused() {
    let mainDiv = document.getElementsByTagName("div")[0];

    Array.from(mainDiv.getElementsByTagName("input")).forEach(element => {
        element.addEventListener("focus", function(e) {
            e.target.parentNode.classList.add("focused");
        });
    });

    Array.from(mainDiv.getElementsByTagName("input")).forEach(element => {
        element.addEventListener("blur", function(e) {
            e.target.parentNode.classList.remove("focused");
        });
    });
}