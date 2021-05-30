using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DTO;
using SEP6_TEST.Models;
using Microsoft.EntityFrameworkCore;

namespace SEP6_TEST.DbAccess
{
    public class MovieInfoDb : IMovieInfoDb
    {
        public List<MovieDTO> MovieDTOs { get; private set; } = new List<MovieDTO>();

        public async Task<List<MovieDTO>> GetAllMovies()
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    if(MovieDTOs.Count == 0)
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
                        
                        return MovieDTOs;
                    }
                    else
                    {
                        return MovieDTOs;
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return MovieDTOs;
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
                    var exists = MovieDTOs.Any(i => i.Movie.Id == id);
                    if(exists == true)
                    {
                        var movieInCache = MovieDTOs.FirstOrDefault(i => i.Movie.Id == id);
                        return movieInCache;
                    }
                   
                    movieDTO.Movie = context.Movies.Find(id);
                    movieDTO.Rating = await getRating(id);
                    //movieDTO.Poster = await getMoviePoster(id);
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

                    var rating = context.Ratings.FirstOrDefault(i => i.MovieId == movieDTO.Movie.Id);
                    if(rating != null)
                    {
                        rating.Rating1 = movieDTO.Rating.Rating1;
                        rating.Votes = movieDTO.Rating.Votes;
                        context.Entry(rating).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    //movie.Rating.Rating1 = movieDTO.Rating.Rating1;
                    //movie.Rating.Votes = movieDTO.Rating.Votes;
                    //context.Ratings.Update();
                    //context.SaveChanges();

                    return movie;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return movie;
                }
            }
        }

        public async Task<List<MovieDTO>> GetSearchResults(string searchPhrase, List<MovieDTO> movies)
        {
            List<MovieDTO> result = new List<MovieDTO>();
            if(!string.IsNullOrWhiteSpace(searchPhrase))
            {
                await Task.Run(() =>
                {
                    foreach (var m in movies)
                    {
                        string movieTitle = m.Movie.Title.ToLowerInvariant();
                        string phrase = searchPhrase.ToLowerInvariant();
                        if (movieTitle.Contains(phrase))
                        {
                            result.Add(m);
                        }
                    }
                });
                return result;
            }
            return result;
        }

        //public async Task<string> getMoviePoster(int movieId)
        //{
        //    using (var context = new SqlServerSep6Context())
        //    {
        //        try
        //        {
        //            string poster = await Task.Run(() => context.Movies.Where(m => m.Id.Equals(movieId)).Select(p => p.Poster).ToString());
        //            return poster;
        //        }
        //        catch (Exception e)
        //        {

        //            Console.WriteLine(e.Message);
        //            return "Poster unavailable";
        //        }
        //    }
        //}

        private async Task GetAllMoviePosters()
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    foreach (var movie in MovieDTOs)
                    {
                        string poster = await Task.Run(()=> context.Movies.Where(m => m.Id.Equals(movie.Movie.Id)).Select(p => p.Poster).FirstOrDefault());
                        //movie.Poster = poster;
                    }
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
