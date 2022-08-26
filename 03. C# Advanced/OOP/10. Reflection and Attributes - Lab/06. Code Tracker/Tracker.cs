using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name} is written by {method.CustomAttributes.First().ConstructorArguments.First().Value}");
            }
            //OR
            //foreach (var method in methods)
            //{
            //    if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
            //    {
            //        object[] attributes = method.GetCustomAttributes(false);
            //        foreach (AuthorAttribute attribute in attributes)
            //        {
            //            Console.WriteLine($"{method.Name} is written by {attribute.Name}");
            //        }
            //        Console.WriteLine($"{method.Name} is written by {method.CustomAttributes.First().ConstructorArguments.First().Value}");
            //    }
            //}
        }
    }
}
