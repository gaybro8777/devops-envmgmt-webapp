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
    public class ApplicationsController : Controller
    {
        private IApplications applicationsDataProvider;
        public ApplicationsController(IApplications applicationsDataProvider)
        {
            this.applicationsDataProvider = applicationsDataProvider;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<IEnumerable<tblApplications>> Get()
        {
            return await this.applicationsDataProvider.GetApplications();
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<tblApplications> Get(int id)
        {
            return await this.applicationsDataProvider.GetApplication(id);
        }
        
        // POST: api/Applications
        [HttpPost]
        public async Task Post([FromBody]tblApplications value)
        {
            await this.applicationsDataProvider.AddApplication(value);
        }
        
        // PUT: api/Applications/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblApplications value)
        {
            await this.applicationsDataProvider.UpdateApplication(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.applicationsDataProvider.DeleteApplication(id);
        }
    }
}
