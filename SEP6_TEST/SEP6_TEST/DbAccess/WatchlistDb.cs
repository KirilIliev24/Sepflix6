using SEP6_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DTO;
namespace SEP6_TEST.DbAccess
{
    public class WatchlistDb : IWatchListDb
    {
        MovieInfoDb MovieInfoDb = new MovieInfoDb();
        
        public List<int> movieId { get; private set; } = new List<int>();
        private List<MovieDTO> WatchlistDTOs { get; set; } = new List<MovieDTO>();

        public void addMovieToWatchlist(string username, int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                var watchlist = new Watchlist();
                watchlist.Username = username;
                watchlist.MovieId = movieId;
                context.Watchlists.Add(watchlist);
                context.SaveChanges();
            }
        }

        public bool islikedMovieInWatchlistDB(int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                var exists = context.Watchlists.Any(i => i.Movie.Id == movieId);

                return exists;
            }
        }

        public async Task addWatchlistMovieToList(int movieId)
        {
            try
            {
                WatchlistDTOs.Add(await MovieInfoDb.getMovieByID(movieId));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        //maybe return boolean and update the frontend accordingly
        public void removeMovieFromWatchList(string username, int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    bool exists = context.Watchlists.Any(u => u.MovieId == movieId && u.Username.Equals(username));
                    if (exists == true)
                    {
                        var likedMovie = context.Watchlists.FirstOrDefault(u => u.MovieId == movieId && u.Username.Equals(username));
                        context.Watchlists.Remove(likedMovie);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public async Task<List<MovieDTO>> GetAllMoviesInWatchList(string username)
        {
            using (var context = new SqlServerSep6Context())
            {

                try
                {
                    if (WatchlistDTOs.Count==0)
                    {
                        movieId = await Task.Run(() => context.Watchlists.Where(n => n.Username.Equals(username)).Select(w => w.MovieId).ToList());

                        foreach (var movie in movieId)
                        {
                            WatchlistDTOs.Add(await MovieInfoDb.getMovieByID(movie));


                        }
                        return WatchlistDTOs;
                    }
                    else
                    {
                        return WatchlistDTOs;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return WatchlistDTOs;
                }

            }
        }

        public bool IsMovieInWatchlist(int id)
        {
            var exists = WatchlistDTOs.Any(i => i.Movie.Id == id);
            return exists;
        }

        public async void deleteWatchlistMovieFromList(int movieId)
        {
            var movieDTO = await MovieInfoDb.getMovieByID(movieId);
            WatchlistDTOs.Remove(movieDTO);
        }
    }
}
