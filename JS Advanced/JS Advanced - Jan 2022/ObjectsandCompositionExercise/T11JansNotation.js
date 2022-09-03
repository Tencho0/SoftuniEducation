function solve(input) {
    let operands = [];
    let wasWrong = false;

    for (let index = 0; index < input.length; index++) {
        if (typeof input[index] === 'number') {
            operands.push(input[index]);
        } else {
            let operator = input[index];
            if (operands.length < 2) {
                console.log('Error: not enough operands!');
                wasWrong = true;
                break;
            }
            let operand2 = operands.pop();
            let operand1 = operands.pop();
            let result = applyOperation(operand1, operand2, operator);
            operands.push(result);
        }
    }

    if (operands.length > 1 && wasWrong === false) {
        console.log('Error: too many operands!');
    } else if (wasWrong === false) {
        console.log(operands[0]);
    }

    function applyOperation(operand1, operand2, operator) {
        const arithmethicOperator = {
            '+': () => operand1 + operand2,
            '-': () => operand1 - operand2,
            '/': () => operand1 / operand2,
            '*': () => operand1 * operand2,
        }
        return arithmethicOperator[operator]();
    }

}

solve([3,
    4,
    '+']);

solve([5,
    3,
    4,
    '*',
    '-']);

solve([7,
    33,
    8,
    '-'])