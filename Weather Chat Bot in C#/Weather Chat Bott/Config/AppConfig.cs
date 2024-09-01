using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Chat_Bott.Config
{
    public static class AppConfig
    {
        public static string ApiKey { get; } = "e89d201f169af183ba0f79f8f9cd4e8a";
        public static string BaseUrl { get; } = "https://api.openweathermap.org/data/2.5/weather?units=metric&appid=";
    }

}
