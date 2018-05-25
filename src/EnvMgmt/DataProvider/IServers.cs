using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IServers
    {
        Task<IEnumerable<tblServers>> GetServers();

        Task<tblServers> GetServer(int id);

        Task AddServer(tblServers server);

        Task UpdateServer(tblServers server);

        Task DeleteServer(int id);
    }
}
