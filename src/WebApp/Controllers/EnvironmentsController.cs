using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBDevOps.DataProvider;
using DBDevOps.Models;

namespace DBDevOps.DataControllers
{
    //[Produces("application/json")]
    public class EnvironmentsController : Controller
    {
        // [Route("api/[controller]")]
        private IEnvironments applicationsDataProvider;
        public EnvironmentsController(IEnvironments applicationsDataProvider)
        {
            this.applicationsDataProvider = applicationsDataProvider;
        }

        // GET: api/Environments
        [Route("api/Environments")]
        [HttpGet]
        public async Task<IEnumerable<tblEnvironments>> Get()
        {
            return await this.applicationsDataProvider.GetEnvironments();
        }

        // GET: api/Environments/AppID/1
        [Route("api/Environments/AppID/{id}")]
        //[HttpGet("{id}")]
        public async Task<IEnumerable<AppEnvsByAppID>> GetbyAppId(int id)
        {
            return await this.applicationsDataProvider.GetEnvironmentsByAppId(id);
        }

        // GET: api/Environments/5
        [Route("api/Environments/{id}")]
        //[HttpGet("{id}")]
        public async Task<tblEnvironments> GetIndividual(int id)
        {
            return await this.applicationsDataProvider.GetEnvironment(id);
        }

        // POST: api/Environments
        [Route("api/Environments")]
        [HttpPost]
        public async Task Post([FromBody]tblEnvironments value)
        {
            await this.applicationsDataProvider.AddEnvironment(value);
        }

        // PUT: api/Environments/5
        [Route("api/Environments")]
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblEnvironments value)
        {
            await this.applicationsDataProvider.UpdateEnvironment(value);
        }

        // DELETE: api/ApiWithActions/5
        [Route("api/Environments")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.applicationsDataProvider.DeleteEnvironment(id);
        }
    }
}
