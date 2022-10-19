function solve(array) {
    let allJuices = {};
    let allBottles = {};
    for (const juice of array) {
        let [name, quantity] = juice.split(' => ');
        if (!allJuices[name]) {
            allJuices[name] = Number(quantity);
        }
        else {
            allJuices[name] += Number(quantity);
        }
        if (allJuices[name] >= 1000) {
            let bottles = Math.floor(allJuices[name] / 1000);
            allJuices[name] %= 1000;
            if (!allBottles[name]) {
                allBottles[name] = bottles;
            }
            else {
                allBottles[name] += bottles;
            }
        }
    }
    let result = '';
    for (const bottle in allBottles) {
        result += `${bottle} => ${allBottles[bottle]}\n`;
    }
    return result.trim();
}