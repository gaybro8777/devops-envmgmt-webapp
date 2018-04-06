using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IReleases
    {
        Task<IEnumerable<tblReleases>> GetReleases();

        Task<tblReleases> GetRelease(int id);

        Task AddRelease(tblReleases release);

        Task UpdateRelease(tblReleases release);

        Task DeleteRelease(int id);
    }
}
