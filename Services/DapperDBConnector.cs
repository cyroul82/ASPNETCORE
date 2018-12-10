using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AwesomeApp.Services
{
    public class DapperDBConnector : IDBConnector
    {
        private readonly IConfiguration _configuration;
        public DapperDBConnector(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public SqlConnection GetIDBConnector()
        {
            var s = new SqlConnectionStringBuilder(_configuration.GetConnectionString("connexion")){
                ConnectTimeout= 120
            }.ToString();
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            return conn;
        }
    }
}