using SEP6_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DbAccess;
namespace SEP6_TEST.BussinesLogic
{
    public class MovieReviewLogic : IMovieReviewLogic
    {

        private IMovieReviewDb MovieReviewDb;

        public MovieReviewLogic(IMovieReviewDb movieReviewDb)
        {
            MovieReviewDb = movieReviewDb;
        }
        public bool addNewReview(string username, int movieId, string text)
        {
            MovieReviewDb.addReview(username, movieId, text);
            return true;
            
        }

        public async Task<List<MovieReview>> getAllMovieReviews(int movieId)
        {
            return await MovieReviewDb.getAllReviewsForMovie(movieId);
        }
    }
}
