
using SEP6_TEST.DbAccess;
using SEP6_TEST.DTO;
using SEP6_TEST.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    public class MovieLogic : IMovieLogic
    {
        private IMovieInfoDb MovieInfoDb;

        public MovieLogic(IMovieInfoDb movieInfoDb)
        {
            MovieInfoDb = movieInfoDb;
        }
        public async Task<MovieDTO> getMovieByID(int movieId)
        {
            MovieDTO movie = new MovieDTO();
            try
            {
                movie = await MovieInfoDb.getMovieByID(movieId);
                return movie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return movie;
                
            }
        }

        public async Task<MovieDTO> updateVotesAndRating(MovieDTO movieDTO, int rating)
        {

            MovieDTO movie = new MovieDTO();
            try
            {
                movie =await MovieInfoDb.getMovieByID(movieDTO.Movie.Id);
                movie.Rating.Votes += 1;
                movie.Rating.Rating1 = (movie.Rating.Rating1 + rating) / 2;
                movie = await MovieInfoDb.updateVotesAndRating(movie);

                return movie;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return movie;
            }
        }

        public async Task<List<MovieDTO>> ReorderMoviesByRating(OrderMovies orderMovies, List<MovieDTO> movieDTOs)
        {
            if (orderMovies == OrderMovies.HighToLow)
            {
                var orderedMovies = await Task.Run(() => movieDTOs.OrderBy(m => m.Rating.Rating1).ToList());
                return orderedMovies;
            }
            else if (orderMovies == OrderMovies.LowToHigh)
            {
                var orderedMovies = await Task.Run(() => movieDTOs.OrderByDescending(m => m.Rating.Rating1).ToList());
                return orderedMovies;
            }
            else
            {
                return movieDTOs;
            }
        }
    }
}
