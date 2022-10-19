const { expect } = require("chai");
const { PaymentPackage } = require("..");

describe("Tests", function () {
    it("should create instance of the class if input is valid (ctor, set(valid) & get)", function () {
        // Arrange
        let name = 'HR Services';
        let value = 0;
        let VAT = 20;
        let active = true;

        // Act
        let package = new PaymentPackage(name, value);

        // Assert - 1
        expect(package.name).to.equal(name);

        // Assert - 2
        expect(package.value).to.equal(value);

        // Assert - 3
        expect(package.VAT).to.equal(VAT);

        // Assert - 4
        expect(package.active).to.equal(active);
    });

    it("should throw error with specific message if input isn't string or is empty (name)", () => {
        // Arrange
        let inputs = [12, [], {}, ''];
        let value = 1500;

        for (const name of inputs) {
            // Act & Assert
            expect(() => new PaymentPackage(name, value)).to.throw('Name must be a non-empty string');
        }
    });

    it("should throw error with specific message if input isn't number or is < 0 (value)", () => {
        // Arrange
        let name = 'HR Services';
        let inputs = [[], {}, '', -1];

        for (const value of inputs) {
            // Act & Assert
            expect(() => new PaymentPackage(name, value)).to.throw('Value must be a non-negative number');
        }
    });

    it("should throw error with specific message if input isn't number or is < 0 (VAT)", () => {
        // Arrange
        let package = new PaymentPackage('HR Services', 1500);
        let inputs = [[], {}, '', -1];

        for (const VAT of inputs) {
            // Act & Assert
            expect(() => package.VAT = VAT).to.throw('VAT must be a non-negative number');
        }
    });

    it("should throw error with specific message if input isn't boolean (active)", () => {
        // Arrange
        let package = new PaymentPackage('HR Services', 1500);
        let inputs = [[], {}, '', 1];

        for (const active of inputs) {
            // Act & Assert
            expect(() => package.active = active).to.throw('Active status must be a boolean');
        }
    });

    it("should return specific message when called (toString(), active = true)", () => {
        // Arrange
        let package = new PaymentPackage('HR Services', 1500);
        let expected = `Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800`;

        // Act
        let result = package.toString();

        // Assert
        expect(result).to.equal(expected);
    });

    it("should return specific message when called (toString(), active = false)", () => {
        // Arrange
        let package = new PaymentPackage('HR Services', 1500);
        package.active = false;
        let expected = `Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800`;

        // Act
        let result = package.toString();

        // Assert
        expect(result).to.equal(expected);
    });
});