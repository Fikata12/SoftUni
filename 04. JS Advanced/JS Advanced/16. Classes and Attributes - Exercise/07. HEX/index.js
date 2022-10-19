class Hex {
    constructor(value) {
        this.value = Number(value);
    }
    valueOf() {
        return this.value;
    }
    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }
    plus(number) {
        let result = undefined;
        if (isNaN(number)) {
            result = this.value + number.valueOf();
        }
        else {
            result = this.value + number;
        }
        return new Hex(result);
    }
    minus(number) {
        let result = undefined;
        if (isNaN(number)) {
            result = this.value - number.valueOf();
        }
        else {
            result = this.value - number;
        }
        return new Hex(result);
    }
    parse(number) {
        return parseFloat(number, 16);
    }
}