class Company {
    constructor() {
        this.departments = {};
    }
    addEmployee(name, salary, position, department) {
        if (Array.from(arguments).some(a => a === undefined || a == null || a === '') || salary < 0) {
            throw new Error("Invalid input!");
        }
        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        this.departments[department].push({ name: name, salary: Number(salary), position: position });
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }
    bestDepartment() {
        let bestDepartmentName = undefined;
        let bestAverage = 0;
        for (const department in this.departments) {
            let currAverage = 0;
            for (const employee of this.departments[department]) {
                currAverage += employee.salary;
            }
            currAverage /= this.departments[department].length;
            if (currAverage > bestAverage) {
                bestDepartmentName = department;
                bestAverage = currAverage;
            }
        }
        let bestDepartment = this.departments[bestDepartmentName];
        let result = `Best Department is: ${bestDepartmentName}`;
        result += `\nAverage salary: ${bestAverage.toFixed(2)}`;

        bestDepartment.sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));

        bestDepartment.forEach(employee => {
            result += `\n${employee.name} ${employee.salary} ${employee.position}`;
        });
        return result.trim();
    }
}