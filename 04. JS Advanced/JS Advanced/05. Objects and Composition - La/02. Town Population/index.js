function func(input) {
    let dict = {};
    for (const item of input) {
        let splittedInput = item.split('<->');
        if (dict[splittedInput[0]] !== undefined) {
            dict[splittedInput[0]] += Number(splittedInput[1]);
        }
        else {
            dict[splittedInput[0]] = Number(splittedInput[1]);
        }
    }
    for (const item of Object.entries(dict)) {
        console.log(`${item[0]}: ${item[1]}`);
    }
}