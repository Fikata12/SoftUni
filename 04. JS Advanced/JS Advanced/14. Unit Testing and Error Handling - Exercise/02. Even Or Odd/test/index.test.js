const { expect } = require("chai");
const { isOddOrEven } = require("..");
describe('Test', () => {
    it("should return undefined if input isn't string", () => {
        // Arrange
        let inputs = [1, [], {}];

        for (const input of inputs) {
            // Act
            let result = isOddOrEven(input);

            // Assert
            expect(result).to.be.undefined;
        }
    });
    it("should return 'even' if input is string and even", () => {
        // Arrange
        let input = 'Hi';

        // Act
        let result = isOddOrEven(input);

        // Assert
        expect(result).to.equal('even');
    });
    it("should return 'odd' if input is string and odd", () => {
        // Arrange
        let input = 'Hii';

        // Act
        let result = isOddOrEven(input);

        // Assert
        expect(result).to.equal('odd');
    });
});