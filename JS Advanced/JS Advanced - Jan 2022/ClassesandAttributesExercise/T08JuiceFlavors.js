function cappy(input = []) {
    const bottles = new Map();

    input.reduce((acc, curr) => {
        let [juice, quantity] = curr.split(" => ");
        quantity = Number(quantity);

        if (!acc.hasOwnProperty(juice)) {
            acc[juice] = 0;
        }
        acc[juice] += quantity;

        if (acc[juice] >= 1000) {
            if (!bottles.has(juice)) {
                bottles.set(juice, 0);
            }

            bottles.set(juice, bottles.get(juice) + parseInt(acc[juice] / 1000));
            acc[juice] %= 1000;
        }

        return acc;
    }, {});

    for (let [juice, quantity] of bottles) {
        console.log(`${juice} => ${quantity}`);
    }
}




// function solve(input) {
//     let map = new Map();
//     for (const iterator of input) {
//         let [juiceName, juiceQuantity] = iterator.split(' => ');
//         if (!map.has(juiceName)) {
//             map[juiceName] = 0;
//         }
//         map[juiceName] += Number(juiceQuantity);
//     }
//     for (const iterator of map.keys()) {
//         if (map[iterator] > 1000) {
//             let bottles = (map[iterator] / 1000).toFixed(0);
//             //console.log(bottles);
//         }
//     }

//     // for (let [juice, quantity] of map) {
//     //     console.log(`${juice} => ${quantity}`);
//     // }

//     // for (const [key, value] of map) {
//     //     console.log(key, value); // 👉️ country Chile, age 30
//     // }
//     // console.log(map);
//     // for (const key of map.keys()) {
//     //     console.log(key);
//     // }
//     // Array.from(map).forEach((value, key) => {
//     //     console.log(value);
//     // })
//     // for (let [name, quantity] of map.entries()) {
//     //     console.log(name);
//     // }
// }

// solve(['Orange => 2000',
//     'Peach => 1432',
//     'Banana => 450',
//     'Peach => 600',
//     'Strawberry => 549']);