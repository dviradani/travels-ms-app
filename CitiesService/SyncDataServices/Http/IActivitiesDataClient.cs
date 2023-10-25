using CitiesService.Dtos;

namespace CitiesService.SyncDataServices.Http
{
    public interface IActivitiesDataClient
    {
        Task SentCityToActivity(CityReadDto city);
    }
}