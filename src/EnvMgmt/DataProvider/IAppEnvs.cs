  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IAppEnvs
    {
        Task<IEnumerable<tblAppEnvs>> GetAppEnvs();

        Task<tblAppEnvs> GetAppEnv(int id);

        Task AddAppEnv(tblAppEnvs appenv);

        Task UpdateAppEnv(tblAppEnvs appenv);

        Task DeleteAppEnv(int id);
    }
}
