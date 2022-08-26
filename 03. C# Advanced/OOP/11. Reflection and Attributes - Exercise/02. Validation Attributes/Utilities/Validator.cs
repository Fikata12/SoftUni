using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objToValidate = obj.GetType();
            PropertyInfo[] props = objToValidate.GetProperties().Where(p => p.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();
            foreach (PropertyInfo property in props)
            {
                foreach (CustomAttributeData attributeData in property.CustomAttributes)
                {
                    Type typeAttr = attributeData.AttributeType;
                    MethodInfo[] methods = typeAttr.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    Attribute instanceAttr = property.GetCustomAttribute(typeAttr);
                    foreach (var method in methods)
                    {
                        bool isValid = (bool)method.Invoke(instanceAttr, new object[] { property.GetValue(obj)});
                        if (isValid == false)
                        {
                            return false;
                        }
                    }
                }
            }
            
            return true;
        }
    }
}
