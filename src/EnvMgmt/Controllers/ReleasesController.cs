using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBDevOps.DataProvider;
using DBDevOps.Models;

namespace DBDevOps.DataControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReleasesController : Controller
    {
        private IReleases releasesDataProvider;
        public ReleasesController(IReleases releasesDataProvider)
        {
            this.releasesDataProvider = releasesDataProvider;
        }

        // GET: api/Releases
        [HttpGet]
        public async Task<IEnumerable<tblReleases>> Get()
        {
            return await this.releasesDataProvider.GetReleases();
        }

        // GET: api/Releases/5
        [HttpGet("{id}")]
        public async Task<tblReleases> Get(int id)
        {
            return await this.releasesDataProvider.GetRelease(id);
        }
        
        // POST: api/Releases
        [HttpPost]
        public async Task Post([FromBody]tblReleases value)
        {
            await this.releasesDataProvider.AddRelease(value);
        }
        
        // PUT: api/Releases/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblReleases value)
        {
            await this.releasesDataProvider.UpdateRelease(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.releasesDataProvider.DeleteRelease(id);
        }
    }
}
