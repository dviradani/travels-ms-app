using CitiesService.Models;

namespace CitiesService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!);
            }
        }

        private static void SeedData(AppDbContext context)
        {
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