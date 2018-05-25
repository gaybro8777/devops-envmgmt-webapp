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
    public class UsersController : Controller
    {
        private IUsers usersDataProvider;
        public UsersController(IUsers usersDataProvider)
        {
            this.usersDataProvider = usersDataProvider;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<tblUsers>> Get()
        {
            return await this.usersDataProvider.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<tblUsers> Get(int id)
        {
            return await this.usersDataProvider.GetUser(id);
        }
        
        // POST: api/Users
        [HttpPost]
        public async Task Post([FromBody]tblUsers value)
        {
            await this.usersDataProvider.AddUser(value);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<apiResult> Put(int id, [FromBody]tblUsers value)
        {
            return await this.usersDataProvider.UpdateUser(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.usersDataProvider.DeleteUser(id);
        }
    }
}
