function solve(area, vol, input) {
    let arrayOfFigures = JSON.parse(input);
    let arrayOfInfo = [];
    for (const figure of arrayOfFigures) {
        arrayOfInfo.push(
            {
                area: area.call(figure),
                volume: vol.call(figure)
            });
    }
    return arrayOfInfo;
}
