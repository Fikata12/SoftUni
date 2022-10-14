function printDeckOfCards(cards) {
    try {
        let result = [];
        for (const card of cards) {
            let face = card.slice(0, card.length - 1);
            let suit = card[card.length - 1];
            result.push(createCard(face, suit));
        }
        console.log(result.join(' '));
    }
    catch (error) {
        console.log(error.message);
    }
    function createCard(face, suit) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = { S: '\u2660', H: '\u2665', D: '\u2666', C: '\u2663' };
        if (validFaces.includes(face) && Object.keys(validSuits).includes(suit)) {
            return {
                face: face,
                suit: validSuits[suit],
                toString() { return this.face + this.suit; }
            }
        }
        throw Error(`Invalid card: ${face + suit}`);
    }
} 