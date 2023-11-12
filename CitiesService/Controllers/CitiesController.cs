using AutoMapper;
using CitiesService.AsyncDataServices;
using CitiesService.Data;
using CitiesService.Dtos;
using CitiesService.Models;
using CitiesService.SyncDataServices.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitiesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepo _repository;
        private readonly IMapper _mapper;
        private readonly IActivitiesDataClient _activitiesDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public CitiesController(ICityRepo repository, IMapper mapper , IActivitiesDataClient activitiesDataClient, IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _activitiesDataClient = activitiesDataClient;
            _messageBusClient = messageBusClient;
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
        public async Task<ActionResult<CityReadDto>> CreateCity(CityCreateDto cityCreateDto)
        {
            var cityModel = _mapper.Map<City>(cityCreateDto);

            _repository.CreateCity(cityModel);
            _repository.SaveChanges();

            var cityReadDto = _mapper.Map<CityReadDto>(cityModel);

            //Send Sync Message
            try 
            {
                await _activitiesDataClient.SentCityToActivity(cityReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            // Send Async Message
            try
            {
                var cityPublishedDto = _mapper.Map<CityPublishedDto>(cityReadDto);
                cityPublishedDto.Event = "City_Published";
                _messageBusClient.PublishNewCity(cityPublishedDto);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetCityById), new {id = cityReadDto.Id}, cityReadDto);
        }
    }
}