using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiHelper
{
    private readonly HttpClient _client;
    public string BaseUrl { get; }
    public string ApiKey { get; }

    public ApiHelper(string baseUrl, string apiKey)
    {
        _client = new HttpClient();
        BaseUrl = baseUrl;
        ApiKey = apiKey;
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}{ApiKey}&{endpoint}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
            return default;
        }
    }

    public async Task<string> GetRawJsonAsync(string endpoint)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}{ApiKey}&{endpoint}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching raw JSON data: {ex.Message}");
            return string.Empty;
        }
    }
}

