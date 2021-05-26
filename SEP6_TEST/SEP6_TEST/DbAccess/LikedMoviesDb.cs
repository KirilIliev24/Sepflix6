using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;

namespace SEP6_TEST.DbAccess
{
    public class LikedMoviesDb : ILikedMoviesDb
    {
        private MovieInfoDb MovieInfoDb = new MovieInfoDb();
        public List<MovieDTO> movieDTOs = new List<MovieDTO>();

        private List<int> movieId = new List<int>();
        public void addMovieToLiked(string username, int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                var likedMovie = new LikedMovie();
                likedMovie.Username = username;
                likedMovie.MovieId = movieId;
                context.LikedMovies.Add(likedMovie);
                context.SaveChanges();
            }
        }

        public void deleteALikedMovie(string username, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieDTO>> getAllLikedMovies(string username)
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    movieId = await Task.Run(() => context.LikedMovies.Where(u => u.Username.Equals(username)).Select(m => m.MovieId).ToList());

                    foreach (var id in movieId)
                    {
                        movieDTOs.Add(await MovieInfoDb.getMovieByID(id));
                    }
                    return movieDTOs;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return movieDTOs;
                }
            }
        }
    }
}
