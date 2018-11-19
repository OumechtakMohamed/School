using SchoolAppToday.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAppToday.Controller
{
    public class SubjectController : ApiController
    {
        SubjectManager subjectManager = new SubjectManager();

        /// <summary>
        /// Get all subjects
        /// </summary>
        /// <remarks>
        /// Get a list of all subject
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/subjects")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Subjects> GetSubjects()
        {
            return subjectManager.GetSubjectsFromDB();
        }

        /// <summary>
        /// Get a subject by code
        /// </summary>
        /// <remarks>
        /// Get a subject by code
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/subject/{code}")]
        [HttpGet]
        public Subjects GetSubject(string code)
        {
            return subjectManager.GetSubjectFromDB(code);
        }

        /// <summary>
        /// Delete a subejct
        /// </summary>
        /// <remarks>
        /// Delete a subject by code
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/subject/{code}")]
        [HttpDelete]
        public IHttpActionResult Delete(string code)
        {
            if (subjectManager.DeleteSubjectFromDB(code))
                return Ok();
            else return BadRequest("Not a valid subject code");
        }

        /// <summary>
        /// Create a subject
        /// </summary>
        /// <remarks>
        /// Create a subject
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/subject/create")]
        [HttpPost]
        public IHttpActionResult CreateSubject([FromBody]Subjects subj)
        {
            if (subj != null && subjectManager.CreateSubjectIntoDB(subj))
            {
                return Ok();
            }
            else return BadRequest("Not a valid subject to create");
        }

        /// <summary>
        /// Uddate a subject
        /// </summary>
        /// <remarks>
        /// Update a subject
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/subject/update")]
        [HttpPut]
        public IHttpActionResult UpdateSubject([FromBody]Subjects subj)
        {
            if (subjectManager.UpdateSubjectIntoDB(subj))
                return Ok();
            else return BadRequest("Not a valid subject to update");
        }
    }
}
