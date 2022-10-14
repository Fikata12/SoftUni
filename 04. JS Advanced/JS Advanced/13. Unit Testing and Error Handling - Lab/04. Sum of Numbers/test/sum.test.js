const { expect } = require("chai");
const { sum } = require("..");
describe('Tests', () => {

    it('should return sum if input is valid', () => {
        // Arrange
        let input = [1, 2, 3];

        // Act
        let result = sum(input);

        // Assert
        expect(result).to.be.equal(6);
    });
    
    it('should return NaN if input is invalid', () => {
        // Arrange
        let input = [1, 2, 'a'];

        // Act
        let result = sum(input);

        // Assert
        expect(result).to.be.NaN;
    });
});