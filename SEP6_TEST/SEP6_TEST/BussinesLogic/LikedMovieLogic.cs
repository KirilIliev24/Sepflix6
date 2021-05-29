using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DbAccess;
using SEP6_TEST.DTO;

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
            
            var exists = LikedMoviesDb.islikedMovieInLikedDB(movieId);

            if (!exists)
            {
                LikedMoviesDb.addMovieToLiked(username, movieId);
                LikedMoviesDb.addLikedMovieToList(movieId);
                return exists;
            }
            else
            {
                return exists;
            }
        }

        public bool deleteMoviesFromLiked(string username, int movieId)
        {
            LikedMoviesDb.deleteALikedMovie(username,movieId);
            var exists = LikedMoviesDb.islikedMovieInLikedDB(movieId);

            if (!exists)
            {
                var isInList = LikedMoviesDb.IsMovieInLikedlist(movieId);

                if (isInList)
                {
                    LikedMoviesDb.deleteLikedMovieFromList(movieId);
                    return exists;
                }
                else
                {
                    return exists;
                }
                
            }
            else
            {
                return exists;
            }
            
        }
        public async Task<List<MovieDTO>> getAllLikedMovies(string username)
        {
            return await LikedMoviesDb.getAllLikedMovies(username);
        }

        public bool isMovieInLikedDB(int movieId)
        {
            var isInDb = LikedMoviesDb.islikedMovieInLikedDB(movieId);
            return isInDb;
        }
    }
}
