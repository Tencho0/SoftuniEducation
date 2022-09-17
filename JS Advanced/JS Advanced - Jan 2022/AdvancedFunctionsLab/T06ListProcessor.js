solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);

function solve(input) {

    let firstZeroTest = solution();

    for (const iterator of input) {
        let commandPair = iterator.split(' ');
        let command = commandPair[0];

        if (command == 'add') {
            firstZeroTest.add(commandPair[1]);
        } else if (command == 'remove') {
            firstZeroTest.remove(commandPair[1]);
        } else if (command == 'print') {
            firstZeroTest.print();
        }
    }

    function solution() {
        let result = [];

        return {
            add(str) {
                result.push(str);
            },
            remove(word) {
                result = result.filter(x => x !== word);
            },
            print() {
                console.log(result.join(','));
            }
        }
    }
}

