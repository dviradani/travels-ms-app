using System.Text;
using System.Text.Json;
using CitiesService.Dtos;

namespace CitiesService.SyncDataServices.Http
{
    public class HttpActivitesDataClient : IActivitiesDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpActivitesDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task SentCityToActivity(CityReadDto city)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(city),
            Encoding.UTF8,
            "application/json");

            var reponse = await _httpClient.PostAsync("http://localhost:6173/api/a/cities", httpContent);
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