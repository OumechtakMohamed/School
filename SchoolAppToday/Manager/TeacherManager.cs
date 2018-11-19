using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolAppToday.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SchoolAppToday.Manager
{
    public class TeacherManager
    {
        SchoolAppTEntities db = new SchoolAppTEntities();
        GeneralManager general = new GeneralManager();
        public TeacherManager()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<Teachers> GetTeachersFromDB()
        {
            return db.Teachers.ToList();
        }

        public List<Classes> GetTeacherClassesFromDB(int id)
        {
            var classes = (from a in db.Ass_Prof_Classe
                           join c in db.Classes on a.ClasseCode equals c.Code
                           where a.Prof_Id == id
                           select c);
            return classes.ToList();
        }
        public TeacherInfosModel GetTeacherDataFromDB()
        {
            TeacherInfosModel t = new TeacherInfosModel();
            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            string identifiant = claimsIdentity.Claims.Where(claim => claim.Type == "Id").FirstOrDefault().Value;
            t.FirstName = claimsIdentity.Claims.Where(claim => claim.Type == "FirstName").FirstOrDefault().Value;
            t.LastName = claimsIdentity.Claims.Where(claim => claim.Type == "LastName").FirstOrDefault().Value;
            t.Email = claimsIdentity.Claims.Where(claim => claim.Type == "Email").FirstOrDefault().Value;
            t.Subject = (from a in db.Teachers
                        join c in db.Subjects on a.Subject_Code equals c.Code
                        where a.User_Id == identifiant
                        select c).SingleOrDefault();
            var suat = (from st in db.Students
                        join c in db.Classes on st.Classe_Code equals c.Code
                        join ass in db.Ass_Prof_Classe on c.Code equals ass.ClasseCode
                        join tch in db.Teachers on ass.Prof_Id equals tch.Id
                        where tch.User_Id == identifiant
                        select new { c, StudentFullName = st.FullName }).ToList();

            t.ClassesAndStudents = new List<StudentClasseModel>();
            foreach (var foo in suat)
            {
                StudentClasseModel hr = new StudentClasseModel();
                hr.Classe = foo.c;
                hr.StudentFullName = foo.StudentFullName;
                t.ClassesAndStudents.Add(hr);
            }
            return t;
        }

        public bool DeleteTeacherFromDB(int id)
        {
            bool result1 = false;
            var teacher = db.Teachers
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            if (teacher != null)
            {

                db.Entry(teacher).State = System.Data.Entity.EntityState.Deleted;
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

        public void removeTeacherAssClassesFromDB(int id)
        {
            if(id != null) { 
                db.Ass_Prof_Classe.RemoveRange(db.Ass_Prof_Classe.Where(s => s.Prof_Id == id));
                db.SaveChanges();
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public bool CreateTeacherIntoDB(Teachers teach)
        {
            bool rep = false;
            var teachers = db.Set<Teachers>();
            teachers.Add(teach);
            try
            {
                db.SaveChanges();
                rep = true;
            }
            catch
            {
                rep = false;
            }
            return rep;
        }
        public bool UpdateTeacherIntoDB(Teachers teach)
        {
            bool rep = false;
            var result = db.Teachers.SingleOrDefault(b => b.Id == teach.Id);
            if (result != null)
            {
                db.Teachers.AddOrUpdate(teach);
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

        public bool CreateTeacherClasseIntoDB(int id, string classe)
        {
            bool rep = false;
            Ass_Prof_Classe profclasse = new Ass_Prof_Classe();
            profclasse.Prof_Id = id;
            profclasse.ClasseCode = classe;
            var clas = db.Set<Ass_Prof_Classe>();
            clas.Add(profclasse);
            try
            {
                db.SaveChanges();
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
