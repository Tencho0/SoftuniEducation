class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }
    loadingVegetables(vegetables) {
        for (const iterator of vegetables) {
            let [type, quantity, price] = iterator.split(' ');

            quantity = Number(quantity);
            price = Number(price);

            let currentProduct = this.availableProducts.find(pr => pr.type === type);
            if (!currentProduct) {
                this.availableProducts.push({ type, quantity, price });
            } else {
                currentProduct.quantity += quantity;
                if (currentProduct.price < price) {
                    currentProduct.price = price;
                }
            }
        }
        let buff = [];
        this.availableProducts.forEach(product => buff.push(product.type));
        return `Successfully added ${buff.join(', ')}`;
    }
    buyingVegetables(selectedProducts) {
        let totalPrice = 0;
        for (const iterator of selectedProducts) {
            let [type, quantity] = iterator.split(' ');
            let currentProduct = this.availableProducts.find(pr => pr.type === type);
            if (!currentProduct) {
                throw Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }
            if (quantity > currentProduct.quantity) {
                throw Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }
            let price = currentProduct.price * quantity;
            currentProduct.quantity -= quantity;
            totalPrice += price;
        }
        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }
    rottingVegetable(type, quantity) {
        let currentProduct = this.availableProducts.find(pr => pr.type === type);
        if (!currentProduct) {
            throw Error(`${type} is not available in the store.`);
        }
        if (quantity > currentProduct.quantity) {
            currentProduct.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }
        currentProduct.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }
    revision() {
        let result = "Available vegetables:\n";
        this.availableProducts.sort((a, b) => (a.price - b.price)).forEach(x => {
            result += `${x.type}-${x.quantity}-$${x.price}\n`;
        });
        result += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;
        return result;
    }
}
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());
