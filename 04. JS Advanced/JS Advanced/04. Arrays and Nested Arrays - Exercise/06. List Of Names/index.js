function func(inputArray) {
    let array = [...inputArray];
    for (const item of array.sort((a, b) => a.localeCompare(b))) {
        console.log(`${array.indexOf(item) + 1}.${item}`);
    }
}