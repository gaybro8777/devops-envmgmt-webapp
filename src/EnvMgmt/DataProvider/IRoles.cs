using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IRoles
    {
        Task<IEnumerable<tblRoles>> GetRoles();

        Task<tblRoles> GetRole(int id);

        Task AddRole(tblRoles role);

        Task UpdateRole(tblRoles role);

        Task DeleteRole(int id);
    }
}
