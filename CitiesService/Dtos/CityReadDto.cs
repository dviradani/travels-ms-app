namespace CitiesService.Dtos
{
    public class CityReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}