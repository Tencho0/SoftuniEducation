let PaymentPackage = require('./PaymentPackage');
let { assert } = require('chai');

describe('PaymentPackage', () => {
    describe('create instance', () => {
        let paymentPackage;
        beforeEach(() => {
            paymentPackage = new PaymentPackage('Todor', 10);
        });

        it('name should be correct', () => {
            assert.equal(paymentPackage._name, 'Todor', 'name has correct set to Todor');
        });
        it('value should be correct', () => {
            assert.equal(paymentPackage._value, 10, 'value has correct set to 10');
        });
        it('vat should be correct', () => {
            assert.equal(paymentPackage._VAT, 20, 'default VAT is set correct');
            assert.equal(typeof (paymentPackage._VAT), 'number', 'vat is correct type');
        });
        it('active should be correct', () => {
            assert.equal(paymentPackage._active, true, 'active has correct initial value true');
            assert.equal(typeof (paymentPackage._active), 'boolean', 'active has correct type')
        });
    })
    describe('test getters', () => {
        let paymentPackage;
        beforeEach(() => {
            paymentPackage = new PaymentPackage('Todor', 10);
        });
        it('instance should return correct name', () => {
            assert.equal(paymentPackage.name, 'Todor', 'name has correct set to Todor');
        });
        it('instance should return correct value', () => {
            assert.equal(paymentPackage.value, 10, 'value has correct set to 10');
        });
        it('instance should return correct VAT', () => {
            assert.equal(paymentPackage.VAT, 20, 'default VAT is set correct');
        });
        it('instance should return correct active', () => {
            assert.equal(paymentPackage.active, true, 'active has correct initial value true');
        });
    })
    describe('test setters', () => {
        it('set incorrect name', () => {
            assert.throws(() => {
                let paymentPackage = new PaymentPackage(2, 10);
            }, 'Name must be a non-empty string');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage(2.2, 10);
            }, 'Name must be a non-empty string');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage(null, 10);
            }, 'Name must be a non-empty string');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage(undefined, 10);
            }, 'Name must be a non-empty string');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage([], 10);
            }, 'Name must be a non-empty string');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage({}, 10);
            }, 'Name must be a non-empty string');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('', 10);
            }, 'Name must be a non-empty string');
        });
        it('Set value to null', () => {
            let instance = new PaymentPackage('Name', 100);
            assert.doesNotThrow(() => { instance.value = 0 })
        });
        it('set incorrect value', () => {
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 'pesho');
            }, 'Value must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('misho', []);
            }, 'Value must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('ssasho', {});
            }, 'Value must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('gosho', null);
            }, 'Value must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('gosho', undefined);
            }, 'Value must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('gosho', true);
            }, 'Value must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('gosho', -2);
            }, 'Value must be a non-negative number');
        });
        it('set incorrect VAT', () => {
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.VAT = [];
            }, 'VAT must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.VAT = {};
            }, 'VAT must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.VAT = null;
            }, 'VAT must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.VAT = undefined;
            }, 'VAT must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.VAT = 'todor';
            }, 'VAT must be a non-negative number');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.VAT = -2;
            }, 'VAT must be a non-negative number');
        });
        it('set incorrect active status', () => {
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = [];
            }, 'Active status must be a boolean');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = {};
            }, 'Active status must be a boolean');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = null;
            }, 'Active status must be a boolean');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = undefined;
            }, 'Active status must be a boolean');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = 'todor';
            }, 'Active status must be a boolean');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = -2;
            }, 'Active status must be a boolean');
            assert.throws(() => {
                let paymentPackage = new PaymentPackage('tosho', 10);
                paymentPackage.active = 2.1;
            }, 'Active status must be a boolean');
        });
    })
    describe('test methods', () => {
        it('test tostring method', () => {
            let paymentPackage = new PaymentPackage('tosho', 10);
            paymentPackage.VAT = 20;
            paymentPackage.active = true;
            const output = [
                `Package: ${paymentPackage.name}` + (paymentPackage.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ];
            let expected = output.join('\n');
            let result = paymentPackage.toString();
            assert.equal(result, expected);
        });
    })
});