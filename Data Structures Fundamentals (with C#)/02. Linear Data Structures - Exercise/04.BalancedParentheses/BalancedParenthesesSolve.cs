namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> openingBrackets = new Stack<char>();

            Dictionary<char, char> validBrackets = new Dictionary<char, char>
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (validBrackets.Keys.Contains(parentheses[i]))
                {
                    openingBrackets.Push(parentheses[i]);
                    continue;
                }

                try
                {
                    if (validBrackets.Values.Contains(parentheses[i]))
                    {
                        if (validBrackets.Contains(new KeyValuePair<char, char>(openingBrackets.Peek(), parentheses[i])))
                        {
                            openingBrackets.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        continue;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            if (openingBrackets.Count != 0)
            {
                return false;
            }

            return true;
        }
    }
}
