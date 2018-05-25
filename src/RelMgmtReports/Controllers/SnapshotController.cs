using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBDevOps.DataProvider;
using DBDevOps.Models;

namespace DBDevOps.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SnapshotController : Controller
    {
        private IHPALMSnapshot hpalmsnapshotDataProvider;
        public SnapshotController(IHPALMSnapshot hpalmsnapshotDataProvider)
        {
            this.hpalmsnapshotDataProvider = hpalmsnapshotDataProvider;
        }

        // GET: api/Snapshot/1
        [HttpGet]
        [Route("SnapshotById/{snapshotid}")]
        public async Task<IEnumerable<HPALM_SnapshotView1>> GetSnapshotById(int snapshotid)
        {
            return await this.hpalmsnapshotDataProvider.GetSnapshot(snapshotid);
        }

        // GET: api/Snapshot/1
        [HttpGet]
        [Route("SnapshotList")]
        public async Task<IEnumerable<HPALMSnapshotList>> GetSnapshotById()
        {
            return await this.hpalmsnapshotDataProvider.GetSnapshotList();
        }
    }
}
