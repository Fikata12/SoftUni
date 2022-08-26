using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam
{
    public static class Validator
    {
        public static string NameValidator(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("A name should not be empty.");
            }
            else
            {
                return name;
            }
        }
    }
}
