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
    public class AppEnvsController : Controller
    {
        private IAppEnvs appenvsDataProvider;
        public AppEnvsController(IAppEnvs appenvsDataProvider)
        {
            this.appenvsDataProvider = appenvsDataProvider;
        }

        // GET: api/AppEnvs
        [HttpGet]
        public async Task<IEnumerable<tblAppEnvs>> Get()
        {
            return await this.appenvsDataProvider.GetAppEnvs();
        }

        // GET: api/AppEnvs/5
        [HttpGet("{id}")]
        public async Task<tblAppEnvs> Get(int id)
        {
            return await this.appenvsDataProvider.GetAppEnv(id);
        }
        
        // POST: api/AppEnvs
        [HttpPost]
        public async Task Post([FromBody]tblAppEnvs value)
        {
            await this.appenvsDataProvider.AddAppEnv(value);
        }
        
        // PUT: api/AppEnvs/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblAppEnvs value)
        {
            await this.appenvsDataProvider.UpdateAppEnv(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.appenvsDataProvider.DeleteAppEnv(id);
        }
    }
}
