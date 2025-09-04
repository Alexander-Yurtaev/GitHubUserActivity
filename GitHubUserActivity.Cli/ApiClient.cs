using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GitHubUserActivity.Cli;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(string baseAddress)
    {
        _httpClient = new HttpClient{BaseAddress = new Uri(baseAddress) };
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GitHubUserActivity.Cli", "1")); // set your own values here
    }

    public async Task<T?> GetAsync<T>(string request) where T: class
    {
        HttpResponseMessage response = await _httpClient.GetAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"ERROR: {content}");
            return null;
        }

        T? result = await response.Content.ReadFromJsonAsync<T>();

        return result;
    }
}