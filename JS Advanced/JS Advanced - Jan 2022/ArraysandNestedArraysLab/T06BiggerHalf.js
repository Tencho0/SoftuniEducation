
function solve(arr) {

    let result = [];

    arr.sort((a, b) => {
        return a - b;
    });

    for (let index = Math.floor(arr.length / 2); index < arr.length; index++) {
        result.push(arr[index]);    
    }

    return result;
}
