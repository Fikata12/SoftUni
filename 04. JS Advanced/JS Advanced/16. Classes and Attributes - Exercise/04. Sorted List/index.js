class List {
    constructor() {
        this._collection = [];
        this.size = 0;
    }
    add(arg) {
        if (typeof (arg) === 'number') {
            this._collection.push(arg);
            this._collection.sort((a, b) => a - b);
            this.size++;
        }
        else {
            throw new Error();
        }
    }
    remove(index) {
        if (index >= 0 && index < this.size) {
            this._collection.splice(index, 1);
            this.size--;
        }
        else {
            throw new Error();
        }
    }
    get(index) {
        if (index >= 0 && index < this.size) {
            return this._collection[index];
        }
        else {
            throw new Error();
        }
    }
}