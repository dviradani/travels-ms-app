using ActivitiesService.Models;

namespace ActivitiesService.SyncDataServices.Grpc
{
    public interface ICityDataClient
    {
        IEnumerable<City> ReturnAllCities();
    }
}