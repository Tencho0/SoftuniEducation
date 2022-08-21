function solve(arr) {

    let result = true;
    let sum = arr[0].reduce((a, b) => a + b);
    arr.forEach(element => {
        let currSum = element.reduce((a, b) => a + b);
        if (currSum != sum) {
            result = false;
        }
    });

    for (let index = 0; index < arr.length; index++) {
        let currSum = 0;
        for (let row = 0; row < arr.length; row++) {
            const element = arr[row][index];
            currSum += element;
        }
        if (currSum != sum) {
            result = false;
        }
    }

    return result;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]));

console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]));

console.log(solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
));