using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Manager
{
    public class TeacherManager
    {
        SchoolAppTodayEntities db = new SchoolAppTodayEntities();
        GeneralManager general = new GeneralManager();
        UserManager userManager = new UserManager();
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
        public Teachers GetTeacherFromDB(int id)
        {
            return db.Teachers.Where(s => s.Id == id).FirstOrDefault();
        }

        public bool DeleteTeacherFromDB(int id)
        {
            bool result1 = false;
            bool result2 = false;
            var teacher = db.Teachers
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            var user = db.Users
                .Where(s => s.Id == teacher.User_Id)
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
                if (user != null)
                {
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

        public int CreateTeacherIntoUserDB(Teachers teacher)
        {
            int rep = -1;
            var users = db.Set<Users>();
            Users user = new Users();
            user.Login = teacher.FirstName[0] + teacher.LastName;
            user.Password = general.RandomString(10);
            if (!userManager.CheckUserExistence(user))
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
