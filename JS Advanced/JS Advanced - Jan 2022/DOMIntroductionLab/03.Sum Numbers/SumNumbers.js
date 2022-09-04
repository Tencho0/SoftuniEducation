function calc() {
    let firstEl = document.getElementById('num1');
    let secondEl = document.getElementById('num2');
    let sum = document.getElementById('sum');
    sum.value = Number(firstEl.value) + Number(secondEl.value);
}
