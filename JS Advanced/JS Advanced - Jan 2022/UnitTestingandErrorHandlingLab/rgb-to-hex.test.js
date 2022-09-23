const expect = require('chai').expect;
const rgbToHexColor = require('./rgb-to-hex');

describe('rgb to hex color tests', () => {
    it('Should return undefined with strings in input', () => {
        expect(rgbToHexColor('some string', 2, 3)).to.equal(undefined);
        expect(rgbToHexColor(2, 'some string', 3)).to.equal(undefined);
        expect(rgbToHexColor(2, 2, 'some string')).to.equal(undefined);
    });
    it('Should return undefined with input less than zero', () => {
        expect(rgbToHexColor(-1, 2, 3)).to.equal(undefined);
        expect(rgbToHexColor(1, -2, 3)).to.equal(undefined);
        expect(rgbToHexColor(1, 2, -3)).to.equal(undefined);
    });
    it('Should return undefined with input more than 255', () => {
        expect(rgbToHexColor(261, 2, 3)).to.equal(undefined);
        expect(rgbToHexColor(1, 262, 3)).to.equal(undefined);
        expect(rgbToHexColor(1, 2, 263)).to.equal(undefined);
    });
    it('Should return correct data', () => {
        let red = 1;
        let green = 2;
        let blue = 3;
        let result = rgbToHexColor(red, green, blue);
        let expected = "#" +
            ("0" + red.toString(16).toUpperCase()).slice(-2) +
            ("0" + green.toString(16).toUpperCase()).slice(-2) +
            ("0" + blue.toString(16).toUpperCase()).slice(-2);
        expect(result).to.equal(expected);
    });
});