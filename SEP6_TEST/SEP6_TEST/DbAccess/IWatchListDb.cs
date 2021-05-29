using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;
using SEP6_TEST.DTO;

namespace SEP6_TEST.DbAccess
{
    public interface IWatchListDb
    {
        public void addMovieToWatchlist(string username, int movieId);
        public void removeMovieFromWatchList(string username, int movieId);
        public Task<List<MovieDTO>> GetAllMoviesInWatchList(string username);
        public bool IsMovieInWatchlist(int id);
        public bool islikedMovieInWatchlistDB(int movieId);

        public void addWatchlistMovieToList(int movieId);

        public void deleteWatchlistMovieFromList(int movieId);
    }
}
