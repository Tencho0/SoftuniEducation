const sumOfTwoNumbers = require('./index');
const { assert } = require('chai');

describe('Sum of two numbers function tests', () => {
   
    it('test with two numbers', () => {
        assert.equal(sumOfTwoNumbers(3, 4), 7);
    });
  
    it('test with string and number', () => {
        assert.equal(sumOfTwoNumbers('3', 4), 7);
    });
    
});