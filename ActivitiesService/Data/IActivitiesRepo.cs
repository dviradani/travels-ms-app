using ActivitiesService.Models;

namespace ActivitiesService.Data
{
    public interface IActivitiesRepo
    {
        bool SaveChanges();

        //Cities
        IEnumerable<City> GetAllCities();
        void CreateCity(City city);
        bool CityExists(int cityId);
        bool ExternalCityExists(int externalCityId);

        //Activities
        IEnumerable<Activity> GetActivitiesForCity(int cityId);
        Activity GetActivity(int cityId , int activityId);
        void CreateActivity(int cityId,Activity activity);
    }
}