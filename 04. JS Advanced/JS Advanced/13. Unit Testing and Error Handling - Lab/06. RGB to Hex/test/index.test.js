const { expect } = require("chai");
const { rgbToHexColor } = require("..");

describe("Test", () => {

    it("should return #100C0D with input: 16, 12, 13", () => {
        // Arrange
        let input = [16, 12, 13];

        // Act
        let result = rgbToHexColor(...input);

        // Assert
        expect(result).to.equal('#100C0D');
    });

    it("should return #FFFFFF with input: 255, 255, 255", () => {
        // Arrange
        let input = [255, 255, 255];

        // Act
        let result = rgbToHexColor(...input);

        // Assert
        expect(result).to.equal('#FFFFFF');
    })

    it("should return #000000 with input: 0, 0, 0", () => {
        // Arrange
        let input = [0, 0, 0];

        // Act
        let result = rgbToHexColor(...input);

        // Assert
        expect(result).to.equal('#000000');
    })


    describe("Red", () => {

        it("should return undefined if red isn't integer", () => {
            // Arrange
            let input = ['0', 0, 0];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });

        it("should return undefined if red < 0", () => {
            // Arrange
            let input = [-1, 0, 0];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });

        it("should return undefined if red > 255", () => {
            // Arrange
            let input = [266, 0, 0];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });
    });


    describe("Green", () => {

        it("should return undefined if green isn't integer", () => {
            // Arrange
            let input = [0, '0', 0];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });

        it("should return undefined if green < 0", () => {
            // Arrange
            let input = [0, -1, 0];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });

        it("should return undefined if green > 255", () => {
            // Arrange
            let input = [0, 266, 0];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });
    });


    describe("Blue", () => {

        it("should return undefined if blue isn't integer", () => {
            // Arrange
            let input = [0, 0, '0'];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });

        it("should return undefined if blue < 0", () => {
            // Arrange
            let input = [0, 0, -1];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });

        it("should return undefined if blue > 255", () => {
            // Arrange
            let input = [0, 0, 266];

            // Act
            let result = rgbToHexColor(...input);

            // Assert
            expect(result).to.be.undefined;
        });
    });
});