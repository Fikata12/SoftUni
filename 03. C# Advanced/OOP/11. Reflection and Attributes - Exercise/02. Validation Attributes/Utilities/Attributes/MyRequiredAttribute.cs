using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
