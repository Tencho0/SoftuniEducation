function solve(arr, input1, input2) {

    let indexOfFirstElement = arr.indexOf(input1);
    let indexOfsecondElement = arr.indexOf(input2);

    let result = arr.slice(indexOfFirstElement, indexOfsecondElement + 1);

    return result;
}


console.log(solve(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));

console.log(solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));