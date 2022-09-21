function func(input) {
    let register = [];
    for (const hero of input) {
        let splittedInput = hero.split(' / ');
        let name = splittedInput[0];
        let level = Number(splittedInput[1]);
        let items = [];
        if (splittedInput.length == 3) {
            items = splittedInput[2].split(', ');
        }
        register.push({ name, level, items });
    }
    console.log(JSON.stringify(register));
}