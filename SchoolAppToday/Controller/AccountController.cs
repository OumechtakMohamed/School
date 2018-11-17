using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolAppToday.Manager;
using SchoolAppToday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SchoolAppToday.Controller
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var studentManager = new StudentManager();
            var teacherManager = new TeacherManager();
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            manager.AddToRole(user.Id, model.Role);
            if(!string.IsNullOrEmpty(model.Class_Code))
            {
                Students s = new Students();
                s.User_Id = user.Id;
                s.Classe_Code = model.Class_Code;
                studentManager.CreateStudentIntoDB(s);
            }
            if(!string.IsNullOrEmpty(model.Subject_Code))
            {
                Teachers t = new Teachers();
                t.User_Id = user.Id;
                t.Subject_Code = model.Subject_Code;
                teacherManager.CreateTeacherIntoDB(t);
            }
            return result;
        }

        [Route("api/GetUserClaims")]
        [HttpGet]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }
    }
}
