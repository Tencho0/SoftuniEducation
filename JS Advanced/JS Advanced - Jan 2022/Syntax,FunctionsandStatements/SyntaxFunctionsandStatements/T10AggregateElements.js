function aggregateElements(array){
    let numbers = array.map(Number);
    let sum = numbers.reduce((a,b) => a + b);
    let inverseValues = 0;

    for (let index = 0; index < numbers.length; index++) {
        inverseValues += 1 / numbers[index];
    }

    let concateNums = numbers.Join(' ');

    console.log(sum);
    console.log(inverseValues);
    console.log(concateNums);
}

aggregateElements(5, 6, 7, 8);