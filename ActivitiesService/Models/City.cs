using System.ComponentModel.DataAnnotations;

namespace ActivitiesService.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Activity> Activities { get; set; } = null!;
    }
}