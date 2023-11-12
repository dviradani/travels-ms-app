using System.Text;
using System.Text.Json;
using CitiesService.Dtos;

namespace CitiesService.SyncDataServices.Http
{
    public class HttpActivitesDataClient : IActivitiesDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpActivitesDataClient(HttpClient httpClient , IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SentCityToActivity(CityReadDto city)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(city),
            Encoding.UTF8,
            "application/json");

            var reponse = await _httpClient.PostAsync($"{_configuration["ActivitiesService"]}", httpContent);
            if(reponse.IsSuccessStatusCode)
            {
                System.Console.WriteLine("--> sync POST to ActivitiesService was OK!");
            }
            else
            {
                System.Console.WriteLine("--> sync POST to ActivitiesService was NOT OK!");
            }
        }
    }
}