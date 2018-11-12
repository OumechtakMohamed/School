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
        public IEnumerable<Classes> GetClasses()
        {
            return classeManager.GetClassesFromDB();
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
        /// Get all subjects for a classe
        /// </summary>
        /// <remarks>
        /// Get a list of subjects of a classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{code}/subjects")]
        [HttpGet]
        public List<Subjects> GetClasseSubjects(string code)
        {
            return classeManager.GetClasseSubjectsFromDB(code);
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
        public IHttpActionResult CreateClasse([FromBody]Classes clas)
        {
            if (clas != null && classeManager.CreateClasseIntoDB(clas))
            {
                return Ok();
            }
            else return BadRequest("Not a valid subject to create");
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
        public IHttpActionResult UpdateClasse([FromBody]Classes clas)
        {
            if (classeManager.UpdateClasseIntoDB(clas))
                return Ok();
            else return BadRequest("Not a valid subject to update");
        }

        /// <summary>
        /// Create a subject for a classe
        /// </summary>
        /// <remarks>
        /// Create a subject for a classe
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [Route("api/classe/{ClasseCode}/subject/create")]
        [HttpPost]
        public IHttpActionResult CreateClasseSubject(string ClasseCode,[FromBody]string subject)
        {
            if (subject != null && ClasseCode != null && classeManager.CreateClasseSubjectIntoDB(ClasseCode, subject))
            {
                return Ok();
            }
            else return BadRequest("Not a valid subject to create");
        }
    }
}
