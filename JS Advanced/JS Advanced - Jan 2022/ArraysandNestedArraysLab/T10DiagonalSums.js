// function solve(arr) {
//     let firstSum = 0;
//     let secondSum = 0;
//     let matrix = [[]];
//     matrix = arr;

//     for (let row = 0; row < matrix.length; row++) {
//         const currRow = matrix[row];

//         for (let col = 0; col < currRow.length; col++) {
//             const element = currRow[col];
//             if (row === col) {
//                 //  firstSum += arr[row][col];
//                 firstSum += element;
//             }
//         }
//         for (let col = currRow.length - 1; col > 0; col--) {
//             const element = currRow[col];
//             if (col === currRow.length - row) {
//                 secondSum += element;
//             }
//         }
//     }
//     return `${firstSum} ${secondSum}`
// }




function solve(arr) {
    let mainSum = 0;
    let secondarySum = 0;
    let matrix = arr;
    for (let row = 0; row < matrix.length; row++) {
        mainSum += matrix[row][row];
        secondarySum += matrix[row][matrix.length - row - 1];
    }

    return mainSum + ' ' + secondarySum;
}




console.log(solve([[20, 40],
[10, 60]]
));
console.log(solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]
));