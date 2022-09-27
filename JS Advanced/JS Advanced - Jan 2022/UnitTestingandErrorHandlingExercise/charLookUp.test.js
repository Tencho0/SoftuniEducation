const lookupChar = require('./charLookUp');
const { assert } = require('chai');

describe('lookupchar function tests', () => {

    it('test with invalid fist input parameter', () => {
        assert.equal(lookupChar(3, 4), undefined);
    });

    it('test with invalid second input parameter', () => {
        assert.equal(lookupChar('pesho', 'tosho'), undefined);
    });

    it('test with invalid parameters', () => {
        assert.equal(lookupChar(3, 'tosho'), undefined);
    });

    it('test with index bigger than length', () => {
        assert.equal(lookupChar('pesho', 15), 'Incorrect index');
        assert.equal(lookupChar('pesho', 5), 'Incorrect index');
        assert.equal(lookupChar('l', 1), 'Incorrect index');
        assert.equal(lookupChar('', 0), 'Incorrect index');
    });

    it('test with index less than zero', () => {
        assert.equal(lookupChar('pesho', -1), 'Incorrect index');
    });

    it('test with correct data', () => {
        let string = 'pesho';
        let index = 3;
        assert.equal(lookupChar(string, index), string.charAt(index));
        assert.equal(lookupChar('l', 0), 'l');
    });
});




// describe("look up char", () => {
//     it('should return undefined when the first input is not a string', () => {
//         //arrange phase
//         let expected = undefined;
//         //assert and act phase
//         expect(lookupChar(0, 0)).to.equal(expected);
//         expect(lookupChar(undefined, 0)).to.equal(expected);
//         expect(lookupChar(null, 0)).to.equal(expected);
//         expect(lookupChar([], 0)).to.equal(expected);
//         expect(lookupChar({}, 0)).to.equal(expected);
//     })
//     it('should return undefined when the second input is not an intiger', () => {
//         //arrange phase
//         let expected = undefined;
//         //assert  and act phase
//         expect(lookupChar('hello', "1")).to.equal(expected);
//         expect(lookupChar('hello', [])).to.equal(expected);
//         expect(lookupChar('hello', {})).to.equal(expected);
//         expect(lookupChar('hello', null)).to.equal(expected);
//         expect(lookupChar('hello', 4.4)).to.equal(expected);
//         expect(lookupChar('hello', '')).to.equal(expected);
 
//     })
 
//     it('should return "Incorrect Index" if the second param is out of range to the strings length', () => {
//         //arrange phase
//         let expected = "Incorrect index";
//         //assert and act phase
//         expect(lookupChar('hello', -1)).to.equal(expected);
//         expect(lookupChar('hello', 5)).to.equal(expected);
//         expect(lookupChar('hello', 100)).to.equal(expected);
//         expect(lookupChar('hello', -100)).to.equal(expected);
//         expect(lookupChar('', 0)).to.equal(expected);
 
//     })
 
//     it('should return the char of the string at the given index - happy case', () => {
//         //assert  and act phase
//         expect(lookupChar('hello', 0)).to.equal('h');
//         expect(lookupChar('hello', 4)).to.equal('o');
//         expect(lookupChar('hello', 3)).to.equal('l');
//     })
// })
 
