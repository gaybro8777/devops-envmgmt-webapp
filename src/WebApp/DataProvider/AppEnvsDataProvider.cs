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
    public class AppEnvsDataProvider : IAppEnvs
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public AppEnvsDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddAppEnv(tblAppEnvs appenv)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicationID", appenv.ApplicationID);
                dynamicParameters.Add("@EnvironmentID", appenv.EnvironmentID);

                dynamicParameters.Add("@AppEnvID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertAppEnv",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteAppEnv(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AppEnvID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteAppEnv",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblAppEnvs>> GetAppEnvs()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblAppEnvs>(
                    "spcGetAppEnvs",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblAppEnvs> GetAppEnv(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AppEnvID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblAppEnvs>(
                    "spcGetAppEnvDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAppEnv(tblAppEnvs appenv)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AppEnvID", appenv.AppEnvID);
                dynamicParameters.Add("@ApplicationID", appenv.ApplicationID);
                dynamicParameters.Add("@EnvironmentID", appenv.EnvironmentID);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateAppEnv",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
