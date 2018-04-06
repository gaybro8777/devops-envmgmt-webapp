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
    public class EnvironmentsDataProvider : IEnvironments
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public EnvironmentsDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddEnvironment(tblEnvironments environments)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvName", environments.EnvName);
                
                dynamicParameters.Add("@EnvironmentID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertEnvironment",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEnvironment(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvironmentID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteEnvironment",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblEnvironments>> GetEnvironments()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblEnvironments>(
                    "spcGetEnvironments",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<tblEnvironments>> GetEnvironmentsByAppId(int AppID)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicationID", AppID);
                return await sqlConnection.QueryAsync<tblEnvironments>(
                    "spcGetEnvironmentsByAppId",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblEnvironments> GetEnvironment(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvironmentID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblEnvironments>(
                    "spcGetEnvironmentDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEnvironment(tblEnvironments environments)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvironmentID", environments.EnvironmentID);
                dynamicParameters.Add("@EnvName", environments.EnvName);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateEnvironment",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
