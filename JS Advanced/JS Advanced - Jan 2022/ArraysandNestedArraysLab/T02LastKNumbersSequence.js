function solve(input) {

    // let firstNum = Number(input);
    // let secondNum = Number(input2);
    // let arr = [1];

    if (secondNum > 1) {
        arr.push(1);
    }

    if (secondNum > 2) {
        arr.push(2);
    }

    for (let index = secondNum; index < firstNum; index++) {
        arr[index] = 0;
        for (let i = 1; i <= secondNum; i++) {
            arr[index] += arr[index - i];
        }
    }

    console.log(arr);
}

solve(6, 3);
solve(8, 2);