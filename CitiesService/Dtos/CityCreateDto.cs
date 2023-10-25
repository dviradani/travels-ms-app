using System.ComponentModel.DataAnnotations;

namespace CitiesService.Dtos
{
    public class CityCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
    }
}