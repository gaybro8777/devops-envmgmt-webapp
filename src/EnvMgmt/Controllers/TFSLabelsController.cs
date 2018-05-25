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
    public class TFSLabelsController : Controller
    {
        private ITFSLabels tfslabelsDataProvider;
        public TFSLabelsController(ITFSLabels tfslabelsDataProvider)
        {
            this.tfslabelsDataProvider = tfslabelsDataProvider;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<IEnumerable<TfsLabels>> Get()
        {
            return await this.tfslabelsDataProvider.GetTFSLabels();
        }
    }
}
