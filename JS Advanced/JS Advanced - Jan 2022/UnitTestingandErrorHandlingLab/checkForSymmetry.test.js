const expect = require('chai').expect;
const isSymmetric = require('./checkForSymmetry');

describe('Is Symmetric', () => {
    it('Should return false with not array input', () => {
        expect(isSymmetric({})).to.false;
        expect(isSymmetric(2)).to.false;
        expect(isSymmetric('pesho')).to.false;
        expect(isSymmetric(true)).to.false;
    });
    it('Should return true with symmetric array', () => {
        expect(isSymmetric([1, 2, 3, 2, 1])).to.true;
        expect(isSymmetric([3, 2, 1, 2, 3])).to.true;
    });
    it('Should return false with not symmetric array', () => {
        expect(isSymmetric([1, 2, 3, 2, 1])).to.true;
        expect(isSymmetric([1, 3, 3, 2, 1])).to.true;
        expect(isSymmetric([1, 17, 45, 21, 1])).to.true;
    });
});