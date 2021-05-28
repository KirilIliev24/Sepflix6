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
        public List<MovieDTO> LinkedMovieDTOs = new List<MovieDTO>();

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

        public bool islikedMovieInLikedDB(int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                var exists = context.LikedMovies.Any(i => i.Movie.Id == movieId);

                return exists;
            }
        }

        public async void addLikedMovieToList(int movieId)
        {
            try
            {
                LinkedMovieDTOs.Add(await MovieInfoDb.getMovieByID(movieId));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        //maybe return a bool if everything went well
        public void deleteALikedMovie(string username, int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    bool exists = context.LikedMovies.Any(u => u.MovieId == movieId && u.Username.Equals(username));
                    if(exists == true)
                    {
                        var likedMovie = context.LikedMovies.FirstOrDefault(u => u.MovieId == movieId && u.Username.Equals(username));
                        context.LikedMovies.Remove(likedMovie);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public async void deleteLikedMovieFromList(int movieId)
        {
            var movieDTO = await MovieInfoDb.getMovieByID(movieId);
            LinkedMovieDTOs.Remove(movieDTO);
        }

        public async Task<List<MovieDTO>> getAllLikedMovies(string username)
        {

            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    if (LinkedMovieDTOs.Count==0)
                    {
                        movieId = await Task.Run(() => context.LikedMovies.Where(u => u.Username.Equals(username)).Select(m => m.MovieId).ToList());

                        foreach (var id in movieId)
                        {
                            LinkedMovieDTOs.Add(await MovieInfoDb.getMovieByID(id));
                        }
                        return LinkedMovieDTOs;
                    }
                    else
                    {
                        return LinkedMovieDTOs;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return LinkedMovieDTOs;
                }
            }
        }

        public bool IsMovieInLikedlist(int id)
        {
            var exists = LinkedMovieDTOs.Any(i => i.Movie.Id == id);
            return exists;
        }

        
    }
}
