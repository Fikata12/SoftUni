function IsWithinTheSpeedLimit(arg1, arg2) {
    let speed = Number(arg1);
    let area = String(arg2);
    let withinTHeSpeedLimit = true;
    let speedLimit;
    switch (area) {
        case 'motorway':
            if (speed > 130) {
                withinTHeSpeedLimit = false;
            }
            speedLimit = 130;
            break;
        case 'interstate':
            if (speed > 90) {
                withinTHeSpeedLimit = false;
            }
            speedLimit = 90;
            break;
        case 'city':
            if (speed > 50) {
                withinTHeSpeedLimit = false;
            }
            speedLimit = 50;
            break;
        case 'residential':
            if (speed > 20) {
                withinTHeSpeedLimit = false;
            }
            speedLimit = 20;
            break;
    }
    let status = speed - speedLimit <= 20 ? 'speeding' : speed - speedLimit <= 40 ? 'excessive speeding' : 'reckless driving';

    if (withinTHeSpeedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`)
    }
    else {
        console.log(`The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}
