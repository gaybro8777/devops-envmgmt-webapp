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
    public class UserRolesController : Controller
    {
        private IUserRoles userrolessDataProvider;
        public UserRolesController(IUserRoles userrolessDataProvider)
        {
            this.userrolessDataProvider = userrolessDataProvider;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<IEnumerable<tblUserRoles>> Get()
        {
            return await this.userrolessDataProvider.GetUserRoles();
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<tblUserRoles> Get(int id)
        {
            return await this.userrolessDataProvider.GetUserRole(id);
        }
        
        // POST: api/UserRoles
        [HttpPost]
        public async Task Post([FromBody]tblUserRoles value)
        {
            await this.userrolessDataProvider.AddUserRole(value);
        }
        
        // PUT: api/UserRoles/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblUserRoles value)
        {
            await this.userrolessDataProvider.UpdateUserRole(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.userrolessDataProvider.DeleteUserRole(id);
        }
    }
}
