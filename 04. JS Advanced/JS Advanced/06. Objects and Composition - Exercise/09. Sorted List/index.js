function createSortedList() {
    return {
        list: [],
        size: 0,
        add(element) {
            this.list.push(element);
            this.list.sort((a, b) => a - b);
            this.size++;
        },
        remove(index) {
            if (index + 1 <= this.list.length && index >= 0) {
                this.list.splice(index, 1);                
                this.size--;
            }
        },
        get(index) {
            if (index + 1 <= this.list.length && index >= 0) {
                return this.list[index];
            }
        }
    }
}