using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IUsers
    {
        Task<IEnumerable<tblUsers>> GetUsers();

        Task<tblUsers> GetUser(int id);

        Task AddUser(tblUsers user);

        Task<apiResult> UpdateUser(tblUsers user);

        Task DeleteUser(int id);
    }
}
