using SchoolAppToday;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Manager
{
    public class UserManager
    {
        SchoolAppTodayEntities db = new SchoolAppTodayEntities();

        public UserManager()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<Users> GetUsersFromDB()
        {
            return db.Users.ToList();
        }
        public Users GetUserFromDB(int id)
        {
            return db.Users.Where(s => s.Id == id).FirstOrDefault();
        }

        public bool DeleteUserFromDB(int id)
        {
            bool result = false;
            var user = db.Users
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            if (user != null)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
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

        public bool CreateUserIntoDB(Users user)
        {
            bool rep = false;
            var users = db.Set<Users>();
            users.Add(user);
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

        public bool CheckUserExistence(Users user)
        {
            var us = db.Users.Where(s => s.Login == user.Login).FirstOrDefault();
            if (us != null)
                return true;
            else return false;
        }
        public bool UpdateUserIntoDB(Users user)
        {
            bool rep = false;
            var result = db.Users.SingleOrDefault(b => b.Id == user.Id);
            if (result != null)
            {
                db.Users.AddOrUpdate(user);
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