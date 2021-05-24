using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;

namespace SEP6_TEST.DbAccess
{
    public class MovieInfoDb : IMovieInfoDb
    {
        public List<Movie> Movies { get; private set; } = new List<Movie>();

        public async Task GetAllMovies()
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    Movies = await Task.Run(() => context.Movies.Select(p => p).ToList());
                    await GetMovieRating();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private async Task GetMovieRating()
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    foreach(var movie in Movies)
                    {
                        double rating = await Task.Run(() => context.Ratings.Where(p => p.MovieId == movie.Id).Select(p => p.Rating1).FirstOrDefault());
                        int noOfVotes = await Task.Run(() => context.Ratings.Where(p => p.MovieId == movie.Id).Select(p => p.Votes).FirstOrDefault());

                        movie.rating = new Rating()
                        {
                            Rating1 = rating,
                            Votes = noOfVotes
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
