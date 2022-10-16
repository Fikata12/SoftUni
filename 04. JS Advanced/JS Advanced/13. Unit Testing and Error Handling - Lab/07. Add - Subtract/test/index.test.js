const { expect } = require("chai");
const { createCalculator } = require("..");

describe("Test", () => {
    it("should return object with properties add, subtract and get", () => {
        //Arrange
        let calculator = createCalculator();

        //Act & Assert - 1
        expect(Object.keys(calculator).includes('add')).to.be.true;

        //Act & Assert - 2
        expect(Object.keys(calculator).includes('subtract')).to.be.true;
        
        //Act & Assert - 3
        expect(Object.keys(calculator).includes('get')).to.be.true;
    });
    describe("Add", () => {
        it("should add the value of the input if valid", () => {
            //Arrange
            let calculator = createCalculator();
    
            //Act
            calculator.add(1);
            let result = calculator.get();

            //Assert
            expect(result).to.equal(1);
        });
        it("should return NaN if the input is invalid", () => {
            //Arrange
            let calculator = createCalculator();
    
            //Act
            calculator.add('a');
            let result = calculator.get();

            //Assert
            expect(result).to.be.NaN;
        });
    });
    describe("Subtract", () => {
        it("should subtract the value of the input if valid", () => {
            //Arrange
            let calculator = createCalculator();
    
            //Act
            calculator.subtract(1);
            let result = calculator.get();

            //Assert
            expect(result).to.equal(-1);      
        });
        it("should return NaN if the input is invalid", () => {
            //Arrange
            let calculator = createCalculator();
    
            //Act
            calculator.subtract('a');
            let result = calculator.get();

            //Assert
            expect(result).to.be.NaN;
        });
    });
    describe("Get", () => {    
        it("should return the value in the closure", () => {
            //Arrange
            let calculator = createCalculator();
    
            //Act
            calculator.add(1);
            calculator.subtract(1);
            let result = calculator.get();

            //Assert
            expect(result).to.equal(0);
        });
        it("should return 0 if the value isn't changed", () => {
            //Arrange
            let calculator = createCalculator();
    
            //Act
            let result = calculator.get();

            //Assert
            expect(result).to.equal(0);
        });
    });
});