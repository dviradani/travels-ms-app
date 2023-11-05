using ActivitiesService.Data;
using ActivitiesService.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ActivitiesService.Controllers
{
    [Route("api/a/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IActivitiesRepo _repo;
        private readonly IMapper _mapper;

        public CitiesController(IActivitiesRepo repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityReadDto>> GetCities()
        {
            Console.WriteLine("--> Getting cities from ActivitiesService");
            var cityItems = _repo.GetAllCities();
            return Ok(_mapper.Map<IEnumerable<CityReadDto>>(cityItems));
        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Activities Service");
            return Ok("Inbound test of from Cities Controller");
        }
    }
}