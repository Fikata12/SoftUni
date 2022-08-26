using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : IBrowseable, ICallable
    {
        public string Browsing(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }

        public string Calling(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }
    }
}
