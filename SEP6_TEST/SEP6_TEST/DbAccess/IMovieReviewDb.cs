using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;
using SEP6_TEST.DTO;

namespace SEP6_TEST.DbAccess
{
    interface IMovieReviewDb
    {
        public void addReview(string username, int movieId, string reviewText);
        public Task<List<MovieReview>> getAllReviewsForMovie(int movieId);
       
    }
}
