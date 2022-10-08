function createFormatter(separator, symbol, symbolFirst, currencyFormatter) {
    return function (value) {
        return currencyFormatter(separator, symbol, symbolFirst, value);
    }
}