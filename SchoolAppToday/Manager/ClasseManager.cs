using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Manager
{
    public class ClasseManager
    {
        SchoolAppEntities db = new SchoolAppEntities();
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

        public List<Teachers> GetClasseTeachersFromDB(string code)
        {
            var teachers = (from a in db.Ass_Prof_Classe
                           join c in db.Teachers on a.Prof_Id equals c.Id
                           where a.ClasseCode == code
                           select c);
            return teachers.ToList();
        }

        public List<Subjects> GetClasseSubjectsFromDB(string code)
        {
            var subjects = (from a in db.Ass_Classe_Subject
                            join c in db.Subjects on a.SubjectCode equals c.Code
                            where a.ClasseCode == code
                            select c);
            return subjects.ToList();
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

        public bool CreateClasseSubjectIntoDB(string ClasseCode, string subject)
        {
            bool rep = false;
            Ass_Classe_Subject classe = new Ass_Classe_Subject();
            classe.SubjectCode = subject;
            classe.ClasseCode = ClasseCode;
            var clas = db.Set<Ass_Classe_Subject>();
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

        public void removeClasseAssSubjectsFromDB(string code)
        {
            if (code != null)
            {
                db.Ass_Classe_Subject.RemoveRange(db.Ass_Classe_Subject.Where(s => s.ClasseCode == code));
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