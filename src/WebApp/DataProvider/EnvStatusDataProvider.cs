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
    public class EnvStatusDataProvider : IEnvStatus
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public EnvStatusDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddEnvStatus(tblEnvStatus envstatus)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AppEnvID", envstatus.AppEnvID);
                dynamicParameters.Add("@AppVersion ", envstatus.AppVersion);
                dynamicParameters.Add("@DatabaseVersion", envstatus.DatabaseVersion);
                dynamicParameters.Add("@DateTimeDeployed", envstatus.DateTimeDeployed);

                dynamicParameters.Add("@EnvStatusID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertEnvStatusz",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEnvStatus(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvStatusID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteEnvStatus",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblEnvStatus>> GetEnvStatuses()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblEnvStatus>(
                    "spcGetEnvStatuses",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblEnvStatus> GetEnvStatus(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvStatusID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblEnvStatus>(
                    "spcGetEnvStatusDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEnvStatus(tblEnvStatus envstatus)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvStatusID", envstatus.EnvStatusID);
                dynamicParameters.Add("@AppEnvID", envstatus.AppEnvID);
                dynamicParameters.Add("@AppVersion", envstatus.AppVersion);
                dynamicParameters.Add("@DatabaseVersion", envstatus.DatabaseVersion);
                dynamicParameters.Add("@DateTimeDeployed", envstatus.DateTimeDeployed);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateEnvStatus",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
