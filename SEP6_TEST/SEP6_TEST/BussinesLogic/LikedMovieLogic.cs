using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DbAccess;

namespace SEP6_TEST.BussinesLogic
{
    public class LikedMovieLogic : ILikedMoviesLogic
    {

        private ILikedMoviesDb LikedMoviesDb;

        public LikedMovieLogic(ILikedMoviesDb likedMoviesDb)
        {
            LikedMoviesDb = likedMoviesDb;
        }

        public bool addMoviesToLiked(string username, int movieId)
        {
            LikedMoviesDb.addMovieToLiked(username, movieId);
            var exists = LikedMoviesDb.islikedMovieInLikedDB(movieId);

            if (exists)
            {
                LikedMoviesDb.addLikedMovieToList(movieId);
                return exists;
            }
            else
            {
                return exists;
            }
        }
    }
}
