using SchoolAppToday.Manager;
using SchoolAppToday.Models;
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
        public ClasseManager classeManager = new ClasseManager();

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
        [Authorize(Roles = "Admin")]
        public IEnumerable<GET_TEACHERS_PS_Result> GetStudents()
        {
            IEnumerable<GET_TEACHERS_PS_Result> items = teacherManager.GetTeachersFromDB();
            if (items == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return items;
        }

        /// <summary>
        /// Get teacher by id
        /// </summary>
        /// <remarks>
        /// Get teacher by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/teacher/{id}")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public GET_TEACHER_BY_ID_PS_Result GetTeacherById(int id)
        {
            GET_TEACHER_BY_ID_PS_Result item = teacherManager.GetTeachersByIdFromDB(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        /// <summary>
        /// Get a teacher by id
        /// </summary>
        /// <remarks>
        /// Get a teacher by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/TeacherData")]
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public TeacherStudentsInfosModel GetTeacher()
        {
            TeacherStudentsInfosModel item = teacherManager.GetTeacherDataFromDB();
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
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
            if (teacherManager.DeleteTeacherFromDB(id) && classeManager.removeTeacherAssClassesFromDB(null,id))
            {
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
            if (teach != null)
            {
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
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateTeacher([FromBody]TeacherInfosModel teach)
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

