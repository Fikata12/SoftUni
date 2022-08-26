using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Dialing... {number}";
            }
        }
    }
}
