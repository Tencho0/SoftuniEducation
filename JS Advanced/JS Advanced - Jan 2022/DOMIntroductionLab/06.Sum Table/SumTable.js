function sumTable() {
    let sum = document.getElementById('sum');
    let prices = document.querySelectorAll('tbody tr:not(:first-child) td:nth-of-type(2n)')
    let totalSum = 0;
    for (let index = 0; index < prices.length - 1; index++) {
        const element = Number(prices[index].textContent);
        totalSum += element;
    }
    sum.textContent = totalSum;


    //Ivo's solutions
    // let costElements = document.querySelectorAll('tr td: td:nth-of-type(2)')
    // let sum = Array.from(costElements).reduce((a, x) => {
    //     let currValue = Number(x.textContent) || 0;
    //     return a + currValue;
    // }, 0);

    // let resultElement = document.getElementById('sum');
    // resultElement.textContent = sum;
}