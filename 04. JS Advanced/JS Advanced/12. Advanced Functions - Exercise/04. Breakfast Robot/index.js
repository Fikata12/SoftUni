function solve() {
    let recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    let commands = {
        restock: (input2, quantity) => {
            stock[input2] += Number(quantity);
            return `Success`;
        },
        prepare: (input2, quantity) => {
            for (const microEl in recipes[input2]) {
                if (stock[microEl] < quantity * recipes[input2][microEl]) {
                    return `Error: not enough ${microEl} in stock`;
                }
            }
            for (const microEl in recipes[input2]) {
                stock[microEl] -= quantity * recipes[input2][microEl];
            }
            return `Success`;
        },
        report: () => `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`
    };
    return function (input) {
        let [command, input2, quantity] = input.split(' ');
        return commands[command](input2, quantity);
    }
}