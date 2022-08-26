using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is int integer)
            {
                return integer >= minValue && integer <= maxValue;
            }
            else
            {
                return false;
            }
        }
    }
}
