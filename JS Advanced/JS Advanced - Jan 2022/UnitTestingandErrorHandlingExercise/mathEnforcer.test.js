const mathEnforcer = require('./mathEnforcer');
const { assert } = require('chai');

describe('mathEnforcer function test', () => {

    describe('add five function tests', () => {

        it('Test with valid data should return true asnwer', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
            assert.equal(mathEnforcer.addFive(0), 5);
            assert.equal(mathEnforcer.addFive(40.5), 45.5);
            assert.equal(mathEnforcer.addFive(-15), -10);
        });

        it('Test with invalid data should return undefined', () => {
            assert.equal(mathEnforcer.addFive('5'), undefined);
            assert.equal(mathEnforcer.addFive([]), undefined);
            assert.equal(mathEnforcer.addFive({}), undefined);
            assert.equal(mathEnforcer.addFive(undefined), undefined);
            assert.equal(mathEnforcer.addFive(null), undefined);
        });

    });

    describe('subtractTen function tests', () => {

        it('Test with valid data should return true asnwer', () => {
            assert.equal(mathEnforcer.subtractTen(5), -5);
            assert.equal(mathEnforcer.subtractTen(-5), -15);
            assert.equal(mathEnforcer.subtractTen(15.5), 5.5);
            assert.equal(mathEnforcer.subtractTen(55), 45);
        });

        it('Test with invalid data should return undefined', () => {
            assert.equal(mathEnforcer.subtractTen('5'), undefined);
            assert.equal(mathEnforcer.subtractTen([]), undefined);
            assert.equal(mathEnforcer.subtractTen({}), undefined);
            assert.equal(mathEnforcer.subtractTen(undefined), undefined);
            assert.equal(mathEnforcer.subtractTen(null), undefined);
        });

    });


    describe('sum function tests', () => {

        it('Test with valid data should return true asnwer', () => {
            assert.equal(mathEnforcer.sum(5, 5), 10);
            assert.equal(mathEnforcer.sum(5, 40), 45);
            assert.equal(mathEnforcer.sum(5.5, 40), 45.5);
            assert.equal(mathEnforcer.sum(5.5, 40.5), 46);
            assert.equal(mathEnforcer.sum(0, 0), 0);
            assert.equal(mathEnforcer.sum(-11, -10), -21);
        });

        it('Test with invalid data should return undefined', () => {
            assert.equal(mathEnforcer.sum(2, '4'), undefined);
            assert.equal(mathEnforcer.sum(2, []), undefined);
            assert.equal(mathEnforcer.sum(2, {}), undefined);
            assert.equal(mathEnforcer.sum('5', 2), undefined);
            assert.equal(mathEnforcer.sum([], 2), undefined);
            assert.equal(mathEnforcer.sum({}, 2), undefined);
            assert.equal(mathEnforcer.sum('5', '5'), undefined);
            assert.equal(mathEnforcer.sum([], []), undefined);
            assert.equal(mathEnforcer.sum({}, {}), undefined);
            assert.equal(mathEnforcer.sum(undefined), undefined);
            assert.equal(mathEnforcer.sum(null), undefined);
        });

    });

});