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
    public class ProjectTeamDataProvider : IProjectTeam
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public ProjectTeamDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddProjectTeam(tblProjectTeam projectteam)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", projectteam.Name);
                dynamicParameters.Add("@LeaderName", projectteam.LeaderName);
                dynamicParameters.Add("@@IsActive", projectteam.@IsActive);

                dynamicParameters.Add("@ProjectTeamID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertProjectTeam",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProjectTeam(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ProjectTeamID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteProjectTeam",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblProjectTeam>> GetProjectTeams()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblProjectTeam>(
                    "spcGetProjectTeams",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblProjectTeam> GetProjectTeam(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ProjectTeamID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblProjectTeam>(
                    "spcGetProjectTeamDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateProjectTeam(tblProjectTeam projectteam)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ProjectTeamID", projectteam.ProjectTeamID);
                dynamicParameters.Add("@Name", projectteam.Name);
                dynamicParameters.Add("@LeaderName", projectteam.LeaderName);
                dynamicParameters.Add("@IsActive", projectteam.IsActive);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateProjectTeam",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
