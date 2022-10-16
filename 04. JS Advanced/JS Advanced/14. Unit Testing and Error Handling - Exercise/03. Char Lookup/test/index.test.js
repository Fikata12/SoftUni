const { expect } = require("chai");
const { lookupChar } = require("..");

describe("Tests", () => {
    
    describe("Check data types", () => {

        it("should return the letter on the input index if input is valid", () => {
            // Arrange
            let arg1 = 'Hi';
            let arg2 = 0;

            // Act
            let result = lookupChar(arg1, arg2);

            // Assert
            expect(result).to.equal('H');
        });

        it("should return the letter on the input index if input is valid", () => {
            // Arrange
            let arg1 = 'Hi';
            let arg2 = 1;

            // Act
            let result = lookupChar(arg1, arg2);

            // Assert
            expect(result).to.equal('i');
        });

    });


    describe("Check data types", () => {

        it("should throw Error if first arg isn't of type string", () => {
            // Arrange
            let arg1 = [1, 1.2, [], {}];
            let arg2 = 0;

            for (const input of arg1) {
                // Act
                let result = lookupChar(input, arg2);

                // Assert
                expect(result).to.be.undefined;
            }
        });

        it("should throw Error if second arg isn't of type number", () => {
            // Arrange
            let arg1 = 'Hi';
            let arg2 = ['a', 1.2, [], {}];

            for (const input of arg2) {
                // Act
                let result = lookupChar(arg1, input);

                // Assert
                expect(result).to.be.undefined;
            }
        });

    });


    describe("Check index is in range", () => {

        it("should throw Error if second arg >= length of first arg", () => {
            // Arrange
            let arg1 = 'Hi';
            let arg2 = [arg1.length, arg1.length + 1, -1];

            for (const input of arg2) {
                // Act
                let result = lookupChar(arg1, input);

                // Assert
                expect(result).to.equal("Incorrect index");
            }
        });

    });

});