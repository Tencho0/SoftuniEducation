function solve(input1, input2, input3){

    let name = input1;
    let population = Number(input2);
    let treasury = Number(input3);

    let city = {
        name: name,
        population: population,
        treasury: treasury,
    };

    return city;
}

solve('Tortuga',
7000,
15000);