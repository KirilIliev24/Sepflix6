using SEP6_TEST.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP6_TEST.DTO;

namespace SEP6_TEST.DbAccess
{
    public interface IMovieInfoDb
    {
        public List<MovieDTO> MovieDTOs { get; }
        public Task GetAllMovies();

        public Task<MovieDTO> getMovieByID(int id);

        public Task<MovieDTO> updateVotesAndRating(MovieDTO movieDTO);

    }
}