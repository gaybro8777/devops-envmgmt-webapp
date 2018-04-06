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
    public class ProjectTeamController : Controller
    {
        private IProjectTeam projectteamDataProvider;
        public ProjectTeamController(IProjectTeam projectteamDataProvider)
        {
            this.projectteamDataProvider = projectteamDataProvider;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<tblProjectTeam>> Get()
        {
            return await this.projectteamDataProvider.GetProjectTeams();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<tblProjectTeam> Get(int id)
        {
            return await this.projectteamDataProvider.GetProjectTeam(id);
        }
        
        // POST: api/Users
        [HttpPost]
        public async Task Post([FromBody]tblProjectTeam value)
        {
            await this.projectteamDataProvider.AddProjectTeam(value);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblProjectTeam value)
        {
            await this.projectteamDataProvider.UpdateProjectTeam(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.projectteamDataProvider.DeleteProjectTeam(id);
        }
    }
}
