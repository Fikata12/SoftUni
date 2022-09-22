function func(inputArray) {
    let array = [];
    for (let i = 1; i < inputArray.length; i++) {
        let [town, latitude, longitude] = inputArray[i].split(/\s*\|\s*/).filter(e => e != '');
        latitude = Number(Number(latitude).toFixed(2));
        longitude = Number(Number(longitude).toFixed(2));
        array.push({ Town: town, Latitude: latitude, Longitude: longitude });
    }
    console.log(JSON.stringify(array))
}