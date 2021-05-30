using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    public interface IUserRatingLogic
    {
        public bool addUserRating(string username, int movieId, int ratingGiven);

        public int getUserRating(string username, int movieId);
    }
}
