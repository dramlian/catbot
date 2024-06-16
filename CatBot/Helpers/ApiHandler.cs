using System.Text;
using System.Text.Json;

namespace SimpleCatBot.Helpers
{
    public class ApiHandler
    {
        private readonly HttpClient _httpClient;

        public ApiHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest content)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(content);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResponse>(responseContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }
    }
}
