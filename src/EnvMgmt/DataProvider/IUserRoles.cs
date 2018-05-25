using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IUserRoles
    {
        Task<IEnumerable<tblUserRoles>> GetUserRoles();

        Task<tblUserRoles> GetUserRole(int id);

        Task AddUserRole(tblUserRoles userrole);

        Task UpdateUserRole(tblUserRoles userrole);

        Task DeleteUserRole(int id);
    }
}
