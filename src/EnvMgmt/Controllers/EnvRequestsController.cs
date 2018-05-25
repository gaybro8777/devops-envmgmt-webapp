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
    public class EnvRequestsController : Controller
    {
        private IEnvRequests envrequestsDataProvider;
        public EnvRequestsController(IEnvRequests envrequestsDataProvider)
        {
            this.envrequestsDataProvider = envrequestsDataProvider;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<tblEnvRequests>> Get()
        {
            return await this.envrequestsDataProvider.GetEnvRequests();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<tblEnvRequests> Get(int id)
        {
            return await this.envrequestsDataProvider.GetEnvRequest(id);
        }
        
        // POST: api/Users
        [HttpPost]
        public async Task Post([FromBody]tblEnvRequests value)
        {
            await this.envrequestsDataProvider.AddEnvRequest(value);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblEnvRequests value)
        {
            await this.envrequestsDataProvider.UpdateEnvRequest(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.envrequestsDataProvider.DeleteEnvRequest(id);
        }
    }
}
