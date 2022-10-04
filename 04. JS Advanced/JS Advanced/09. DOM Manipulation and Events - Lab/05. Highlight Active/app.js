function focused() {
    let mainDiv = document.getElementsByTagName('div')[0];
    mainDiv.addEventListener('focus', () => 0)
    let fields = Array.from(document.querySelectorAll('div div'));
}