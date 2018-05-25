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
    public class EnvStatusController : Controller
    {
        private IEnvStatus envstatusDataProvider;
        public EnvStatusController(IEnvStatus envstatusDataProvider)
        {
            this.envstatusDataProvider = envstatusDataProvider;
        }

        // GET: api/EnvStatus
        [HttpGet]
        public async Task<IEnumerable<tblEnvStatus>> Get()
        {
            return await this.envstatusDataProvider.GetEnvStatuses();
        }

        // GET: api/EnvStatus/5
        [HttpGet("{id}")]
        public async Task<tblEnvStatus> Get(int id)
        {
            return await this.envstatusDataProvider.GetEnvStatus(id);
        }
        
        // POST: api/EnvStatus
        [HttpPost]
        public async Task Post([FromBody]tblEnvStatus value)
        {
            await this.envstatusDataProvider.AddEnvStatus(value);
        }
        
        // PUT: api/EnvStatus/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblEnvStatus value)
        {
            await this.envstatusDataProvider.UpdateEnvStatus(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.envstatusDataProvider.DeleteEnvStatus(id);
        }
    }
}
