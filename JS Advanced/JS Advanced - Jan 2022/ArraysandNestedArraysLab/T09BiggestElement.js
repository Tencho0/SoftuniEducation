function solve(arr) {
    let biggestNum = Number.MIN_VALUE;
    for (let currArr of matrix) {
        for (let currElement of currArr) {
            if(currElement > biggestNum){
                biggestNum = currElement;
            }
        }
    }
    return biggestNum;
}

console.log(solve([[20, 50, 10],
[8, 33, 145]]
));
console.log(solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
));


// function solve(arr){
//     var matrix = arr.map(row => row.split(' ').map(Number));
//     return matrix; }
// console.log(solve(['20 50 10', '8 33 145']));
