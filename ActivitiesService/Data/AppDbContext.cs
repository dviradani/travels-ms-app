using ActivitiesService.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesService.Data
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Activity> Activities { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<City>().
        //     HasMany(c => c.Activities)
        //     .WithOne(c => c.City)
        //     .HasForeignKey(c => c.CityId);

        //     modelBuilder.Entity<Activity>()
        //     .HasOne(c => c.City)
        //     .WithMany(c => c.Activities)
        //     .HasForeignKey(c => c.CityId);
        // }
    }
}
