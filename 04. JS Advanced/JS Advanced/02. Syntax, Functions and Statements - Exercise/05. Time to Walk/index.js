function TimeToWalk(numberOfSteps, footprintLength, velocity) {
    let distanceInKm = numberOfSteps * footprintLength / 1000;
    let rest = Math.floor(distanceInKm / 0.5) * 60;
    let totalSeconds = distanceInKm / velocity * 3600 + rest;

    let hours = Math.floor(totalSeconds / 3600);
    let minutes = Math.floor(totalSeconds / 60 - hours * 60);
    let seconds = Math.ceil(totalSeconds - hours * 3600 - minutes * 60);
    console.log(`${(hours < 10 ? "0" : "") + hours}:${(minutes < 10 ? "0" : "") + minutes}:${(seconds < 10 ? "0" : "") + seconds}`);
}