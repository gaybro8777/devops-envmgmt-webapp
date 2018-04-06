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
    public class UsersDataProvider : IUsers
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public UsersDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddUser(tblUsers user)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FirstName", user.FirstName);
                dynamicParameters.Add("@LastName", user.LastName);
                dynamicParameters.Add("@IsActive", user.IsActive);
                dynamicParameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await sqlConnection.ExecuteAsync(
                    "spcInsertUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteUser(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblUsers>> GetUsers()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblUsers>(
                    "spcGetUsers",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblUsers> GetUser(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblUsers>(
                    "spcGetUserDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<apiResult> UpdateUser(tblUsers user)
        {
            var connectionString = this.GetConnection();
            apiResult _apiResult = new apiResult();
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", user.UserID);
                    dynamicParameters.Add("@FirstName", user.FirstName);
                    dynamicParameters.Add("@LastName", user.LastName);
                    dynamicParameters.Add("@IsActive", user.IsActive);
                    await sqlConnection.ExecuteAsync(
                        "spcUpdateUser",
                        dynamicParameters,
                        commandType: CommandType.StoredProcedure);
                    
                    _apiResult.status = "success";
                    return _apiResult;
                }
            }
            catch
            {
                _apiResult.status = "failure";
                return _apiResult;
                throw;
            }

        }





    }

}
