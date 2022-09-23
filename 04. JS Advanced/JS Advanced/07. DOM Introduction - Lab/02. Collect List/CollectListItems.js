function extractText() {
    let element = document.querySelectorAll('ul#items li');
    let textArea = document.querySelector('#result');
    for (const node of element) {
        textArea.value += node.textContent + "\n";
    }
}