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
    public class UserRolesDataProvider : IUserRoles
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public UserRolesDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddUserRole(tblUserRoles userrole)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", userrole.UserID);
                dynamicParameters.Add("@RoleID", userrole.RoleID);
                dynamicParameters.Add("@UserRoleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertUserRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteUserRole(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserRoleID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteUserRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblUserRoles>> GetUserRoles()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblUserRoles>(
                    "spcGetUserRoles",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblUserRoles> GetUserRole(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserRoleID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblUserRoles>(
                    "pcGetUserRoleDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateUserRole(tblUserRoles userrole)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserRoleID", userrole.UserRoleID);
                dynamicParameters.Add("@UserID", userrole.UserID);
                dynamicParameters.Add("@RoleID", userrole.RoleID);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateUserRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
