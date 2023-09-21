using CitiesService.Models;

namespace CitiesService.Data
{
    public class CityRepo : ICityRepo
    {
        private readonly AppDbContext _context;

        public CityRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCity(City city)
        {
            if (city == null) {
                throw new ArgumentNullException(nameof(city));
            }

            _context.Cities.Add(city);
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCityById(int id)
        {
            return _context.Cities.FirstOrDefault(c => c.Id == id)!;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}