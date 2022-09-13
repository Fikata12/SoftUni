function AreTheSame(num) {
    let AreTheSame = true;
    let numAsString = String(num);
    for (let i = 0; i < numAsString.length - 1; i++) {
        if (numAsString[i] != numAsString[i + 1] && AreTheSame) {
            AreTheSame = false;
        }
    }
    let sum = 0;
    for (let i = 0; i < numAsString.length; i++) {
        sum += Number(numAsString[i]);
    }
    console.log(AreTheSame);
    console.log(sum);
}