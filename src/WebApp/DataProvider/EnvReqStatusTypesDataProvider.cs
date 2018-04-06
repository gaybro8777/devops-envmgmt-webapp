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
    public class EnvReqStatusTypesDataProvider : IEnvReqStatusTypes
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public EnvReqStatusTypesDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddEnvReqStatusType(tblEnvReqStatusTypes envreqsstatustypes)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Description", envreqsstatustypes.Description);
                dynamicParameters.Add("@OrderBy", envreqsstatustypes.OrderBy);

                dynamicParameters.Add("@EnvReqStatusTypesID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertEnvReqStatusType",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEnvReqStatusType(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvReqStatusTypesID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteEnvReqStatusType",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblEnvReqStatusTypes>> GetEnvReqStatusTypes()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblEnvReqStatusTypes>(
                    "spcGetEnvReqStatusTypes",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblEnvReqStatusTypes> GetEnvReqStatusType(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvReqStatusTypesID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblEnvReqStatusTypes>(
                    "spcGetEnvReqStatusTypeDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEnvReqStatusType(tblEnvReqStatusTypes envreqsstatustypes)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvReqStatusTypesID", envreqsstatustypes.EnvReqStatusTypesID);
                dynamicParameters.Add("@Description", envreqsstatustypes.Description);
                dynamicParameters.Add("@OrderBy", envreqsstatustypes.OrderBy);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateEnvReqStatusType",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
