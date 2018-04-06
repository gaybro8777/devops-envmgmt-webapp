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
    public class RolesDataProvider : IRoles
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public RolesDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddRole(tblRoles role)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RoleName", role.RoleName);
                dynamicParameters.Add("@OrderBy", role.OrderBy);
                dynamicParameters.Add("@IsAdmin", role.IsAdmin);

                dynamicParameters.Add("@RoleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteRole(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RoleID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblRoles>> GetRoles()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblRoles>(
                    "spcGetRoles",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblRoles> GetRole(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ServerID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblRoles>(
                    "pcGetRoleDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateRole(tblRoles role)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RoleID", role.RoleID);
                dynamicParameters.Add("@RoleName", role.RoleName);
                dynamicParameters.Add("@OrderBy", role.OrderBy);
                dynamicParameters.Add("@IsAdmin", role.IsAdmin);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateRole",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
