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
    public class EnvServersDataProvider : IEnvServers
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public EnvServersDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddEnvServer(tblEnvServers envserver)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvironmentID", envserver.EnvironmentID);
                dynamicParameters.Add("@ServerID", envserver.ServerID);

                dynamicParameters.Add("@EnvServerID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertEnvServer",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEnvServer(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvServerID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteEnvServer",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblEnvServers>> GetEnvServers()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblEnvServers>(
                    "spcGetEnvServers",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblEnvServers> GetEnvServer(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvServerID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblEnvServers>(
                    "spcGetEnvServerDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEnvServer(tblEnvServers envserver)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvServerID", envserver.EnvServerID);
                dynamicParameters.Add("@EnvironmentID", envserver.EnvironmentID);
                dynamicParameters.Add("@ServerID", envserver.ServerID);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateEnvServer",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
