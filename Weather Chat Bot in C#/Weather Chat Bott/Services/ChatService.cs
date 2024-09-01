using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Chat_Bott.Utilities;

namespace Weather_Chat_Bott.Services
{
    public class ChatService
    {
        private readonly Dictionary<string, string> _predefinedResponses = new Dictionary<string, string>
        {
            { "hot", "It seems like it's quite warm today!" },
            { "rain", "Carry an umbrella, just in case!" },
            { "cold", "Brrr! Make sure to bundle up!" }
        };

        public string GetResponse(string userInput)
        {
            foreach (var pattern in _predefinedResponses.Keys)
            {
                if (PatternMatcher.Matches(userInput, pattern))
                {
                    return _predefinedResponses[pattern];
                }
            }

            return "I don't have a specific response for that, but I hope the weather is to your liking!";
        }
    }
}
