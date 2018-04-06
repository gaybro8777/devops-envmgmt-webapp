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
    public class EnvServersController : Controller
    {
        private IEnvServers envserversDataProvider;
        public EnvServersController(IEnvServers envserversDataProvider)
        {
            this.envserversDataProvider = envserversDataProvider;
        }

        // GET: api/EnvServers
        [HttpGet]
        public async Task<IEnumerable<tblEnvServers>> Get()
        {
            return await this.envserversDataProvider.GetEnvServers();
        }

        // GET: api/EnvServers/5
        [HttpGet("{id}")]
        public async Task<tblEnvServers> Get(int id)
        {
            return await this.envserversDataProvider.GetEnvServer(id);
        }
        
        // POST: api/EnvServers
        [HttpPost]
        public async Task Post([FromBody]tblEnvServers value)
        {
            await this.envserversDataProvider.AddEnvServer(value);
        }
        
        // PUT: api/EnvServers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblEnvServers value)
        {
            await this.envserversDataProvider.UpdateEnvServer(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.envserversDataProvider.DeleteEnvServer(id);
        }
    }
}
