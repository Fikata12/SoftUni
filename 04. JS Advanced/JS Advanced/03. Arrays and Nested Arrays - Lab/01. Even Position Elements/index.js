function GetEven(input) { 
    let array = [...input];
    console.log(array.filter((element, index) => index % 2 == 0).join(' '));
}