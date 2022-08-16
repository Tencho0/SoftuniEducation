function solve(first, second, third) {
    let firstLegth = first.length;
    let secondLegth = second.length;
    let thirdLegth = third.length;

    let sum = firstLegth + secondLegth + thirdLegth;
    let result = Math.floor(sum / 3);

    console.log(sum);
    console.log(result);
}

solve('chocolate', 'ice cream', 'cake');
