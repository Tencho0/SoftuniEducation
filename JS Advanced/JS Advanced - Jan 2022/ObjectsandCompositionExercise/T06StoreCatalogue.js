function solve(input) {

    let letters = [];
    let sorted = input.sort((a, b) => a.localeCompare(b));

    for (const iterator of sorted) {
        let [productName, productPrice] = iterator.split(' : ');
        if (!letters.some(x => x === productName[0])) {
            letters.push(productName[0]);
        }
    }

    for (const iterator of letters) {
        console.log(iterator);
        for (const arr of sorted.filter(x => x.split(' : ')[0][0] == iterator)) {
            let [word, price] = arr.split(' : ');
            console.log(`  ${word}: ${price}`);
        }
    }
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);

solve(['Banana : 2',
    'Rubics Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']);