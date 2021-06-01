using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    public interface IWacthlistLogic
    {
        public bool addMovieToWatchlist(string username, int movieId);
        public bool removeMovieFromWatchlist(string username, int movieId);

        public Task<List<MovieDTO>> getAllMoviesInWatchlist(string username);

        public bool isMovieWatchlistInDB(int movieId, string username);
    }
}
