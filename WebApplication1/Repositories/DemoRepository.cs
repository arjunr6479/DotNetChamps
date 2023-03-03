using System.Net.Http.Headers;
using System.Net.Http;

namespace WebApplication1.Repositories
{
    public class DemoRepository : IDemoRepository
    {
        private readonly HttpClient _httpClient;
        public DemoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetApiData(string endpointUrl, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(endpointUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            throw new Exception($"Failed to get data from {endpointUrl}. Error: {response.StatusCode}");
        }

        public async Task<string> PostApiData(string endpointUrl, string token, string jsonData)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.PostAsync(endpointUrl, new StringContent(jsonData));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            throw new Exception($"Failed to post data to {endpointUrl}. Error: {response.StatusCode}");
        }
    }
}
