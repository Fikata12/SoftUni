function func(inputArray) {
    let array = [];
    for (const item of inputArray) {
        let [productName, productPrice] = item.split(' : ');
        array.push({ name: productName, price: productPrice });
    }
    array.sort((a, b) => a.name.localeCompare(b.name));
    let currentLetter = '';
    for (const item of array) {
        if (currentLetter != item.name[0]) {
            console.log(item.name[0]);
            currentLetter = item.name[0];
        }
        console.log(`  ${item.name}: ${item.price}`)
    }
}