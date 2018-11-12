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
        SchoolAppTodayEntities db = new SchoolAppTodayEntities();
        GeneralManager general = new GeneralManager();

        UserManager userManager = new UserManager();

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
            bool result2 = false;
            var student = db.Students
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            var user = db.Users
                .Where(s => s.Id == student.User_Id)
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
            if(user != null) { 
                db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                    result2 = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    result2 = false;
                }
            }
            return result1 || result2;
        }

        public bool CreateStudentIntoDB(Students stud)
        {
            bool rep = false;
            var students = db.Set<Students>();
            students.Add(stud);
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


        public int CreateStudentIntoUserDB(Students stud)
        {
            int rep = -1;
            var users = db.Set<Users>();
            Users user = new Users();
            user.Login = stud.FirstName[0] + stud.LastName;
            user.Password = general.RandomString(10);
            if(!userManager.CheckUserExistence(user))
            {
                users.Add(user);
                try
                {
                    db.SaveChanges();
                    rep = user.Id;
                }
                catch
                {
                    rep = -1;
                }
                return rep;
            }
            else return -1;
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