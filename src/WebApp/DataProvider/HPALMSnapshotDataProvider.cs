using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DBDevOps.DataProvider
{
    public class HPALMSnapshotDataProvider : IHPALMSnapshot
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public HPALMSnapshotDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("TFSMetricsDatabase").Value;
            return connection;
        }

        
        public async Task<IEnumerable<HPALM_SnapshotView1>> GetSnapshot(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SnapshotID", id);
                return await sqlConnection.QueryAsync<HPALM_SnapshotView1>(
                    "spcGetHPALMSnapshotById",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<HPALMSnapshotList>> GetSnapshotList()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<HPALMSnapshotList>(
                    "spcGetSnapshotList",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
