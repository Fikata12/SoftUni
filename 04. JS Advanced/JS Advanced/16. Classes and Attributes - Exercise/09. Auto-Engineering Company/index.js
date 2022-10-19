function solve(array) {
    let allCars = {};
    for (const car of array) {
        let [carBrand, carModel, producedCars] = car.split(' | ');
        if (!allCars[carBrand]) {
            allCars[carBrand] = { [carModel]: Number(producedCars) };
        }
        else if (!allCars[carBrand][carModel]) {
            allCars[carBrand][carModel] = Number(producedCars);
        }
        else {
            allCars[carBrand][carModel] += Number(producedCars);
        }
    }
    let result = '';
    for (const carBrand in allCars) {
        result += `${carBrand}\n`;
        for (const model in allCars[carBrand]) {
            result += `###${model} -> ${allCars[carBrand][model]}\n`;
        }
    }
    return result.trim();
}