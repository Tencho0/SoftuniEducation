const isOddOrEven = require('./isOddOrEven');
const { assert } = require('chai');

describe('isOddOrEven tests', () => {

    it('test with correct odd string', () => {
        assert.equal(isOddOrEven('pesho'), 'odd');
    });

    it('test with correct even string', () => {
        assert.equal(isOddOrEven('peshka'), 'even');
    });

    it('test with incorrect string', () => {
        assert.equal(isOddOrEven(10), undefined);
        assert.equal(isOddOrEven([]), undefined);
        assert.equal(isOddOrEven({}), undefined);
    });
});