function solve(input) {
    let towns = [];

    input.shift();
    for (const iterator of input) {
        let [Town, Latitude, Longitude] = iterator.split(' | ');

        Town = Town.split('| ')[1];
        Latitude = Number(Latitude).toFixed(2);
        Longitude = Number(Longitude.split(' |')[0]).toFixed(2);

        towns.push({ Town, Latitude: Number(Latitude), Longitude: Number(Longitude) });
    }

    // for (const iterator of input) {
    //     let [firstWord, secondWord, thirdWord] = iterator.split(' | ');
    //     let Town = firstWord.split('| ')[0];
    //     let Latitude = Number(secondWord);
    //     let Longitude = Number(thirdWord.split(' |')[0]);
    //     towns.push({ Town, Latitude, Longitude });
    // }


    // let givenWords = input.split(' | ', '| ', ' |')
    // for (let index = 0; index < input.length; index += 3) {
    //     const element = input[index];
    //     const secondElement = Number(input[index + 1]);
    //     const thirdElement = Number(input[index + 2]);
    //     let town = {
    //         Town: element,
    //         Latitude: secondElement,
    //         Longitude: thirdElement
    //     };
    //     towns.push(town);
    // }

    // for (const iterator of towns) {
    //     console.log(iterator);
    // }

    return JSON.stringify(towns);
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']));