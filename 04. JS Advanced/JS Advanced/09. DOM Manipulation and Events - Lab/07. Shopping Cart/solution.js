function solve() {
    let productAdds = document.querySelectorAll('div.product-add ');
    let textArea = document.getElementsByTagName('textarea')[0];
    let cart = {};
    for (const add of Array.from(productAdds)) {
        add.addEventListener('click', function (event) {
            let productName = add.parentElement.getElementsByClassName('product-title')[0].textContent;
            let productPrice = add.parentElement.getElementsByClassName('product-line-price')[0].textContent;
            if (cart[productName] != undefined) {
                cart[productName] += Number(productPrice);
            } 
            else {
                cart[productName] = Number(productPrice);
            }
            textArea.value += `Added ${productName} for ${Number(productPrice).toFixed(2)} to the cart.\n`;
        });
    }
    let checkout = document.getElementsByClassName('checkout')[0];
    checkout.addEventListener('click', function (event) {
        let sum = Object.values(cart).reduce((total, current) => total += current, 0);
        textArea.value += `You bought ${Object.keys(cart).join(', ')} for ${sum.toFixed(2)}.`;
        Array.from(document.getElementsByTagName('button')).forEach(e => e.disabled = true);
    });
}