using Npgsql;
using search_engine.Domain;

namespace search_engine.DbHandler
{
    public interface IDbRepository
    {
        public void CreatePlanetsTable(NpgsqlConnection conn);

        public void InsertNewPlanet(NpgsqlConnection conn, Planet planet);

        public void DeletePlanet(NpgsqlConnection conn, int planetId);

        public List<Planet> GetPlanets(NpgsqlConnection conn);
    }
}
