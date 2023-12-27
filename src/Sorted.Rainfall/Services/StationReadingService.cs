using Sorted.Rainfall.Model;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Web.Http;

namespace Sorted.Rainfall
{
    public class StationReadingService : IStationReadingService
    {
        private readonly HttpClient _rainFallAPIClient;
        public StationReadingService(IHttpClientFactory httpClientFactory)
        {
            _rainFallAPIClient = httpClientFactory.CreateClient("RainFallAPI");
        }
        public async Task<StationReading> Get(string stationId, int count = 10)
        {
            var endpoint = @$"/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit={count}";

            var httpResponse = await _rainFallAPIClient.GetAsync(endpoint);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Error Rainfall response with status code {httpResponse.StatusCode}");
            }

            var stringResult = await httpResponse.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<StationReading>(stringResult, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            return result ??new();
        }
    }
}
