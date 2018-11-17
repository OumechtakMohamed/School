using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Manager
{
    public class SubjectManager
    {
        SchoolAppEntities db = new SchoolAppEntities();
        public SubjectManager()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Subjects> GetSubjectsFromDB()
        {
                return db.Subjects;
        }

        public List<Classes> GetSubjectClassesFromDB(string code)
        {
            var classes = (from a in db.Ass_Classe_Subject
                           join c in db.Classes on a.ClasseCode equals c.Code
                           where a.SubjectCode == code
                           select c);
            return classes.ToList();
        }

        public Subjects GetSubjectFromDB(string code)
        {
            return db.Subjects.Where(s => s.Code == code).FirstOrDefault();
        }

        public bool DeleteSubjectFromDB(string code)
        {
            bool result = false;
            var subject = db.Subjects
                    .Where(s => s.Code == code)
                    .FirstOrDefault();
            if (subject != null)
            {
                db.Entry(subject).State = System.Data.Entity.EntityState.Deleted;
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

        public bool CreateSubjectIntoDB(Subjects subj)
        {
            bool rep = false;
            var subject = db.Set<Subjects>();
            subject.Add(subj);
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

        public bool UpdateSubjectIntoDB(Subjects subj)
        {
            bool rep = false;
            var result = db.Subjects.SingleOrDefault(b => b.Code == subj.Code);
            if (result != null)
            {
                db.Subjects.AddOrUpdate(subj);
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
