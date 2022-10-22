const { expect } = require("chai");
const { chooseYourCar } = require("../chooseYourCar");

describe("Tests …", function () {
    describe("choosingType", function () {
        it("should throw error with message Invalid year", function () {
            // Arrange 
            let type = "Type";
            let color = "Color";
            let inputs = [1899, 2023];

            for (const input of inputs) {
                // Act & Assert
                expect(() => chooseYourCar.choosingType(type, color, input)).to.throw("Invalid Year!");
            }
        });
        it("type = Sedan & year >= 2010", function () {
            // Arrange 
            let type = "Sedan";
            let color = "Color";
            let inputs = [2010, 2011];

            for (const input of inputs) {
                // Act & Assert
                expect(chooseYourCar.choosingType(type, color, input)).to.equal(`This ${color} ${type} meets the requirements, that you have.`);
            }
        });
        it("type = Sedan & year < 2010", function () {
            // Arrange 
            let type = "Sedan";
            let color = "Color";
            let inputs = [2009, 2000];

            for (const input of inputs) {
                // Act & Assert
                expect(chooseYourCar.choosingType(type, color, input)).to.equal(`This ${type} is too old for you, especially with that ${color} color.`);
            }
        });
        it("type != Sedan", function () {
            // Arrange 
            let type = "Type";
            let color = "Color";
            let inputs = [1900, 2022];
            for (const input of inputs) {
                // Act & Assert
                expect(() => chooseYourCar.choosingType(type, color, input)).to.throw(`This type of car is not what you are looking for.`);
            }
        });
    });
    describe("brandName", function () {
        it("invalid brands", function () {
            // Arrange 
            let inputs = [[], {}, '', 1, 2.2];
            let brandIndex = 0;

            for (const input of inputs) {
                // Act & Assert
                expect(() => chooseYourCar.brandName(input, brandIndex)).to.throw("Invalid Information!");
            }
        });
        it("invalid brandIndex", function () {
            // Arrange 
            let inputs = [[], {}, '', 8, 2.2, -1];
            let brands = ["BMW", "Toyota", "Peugeot"];

            for (const input of inputs) {
                // Act & Assert
                expect(() => chooseYourCar.brandName(brands, input)).to.throw("Invalid Information!");
            }
        });
        it("invalid brandIndex", function () {
            // Arrange 
            let index = 1;
            let brands = ["BMW", "Toyota", "Peugeot"];
            let expected = "BMW, Peugeot";

            //Act
            let result = chooseYourCar.brandName(brands, index);

            //Assert
            expect(result).to.equal(expected);
        });
    });
    describe("carFuelConsumption", function () {
        it("invalid distance", function () {
            // Arrange 
            let inputs = [[], {}, '', -1, 0];
            let consumpted = 100;

            for (const input of inputs) {
                // Act & Assert
                expect(() => chooseYourCar.carFuelConsumption(input, consumpted)).to.throw("Invalid Information!");
            }
        });
        it("invalid consumpted", function () {
            // Arrange 
            let distance = 100;
            let inputs = [[], {}, '', -1, 0];

            for (const input of inputs) {
                // Act & Assert
                expect(() => chooseYourCar.carFuelConsumption(input, distance)).to.throw("Invalid Information!");
            }
        });
        it("invalid brandIndex", function () {
            // Arrange 
            let distance = 100;
            let consumpted = 7;
            let litersPerHundredKm = ((consumpted / distance) * 100).toFixed(2);
            let expected = `The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`;

            //Act
            let result = chooseYourCar.carFuelConsumption(distance, consumpted);

            //Assert
            expect(result).to.equal(expected);
        });
        it("efficient", function () {
            // Arrange 
            let distance = 100;
            let consumpted = 6;
            let litersPerHundredKm = ((consumpted / distance) * 100).toFixed(2);
            let expected = `The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`;

            //Act
            let result = chooseYourCar.carFuelConsumption(distance, consumpted);

            //Assert
            expect(result).to.equal(expected);
        });
        it("not efficient", function () {
            // Arrange 
            let distance = 100;
            let consumpted = 8;
            let litersPerHundredKm = ((consumpted / distance) * 100).toFixed(2);
            let expected = `The car burns too much fuel - ${litersPerHundredKm} liters!`;

            //Act
            let result = chooseYourCar.carFuelConsumption(distance, consumpted);

            //Assert
            expect(result).to.equal(expected);
        });
    });
});