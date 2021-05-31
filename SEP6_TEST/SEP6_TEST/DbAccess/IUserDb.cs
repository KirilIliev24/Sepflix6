using SEP6_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.DbAccess
{
    interface IUserDb
    {
        public User user { get; }
        public bool createUser(User user);
        public bool getUserByName(string username, string password);
        public void logoutUser();
    }
}
