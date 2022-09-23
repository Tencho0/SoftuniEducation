const expect = require('chai').expect;
const sum = require('./sumNumbers');

describe('Sum calculate', () => {
    it('Should return the sum of numbers in the array', () => {
        let numbers = [1,2,3,4,5];
        let expected = 15;
        let actual = sum(numbers);
        expect(actual).to.equal(expected);
    });
});