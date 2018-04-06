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
    public class ServersController : Controller
    {
        private IServers serversDataProvider;
        public ServersController(IServers serversDataProvider)
        {
            this.serversDataProvider = serversDataProvider;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<IEnumerable<tblServers>> Get()
        {
            return await this.serversDataProvider.GetServers();
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<tblServers> Get(int id)
        {
            return await this.serversDataProvider.GetServer(id);
        }
        
        // POST: api/Servers
        [HttpPost]
        public async Task Post([FromBody]tblServers value)
        {
            await this.serversDataProvider.AddServer(value);
        }
        
        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblServers value)
        {
            await this.serversDataProvider.UpdateServer(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.serversDataProvider.DeleteServer(id);
        }
    }
}
