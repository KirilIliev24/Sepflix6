using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;
using SEP6_TEST.DTO;

namespace SEP6_TEST.DbAccess
{
    interface IWatchListDb
    {
        public void addMovieToWatchlist(string username, int movieId);
        public void removeMovieFromWatchList(string username, int movieId);
        public Task<List<MovieDTO>> GetAllMoviesInWatchList(string username);
    }
}
