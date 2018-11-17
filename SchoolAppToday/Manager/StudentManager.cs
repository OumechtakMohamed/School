using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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

        public Students GetStudentFromDB(int id)
        {
                return db.Students.Where(s => s.Id == id).FirstOrDefault();
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