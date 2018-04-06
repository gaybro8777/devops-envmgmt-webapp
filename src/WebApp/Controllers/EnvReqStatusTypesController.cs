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
    public class EnvReqStatusTypesController : Controller
    {
        private IEnvReqStatusTypes envreqsstatustypesDataProvider;
        public EnvReqStatusTypesController(IEnvReqStatusTypes envreqsstatustypesDataProvider)
        {
            this.envreqsstatustypesDataProvider = envreqsstatustypesDataProvider;
        }

        // GET: api/EnvReqStatusTypes
        [HttpGet]
        public async Task<IEnumerable<tblEnvReqStatusTypes>> Get()
        {
            return await this.envreqsstatustypesDataProvider.GetEnvReqStatusTypes();
        }

        // GET: api/EnvReqStatusTypes/5
        [HttpGet("{id}")]
        public async Task<tblEnvReqStatusTypes> Get(int id)
        {
            return await this.envreqsstatustypesDataProvider.GetEnvReqStatusType(id);
        }
        
        // POST: api/EnvReqStatusTypes
        [HttpPost]
        public async Task Post([FromBody]tblEnvReqStatusTypes value)
        {
            await this.envreqsstatustypesDataProvider.AddEnvReqStatusType(value);
        }
        
        // PUT: api/EnvReqStatusTypes/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]tblEnvReqStatusTypes value)
        {
            await this.envreqsstatustypesDataProvider.UpdateEnvReqStatusType(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.envreqsstatustypesDataProvider.DeleteEnvReqStatusType(id);
        }
    }
}
