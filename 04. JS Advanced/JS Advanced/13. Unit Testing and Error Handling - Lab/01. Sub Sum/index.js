function solve(array, start, end) {
    if (Array.isArray(array) && array.every(e => !isNaN(e))) {
        start = start < 0 ? 0 : start;
        end = end > array.length - 1 ? array.length - 1 : end;
        return array.map(e => Number(e))
            .filter(e => array.indexOf(e) >= start && array.indexOf(e) <= end)
            .reduce((total, current) => total + current, 0);
    }
    return NaN;
}