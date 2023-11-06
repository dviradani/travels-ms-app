using ActivitiesService.Dtos;
using ActivitiesService.Models;
using AutoMapper;
using CitiesService;

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
            CreateMap<GrpcCityModel, City>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Activities, opt => opt.Ignore());
                
        }
    }
}