using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DbAccess;
namespace SEP6_TEST.BussinesLogic
{
    public class UserRatingLogic : IUserRatingLogic
    {
        private IUserRatingDb UserRatingDb;

        public UserRatingLogic(IUserRatingDb userRatingDb)
        {
            UserRatingDb = userRatingDb;
        }

        public bool addUserRating(string username, int movieId, int ratingGiven)
        {
            var exists = UserRatingDb.hasUserVoted(username, movieId);

            if (!exists)
            {
                UserRatingDb.saveUserRating(username, movieId, ratingGiven);
                return exists;
            }
            else
            {
                return exists;
            }
        }

        public int getUserRating(string username, int movieId)
        {
            var exists = UserRatingDb.hasUserVoted(username, movieId);
            if (exists)
            {
                var rating = UserRatingDb.returnUserRating(username, movieId);

                return rating;
            }
            else
            {
                return 0;
            }
        }
    }
}
