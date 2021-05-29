using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;
namespace SEP6_TEST.BussinesLogic
{
    public interface IMovieReviewLogic
    {
        public bool addNewReview(string username, int movieId, string text);

        public Task<List<MovieReview>> getAllMovieReviews(int movieId);
    }
}
