using SchoolAppToday.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAppToday.Controller
{
    public class TeacherController : ApiController
    {
        public TeacherManager teacherManager = new TeacherManager();

        /// <summary>
        /// Get all teachers
        /// </summary>
        /// <remarks>
        /// Get a list of all teachers
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teachers")]
        [HttpGet]
        public List<Teachers> GetTeachers()
        {
            return teacherManager.GetTeachersFromDB();
        }

        /// <summary>
        /// Get a teacher by id
        /// </summary>
        /// <remarks>
        /// Get a teacher by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/{id}")]
        [HttpGet]
        public Teachers GetTeacher(int id)
        {
            return teacherManager.GetTeacherFromDB(id);
        }

        /// <summary>
        /// Get all classes of a teacher by id
        /// </summary>
        /// <remarks>
        /// Get a list of all classes by teacher id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/{id}/classes")]
        [HttpGet]
        public List<Classes> GetTeacherClasses(int id)
        {
            return teacherManager.GetTeacherClassesFromDB(id);
        }

        /// <summary>
        /// Delete a teacher by id
        /// </summary>
        /// <remarks>
        /// Delete a teacher by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (teacherManager.DeleteTeacherFromDB(id))
            {
                teacherManager.removeTeacherAssClassesFromDB(id);
                return Ok(); }
            else return BadRequest("Not a valid teacher id");
        }

        /// <summary>
        /// Create a teacher
        /// </summary>
        /// <remarks>
        /// Create a teacher
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/create")]
        [HttpPost]
        public IHttpActionResult CreateTeacher([FromBody]Teachers teach)
        {
            int use_id = teacherManager.CreateTeacherIntoUserDB(teach);
            if (teach != null && use_id != -1)
            {
                teach.User_Id = use_id;
                if (teacherManager.CreateTeacherIntoDB(teach))
                { return Ok(); }
                else return BadRequest("Not a valid teacher to create");
            }
            else return BadRequest("Teacher exist already");
        }

        /// <summary>
        /// Update a teacher
        /// </summary>
        /// <remarks>
        /// Update a teacher
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/update")]
        [HttpPut]
        public IHttpActionResult UpdateTeacher([FromBody]Teachers teach)
        {
            if (teacherManager.UpdateTeacherIntoDB(teach))
                return Ok();
            else return BadRequest("Not a valid teacher to update");
        }

        /// <summary>
        /// Create a classe for a teacher
        /// </summary>
        /// <remarks>
        /// Create a classe for a teacher
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/{id}/classe/create")]
        [HttpPost]
        public IHttpActionResult CreateTeacherClasse(int id, [FromBody]string classe)
        {
            if (id != null && classe != null && teacherManager.CreateTeacherClasseIntoDB(id, classe))
            {
                return Ok();
            }
            else return BadRequest("Not a valid subject to create");
        }
    }
}

