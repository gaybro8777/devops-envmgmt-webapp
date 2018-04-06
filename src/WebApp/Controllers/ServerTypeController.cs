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
    public class ServerTypeController : Controller
    {
        private IServerType servertypeDataProvider;
        public ServerTypeController(IServerType usersDataProvider)
        {
            this.servertypeDataProvider = usersDataProvider;
        }

        // GET: api/ServerType
        [HttpGet]
        public async Task<IEnumerable<tblServerType>> Get()
        {
            return await this.servertypeDataProvider.GetServerTypes();
        }

        // GET: api/ServerType/5
        [HttpGet("{id}")]
        public async Task<tblServerType> Get(int id)
        {
            return await this.servertypeDataProvider.GetServerType(id);
        }

        // POST: api/ServerType
        [HttpPost]
        public async Task Post([FromBody]tblServerType value)
        {
            await this.servertypeDataProvider.AddServerType(value);
        }

        // PUT: api/ServerType/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblServerType value)
        {
            await this.servertypeDataProvider.UpdateServerType(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.servertypeDataProvider.DeleteServerType(id);
        }
    }
}
