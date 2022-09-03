function solve(input) {

    let power;
    let volume;
    let wheels = [];

    if (input.power <= 90) {
        volume = 1800;
        power = 90;
    } else if (input.power <= 120) {
        power = 120;
        volume = 2400;
    } else {
        power = 200;
        volume = 3500;
    }

    let wheelsize = input.wheelsize;
    if (wheelsize % 2 == 0) wheelsize--;

    for (let index = 0; index < 4.; index++) {
        wheels.push(wheelsize);
    }

    let car = {
        model: input.model,
        engine: {
            power,
            volume
        },
        carriage: {
            type: input.carriage,
            color: input.color
        },
        wheels
    };

    return car;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));