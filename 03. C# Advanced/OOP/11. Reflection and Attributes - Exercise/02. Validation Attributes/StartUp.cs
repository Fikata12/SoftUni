using System;
using ValidationAttributes.Utilities.Attributes;
using ValidationAttributes.Models;
using ValidationAttributes.Utilities;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("", -1);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
