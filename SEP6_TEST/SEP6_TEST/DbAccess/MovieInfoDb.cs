using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DTO;
using SEP6_TEST.Models;

namespace SEP6_TEST.DbAccess
{
    public class MovieInfoDb : IMovieInfoDb
    {
        public List<MovieDTO> MovieDTOs { get; private set; } = new List<MovieDTO>();

        public async Task GetAllMovies()
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    List<Movie> Movies = await Task.Run(() => context.Movies.Select(p => p).ToList());
                   
                    foreach (var movie in Movies)
                    {
                        MovieDTO movieDTO = new MovieDTO()
                        {
                            Movie = movie
                        };
                        MovieDTOs.Add(movieDTO);
                    }
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
                    foreach(var movieDTO in MovieDTOs)
                    {
                        double rating = await Task.Run(() => context.Ratings.Where(p => p.MovieId == movieDTO.Movie.Id).Select(p => p.Rating1).FirstOrDefault());
                        int noOfVotes = await Task.Run(() => context.Ratings.Where(p => p.MovieId == movieDTO.Movie.Id).Select(p => p.Votes).FirstOrDefault());

                        movieDTO.Rating = new Rating()
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
