using CitiesService.Models;
using Microsoft.EntityFrameworkCore;
namespace CitiesService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<City> Cities { get; set; } = null!;
    }
}