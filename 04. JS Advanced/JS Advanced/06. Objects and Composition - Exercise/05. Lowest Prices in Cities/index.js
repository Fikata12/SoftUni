function func(array) {
    let dict = {};
    for (const townAndProduct of array) {
        let [townName, product, productPrice] = townAndProduct.split(' | ');
        productPrice = Number(productPrice);
        if (dict[product] == undefined || dict[product].price > productPrice) {
            dict[product] = {
                town: townName,
                price: productPrice
            }
        }
    }
    for (const item in dict) {
        console.log(`${item} -> ${dict[item].price} (${dict[item].town})`);
    }
}