using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PublicHolidaysFinder.Models;

namespace PublicHolidaysFinder
{
    public class Program
    {
        private const string ApiUrlTemplate = "https://date.nager.at/api/v3/PublicHolidays/{0}/{1}";
        private const string ExitCommand = "exit";

        public static async Task Main(string[] args)
        {
            ShowHeader();
            while (true)
            {
                string countryCode = PromptInput(Consts.PromptCountryCode, ValidateCountryCode);
                if (countryCode.Equals(ExitCommand, StringComparison.OrdinalIgnoreCase))
                    break;
                string year = PromptInput(Consts.PromptYear, ValidateYear);
                if (year.Equals(ExitCommand, StringComparison.OrdinalIgnoreCase))
                    break;

                var holidays = await FetchHolidaysAsync(countryCode.ToUpperInvariant(), year);
                if (holidays != null && holidays.Count > 0)
                    ShowTable(holidays, countryCode.ToUpperInvariant(), year);
                else
                    Console.WriteLine(Consts.NoHolidayFound);

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

        private static bool ValidateCountryCode(string input) =>
            !string.IsNullOrEmpty(input) && input.Length == 2 && IsAllLetters(input);

        private static bool ValidateYear(string input) =>
            int.TryParse(input, out int y) && y > 1900 && y < 2100;

        private static bool IsAllLetters(string input)
        {
            foreach (var c in input)
                if (!char.IsLetter(c)) return false;
            return true;
        }

        private static async Task<List<HolidayModel>> FetchHolidaysAsync(string countryCode, string year)
        {
            using var client = new HttpClient();
            try
            {
                string url = string.Format(ApiUrlTemplate, year, countryCode);
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<HolidayModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                Console.WriteLine(Consts.ApiError);
                return null;
            }
        }

        private static void ShowTable(List<HolidayModel> holidays, string countryCode, string year)
        {
            Console.WriteLine($"\nPublic Holidays in {countryCode} for {year}:\n");
            Console.WriteLine(Consts.TableHeader);
            foreach (var h in holidays)
            {
                Console.WriteLine($"{h.Date,-12} | {h.LocalName,-24} | {h.Name,-30}");
            }
        }
    }
}