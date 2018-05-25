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
    public class EnvRequestsDataProvider : IEnvRequests
    {
        IConfiguration _configuration;
        //private readonly string connectionString = "Server=192.168.217.129;Database=DevOps; User ID=richard; Password=richard";

        public EnvRequestsDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DevOpsDatabase").Value;
            return connection;
        }

        public async Task AddEnvRequest(tblEnvRequests envrequest)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RequestorID", envrequest.RequestorID);
                dynamicParameters.Add("@OwnerID", envrequest.OwnerID);
                dynamicParameters.Add("@ReleaseID", envrequest.ReleaseID);
                dynamicParameters.Add("@ApplicationID", envrequest.ApplicationID);
                dynamicParameters.Add("@DateFrom", envrequest.DateFrom);
                dynamicParameters.Add("@TimeFrom", envrequest.TimeFrom);
                dynamicParameters.Add("@DateTo", envrequest.DateTo);
                dynamicParameters.Add("@TimeTo", envrequest.TimeTo);
                dynamicParameters.Add("@EnvReqStatusTypesID", envrequest.EnvReqStatusTypesID);
                dynamicParameters.Add("@Notes", envrequest.Notes);

                dynamicParameters.Add("@EnvRequestID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await sqlConnection.ExecuteAsync(
                    "spcInsertEnvRequest",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEnvRequest(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvRequestID", id);
                await sqlConnection.ExecuteAsync(
                    "spcDeleteEnvRequest",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<tblEnvRequests>> GetEnvRequests()
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<tblEnvRequests>(
                    "spcGetEnvRequests",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<tblEnvRequests> GetEnvRequest(int id)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvRequestID", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<tblEnvRequests>(
                    "spcGetEnvRequestDetails",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEnvRequest(tblEnvRequests envrequest)
        {
            var connectionString = this.GetConnection();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EnvRequestID", envrequest.EnvRequestID);
                dynamicParameters.Add("@RequestorID", envrequest.RequestorID);
                dynamicParameters.Add("@OwnerID", envrequest.OwnerID);
                dynamicParameters.Add("@ReleaseID", envrequest.ReleaseID);
                dynamicParameters.Add("@ApplicationID", envrequest.ApplicationID);
                dynamicParameters.Add("@DateFrom", envrequest.DateFrom);
                dynamicParameters.Add("@TimeFrom", envrequest.TimeFrom);
                dynamicParameters.Add("@DateTo", envrequest.DateTo);
                dynamicParameters.Add("@TimeTo", envrequest.TimeTo);
                dynamicParameters.Add("@EnvReqStatusTypesID", envrequest.EnvReqStatusTypesID);
                dynamicParameters.Add("@Notes", envrequest.Notes);
                await sqlConnection.ExecuteAsync(
                    "spcUpdateEnvRequest",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }





    }

}
