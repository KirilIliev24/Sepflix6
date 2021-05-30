using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.DbAccess
{
    public interface IUserRatingDb
    {

        public void saveUserRating(string username, int movieId,int ratingGiven);

        public bool hasUserVoted(string username, int movieId);

        public int returnUserRating(string username, int movieId);

        
    }
}
