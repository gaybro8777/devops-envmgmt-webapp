using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IApplications
    {
        Task<IEnumerable<tblApplications>> GetApplications();

        Task<tblApplications> GetApplication(int id);

        Task AddApplication(tblApplications application);

        Task UpdateApplication(tblApplications application);

        Task DeleteApplication(int id);
    }
}
