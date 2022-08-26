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
            FieldInfo[] classFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            object instance = Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder($"Class under investigation: {className}\r\n");
            foreach (var field in classFields.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
