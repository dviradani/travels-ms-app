using AutoMapper;
using CitiesService.Dtos;
using CitiesService.Models;

namespace CitiesService.Profiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            //source => target
            CreateMap<City, CityReadDto>();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityReadDto, CityPublishedDto>();
            CreateMap<City, GrpcCityModel>().
                ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).
                ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

        }
    }
}