using ActivitiesService.Models;

namespace ActivitiesService.Data
{
    public class ActivitiesRepo : IActivitiesRepo
    {
        private readonly AppDbContext _context;

        public ActivitiesRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public void CreateActivity(int cityId, Activity activity)
        {
            if(activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }
            activity.CityId = cityId;
            _context.Activities.Add(activity);
        }

        public void CreateCity(City city)
        {
            if(city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            _context.Cities.Add(city);
        }

        public bool ExternalCityExists(int externalCityId)
        {
            return _context.Cities.Any(c => c.ExternalID == externalCityId);
        }

        public IEnumerable<Activity> GetActivitiesForCity(int cityId)
        {
            return _context.Activities
            .Where(a => a.CityId == cityId)
            .OrderBy(a => a.City.Name)
            .ToList();
        }

        public Activity GetActivity(int cityId, int activityId)
        {
            return _context.Activities
            .Where(a => a.CityId == cityId && a.Id == activityId).FirstOrDefault()!;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}