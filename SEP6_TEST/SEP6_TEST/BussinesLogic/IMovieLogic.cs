using SEP6_TEST.DTO;
using SEP6_TEST.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    public interface IMovieLogic
    {
        public Task<MovieDTO> updateVotesAndRating(MovieDTO movieDTO,int rating);

        public Task<MovieDTO> getMovieByID(int movieId);

        public Task<List<MovieDTO>> ReorderMoviesByRating(OrderMovies orderMovies, List<MovieDTO> movieDTOs);
    }
}
