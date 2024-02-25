using StreamSafari.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.Repository
{
    public class UserRepository
    {
        StreamSafariEntities db = new StreamSafariEntities();

        public User CreateUser(User p_User)
        {
            User user = db.Users.Add(p_User);
            db.SaveChanges();
            return user;
        }

        public User GetUser (User p_User)
        {
            User user = db.Users.Where(u => u.UserName == p_User.UserName).FirstOrDefault();
            return user;
        }

      
        public User EditUser(User p_User)
        {
         
                db.Entry(p_User).State = EntityState.Modified;
                db.SaveChanges();
                return p_User;
      
             
        }

        public User FindUser(int? p_User)
        {
            User user = db.Users.Find(p_User);
            return user;
        }

        public List<User> ListUsers()
        {
            List<User> users = db.Users.OrderByDescending(u => u.UserId).ToList();
            return users;
        }

        public User DeleteUser(User p_User)
        {
         
            db.Users.Remove(p_User);
            db.SaveChanges();
            return p_User;
        }

      
    }
}
