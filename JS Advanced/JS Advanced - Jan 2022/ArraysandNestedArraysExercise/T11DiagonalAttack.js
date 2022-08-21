function diagonalSums(input) {

    let matrix = [];
    while (input.length > 0) {
        matrix.push(input.shift().split(' ').map(Number));
    }

    let mainSum = 0;
    let secondarySum = 0;
    for (let row = 0; row < matrix.length; row++) {
        mainSum += matrix[row][row];
        secondarySum += matrix[row][matrix.length - row - 1];
    }

    if (mainSum === secondarySum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                const element = matrix[col];
                // if (row !== col && matrix.length - row !== col) {
                if (col !== matrix.length - row - 1 && row !== col) {
                    matrix[row][col] = mainSum;
                }
            }
        }
    }
    matrix.forEach(element => {
        console.log(element.join(' '));
    });
}

diagonalSums(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

diagonalSums(['1 1 1',
    '1 1 1',
    '1 1 0']
);