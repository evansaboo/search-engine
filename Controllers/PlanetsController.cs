using Microsoft.AspNetCore.Mvc;
using Npgsql;
using search_engine.DbHandler;
using search_engine.Domain;

namespace search_engine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetsController : ControllerBase
    {

        private readonly ILogger<PlanetsController> logger;
        private NpgsqlConnection dbConnection;
        private readonly IDbRepository dbRepository;

        private List<String> planets = new List<String>() 
        {
            "Mars",
            "Pluto",
            "Mercury",
            "Venus",
            "Earth"
        };

        public PlanetsController(ILogger<PlanetsController> logger, IDbRepository dbRepository)
        {
            this.logger = logger;
            this.dbRepository = dbRepository;
            dbConnection = new DbConnection().OpenConnectionToDb();
        }

        [HttpGet]
        public ActionResult<List<Planet>> Get()
        {
            return dbRepository.GetPlanets(dbConnection);
        }

        [HttpPost]
        [Route("search")]
        public ActionResult<List<String>> FindPlanetsByInput(String input)
        {
            return planets;
        }

        [HttpPost]
        [Route("create-table")]
        public void CreateTableDebugger()
        {
            dbRepository.CreatePlanetsTable(dbConnection);
        }
    }
}