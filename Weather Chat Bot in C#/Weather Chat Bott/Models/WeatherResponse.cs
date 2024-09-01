using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Chat_Bott.Models
{
    using System.Collections.Generic;

    public class WeatherResponse
    {
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Coord Coord { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Sea_Level { get; set; }
        public int Grnd_Level { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Coord
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

}
