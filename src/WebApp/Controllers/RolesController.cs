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
    public class RolesController : Controller
    {
        private IRoles rolesDataProvider;
        public RolesController(IRoles rolesDataProvider)
        {
            this.rolesDataProvider = rolesDataProvider;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<tblRoles>> Get()
        {
            return await this.rolesDataProvider.GetRoles();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<tblRoles> Get(int id)
        {
            return await this.rolesDataProvider.GetRole(id);
        }
        
        // POST: api/Users
        [HttpPost]
        public async Task Post([FromBody]tblRoles value)
        {
            await this.rolesDataProvider.AddRole(value);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblRoles value)
        {
            await this.rolesDataProvider.UpdateRole(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.rolesDataProvider.DeleteRole(id);
        }
    }
}
