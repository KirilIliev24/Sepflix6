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
        public bool createUser(User user)
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    bool exists = context.Users.Any(u => u.Username == user.Username);
                    if (exists == false)
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //maybe this should return bool
        //true if there is such user, false if there is not
        public bool getUserByName(string username)
        {
            //add a password check
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    var user = context.Users.Find(username);
                    if (user != null)
                    {
                        this.user = user;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void logoutUser()
        {
            user = new User();
        }

    }
}
