function OrderInterpreter(product, weight, pricePerKg) {
    let price = weight / 1000 * pricePerKg;
    let weightInKg = weight / 1000;
    console.log(`I need $${price.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${product}.`);
}