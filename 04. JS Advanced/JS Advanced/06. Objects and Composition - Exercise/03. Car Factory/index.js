function func(input) {
    let EngineTypes = {
        smallEngine: { power: 90, volume: 1800 },
        normalEngine: { power: 120, volume: 2400 },
        monsterEngine: { power: 200, volume: 3500 }
    }
    let CarriageTypes = {
        Hatchback: { type: 'hatchback', color: undefined },
        Coupe: { type: 'coupe', color: undefined }
    }
    let obj = {
        model: input.model
    };
    for (const item of Object.values(EngineTypes)) {
        if (input.power <= item.power) {
            obj.engine = item;
            break;
        }
    }
    for (const item of Object.values(CarriageTypes)) {
        if (input.carriage == item.type) {
            obj.carriage = item;
            obj.carriage.color = input.color;
            break;
        }
    }
    if (Math.floor(input.wheelsize) % 2 == 0) {
        input.wheelsize--;
    } 
    obj.wheels = [];
    obj.wheels.length = 4;
    obj.wheels.fill(Math.floor(input.wheelsize), 0, 4);
    return obj;
}