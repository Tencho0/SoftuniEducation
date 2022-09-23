//const expect = require('chai').expect;
const assert = require('mocha').assert;
const createCalculator = require('./addSubtract');

describe('create calculator tests', () => {
    it('Should return object', () => {
        let calculator = createCalculator();
        
        // expect(calculator['add']).to.true;
        // expect(calculator['subtract']).to.true;
        // expect(calculator['get']).to.true;
    });
});