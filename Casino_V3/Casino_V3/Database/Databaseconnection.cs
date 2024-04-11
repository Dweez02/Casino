using Dapper;
using System.Data;
using System.Data.SQLite;


//Fik hjælp af Martin 3.D Til at opsætte denne connection string
namespace Casino_V3.Database
{
    public class Databaseconnection
    {
        private string _connectionString;
        public Databaseconnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void createSpinResult(int result)
        {
            using(IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                string query = "INSERT INTO Bets (betnumber) VALUES (@betnumber)";
                cnn.Execute(query, new { @betnumber = result });
            }
        }
    }
}
