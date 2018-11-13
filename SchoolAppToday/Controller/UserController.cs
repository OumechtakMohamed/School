using SchoolAppToday.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAppToday.Controller
{
    public class UserController : ApiController
    {
        public UserManager userManager = new UserManager();

        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>
        /// Get a list of all users
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/user1s")]
        [HttpGet]
        public List<Users> GetUsers()
        {
            return userManager.GetUsersFromDB();
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <remarks>
        /// Get a user by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/user1/{id}")]
        [HttpGet]
        public Users GetUser(int id)
        {
            return userManager.GetUserFromDB(id);
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <remarks>
        /// Delete a user by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/user1/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (userManager.DeleteUserFromDB(id))
                return Ok();
            else return BadRequest("Not a valid user id");
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <remarks>
        /// Create a user
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/user1/create")]
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]Users user)
        {
            if (user != null && userManager.CreateUserIntoDB(user))
            {
                return Ok();
            }
            else return BadRequest("Not a valid user to create");
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <remarks>
        /// Update a user
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/user1/update")]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromBody]Users user)
        {
            if (userManager.UpdateUserIntoDB(user))
                return Ok();
            else return BadRequest("Not a valid user to update");
        }
    }
}
