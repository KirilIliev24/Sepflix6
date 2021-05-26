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

        public async Task<MovieDTO> getMovieByID(int id)
        {
            var movieDTO = new MovieDTO();
            using (var context = new SqlServerSep6Context())
            {

                try
                {
                    movieDTO.Movie = context.Movies.Find(id);
                    movieDTO.Rating =await getRating(id);
                    return movieDTO;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return movieDTO;
                }
            }
        }

        public async Task<Rating> getRating(int movieId)
        {
            var r = new Rating();
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    double rating = await Task.Run(() => context.Ratings.Where(p => p.MovieId == movieId).Select(p => p.Rating1).FirstOrDefault());
                    int noOfVotes = await Task.Run(() => context.Ratings.Where(p => p.MovieId == movieId).Select(p => p.Votes).FirstOrDefault());
                    r.Rating1 = rating;
                    r.Votes = noOfVotes;
                    return r;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return r;
                }
            }
        }

        public async Task<MovieDTO> updateVotesAndRating(MovieDTO movieDTO)
        {
            MovieDTO movie=new MovieDTO();
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    movie = await getMovieByID(movieDTO.Movie.Id);
                    movie.Rating.Rating1 = movieDTO.Rating.Rating1;
                    movie.Rating.Votes = movieDTO.Rating.Votes;
                    context.SaveChanges();

                    return movie;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return movie;
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
