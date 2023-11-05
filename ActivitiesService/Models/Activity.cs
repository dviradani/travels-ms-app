using System.ComponentModel.DataAnnotations;

namespace ActivitiesService.Models
{
    public class Activity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int CityId { get; set; }

        public City City { get; set; } = null!;

    }
}