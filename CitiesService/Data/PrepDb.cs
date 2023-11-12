using CitiesService.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app , bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()! , isProd);
            }
        }

        private static void SeedData(AppDbContext context , bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            if(!context.Cities.Any())
            {
                Console.WriteLine("--> seeding data...");

                context.Cities.AddRange(
                    new City() {Name = "New York",Country="USA"},
                    new City() {Name = "Paris",Country="France"},
                    new City() {Name = "Madrid",Country="Spain"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}