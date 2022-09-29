using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using ApiProcessFile.Models;
using ApiProcessFile.Interfaces;

namespace ApiProcessFile.Service
{
    public class TramaPositionService : ITramaPosition
    {
        private readonly IDataConnection _dataConnection;
        public TramaPositionService(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }
        public async  Task<List<TramaPosition>> GetTramaPosition()
        {
            using (var connection = _dataConnection.GetConnection())
            {
                connection.Open();
                var Lista = await connection.QueryAsync<TramaPosition>("SpListdsfsfdsfdsfdsfTramaPositiodddddddddddddddddddddn"
                    , commandType: CommandType.StoredProcedure);
                connection.Close();

                return Lista.ToList();
            }
        }
    }
}
