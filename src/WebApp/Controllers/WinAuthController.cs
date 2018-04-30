using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DBDevOps.Models;
using DevOpsEnvMgmt;
using Newtonsoft.Json;

namespace DevOpsEnvMgmt.Controllers
{
    
    public class WinAuthController : Controller
    {
        // GET: api/<controller>
        //[Produces("application/json")]
        [Route("api/getauthuser")]
        [HttpGet]
        public Task<string> GetUser()
        {
            return Task.Run(() =>
            {
                Debug.Write($"AuthenticationType: {User.Identity.AuthenticationType}");
                Debug.Write($"IsAuthenticated: {User.Identity.IsAuthenticated}");
                Debug.Write($"Name: {User.Identity.Name}");

                AuthenticationResult _identity = new AuthenticationResult();
                _identity.AuthenticationType = User.Identity.AuthenticationType;
                _identity.IsAuthenticated = User.Identity.IsAuthenticated.ToString();
                _identity.Name = User.Identity.Name;
                _identity.Domain = Utilities.GetDomain(User.Identity);
                _identity.Login = Utilities.GetLogin(User.Identity);


                string _jsonString = JsonConvert.SerializeObject(_identity);
                return _jsonString;

                //return SomeLongRunningMethodThatReturnsAString();
            });


            
        }

    }
}
