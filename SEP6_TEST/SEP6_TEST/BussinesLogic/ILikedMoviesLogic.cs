using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    interface ILikedMoviesLogic
    {
        public bool addMoviesToLiked(string username, int movieId);
    }
}
