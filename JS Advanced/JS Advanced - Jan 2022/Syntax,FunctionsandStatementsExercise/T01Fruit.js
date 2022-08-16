function demo(fruit, weight, price) {
    let fruitType = fruit;
    let fruitWeight = weight;
    let pricePerKg = price;

    let weightInKg = fruitWeight / 1000;
    let totalPrice = weightInKg * pricePerKg;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruitType}.`);
}

demo('orange', 2500, 1.80);