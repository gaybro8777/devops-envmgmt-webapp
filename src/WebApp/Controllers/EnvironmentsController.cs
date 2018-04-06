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
        //[HttpGet("{id}")]
        //[Route("api/Environments/AppID")]
        //[HttpGet("{id}")]
        //public async Task<IEnumerable<tblEnvironments>> GetbyAppId(int id)
        //{
        //    // public async Task<IEnumerable<tblEnvironments>> GetbyAppId(int id)
        //    return await this.applicationsDataProvider.GetEnvironmentsByAppId(id);

        //    //IEnumerable<tblEnvironments> tbls_ = await this.applicationsDataProvider.GetEnvironmentsByAppId(id);
        //    //return tbls_;

        //    //IEnumerable<tblEnvironments> tbls_ = Enumerable.Empty<tblEnvironments>();
        //    //tblEnvironments tbl_ = new tblEnvironments();
        //    //tbls_.Append(tbl_);
        //    //return tbls_;
        //    //return 1;
        //}

        // GET: api/Environments/5
        // [Route("api/Environments/{id}")]
        // [HttpGet("{id}")]
        // public async Task<tblEnvironments> Get(int id)
        // {
        //     //tblEnvironments tbl_ = await this.applicationsDataProvider.GetEnvironment(id);
        //     //return await this.applicationsDataProvider.GetEnvironment(id);
        //     // tblEnvironments tbl_ = new tblEnvironments();
        //     // tbl_.EnvName = "asdf";
        //     // tbl_.EnvironmentID = 1;
        //     // return tbl_;
        // }

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
