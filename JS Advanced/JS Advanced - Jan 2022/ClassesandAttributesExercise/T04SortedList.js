class List {
    // numbers = [];
    constructor() {
        this.numbers = [];
        this.size = this.numbers.length;
    }
    add(num) {
        this.numbers.push(num);
        this.size = this.numbers.length;
        this.numbers.sort((a, b) => a - b);
    }
    remove(index) {
        if (index < 0 || index >= this.numbers.length) {
            throw new Error('Invalid index');
        }

        this.numbers.splice(index, 1);
        this.size = this.numbers.length;
        this.numbers.sort((a, b) => a - b);
    }
    get(index) {
        if (index < 0 || index >= this.numbers.length) {
            throw new Error('Invalid index');
        }

        return this.numbers[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
