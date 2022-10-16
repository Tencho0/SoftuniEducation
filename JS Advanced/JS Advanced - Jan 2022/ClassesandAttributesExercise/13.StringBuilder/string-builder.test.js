let { expect } = require('chai');
let StringBuilder = require('./string-builder');

describe('StringBuilder', () => {
    describe('Constructor', () => {

        it('Should initialize with empty array if undefined is passed', () => {
            let sb = new StringBuilder(undefined);
            expect(sb.toString()).to.equal('');
        })
        it('Should throw error if passed a non-string argument', () => {
            expect(() => new StringBuilder(1.23)).to.throw(TypeError);
            expect(() => new StringBuilder(null)).to.throw(TypeError);
        })
        it('Should initialize correct array when passed a valid string', () => {
            let sb1 = new StringBuilder('abc');
            let sb2 = new StringBuilder('test');

            expect(sb1.toString()).to.equal('abc');
            expect(sb2.toString()).to.equal('test');
        })

    })

    describe('append', () => {

        it('Should throw when passed a non-string argument', () => {
            let sb = new StringBuilder();
            let sb2 = new StringBuilder();

            expect(() => sb.append(true)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb2.append(123)).to.throw(TypeError);
        })

        it('Should append only the string chars when passed a string argument', () => {
            let expected = '123';
            let expected2 = 'abcd';
            let sb = new StringBuilder('abc');
            let sb2 = new StringBuilder('vda');

            sb.append(expected);
            sb2.append(expected2);

            expect(sb.toString()).to.equal('abc123');
            expect(sb2.toString()).to.equal('vdaabcd');

            sb.append('wow');
            sb.remove(7, 1);
            expect(sb.toString()).to.equal('abc123ww');
        })
    })

    describe('prepend', () => {

        it('Should throw when passed a non-string argument', () => {
            let sb = new StringBuilder();
            let sb2 = new StringBuilder();

            expect(() => sb.prepend(true)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb2.prepend(123)).to.throw(TypeError);
        })

        it('Should prepend correctly when passed a string argument', () => {
            let expected = '123';
            let expected2 = 'abcd';
            let sb = new StringBuilder('abc');
            let sb2 = new StringBuilder('vda');

            sb.prepend(expected);
            sb2.prepend(expected2);

            expect(sb.toString()).to.equal('123abc');
            expect(sb2.toString()).to.equal('abcdvda');
        })

        it('Should prepend chars at correct index when passed a string argument', () => {
            let expected = '123';
            let expected2 = 'abcd';
            let sb = new StringBuilder('abc');
            let sb2 = new StringBuilder('vda');

            sb.prepend(expected);
            sb2.prepend(expected2);

            expect(sb.toString()).to.equal('123abc');
            expect(sb2.toString()).to.equal('abcdvda');

            sb.prepend('wow');
            sb.remove(6,1);
            expect(sb.toString()).to.equal('wow123bc');
        })

    })

    describe('insertAt', () => {

        it('Should throw when passed a non-string argument', () => {
            let sb = new StringBuilder();
            let sb2 = new StringBuilder();

            expect(() => sb.insertAt(true, 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb2.insertAt(123, 0)).to.throw(TypeError);
        })

        it('Should insert chars at correct index when passed a valid string', () => {
            let expected = ' fast';
            let expected2 = ' are';
            let sb = new StringBuilder('cars');

            sb.insertAt(expected, 4);
            expect(sb.toString()).to.equal('cars fast');

            sb.insertAt(expected2, 4);
            expect(sb.toString()).to.equal('cars are fast');
        })

        it('Should insert chars at correct index when passed a valid string', () => {
            let expected = ' fast';
            let expected2 = ' are';
            let sb = new StringBuilder('cars');

            sb.insertAt(expected, 4);
            expect(sb.toString()).to.equal('cars fast');

            sb.insertAt(expected2, 4);
            expect(sb.toString()).to.equal('cars are fast');

            sb.remove(11,1);
            expect(sb.toString()).to.equal('cars are fat');
        })
    })

    describe('remove', () => {

        it('Should remove chars at correct index', () => {
            let sb = new StringBuilder('cars are fast');

            sb.remove(11, 1);
            expect(sb.toString()).to.equal('cars are fat');

            sb.remove(4, 4);
            expect(sb.toString()).to.equal('cars fat');
        })

    })

    describe('toString', () => {

        it('Should return correct string representation internal array when called', () => {
            let sb = new StringBuilder();
            let sb2 = new StringBuilder('cars are fast');

            expect(sb.toString()).to.equal('');
            expect(sb2.toString()).to.equal('cars are fast');
        })

    })
})