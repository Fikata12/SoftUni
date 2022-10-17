function solve(firstName, lastName) {
    class Person {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        get fullName() {
            return this.firstName + ' ' + this.lastName;
        }
        set fullName(parts) {
            let fullName = parts.split(' ');
            if (fullName.length !== 2) {
                return;
            }
            this.firstName = fullName[0];
            this.lastName = fullName[1];
        }
    }
    return new Person(firstName, lastName);
}