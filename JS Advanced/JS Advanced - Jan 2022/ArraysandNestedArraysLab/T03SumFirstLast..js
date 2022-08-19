function solve(input) {

    let result = Number(input.pop());
    result += Number(input.shift());

    console.log(result);
}

solve(['20', '30', '40', '50', '60']);
solve(['5', '10']);