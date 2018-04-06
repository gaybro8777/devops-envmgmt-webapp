using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IServerType
    {
        Task<IEnumerable<tblServerType>> GetServerTypes();

        Task<tblServerType> GetServerType(int id);

        Task AddServerType(tblServerType servertype);

        Task UpdateServerType(tblServerType servertype);

        Task DeleteServerType(int id);
    }
}
