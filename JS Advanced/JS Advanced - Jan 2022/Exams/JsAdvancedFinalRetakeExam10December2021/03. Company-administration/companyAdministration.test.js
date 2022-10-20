let companyAdministration = require('../03. Company-administration/companyAdministration');
let { assert } = require('chai');

describe("companyAdministration tests", () => {
    describe("hiringEmployee tests", () => {

        it("Test should throw error", () => {
            assert.throws(() => companyAdministration.hiringEmployee('Pesho', 'Cleaner', 2), 'We are not looking for workers for this position.');
        });

        it("Not enought years experiencde", () => {
            assert.equal(companyAdministration.hiringEmployee('Pesho', 'Programmer', 2), 'Pesho is not approved for this position.');
        });

        it("It should return correct data", () => {
            let name = 'Pesho';
            let position = 'Programmer';
            assert.equal(companyAdministration.hiringEmployee(name, position, 3), `${name} was successfully hired for the position ${position}.`);
            assert.equal(companyAdministration.hiringEmployee(name, position, 4), `${name} was successfully hired for the position ${position}.`);
        });
    });

    describe("calculateSalary tests", () => {

        it("Test with invalid hours should throw error", () => {
            assert.throws(() => companyAdministration.calculateSalary(-1), 'Invalid hours');
            assert.throws(() => companyAdministration.calculateSalary([]), 'Invalid hours');
            assert.throws(() => companyAdministration.calculateSalary({}), 'Invalid hours');
            assert.throws(() => companyAdministration.calculateSalary(false), 'Invalid hours');
            assert.throws(() => companyAdministration.calculateSalary('Gosho'), 'Invalid hours');
        });

        it("Test should return total amount without bonus", () => {
            assert.equal(companyAdministration.calculateSalary(0), 0);
            assert.equal(companyAdministration.calculateSalary(1), 15);
            assert.equal(companyAdministration.calculateSalary(5), 5 * 15);
            assert.equal(companyAdministration.calculateSalary(160), 160 * 15);
        });

        it("Test should return total amount with bonus", () => {
            assert.equal(companyAdministration.calculateSalary(161), 161 * 15 + 1000);
            assert.equal(companyAdministration.calculateSalary(200), 200 * 15 + 1000);
        });
    });

    describe("firedEmployee tests", () => {

        it("Test with invalid input should throw error", () => {
            assert.throws(() => companyAdministration.firedEmployee('Pesho', 2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee({}, 2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee(true, 2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee(2, 2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee(2, 2.2), 'Invalid input');


            assert.throws(() => companyAdministration.firedEmployee([], 'Pesho'), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee([], -2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee([], -2.2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee([], 2.2), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee([], []), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee([], {}), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee([], true), 'Invalid input');

            assert.throws(() => companyAdministration.firedEmployee(['Pesho', 'Gosho', 'Sasho'], 3), 'Invalid input');
            assert.throws(() => companyAdministration.firedEmployee(['Pesho', 'Gosho', 'Sasho'], 5), 'Invalid input');
        });

        it('Test should return correct result', () => {
            let employees = ['Sasho', 'Ivan', 'Todor', 'Pesho', 'Gosho'];
            let index = 2;

            let result = [];
            for (let i = 0; i < employees.length; i++) {
                if (i !== index) {
                    result.push(employees[i]);
                }
            }
            let expectedResult = result.join(", ");

            assert.equal(companyAdministration.firedEmployee(employees, index), expectedResult);
            assert.equal(companyAdministration.firedEmployee(['Gosho'], 0), '');
        });
    });
});
