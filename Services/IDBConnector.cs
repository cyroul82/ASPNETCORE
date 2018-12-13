
using System.Data.SqlClient;

namespace AwesomeApp.Services
{
    public interface IDBConnector
    {
        SqlConnection GetIDBConnector();
    }
}