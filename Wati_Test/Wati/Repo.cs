using Dapper;
using System.Data.SqlClient;

namespace Wati
{
    public class Repo : IRepo
    {
        // we can read conn str from config later
        string connstr;

        public Repo(IConfiguration configuration)
        {
            connstr = configuration.GetConnectionString("Wati");
        }

        public void Add(int num1, int num2, int result)
        {
            var sql = @"INSERT INTO [dbo].[Wati]
           ([AddResult],[Num1],[Num2])
            VALUES (@AddResult, @Num1, @Num2)";

            using(var conn = new SqlConnection(connstr))
            {
                conn.Open();

                conn.ExecuteScalar(@sql, new
                {
                    AddResult = result,
                    Num1 = num1,
                    Num2 = num2,
                });
            }
        }
    }
}
