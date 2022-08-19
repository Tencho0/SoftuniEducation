function solve(arr) {

    let result = [];

    for (let index = 0; index < arr.length; index++) {
        let element = arr[index];
        if (element < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    }

    console.log(result.join('\n'));
}


solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);