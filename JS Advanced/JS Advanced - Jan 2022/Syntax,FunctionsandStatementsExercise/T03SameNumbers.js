function solve(input) {
    let inputAsString = input.toString();
    let firstNumber = Number(inputAsString[0]);
    let isSame = true;
    let sumOfDigits = 0;
    sumOfDigits += firstNumber;

    for (let index = 1; index < inputAsString.length; index++) {
        let number = Number(inputAsString[index]);
        if (number !== firstNumber) {
             isSame = false;
         }
        sumOfDigits += number;
    }

    console.log(isSame);
    console.log(sumOfDigits);
}
solve(2222222);