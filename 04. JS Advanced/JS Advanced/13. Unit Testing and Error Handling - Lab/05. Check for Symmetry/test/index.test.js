const { expect } = require("chai");
const { isSymmetric } = require("..");

describe('Tests', () => {
    it("should return false if input isn't array", () => {
        // Arrange
        let input = "Not array";

        // Act
        let result = isSymmetric(input);

        // Assert
        expect(result).to.be.false;
    });
    it("should return false if input is array, but not symmetric", () => {
        // Arrange
        let input = [1, 2, 3, 4];

        // Act
        let result = isSymmetric(input);

        // Assert
        expect(result).to.be.false;
    });
    it("should return true if input is array and symmetric", () => {
        // Arrange
        let input = [1, 2, 2, 1];

        // Act
        let result = isSymmetric(input);

        // Assert
        expect(result).to.be.true;
    });
    it("should return true for [1]", () => {
        // Arrange
        let input = [1];

        // Act
        let result = isSymmetric(input);

        // Assert
        expect(result).to.be.true;
    });
    it("should return true for [5,'hi',{a:5},new Date(),{a:5},'hi',5]", () => {
        // Arrange
        let input = [5, 'hi', { a: 5 }, new Date(), { a: 5 }, 'hi', 5];

        // Act
        let result = isSymmetric(input);

        // Assert
        expect(result).to.be.true;
    });
});