const { expect } = require("chai");
const { mathEnforcer } = require("../index");

describe("Test", () => {
    describe("addFive", () => {
        it("should return undefined if input isn't of type number", () => {
            // Arrange
            let inputs = ['a', [], {}];

            for (const input of inputs) {
                // Act
                let result = mathEnforcer.addFive(input);

                // Assert
                expect(result).to.be.undefined;
            }
        });
        it("should return input + 5 if input is of type number", () => {
            // Arrange
            let inputs = [1, 1.5, -1];

            for (const input of inputs) {
                // Act
                let result = mathEnforcer.addFive(input);

                // Assert
                expect(result).to.be.closeTo(input + 5, 0.01);
            }
        });
    });

    describe("subtractTen", () => {
        it("should return undefined if input isn't of type number", () => {
            // Arrange
            let inputs = ['a', [], {}];

            for (const input of inputs) {
                // Act
                let result = mathEnforcer.subtractTen(input);

                // Assert
                expect(result).to.be.undefined;
            }
        });
        it("should return input - 10 if input is of type number", () => {
            // Arrange
            let inputs = [1, 1.5, -1];

            for (const input of inputs) {
                // Act
                let result = mathEnforcer.subtractTen(input);

                // Assert
                expect(result).to.be.closeTo(input - 10, 0.01);
            }
        });
    });

    describe("sum", () => {
        it("should return undefined if arg1 isn't of type number", () => {
            // Arrange
            let arg1 = ['a', [], {}];
            let arg2 = 1;
            
            for (const input of arg1) {
                // Act
                let result = mathEnforcer.sum(input, arg2);

                // Assert
                expect(result).to.be.undefined;
            }
        });
        it("should return input + 5 if arg2 isn't of type number", () => {
            // Arrange
            let arg1 = 1;
            let arg2 = ['a', [], {}];
            
            for (const input of arg2) {
                // Act
                let result = mathEnforcer.sum(arg1, input);

                // Assert
                expect(result).to.be.undefined;
            }
        });
        it("should return arg1 + arg2 if input is of type number", () => {
            // Arrange
            let arg1 = [-1, 1.5, 1];
            let arg2 = [-1, 1.5, 1];
            
            for (let i = 0; i < arg1.length; i++) {
                // Act
                let result = mathEnforcer.sum(arg1[i], arg2[i]);

                // Assert
                expect(result).to.be.closeTo(arg1[i] + arg2[i], 0.01);
            }
        });
    });
});