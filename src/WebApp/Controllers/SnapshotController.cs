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

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<HPALM_SnapshotView1>> Get()
        {
            return await this.hpalmsnapshotDataProvider.GetSnapshot();
        }
    }
}
