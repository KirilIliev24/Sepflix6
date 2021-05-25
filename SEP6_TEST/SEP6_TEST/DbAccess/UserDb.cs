using SEP6_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.DbAccess
{
    public class UserDb : IUserDb
    {
        public void createUser(User user)
        {
            using (var context = new SqlServerSep6Context())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User getUserByName(string username)
        {
            using (var context = new SqlServerSep6Context())
            {
                var user = context.Users.Find(username);
                return user;
            }
        }
    }
}
