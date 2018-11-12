using Microsoft.AspNet.Identity.Owin;
using SchoolAppToday.Manager;
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
        [Route("api/student/{id}")]
        [HttpGet]
        public Students GetStudent(int id)
        {
            return studentManager.GetStudentFromDB(id);
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
        /// create a student
        /// </summary>
        /// <remarks>
        /// create student
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/student/create")]
        [HttpPost]
        public IHttpActionResult CreateSudent([FromBody]Students stud)
        {
            int use_id = studentManager.CreateStudentIntoUserDB(stud);
            if (stud != null && use_id != -1)
            {
                stud.User_Id = use_id;
                if (studentManager.CreateStudentIntoDB(stud))
                { return Ok(); }
                else return BadRequest("Not a valid student to create");
            }
            else return BadRequest("Student exist already"); 
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
