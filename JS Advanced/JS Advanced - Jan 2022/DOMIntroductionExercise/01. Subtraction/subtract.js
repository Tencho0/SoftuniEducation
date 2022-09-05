function subtract() {
    let firstElement = document.getElementById('firstNumber');
    let secondElement = document.getElementById('secondNumber');

    let firstNum = Number(firstElement.value);
    let secondNum = Number(secondElement.value);

    let result = document.getElementById('result');
    result.textContent = (firstNum - secondNum);
}