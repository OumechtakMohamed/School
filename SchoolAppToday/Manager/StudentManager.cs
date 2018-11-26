using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SchoolAppToday.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IdentityModel.Claims;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SchoolAppToday.Manager
{
   public class StudentManager
    {
        SchoolAppTEntities db = new SchoolAppTEntities();
        GeneralManager general = new GeneralManager();

        public StudentManager()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<GET_STUDENTS_PS_Result> GetStudentsFromDB()
        {
            return db.Database.SqlQuery<GET_STUDENTS_PS_Result>("GET_STUDENTS_PS");
        }

        public GET_STUDENT_BY_ID_PS_Result GetStudentsByIdFromDB(int id)
        {
            return db.Database.SqlQuery<GET_STUDENT_BY_ID_PS_Result>("GET_STUDENT_BY_ID_PS @StudentID",
            new SqlParameter("StudentID", id)).SingleOrDefault();
        }

        public StudentInfosModel GetStudentDataFromDB()
        {
            StudentInfosModel s = new StudentInfosModel();
            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            string identifiant = claimsIdentity.Claims.Where(claim => claim.Type == "Id").FirstOrDefault().Value;
            s.FirstName = claimsIdentity.Claims.Where(claim => claim.Type == "FirstName").FirstOrDefault().Value;
            s.LastName = claimsIdentity.Claims.Where(claim => claim.Type == "LastName").FirstOrDefault().Value;
            s.Email = claimsIdentity.Claims.Where(claim => claim.Type == "Email").FirstOrDefault().Value;
            s.Classe = (from a in db.Students
             join c in db.Classes on a.Classe_Code equals c.Code
             where a.User_Id == identifiant
                        select c).SingleOrDefault();
            var suat = (from st in db.Students
                                     join ass in db.Ass_Prof_Classe on st.Classe_Code equals ass.ClasseCode
                                     join t in db.Teachers on ass.Prof_Id equals t.Id
                                     join sub in db.Subjects on t.Subject_Code equals sub.Code
                                     where st.User_Id == identifiant
                                     select new { sub, TeacherFullName = t.FullName}).ToList();
            s.SubjectsAndTeachers = new List<StudentSubjectTeacherModel>();
            foreach (var foo in suat)
            {
                StudentSubjectTeacherModel hr = new StudentSubjectTeacherModel();
                hr.Subject = foo.sub;
                hr.TeacherFullName= foo.TeacherFullName;
                s.SubjectsAndTeachers.Add(hr);
            }
            return s;
        }

        public Boolean DeleteStudentFromDB(int id)
        {
            bool rep = false;
            try
            {
                rep = true;
                db.Database.ExecuteSqlCommand("DELETE_STUDENT_PS @StudentID",
            new SqlParameter("StudentID", id));
            }
            catch (Exception ex)
            {
                rep = false;
                Console.WriteLine(ex);
                throw;
            }
            return rep;
        }

        public void CreateStudentIntoDB(Students stud)
        {
            var students = db.Set<Students>();
            students.Add(stud);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Exception");
            }
        }

        public bool UpdateStudentIntoDB(StudentInfosModel stud)
        {
            bool rep = false;
            try
            {
                db.Database.ExecuteSqlCommand("UPDATEE_STUDENT_BY_ID_PS @Id,@FirstName,@LastName,@Email, @Code",
        new SqlParameter("Id", stud.Id), new SqlParameter("FirstName", stud.FirstName), new SqlParameter("LastName", stud.LastName), new SqlParameter("Email", stud.Email), new SqlParameter("Code", stud.Code));
                rep = true;
            }
            catch
            {
                rep = false;
            }
            return rep;
        }
    }
}