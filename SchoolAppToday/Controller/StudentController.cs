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
        public List<Students> GetStudents()
        {
            return studentManager.GetStudentsFromDB();
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
        /// delete student
        /// </summary>
        /// <remarks>
        /// delete student by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/student/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (studentManager.DeleteStudentFromDB(id))
                return Ok();
            else return BadRequest("Not a valid student id");
        }


        /// <summary>
        /// Update student
        /// </summary>
        /// <remarks>
        /// Update student
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/student/update")]
        [HttpPut]
        public IHttpActionResult UpdateSudent([FromBody]Students stud)
        {
            if(studentManager.UpdateStudentIntoDB(stud))
                return Ok();
            else return BadRequest("Not a valid student to update");
        }
    }
}
