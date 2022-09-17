let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();


function solution() {
    let result = '';

    return {
        append(str) {
            result += str;
        },
        removeStart(num) {
            // result = result.slice(num);
            result = result.substring(num);
        },
        removeEnd(num) {
            // result = result.slice(0, result.length - num);
            result = result.substring(0, result.length - num);
        },
        print() {
            console.log(result);
        }
    }
}


let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();
