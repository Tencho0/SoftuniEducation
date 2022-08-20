function solve(arr) {

    let result = [];

    // arr = arr.map(x => Number(x));
    arr.sort((a, b) => {
        return a - b;
    });
    result.push(arr[0]);
    result.push(arr[1]);

    console.log(result.join(' '));
}


solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);