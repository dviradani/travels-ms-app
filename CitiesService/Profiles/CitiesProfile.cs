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
        }
    }
}