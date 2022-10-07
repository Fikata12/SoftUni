function solve() {
  let generateButton = document.getElementsByTagName('button')[0];
  let list = document.querySelector('tbody');
  generateButton.addEventListener('click', function () {
    let products = JSON.parse(document.getElementsByTagName('textarea')[0].value);
    for (const product of products) {
      let tr = document.createElement('tr');
      tr.innerHTML = `<td><img src="${product.img}"></td><td><p>${product.name}</p></td>
      <td><p>${product.price}</p></td><td><p>${product.decFactor}</p></td><td><input type="checkbox"/></td>`;
      list.appendChild(tr);
    }
    document.getElementsByTagName('textarea')[0].value = '';
  });

  let buyButton = document.getElementsByTagName('button')[1];
  buyButton.addEventListener('click', function () {
    let listBought = [];
    for (const piece of Array.from(list.children)) {
      if (piece.getElementsByTagName('input')[0].checked == true) {
        let info = piece.querySelectorAll('p');
        let name = info[0].textContent;
        let price = Number(info[1].textContent);
        let decFactor = Number(info[2].textContent);
        listBought.push({
          name: name,
          price: price,
          decFactor: decFactor
        });
      }
    }
    let textarea = document.getElementsByTagName('textarea')[1];
    textarea.value = `Bought furniture: ${listBought.map(e => e.name).join(", ")}`;
    textarea.value += `\nTotal price: ${listBought.reduce((total, current) => total + current.price, 0).toFixed(2)}`;
    textarea.value += `\nAverage decoration factor: ${listBought.reduce((total, current) => total + current.decFactor, 0) / listBought.length}`;
  });
}