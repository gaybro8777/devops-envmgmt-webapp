using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using DBDevOps.Models;
using Microsoft.AspNetCore.Authorization;

namespace DBDevOps.DataControllers
{
    [Produces("application/json")]
    [Route("api/WinAuth")]
    public class WinAuthController : Controller
    {
        //IHttpContextAccessor httpContextAccessor;
        //string _identityName;
        //string userId;
        AuthenticationResult _identity = new AuthenticationResult();
        public WinAuthController(IHttpContextAccessor httpContextAccessor)
        {
            //this._identityName = httpContextAccessor.HttpContext.User.Identity.Name;
            //this.userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try { this._identity.AuthenticationType = httpContextAccessor.HttpContext.User.Identity.AuthenticationType; }
            catch { this._identity.AuthenticationType = "unknown"; }

            try { this._identity.IsAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated.ToString(); }
            catch { this._identity.IsAuthenticated = "False"; }

            try { this._identity.Name = httpContextAccessor.HttpContext.User.Identity.Name; }
            catch { this._identity.Name = "unknown"; }

            try { this._identity.Domain = DevOpsEnvMgmt.Utilities.GetDomain(httpContextAccessor.HttpContext.User.Identity); }
            catch { this._identity.Domain = "unknown"; }

            try { this._identity.Login = DevOpsEnvMgmt.Utilities.GetLogin(httpContextAccessor.HttpContext.User.Identity); }
            catch { this._identity.Login = "unknown"; }

            //this._identity.IsAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated.ToString();
            //this._identity.Name = httpContextAccessor.HttpContext.User.Identity.Name;
            //this._identity.Domain = DevOpsEnvMgmt.Utilities.GetDomain(httpContextAccessor.HttpContext.User.Identity);
            //this._identity.Login = DevOpsEnvMgmt.Utilities.GetLogin(httpContextAccessor.HttpContext.User.Identity);
        }
        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public async Task<AuthenticationResult> GetUser()
        {
            //return Task.Run(() =>
            //{
            //Debug.Write($"AuthenticationType: {User.Identity.AuthenticationType}");
            //Debug.Write($"IsAuthenticated: {User.Identity.IsAuthenticated}");
            //Debug.Write($"Name: {User.Identity.Name}");

            //AuthenticationResult _identity = new AuthenticationResult();
            //_identity.AuthenticationType = User.Identity.AuthenticationType;
            //_identity.IsAuthenticated = User.Identity.IsAuthenticated.ToString();
            //_identity.Name = User.Identity.Name;
            //_identity.Domain = Utilities.GetDomain(User.Identity);
            //_identity.Login = Utilities.GetLogin(User.Identity);

            //var user = await _userManager.GetUserAsync(HttpContext.User);


            //string _jsonString = JsonConvert.SerializeObject(this._identity);
            //string _jsonString = "{\"AuthenticationType\":\"Kerberos\",\"IsAuthenticated\":\"True\",\"Name\":\"MOTIVA\\Richard.Nunez\",\"Domain\":\"MOTIVA\",\"Login\":\"Richard.Nunez\"}";
            //string _jsonString = this._identityName;
            return this._identity;

                //return SomeLongRunningMethodThatReturnsAString();
            //});
        }
    }
}
