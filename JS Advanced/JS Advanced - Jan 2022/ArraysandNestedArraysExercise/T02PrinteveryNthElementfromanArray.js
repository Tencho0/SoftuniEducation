function solve(arr, n) {

    let result = [];
    for (let index = 0; index < arr.length; index += n) {
        const element = arr[index];
        result.push(element);
    }
    return result;
}

console.log(solve(['5',
    '20',
    '31',
    '4',
    '20'],
    2
));