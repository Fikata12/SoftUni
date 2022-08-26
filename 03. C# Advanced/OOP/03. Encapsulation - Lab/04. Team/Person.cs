using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = FirstNameValidator(value); }
        }
        public string LastName
        {
            get { return lastName; }
            private set { lastName = LastNameValidator(value); }
        }
        public int Age
        {
            get { return age; }
            private set { age = AgeValidator(value); }
        }
        public decimal Salary
        {
            get { return salary; }
            private set { salary = SalaryValidator(value); }
        }
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += percentage / 100 / 2 * Salary;
            }
            else
            {
                Salary += percentage / 100 * Salary;
            }
        }
        private string FirstNameValidator(string name)
        {
            if (name.Length > 2)
            {
                return name;
            }
            else
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
        }   
        private string LastNameValidator(string name)
        {
            if (name.Length > 2)
            {
                return name;
            }
            else
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
        }
        private int AgeValidator(int age)
        {
            if (age > 0)
            {
                return age;
            }
            else
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
        }
        private decimal SalaryValidator(decimal salary)
        {
            if (salary >= 650 )
            {
                return salary;
            }
            else
            {
                throw new ArgumentException("Salary cannot be less than 650 leva!");
            }
        }
    }
}
