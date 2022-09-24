function extract(content) {
    let paragraph = document.getElementById(content).textContent;
    return paragraph.match(/\(([^)]+)\)/g).join('; ');
}