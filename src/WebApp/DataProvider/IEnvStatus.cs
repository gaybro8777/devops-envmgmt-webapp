using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IEnvStatus
    {
        Task<IEnumerable<tblEnvStatus>> GetEnvStatuses();

        Task<tblEnvStatus> GetEnvStatus(int id);

        Task AddEnvStatus(tblEnvStatus envstatus);

        Task UpdateEnvStatus(tblEnvStatus envstatus);

        Task DeleteEnvStatus(int id);
    }
}
