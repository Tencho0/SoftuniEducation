function printDeckOfCards(cards) {

    let cardsResult = [];
    cards.forEach(card => {
        try {
            let arr = card.split('');
            let suit = arr.pop();
            let face = arr.join('');
            cardsResult.push(createCard(face, suit).toString());
        } catch (error) {
            console.log(`Invalid card: ${card}`);
        }
    });
    console.log(cardsResult.join(' '));

    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        };
        if (!(faces.includes(face) && suits[suit])) {
            throw new Error();
        }

        if (face != face.toUpperCase()) {
            throw new Error();
        }

        let card = {
            face,
            suit,
            toString() {
                console.log(`${this.face}${suits[this.suit]}`);
            }
        }
        return card;
    }
}


printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);
printDeckOfCards(['AS', '10D', 'KH', '2C']);