using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApiProcessFile.Interfaces
{
    public  interface IDataConnection
    {
        public IDbConnection GetConnection();
    }
}
