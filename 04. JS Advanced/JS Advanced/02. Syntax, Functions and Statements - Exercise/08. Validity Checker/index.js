function ValidityChecker(x1, y1, x2, y2){

    IsValid(x1, y1, 0, 0);
    IsValid(x2, y2, 0, 0);
    IsValid(x1, y1, x2, y2);
    function IsValid(x1, y1, x2, y2)
    {
        if(calc(x1, y1, x2, y2) % 1 == 0){
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        }
        else { 
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }
    }
    function calc(x1, y1, x2, y2)
    {
        return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    }
}