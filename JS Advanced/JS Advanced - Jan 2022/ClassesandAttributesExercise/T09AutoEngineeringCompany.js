function solve(input) {
    const brands = {};

    for (const item of input) {
        const [brand, model, quant] = item.split(" | ");

        if (!brands.hasOwnProperty(brand)) {
            brands[brand] = {};
        }

        if (!brands[brand].hasOwnProperty(model)) {
            brands[brand][model] = 0;
        }

        brands[brand][model] += Number(quant);
    }

    for (const [brand, models] of Object.entries(brands)) {
        console.log(brand);

        for (const [model, quant] of Object.entries(models)) {
            console.log(`###${model} -> ${quant}`);
        }
    }
}






// function solve(input) {
//     let collection = new Map();

//     for (let line of input) {
//         let [brand, model, prodCars] = line.split(' | ');
//         prodCars = Number(prodCars);

//         if (!collection.has(brand)) {
//             collection.set(brand, new Map());
//         }

//         if (collection.get(brand).has(model)) {
//             collection.get(brand).set(model, collection.get(brand).get(model) + prodCars);
//         } else {
//             collection.get(brand).set(model, prodCars);
//         }
//     }

//     for (let [brand, models] of collection.entries()) {
//         console.log(brand);

//         for (let [model, prodCars] of models.entries()) {
//             console.log(`###${model} -> ${prodCars}`);
//         }
//     }
// }






// // function solve(input) {
// //     let brands = new Map();
// //     while (input.length > 0) {
// //         let [brand, model, quantity] = input.shift().split(' | ');
// //         let models = new Map();

// //         if (!brands.has(brand)) {
// //             models.set(model, quantity);
// //             brands.set(brand, model);
// //         } else {
// //             let models = brands.get(brand);
// //             if (!models.has(model)) {
// //                 models.set(model, quantity);
// //             } else {
// //                 let currentQuantity = brands.get(brand);
// //                 models.set(model, currentQuantity + Number(quantity));
// //             }
// //             brands.set(brand, models);
// //         }
// //     }
// // }

// // solve(['Audi | Q7 | 1000',
// //     'Audi | Q6 | 100',
// //     'BMW | X5 | 1000',
// //     'BMW | X6 | 100',
// //     'Citroen | C4 | 123',
// //     'Volga | GAZ-24 | 1000000',
// //     'Lada | Niva | 1000000',
// //     'Lada | Jigula | 1000000',
// //     'Citroen | C4 | 22',
// //     'Citroen | C5 | 10']);