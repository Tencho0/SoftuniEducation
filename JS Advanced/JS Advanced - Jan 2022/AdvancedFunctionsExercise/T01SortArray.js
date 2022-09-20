function solve(inputArr, inputString) {
    if (inputString === 'asc') {
        return inputArr.sort((a, b) => a - b);
    } else if (inputString === 'desc') {
        return inputArr.sort((a, b) => b - a);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));