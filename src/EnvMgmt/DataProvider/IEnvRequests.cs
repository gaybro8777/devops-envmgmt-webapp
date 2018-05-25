using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IEnvRequests
    {
        Task<IEnumerable<tblEnvRequests>> GetEnvRequests();

        Task<tblEnvRequests> GetEnvRequest(int id);

        Task AddEnvRequest(tblEnvRequests envrequest);

        Task UpdateEnvRequest(tblEnvRequests envrequest);

        Task DeleteEnvRequest(int id);
    }
}
