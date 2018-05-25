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
    public class ServersDataProvider : IServers
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public ServersDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddServer(tblServers server)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ServerName", server.ServerID);
                dynamicParameters.Add("@ServerIPAddressID", server.ServerIPAddress);
                dynamicParameters.Add("@ServerType", server.ServerIPAddress);
                dynamicParameters.Add("@URL", server.URL);
                dynamicParameters.Add("@DirectoryPath", server.DirectoryPath);
                dynamicParameters.Add("@Owner", server.Owner);
                dynamicParameters.Add("@IsActive", server.IsActive);
                
                dynamicParameters.Add("@ServerID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertServer",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteServer(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ServerID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteUserRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblServers>> GetServers()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblServers>(
                    "spcGetServers",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblServers> GetServer(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ServerID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblServers>(
                    "spcGetServerDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateServer(tblServers server)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ServerID", server.ServerID);
                dynamicParameters.Add("@ServerName", server.ServerName);
                dynamicParameters.Add("@ServerIPAddress", server.ServerIPAddress);
                dynamicParameters.Add("@ServerType", server.ServerType);
                dynamicParameters.Add("@URL", server.URL);
                dynamicParameters.Add("@DirectoryPath", server.DirectoryPath);
                dynamicParameters.Add("@Owner", server.Owner);
                dynamicParameters.Add("@IsActive", server.IsActive);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateServer",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
