using SchoolAppToday.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAppToday.Controller
{
    public class ClasseController : ApiController
    {
        ClasseManager classeManager = new ClasseManager();

        /// <summary>
        /// Get all classes
        /// </summary>
        /// <remarks>
        /// Get a list of all classes
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classes")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Classes> GetClasses()
        {
            IEnumerable<Classes> items = classeManager.GetClassesFromDB();
            if (items == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return items;
        }

        /// <summary>
        /// Get a classe
        /// </summary>
        /// <remarks>
        /// Get a classe by id
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{code}")]
        [HttpGet]
        public Classes GetClasse(string code)
        {
            return classeManager.GetClasseFromDB(code);
        }

        /// <summary>
        /// Get teachers of a classe
        /// </summary>
        /// <remarks>
        /// Get a list of teachers by classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{code}/teachers")]
        [HttpGet]
        public List<Teachers> GetClasseTeachers(string code)
        {
            return classeManager.GetClasseTeachersFromDB(code);
        }

        /// <summary>
        /// Delete a classe
        /// </summary>
        /// <remarks>
        /// Delete a classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{code}")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(string code)
        {
            if (classeManager.DeleteClasseFromDB(code))
            {
                return Ok(); }
            else return BadRequest("Not a valid subject code");
        }

        /// <summary>
        /// Create a classe
        /// </summary>
        /// <remarks>
        /// Create a classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/create")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult CreateClasse([FromBody]Classes clas)
        {
            if (clas != null && classeManager.CreateClasseIntoDB(clas))
            {
                return Ok();
            }
            else return BadRequest("Not a valid subject to create");
        }

        /// <summary>
        /// Insert teacher into classe
        /// </summary>
        /// <remarks>
        /// Insert teacher into classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{code}/teacher")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddTeacherToClasse(String code,[FromBody]int id)
        {
            if (!String.IsNullOrEmpty(code) && classeManager.AddTeacherToClasseIntoDB(code,id))
            {
                return Ok();
            }
            else return BadRequest("Not a valid subject to create");
        }

        /// <summary>
        /// Delete a teacher from classe
        /// </summary>
        /// <remarks>
        /// Delete a teacher from classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{code}/teacher/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteTeacherFromClasse(string code, int id)
        {
            if (classeManager.removeTeacherAssClassesFromDB(code, id))
            {
                return Ok();
            }
            else return BadRequest("Not a valid teacher id");
        }

        /// <summary>
        /// Update a classe
        /// </summary>
        /// <remarks>
        /// Update a classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/update")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateClasse([FromBody]Classes clas)
        {
            if (classeManager.UpdateClasseIntoDB(clas))
                return Ok();
            else return BadRequest("Not a valid subject to update");
        }
    }
}
