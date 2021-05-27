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
        public void createUser(User user);
        public User getUserByName(string username);
    }
}
