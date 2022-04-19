using Npgsql;

namespace search_engine.DbHandler
{
    public class DbConnection
    {
        private static string Host = "**";
        private static string User = "**";
        private static string DBname = "**";
        private static string Password = "**";
        private static string Port = "**";

        public NpgsqlConnection OpenConnectionToDb()
        {
            String connString = String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

            var conn = new NpgsqlConnection(connString);

            conn.Open();

            return conn;
        }

        protected void CloseConnectionToDb(NpgsqlConnection conn)
        {
            conn.Close();
        }
    }
}
