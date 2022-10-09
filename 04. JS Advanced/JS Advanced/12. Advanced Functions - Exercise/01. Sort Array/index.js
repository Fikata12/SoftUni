function solve(array, criteria) {
    let sortingStrategies = {
        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    };
    return array.sort(sortingStrategies[criteria]);
}