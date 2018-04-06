using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IEnvServers
    {
        Task<IEnumerable<tblEnvServers>> GetEnvServers();

        Task<tblEnvServers> GetEnvServer(int id);

        Task AddEnvServer(tblEnvServers envserver);

        Task UpdateEnvServer(tblEnvServers envserver);

        Task DeleteEnvServer(int id);
    }
}
