let chooseYourCar = require('../03.Choose_Your_Car_Resources/chooseYourCar');
let { assert } = require('chai');

describe("choose your car tests", function () {
    describe("choosingType tests", function () {
        it("test should throw error with invalid year", function () {
            assert.throws(() => chooseYourCar.choosingType('Sedan', 'White', 2023), `Invalid Year!`);
            assert.throws(() => chooseYourCar.choosingType('Sedan', 'Purple', 1899), `Invalid Year!`);
        });
        it("test should throw error with invalid type", function () {
            assert.throws(() => chooseYourCar.choosingType('Coupe', 'White', 2022), `This type of car is not what you are looking for.`);
            assert.throws(() => chooseYourCar.choosingType('cabrio', 'Purple', 1900), `This type of car is not what you are looking for.`);
            assert.throws(() => chooseYourCar.choosingType('Coupe', 'White', 2012), `This type of car is not what you are looking for.`);
            assert.throws(() => chooseYourCar.choosingType('cabrio', 'Purple', 1990), `This type of car is not what you are looking for.`);
        });
        it("test should return correct result with year after 2010", function () {
            let color = 'black';
            let type = 'Sedan';
            let expected = `This ${color} ${type} meets the requirements, that you have.`;
            let actual = chooseYourCar.choosingType(type, color, 2010);
            assert.equal(expected, actual);
            let actual2 = chooseYourCar.choosingType(type, color, 2011);
            assert.equal(expected, actual2);
        });
        it("test should return correct result with year before 2010", function () {
            let color = 'black';
            let type = 'Sedan';
            let expected = `This ${type} is too old for you, especially with that ${color} color.`;
            let actual = chooseYourCar.choosingType(type, color, 2009);
            assert.equal(expected, actual);
            let actual2 = chooseYourCar.choosingType(type, color, 2002);
            assert.equal(expected, actual2);
        });
    });
    describe("brandName tests", function () {
        it("test should throw error with invalid input", function () {
            //  if (!Array.isArray(brands) || !Number.isInteger(brandIndex) || brandIndex < 0 || brandIndex >= brands.length) {
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], true), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], {}), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], []), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], 'Gossho'), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], 2), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], 3), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(['Sedan', 'White'], -3), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName([], 0), `Invalid Information!`);

            assert.throws(() => chooseYourCar.brandName({}, 2), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(true, 2), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName('Gosho', 2), `Invalid Information!`);
            assert.throws(() => chooseYourCar.brandName(2, 2), `Invalid Information!`);
        });
        it('test should return correct result', () => {
            assert.equal(chooseYourCar.brandName(["Petar", "Ivan", "George"], 1), `Petar, George`);
            assert.equal(chooseYourCar.brandName(["Petar"], 0), ``);
        })
    });
    describe("carFuelConsumption tests", function () {
        it('test should return correct result', () => {
            let consumptedFuelInLiters = 10;
            let distanceInKilometers = 100;
            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers) * 100).toFixed(2);
            let result = chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters);
            assert.equal(result, `The car burns too much fuel - ${litersPerHundredKm} liters!`);
        })
        it('test should return correct result 2', () => {
            let consumptedFuelInLiters = 7;
            let distanceInKilometers = 100;
            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers) * 100).toFixed(2);
            let result = chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters);
            assert.equal(result, `The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
        })
        it('test should return correct result 3', () => {
            let consumptedFuelInLiters = 6;
            let distanceInKilometers = 100;
            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers) * 100).toFixed(2);
            let result = chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters);
            assert.equal(result, `The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
        })
        it('test with invalid input should throw erro', () => {
            assert.throws(() => chooseYourCar.carFuelConsumption(1, 0), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption(0, 1), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption(1, -2), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption(-2, 1), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption(1, 'Gosho'), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption('Gosho', 1), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption('gosho', 0), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption(0, 0), `Invalid Information!`);
            assert.throws(() => chooseYourCar.carFuelConsumption(-1, -1), `Invalid Information!`);
        });
    });
}); 