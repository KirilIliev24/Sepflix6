using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DbAccess;
namespace SEP6_TEST.BussinesLogic
{
    public class WatchlistLogic : IWacthlistLogic
    {

        private IWatchListDb WatchListDb;

        public WatchlistLogic(IWatchListDb watchListDb)
        {
            WatchListDb = watchListDb;
        }

        public bool addMovieToWatchlist(string username, int movieId)
        {
            WatchListDb.addMovieToWatchlist(username, movieId);
            var exists = WatchListDb.islikedMovieInWatchlistDB(movieId);

            if (exists)
            {
                WatchListDb.addWatchlistMovieToList(movieId);
                return exists;
            }

            else
            {
                return exists;
            }
        }

        public async Task<List<MovieDTO>> getAllMoviesInWatchlist(string username)
        {
            return await WatchListDb.GetAllMoviesInWatchList(username);
        }

        public bool removeMovieFromWatchlist(string username, int movieId)
        {
            WatchListDb.removeMovieFromWatchList(username, movieId);

            var exists = WatchListDb.islikedMovieInWatchlistDB(movieId);

            if (!exists)
            {
                WatchListDb.deleteWatchlistMovieFromList(movieId);
                return exists;
            }
            else
            {
                return exists;
            }
        }
    }
}
