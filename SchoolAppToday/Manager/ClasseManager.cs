using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Manager
{
    public class ClasseManager
    {
        SchoolAppTEntities db = new SchoolAppTEntities();
        public ClasseManager()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Classes> GetClassesFromDB()
        {
            return db.Classes;
        }

        public Classes GetClasseFromDB(string code)
        {
            return db.Classes.Where(s => s.Code == code).FirstOrDefault();
        }

        public bool DeleteClasseFromDB(string code)
        {
            bool result = false;
            var classe = db.Classes
                    .Where(s => s.Code == code)
                    .FirstOrDefault();
            if (classe != null)
            {
                db.Entry(classe).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
        public Boolean AddTeacherToClasseIntoDB(string code, int id)
        {
            bool rep = false;
            try
            {
                rep = true;
                db.Database.ExecuteSqlCommand("ADD_TEACHER_TO_CLASSE_PS @TeacherID,@Code",
            new SqlParameter("TeacherID", id), new SqlParameter("Code", code));
            }
            catch (Exception ex)
            {
                rep = false;
                Console.WriteLine(ex);
                throw;
            }
            return rep;
        }

        public Boolean removeTeacherAssClassesFromDB(string code, int id)
        {
            bool rep = false;
            try
            {
                rep = true;
                db.Database.ExecuteSqlCommand("DELETE_TEACHER_FROM_CLASSE_PS @TeacherID,@Code",
            new SqlParameter("TeacherID", id), new SqlParameter("Code", code));
            }
            catch (Exception ex)
            {
                rep = false;
                Console.WriteLine(ex);
                throw;
            }
            return rep;
        }

        public List<Teachers> GetClasseTeachersFromDB(string code)
        {
            var teachers = (from a in db.Ass_Prof_Classe
                           join c in db.Teachers on a.Prof_Id equals c.Id
                           where a.ClasseCode == code
                           select c);
            return teachers.ToList();
        }

        public bool CreateClasseIntoDB(Classes classe)
        {
            bool rep = false;
            var clas = db.Set<Classes>();
            clas.Add(classe);
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

      

      


        public bool UpdateClasseIntoDB(Classes classe)
        {
            bool rep = false;
            var result = db.Classes.SingleOrDefault(b => b.Code == classe.Code);
            if (result != null)
            {
                db.Classes.AddOrUpdate(classe);
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