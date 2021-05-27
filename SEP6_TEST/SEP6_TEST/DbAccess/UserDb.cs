using SEP6_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.DbAccess
{
    public class UserDb : IUserDb
    {
        public User user { get; private set; } = new User();
        public void createUser(User user)
        {
            using (var context = new SqlServerSep6Context())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        //maybe this should return bool
        //true if there is such user, false if there is not
        public User getUserByName(string username)
        {
            using (var context = new SqlServerSep6Context())
            {
                var user = context.Users.Find(username);
                if(user != null)
                {
                    this.user = user;
                    return user;
                }
                else
                {
                    return new User();
                }
            }
        }

        //add a logout user
        //clean all data
    }
}
