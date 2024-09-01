using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Chat_Bott.Utilities
{
    public static class PatternMatcher
    {
        public static bool Matches(string userInput, string pattern)
        {
            return userInput.Contains(pattern);
        }
    }
}
