using StreamSafari.Model;
using System;
using System.Collections.Generic;
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
    }
}
