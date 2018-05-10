using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IHPALMSnapshot
    {
        Task<IEnumerable<HPALM_SnapshotView1>> GetSnapshot();
    }
}
