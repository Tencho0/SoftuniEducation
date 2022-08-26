function cityTaxes(name, population, treasury) {

    const object = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            //treasury = Math.floor(this.treasury + this.population * this.taxRate)
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            //this.population = Math.floor(this.population * (percentage / 100 + 1));
            percentage /= 100;
            this.population *= percentage + 1;
        },
        applyRecession(percentage) {
            this.treasury = Math.floor(this.treasury * (1 - percentage / 100));
        }
    }
    return object;
}

const city =
    cityTaxes('Tortuga',
        7000,
        15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
