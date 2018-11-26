using Microsoft.AspNet.Identity.Owin;
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
    public class StudentController : ApiController
    {
        public StudentManager studentManager = new StudentManager();
        /// <summary>
        /// Get all students
        /// </summary>
        /// <remarks>
        /// Get a list of all students
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/students")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<GET_STUDENTS_PS_Result> GetStudents()
        {
            IEnumerable<GET_STUDENTS_PS_Result> items = studentManager.GetStudentsFromDB();
            if (items == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return items;
        }
        /// <summary>
        /// Get student
        /// </summary>
        /// <remarks>
        /// Get student by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/StudentData")]
        [HttpGet]
        [Authorize(Roles = "Student")]
        public StudentInfosModel GetStudent()
        {
            return studentManager.GetStudentDataFromDB();
        }

        /// <summary>
        /// Get student by id
        /// </summary>
        /// <remarks>
        /// Get student by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/student/{id}")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public GET_STUDENT_BY_ID_PS_Result GetStudentById(int id)
        {
            GET_STUDENT_BY_ID_PS_Result item = studentManager.GetStudentsByIdFromDB(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        /// <summary>
        /// delete student
        /// </summary>
        /// <remarks>
        /// delete student by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/student/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            if (studentManager.DeleteStudentFromDB(id))
                return Ok();
            else return BadRequest("Not a valid student id");
        }

        /// <summary>
        /// Update a student
        /// </summary>
        /// <remarks>
        /// Update a student
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/student/update")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateStudent([FromBody]StudentInfosModel stud)
        {
            if (studentManager.UpdateStudentIntoDB(stud))
                return Ok();
            else return BadRequest("Not a valid student to update");
        }
    }
}
