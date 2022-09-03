function solve(input) {

    let products = [];

    for (const iterator of input) {
        let [town, product, price] = iterator.split(' | ');
        price = Number(price);
        
        if (products.some(x => x.product === product)) {
            let obj = products.find(x => x.product === product);

            if (price < obj.price) {
                obj.price = price;
                obj.town = town;
            }

        } else {
            products.push({ town, product, price });
        }
    }

    // while (input.length > 0) {

    //     let [town, product, price] = input.shift().split(' | ');

    //     if (products.some(x => x.product === product)) {
    //         let obj = products.find(x => x.product === product);

    //         if (price < obj.price) {
    //             obj.price = price;
    //             obj.town = town;
    //         }

    //     } else {
    //         products.push({ town, product, price });
    //     }
    // }
    for (const iterator of products) {
        console.log(`${iterator.product} -> ${iterator.price} (${iterator.town})`);
    }
}

// solve(['Sample Town | Sample Product | 1000',
//     'Sofia | Orange | 3',
//     'Sample Town | Orange | 2',
//     'Sofia | Peach | 2',
//     'Burgas | Peach | 1',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10']
// );


solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000',
]);