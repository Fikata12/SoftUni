function notify(message) {
  let div = document.getElementById('notification');
  div.textContent = message;
  if (div.style.display == 'none' || div.style.display == '') {
    div.style.display = 'block';
  }
  div.addEventListener('click', () => {
    div.style.display = 'none';
  });
}