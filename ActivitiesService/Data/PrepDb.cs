using ActivitiesService.Models;
using ActivitiesService.SyncDataServices.Grpc;

namespace ActivitiesService.Data
{
    public static class PrepDb
    {
        public static void PropPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<ICityDataClient>();

                var cities = grpcClient!.ReturnAllCities();

                SeedData(serviceScope.ServiceProvider.GetService<IActivitiesRepo>()!, cities);
            }
        }
        private static void SeedData(IActivitiesRepo repo, IEnumerable<City> cities)
        {
            System.Console.WriteLine("Seeding new cities...");

            foreach (var city in cities)
            {
                if (!repo.ExternalCityExists(city.ExternalID))
                {
                    repo.CreateCity(city);
                }
                repo.SaveChanges();
            }
        }
    }
}