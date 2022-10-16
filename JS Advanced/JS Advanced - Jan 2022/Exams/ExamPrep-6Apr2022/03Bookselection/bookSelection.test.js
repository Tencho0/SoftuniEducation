// let { isGenreSuitable, isItAffordable, suitableTitles } = require('../03Bookselection/bookSelection');
const { assert } = require('chai');
const bookSelection = require('../03Bookselection/bookSelection');

describe("Tests for bookSelection", () => {

    describe("Test isGenreSuitable", () => {

        it("Check for invalid parameters", () => {

            // let age = 12;
            // let genre = 'Thriller';
            // let expected = `Books with ${genre} genre are not suitable for kids at ${age} age`;
            // assert.equal(isGenreSuitable(genre, age), expected);

            assert.equal(bookSelection.isGenreSuitable("Thriller", 12), `Books with Thriller genre are not suitable for kids at 12 age`);
            assert.equal(bookSelection.isGenreSuitable('Horror', 12), `Books with Horror genre are not suitable for kids at 12 age`);
            assert.equal(bookSelection.isGenreSuitable('Thriller', 10), `Books with Thriller genre are not suitable for kids at 10 age`);
            assert.equal(bookSelection.isGenreSuitable('Horror', 10), `Books with Horror genre are not suitable for kids at 10 age`);
        });

        it("Check for valid parameters", () => {
            assert.equal(bookSelection.isGenreSuitable("Thriller", 13), `Those books are suitable`);
            assert.equal(bookSelection.isGenreSuitable('Horror', 13), `Those books are suitable`);
            assert.equal(bookSelection.isGenreSuitable('Comedy', 10), `Those books are suitable`);
            assert.equal(bookSelection.isGenreSuitable('Action', 10), `Those books are suitable`);
        });
    });

    describe("Test isItAffordable", () => {

        it("Check for invalid input parameters", () => {
            assert.throws(() => bookSelection.isItAffordable("Thriller", 12), 'Invalid input');
            assert.throws(() => bookSelection.isItAffordable([], 12), 'Invalid input');
            assert.throws(() => bookSelection.isItAffordable({}, 12), 'Invalid input');
            assert.throws(() => bookSelection.isItAffordable(true, 12), 'Invalid input');

            assert.throws(() => bookSelection.isItAffordable(15, "Thriller"), 'Invalid input');
            assert.throws(() => bookSelection.isItAffordable(15, []), 'Invalid input');
            assert.throws(() => bookSelection.isItAffordable(15, {}), 'Invalid input');
            assert.throws(() => bookSelection.isItAffordable(15, true), 'Invalid input');
        });

        it("Check for valid parameters and not enought money", () => {
            let expected = "You don't have enough money";

            assert.equal(bookSelection.isItAffordable(16, 15), expected);
            assert.equal(bookSelection.isItAffordable(15.5, 15), expected);
        });

        it("Check for valid parameters and enought money", () => {
            assert.equal(bookSelection.isItAffordable(14, 15), `Book bought. You have 1$ left`);
            assert.equal(bookSelection.isItAffordable(14.5, 15), `Book bought. You have 0.5$ left`);
        });
    });

    describe("Test suitableTitles", () => {

        it("Check for invalid input parameters", () => {
            assert.throws(() => bookSelection.suitableTitles("Thriller", 'suitableTitles'), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles(11, 'suitableTitles'), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles({}, 'suitableTitles'), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles(true, 'suitableTitles'), 'Invalid input');

            assert.throws(() => bookSelection.suitableTitles([], 21), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles([], []), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles([], {}), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles([], true), 'Invalid input');
        });

        it("Check for valid parameters", () => {
            let expectedGenre = 'Horror';
            let expectedResult = [];
            let givenArr = [
                { genre: expectedGenre, title: 'Some horror movie' },
                { genre: 'Comedy', title: 'Some comedy movie' },
                { genre: 'Thriller', title: 'Some thriller movie' },
                { genre: expectedGenre, title: 'Second horror movie' },
                { genre: 'Thriller', title: 'Second thriller movie' },
                { genre: expectedGenre, title: 'Third horror movie' },
                { genre: 'Comedy', title: 'Second comedy movie' },
            ];

            expectedResult.push('Some horror movie');
            expectedResult.push('Second horror movie');
            expectedResult.push('Third horror movie');

            assert.deepEqual(bookSelection.suitableTitles(givenArr, expectedGenre), expectedResult);
        });
    });
});