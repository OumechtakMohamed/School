using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SchoolAppToday.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public List<Students> GetStudentsFromDB()
        {
            return db.Students.ToList();
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

        public bool DeleteStudentFromDB(int id)
        {
            bool result1 = false;
            var student = db.Students
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            if (student != null)
            {

                db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                    result1 = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    result1 = false;
                }
            }
            
            return result1;
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

        public bool UpdateStudentIntoDB(Students stud)
        {
            bool rep = false;
            var result = db.Students.SingleOrDefault(b => b.Id == stud.Id);
            if (result != null)
            {
                db.Students.AddOrUpdate(stud);
                try
                {
                    db.SaveChanges();
                    rep = true;
                }
                catch
                {
                    rep = false;
                }
            }
            return rep;
        }
    }
}