using Npgsql;

namespace search_engine.DbHandler
{
    public class DbConnection
    {
        private static string Host = "search-engine-database.postgres.database.azure.com";
        private static string User = "searchEngineDB";
        private static string DBname = "searchEngineDB";
        private static string Password = "hge_dbq_nwx2PXE*dqt";
        private static string Port = "5432";

        public static NpgsqlConnection OpenConnectionToDb()
        {
            String connString = String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

            var conn = new NpgsqlConnection(connString);

            return conn;
        }

        protected void CloseConnectionToDb(NpgsqlConnection conn)
        {
            conn.Close();
        }
    }
}
