using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IEnvironments
    {
        Task<IEnumerable<tblEnvironments>> GetEnvironments();
        Task<IEnumerable<tblEnvironments>> GetEnvironmentsByAppId(int AppID);

        Task<tblEnvironments> GetEnvironment(int id);

        Task AddEnvironment(tblEnvironments environment);

        Task UpdateEnvironment(tblEnvironments environment);

        Task DeleteEnvironment(int id);
    }
}
