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
    public class ReleasesDataProvider : IReleases
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public ReleasesDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddRelease(tblReleases release)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ReleaseName", release.ReleaseName);
                dynamicParameters.Add("@ReleaseDate", release.ReleaseDate);

                dynamicParameters.Add("@ReleaseID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertRelease",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteRelease(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ReleaseID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteRelease",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblReleases>> GetReleases()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblReleases>(
                    "spcGetReleases",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblReleases> GetRelease(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ReleaseID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblReleases>(
                    "spcGetReleaseDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateRelease(tblReleases release)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ReleaseID", release.ReleaseID);
                dynamicParameters.Add("@ReleaseName", release.ReleaseName);
                dynamicParameters.Add("@ReleaseDate", release.ReleaseDate);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateRelease",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
