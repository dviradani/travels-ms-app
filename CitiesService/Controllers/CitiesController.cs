using AutoMapper;
using CitiesService.Data;
using CitiesService.Dtos;
using CitiesService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitiesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepo _repository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityReadDto>> GetCities()
        {
            Console.WriteLine("--> Getting cities...");

            var cities = _repository.GetAllCities();

            return Ok(_mapper.Map<IEnumerable<CityReadDto>>(cities));
        }
        [HttpGet("{id}", Name ="GetCityById")]
        public ActionResult<CityReadDto> GetCityById(int id)
        {
            var city = _repository.GetCityById(id);

            if (city != null)
                return Ok(_mapper.Map<CityReadDto>(city));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CityReadDto> CreateCity(CityCreateDto cityCreateDto)
        {
            var cityModel = _mapper.Map<City>(cityCreateDto);

            _repository.CreateCity(cityModel);
            _repository.SaveChanges();

            var cityReadDto = _mapper.Map<CityReadDto>(cityModel);

            return CreatedAtRoute(nameof(GetCityById), new {id = cityReadDto.Id}, cityReadDto);
        }
    }
}