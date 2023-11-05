using ActivitiesService.Dtos;
using ActivitiesService.Models;
using AutoMapper;

namespace ActivitiesService.Profiles
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            //source => target
            CreateMap<City, CityReadDto>();
            CreateMap<ActivityCreateDto, Activity>();
            CreateMap<Activity, ActivityReadDto>();
            CreateMap<CityPublishedDto, City>()
            .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));
            
        }
    }
}