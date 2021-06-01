using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    public interface ILikedMoviesLogic
    {
        public bool addMoviesToLiked(string username, int movieId);

        public bool deleteMoviesFromLiked(string username, int movieId);

        public Task<List<MovieDTO>> getAllLikedMovies(string username);

        public bool isMovieInLikedDB(int movieId, string username);
    }
}
