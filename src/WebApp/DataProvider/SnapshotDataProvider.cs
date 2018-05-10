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
    public class SnapshotDataProvider : IHPALMSnapshot
    {
        IConfiguration _configuration;
        
        public SnapshotDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("TFSMetricsDatabase").Value;
            return connection;
        }

        public async Task<IEnumerable<HPALM_SnapshotView1>> GetSnapshot()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<HPALM_SnapshotView1>(
                    "spc_GetLatestHPALMSnapshot",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }


}
