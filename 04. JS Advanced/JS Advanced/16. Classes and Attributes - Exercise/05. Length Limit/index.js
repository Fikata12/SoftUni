class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }
    increase(value) {
        this.innerLength += value;
    }
    decrease(value) {
        this.innerLength -= value;
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }
    toString() {
        let stringArr = [...this.innerString];
        stringArr = stringArr.splice(0, this.innerLength);
        let dots = '';
        if (this.innerLength < this.innerString.length) {
            dots = '...';
        }
        return stringArr.join('') + dots;
    }
}