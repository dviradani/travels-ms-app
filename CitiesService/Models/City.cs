using System.ComponentModel.DataAnnotations;

namespace CitiesService.Models
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
    }
}