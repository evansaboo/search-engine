using Npgsql;
using Dapper;
using search_engine.Domain;

namespace search_engine.DbHandler
{
    public class DbRepository
    {
        private readonly ILogger<DbRepository> logger;

        public DbRepository(ILogger<DbRepository> logger)
        {
            this.logger = logger;
        }

        public void CreatePlanetsTable(NpgsqlConnection conn)
        {
            String sqlStatement = "CREATE TABLE planets(" +
                "Id serial PRIMARY KEY, " +
                "Name VARCHAR(50), " +
                "Diameter DOUBLE, " +
                "LengthOfDay DOUBLE, " +
                "Density DOUBLE, " +
                "EscapeVelocity DOUBLE, " +
                "DistFromSun DOUBLE)";

            var command = new NpgsqlCommand(sqlStatement, conn);

            command.ExecuteNonQuery();

            logger.LogInformation("Created Planets Table");
        }

        public void InsertNewPlanet(NpgsqlConnection conn, Planet planet)
        {
            String sqlStatement = "INSERT INTO planets" +
                "(Id, Name, Diameter, LengthOfDay, Density, EscapeVelocity, DistFromSun) " +
                "VALUES (@id, @name, @lengthOfDay, @density, @escapeVelocity, @distFromSun)";


            var command = new NpgsqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("id", planet.Id);
            command.Parameters.AddWithValue("name", planet.Name);
            command.Parameters.AddWithValue("lengthOfDay", planet.Diameter);
            command.Parameters.AddWithValue("density", planet.Density);
            command.Parameters.AddWithValue("escapeVelocity", planet.EscapeVelocity);
            command.Parameters.AddWithValue("distFromSun", planet.DistFromSun);

            command.ExecuteNonQuery();

            logger.LogInformation("Inserted a new planet in the 'Planets' table");

        }

        public void DeletePlanet(NpgsqlConnection conn, int planetId)
        {
            String sqlStatement = "DELETE FROM planets  WHERE id = @id";

            var command = new NpgsqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("id", planetId);

            command.ExecuteNonQuery();

            logger.LogInformation("Deleted a planet with ID = " + planetId + " from the 'Planets' table");
        }

        public List<Planet> GetPlanets(NpgsqlConnection conn)
        {
            String sqlStatement = "SELECT * FROM planets";

            return conn.Query<Planet>(sqlStatement).ToList();
        }
    }
}
