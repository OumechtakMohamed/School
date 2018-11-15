using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using SchoolAppToday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SchoolAppToday
{
    public class ApplicationOAuthProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
          

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("Username", context.UserName));
            identity.AddClaim(new Claim("Email", user.Email));
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
            identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
            context.Validated(identity);
            //var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            //var manager = new UserManager<ApplicationUser>(userStore);
            //var user = await manager.FindAsync(context.UserName, context.Password);
            //if (user != null) {
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    identity.AddClaim(new Claim("Username", user.UserName));
            //    identity.AddClaim(new Claim("Email", user.Email));
            //    identity.AddClaim(new Claim("FirstName", user.FirstName));
            //    identity.AddClaim(new Claim("LastName", user.LastName));
            //    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
            //    context.Validated(identity);
            //}
            //else return;
        }
    }
}