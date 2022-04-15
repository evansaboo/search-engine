using Microsoft.AspNetCore.Mvc;

namespace search_engine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetsController : ControllerBase
    {

        private readonly ILogger<PlanetsController> _logger;

        private List<String> planets = new List<String>() 
        {
            "Mars",
            "Pluto",
            "Mercury",
            "Venus",
            "Earth"
        };

        public PlanetsController(ILogger<PlanetsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<String>> Get()
        {
            return planets;
        }

        [HttpPost]
        [Route("search")]
        public ActionResult<List<String>> FindPlanetsByInput(String input)
        {
            return planets;
        }

    }
}