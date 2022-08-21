function solve(arr) {
    let result = [];
    arr.sort((a, b) => a - b);

    while (arr.length > 0) {
        result.push(arr.shift());
        result.push(arr.pop());
    }

    // for (let index = 0; index < arr.length / 2; index++) {
    //     let smallElement = arr[index];
    //     let bigElement = arr[index - 1];

    //     result.push(smallElement);
    //     result.push(bigElement);
    // }

    return result;
}