function addItem() {
    let list = document.getElementById('items');
    let input = document.getElementById('newItemText').value;
    let li = list.appendChild(document.createElement('li'));
    li.textContent = input;
    let remove = li.appendChild(document.createElement('a'));
    remove.textContent = '[Delete]';
    remove.href = '#';
    remove.addEventListener('click', () => list.removeChild(li));
}