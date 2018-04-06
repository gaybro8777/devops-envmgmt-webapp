using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IProjectTeam
    {
        Task<IEnumerable<tblProjectTeam>> GetProjectTeams();

        Task<tblProjectTeam> GetProjectTeam(int id);

        Task AddProjectTeam(tblProjectTeam projectteam);

        Task UpdateProjectTeam(tblProjectTeam projectteam);

        Task DeleteProjectTeam(int id);
    }
}
