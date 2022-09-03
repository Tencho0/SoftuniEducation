function solve(input) {

    let foods = {};
    for (let index = 0; index < input.length; index += 2) {
        const element = input[index];
        const calories = Number(input[index + 1]);

        foods[element] = calories;
    }

    console.log(foods);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);