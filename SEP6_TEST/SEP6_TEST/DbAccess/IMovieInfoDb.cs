using SEP6_TEST.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEP6_TEST.DbAccess
{
    public interface IMovieInfoDb
    {
        public List<Movie> Movies { get; }
        public Task GetAllMovies();
    }
}