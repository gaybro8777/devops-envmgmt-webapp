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
    public class ApplicationsDataProvider : IApplications
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public ApplicationsDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddApplication(tblApplications applications)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ProjectTeamID", applications.ProjectTeamID);
                dynamicParameters.Add("@ApplicationName", applications.ApplicationName);

                dynamicParameters.Add("@ApplicationID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcUpdateApplication",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteApplication(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicationID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteApplication",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblApplications>> GetApplications()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblApplications>(
                    "spcGetApplications",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblApplications> GetApplication(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicationID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblApplications>(
                    "spcGetApplicationDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateApplication(tblApplications applications)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicationID", applications.ApplicationID);
                dynamicParameters.Add("@ProjectTeamID", applications.ProjectTeamID);
                dynamicParameters.Add("@ApplicationName", applications.ApplicationName);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateApplication",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
