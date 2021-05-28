
using SEP6_TEST.DbAccess;
using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    public class MovieLogic : IMovieLogic
    {
        private MovieInfoDb movieInfoDb = new MovieInfoDb();
        MovieDTO movie = new MovieDTO();
        public async Task<MovieDTO> getMovieByID(int movieId)
        {
           
            try
            {
                movie = await movieInfoDb.getMovieByID(movieId);
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
            
            try
            {
                movie =await movieInfoDb.getMovieByID(movieDTO.Movie.Id);
                movie.Rating.Votes += 1;
                movie.Rating.Rating1 = (movie.Rating.Rating1 + rating) / 2;
                movie = await movieInfoDb.updateVotesAndRating(movie);

                return movie;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return movie;
            }
        }
    }
}
