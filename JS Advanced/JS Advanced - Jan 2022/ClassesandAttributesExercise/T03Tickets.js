function solve(inputArr, sortingCriterion) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status; 
        }
    }

    let tickets = [];
    for (const iterator of inputArr) {
        let [destinationName, price, status] = iterator.split('|');
        price = Number(price);
        let ticket = new Ticket(destinationName, price, status);
        tickets.push(ticket);
    }

    return tickets.sort((a, b) => {
        if (typeof a[sortingCriterion] === 'number') {
            return a[sortingCriterion] - b[sortingCriterion];
        } else {
            return a[sortingCriterion].localeCompare(b[sortingCriterion]);
        }
    });
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));