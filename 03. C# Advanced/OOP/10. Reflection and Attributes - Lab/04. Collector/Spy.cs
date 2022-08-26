using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            Hacker hacker = Activator.CreateInstance(classType) as Hacker;

            StringBuilder stringBuilder = new StringBuilder($"Class under investigation: {className}\r\n");
            foreach (var field in classFields.Where(f => fields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType($"{nameof(Stealer)}.{className}");
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }
            return stringBuilder.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder stringBuilder = new StringBuilder($"All Private Methods of Class: {classType}\r\nBase Class: {classType.BaseType.Name}\r\n");
            foreach (var method in nonPublicMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }
            return stringBuilder.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] settersAndGetters = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var method in settersAndGetters.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in settersAndGetters.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
