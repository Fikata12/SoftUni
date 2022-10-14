const { expect } = require("chai");
const { sum } = require("..");
describe('Tests', () => {
    it('should return sum if input is valid', () => {
        expect(sum([1, 2, 3])).to.be.equal(6);
    });
    it('should return NaN if input is invalid', () => {
        expect(sum([1, 2, 'a'])).to.be.NaN;
    });
});