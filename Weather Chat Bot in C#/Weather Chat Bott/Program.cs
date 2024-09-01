using System;
using System.Threading.Tasks;
using Weather_Chat_Bott.Services;
using Weather_Chat_Bott.Config;
using Weather_Chat_Bott.Utilities;

namespace Weather_Chat_Bott
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var chatService = new ChatService();
            var weatherService = new WeatherService(new ApiHelper(AppConfig.BaseUrl, AppConfig.ApiKey));

            Console.WriteLine("Chat Bot: Hi there! I'm your weather bot. Type 'exit' to end the conversation.");

            while (true)
            {
                Console.WriteLine("Chat Bot: Please tell me a city name to get the current weather:");
                Console.Write("You: ");
                string city = Console.ReadLine();

                if (city.ToLower() == "exit")
                {
                    Console.WriteLine("Chat Bot: Goodbye! Stay safe!");
                    break;
                }

                string weatherInfo = await weatherService.GetWeatherAsync(city);
                Console.WriteLine($"Chat Bot: {weatherInfo}");

                Console.WriteLine("Chat Bot: How do you feel about the weather?");
                string userInput = Console.ReadLine().ToLower();

                string response = chatService.GetResponse(userInput);
                Console.WriteLine($"Chat Bot: {response}");
            }
        }
    }
}
