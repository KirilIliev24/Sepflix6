using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.BussinesLogic
{
    interface IMovieLogic
    {
        public Task<MovieDTO> updateVotesAndRating(MovieDTO movieDTO,int rating);
    }
}
