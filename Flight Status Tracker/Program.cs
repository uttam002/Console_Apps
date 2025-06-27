using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FlightStatusTracker.Model;

namespace FlightStatusTracker
{
    public class Program
    {
        private const string ApiKey = "YOUR_AVIATIONSTACK_API_KEY"; // <-- Replace with your key
        private const string ApiUrl = "http://api.aviationstack.com/v1/flights?access_key={0}&flight_iata={1}&flight_date={2}";
        private const string HistoryFile = "flight_history.json";
        private const string ExitCommand = "exit";

        public static async Task Main(string[] args)
        {
            ShowHeader();
            while (true)
            {
                string flightNumber = PromptInput(Consts.PromptFlightNumber, ValidateFlightNumber);
                if (flightNumber.Equals(ExitCommand, StringComparison.OrdinalIgnoreCase)) break;

                string date = PromptInput(Consts.PromptFlightDate, ValidateDate);
                if (date.Equals(ExitCommand, StringComparison.OrdinalIgnoreCase)) break;

                var flight = await FetchFlightStatusAsync(flightNumber, date);
                if (flight != null)
                {
                    ShowFlight(flight);
                    SaveToHistory(flight);
                }
                else
                {
                    Console.WriteLine(Consts.FlightNotFound);
                }

                Console.WriteLine(Consts.Menu);
                string menuOpt = Console.ReadLine();
                if (menuOpt?.Trim() == "1")
                {
                    SearchHistory();
                }
                else if (menuOpt?.Trim().Equals(ExitCommand, StringComparison.OrdinalIgnoreCase) == true)
                {
                    break;
                }
                Console.WriteLine(Consts.Separator);
            }
            Console.WriteLine(Consts.Goodbye);
        }

        private static void ShowHeader()
        {
            Console.WriteLine(Consts.AppTitle);
            Console.WriteLine(Consts.Separator);
        }

        private static string PromptInput(string prompt, Func<string, bool> validator)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? "";
                if (input.Equals(ExitCommand, StringComparison.OrdinalIgnoreCase)) break;
            } while (!validator(input));
            return input;
        }

        private static bool ValidateFlightNumber(string input) =>
            !string.IsNullOrEmpty(input) && input.Length >= 3 && char.IsLetter(input[0]) && char.IsLetter(input[1]);

        private static bool ValidateDate(string input) =>
            DateTime.TryParseExact(input, "yyyy-MM-dd", null, DateTimeStyles.None, out _);

        private static async Task<FlightModel> FetchFlightStatusAsync(string flightNumber, string date)
        {
            using var client = new HttpClient();
            try
            {
                string url = string.Format(ApiUrl, ApiKey, flightNumber, date);
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<AviationStackResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (apiResponse?.Data?.Count > 0)
                {
                    var d = apiResponse.Data[0];
                    return new FlightModel
                    {
                        FlightNumber = d.Flight?.Iata,
                        Date = d.FlightDate,
                        Status = d.FlightStatus,
                        DepartureAirport = d.Departure?.Airport,
                        DepartureTime = d.Departure?.Scheduled,
                        DepartureGate = d.Departure?.Gate,
                        ArrivalAirport = d.Arrival?.Airport,
                        ArrivalTime = d.Arrival?.Scheduled,
                        ArrivalGate = d.Arrival?.Gate
                    };
                }
                return null;
            }
            catch
            {
                Console.WriteLine(Consts.ApiError);
                return null;
            }
        }

        private static void ShowFlight(FlightModel f)
        {
            Console.WriteLine(Consts.TableHeader);
            Console.WriteLine($"{f.FlightNumber,-10} | {f.Date,-12} | {f.Status,-10} | {f.DepartureAirport,-18} | {f.DepartureTime,-18} | {f.DepartureGate ?? "-",-5} | {f.ArrivalAirport,-18} | {f.ArrivalTime,-18} | {f.ArrivalGate ?? "-",-5}");
        }

        private static void SaveToHistory(FlightModel model)
        {
            var history = LoadHistory();
            history.Add(model);
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(HistoryFile, JsonSerializer.Serialize(history, options));
        }

        private static List<FlightModel> LoadHistory()
        {
            if (!File.Exists(HistoryFile)) return new List<FlightModel>();
            try
            {
                var json = File.ReadAllText(HistoryFile);
                return JsonSerializer.Deserialize<List<FlightModel>>(json) ?? new List<FlightModel>();
            }
            catch
            {
                return new List<FlightModel>();
            }
        }

        private static void SearchHistory()
        {
            var history = LoadHistory();
            if (history.Count == 0)
            {
                Console.WriteLine(Consts.NoHistory);
                return;
            }
            Console.Write(Consts.PromptSearchHistory);
            var search = Console.ReadLine()?.Trim().ToUpperInvariant();
            foreach (var f in history)
            {
                if (f.FlightNumber?.ToUpperInvariant().Contains(search) == true)
                    ShowFlight(f);
            }
        }
    }
}