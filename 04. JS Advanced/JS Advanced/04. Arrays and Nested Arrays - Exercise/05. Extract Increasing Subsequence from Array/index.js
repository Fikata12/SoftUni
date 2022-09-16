function func(inputArray) {
    let array = [...inputArray];
        let max = Number.NEGATIVE_INFINITY;
        return array.reduce((total, currValue) => {
        if(currValue >= max) { 
            total.push(currValue);
            max = currValue;
        }
        return total;
    }, []);
}