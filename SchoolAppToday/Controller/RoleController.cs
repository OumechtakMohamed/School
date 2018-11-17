using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolAppToday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAppToday.Controller
{
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMgr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "For Admin Role";
        }
    }

}
