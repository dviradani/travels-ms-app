namespace ActivitiesService.Dtos
{
    public class ActivityReadDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int CityId { get; set; }
    }
}