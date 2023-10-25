using Microsoft.AspNetCore.Mvc;

namespace ActivitiesService.Controllers
{
    [Route("api/a/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public CitiesController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Activities Service");
            return Ok("Inbound test of from Cities Controller");
        }
    }
}