using System.ComponentModel;
using ActivitiesService.Data;
using ActivitiesService.Dtos;
using ActivitiesService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ActivitiesService.Controllers
{
        [Route("api/a/cities/{cityId}/[controller]")]
        [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesRepo _repo;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivitiesRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActivityReadDto>> GetActivitiesForCity(int cityId)
        {
            System.Console.WriteLine("--> Hit GetActivitiesForCity: " + cityId);

            if(!_repo.CityExists(cityId))
            {
                return NotFound();
            }
            var activities = _repo.GetActivitiesForCity(cityId);

            return Ok(_mapper.Map<IEnumerable<ActivityReadDto>>(activities));
        }

        [HttpGet("{activityId}" , Name = "GetActivityForCity")]
        public ActionResult<ActivityReadDto> GetActivityForCity(int cityId, int activityId)
        {
            
            System.Console.WriteLine("--> Hit GetActivitysForCity: " + cityId + " / " + activityId);

            if(!_repo.CityExists(cityId))
            {
                return NotFound();
            }
            var activity = _repo.GetActivity(cityId, activityId);
            if(activity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ActivityReadDto>(activity));
        }

        [HttpPost]
        public ActionResult<ActivityReadDto> CreateActivity(int cityId, ActivityCreateDto activityCreateDto)
        {
             System.Console.WriteLine("--> Hit CreateActivityForCity: " + cityId);

            if(!_repo.CityExists(cityId))
            {
                return NotFound();
            }
            var activity = _mapper.Map<Activity>(activityCreateDto);

            _repo.CreateActivity(cityId, activity);
            _repo.SaveChanges();

            var activityReadDto = _mapper.Map<ActivityReadDto>(activity);
            return CreatedAtRoute(nameof(GetActivityForCity),
            new { cityId = cityId, activityId = activityReadDto.Id }, activityReadDto);
        }
    }
}