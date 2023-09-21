using CitiesService.Models;

namespace CitiesService.Data
{
    public interface ICityRepo
    {
        bool SaveChanges();

        IEnumerable<City> GetAllCities();

        City GetCityById(int id);

        void CreateCity(City city);

        
    }
}