using SEP6_TEST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.Models;

namespace SEP6_TEST.DbAccess
{
    public class MovieReviewDb : IMovieReviewDb
    {
        public List<MovieReview> reviews = new List<MovieReview>();
        
        private List<int> reviewIDs = new List<int>();
        public void addReview(string username, int movieId, string reviewText)
        {
            using (var context = new SqlServerSep6Context())
            {
                var movieReview = new MovieReview();
                movieReview.Username = username;
                movieReview.MovieId = movieId;
                movieReview.ReviewText = reviewText;
                context.MovieReviews.Add(movieReview);
                context.SaveChanges();
            }
        }

        public async Task<List<MovieReview>> getAllReviewsForMovie(int movieId)
        {
            
            using (var context = new SqlServerSep6Context())
            {
                List<MovieReview> localReviews = new List<MovieReview>();
                try
                {
                    //could have gotten full objects of review, not just ids
                    reviewIDs = await Task.Run(() => context.MovieReviews.Where(i=>i.MovieId.Equals(movieId)).Select(r=>r.ReviewId).ToList());

                    foreach (var id in reviewIDs)
                    {
                        localReviews.Add(getReviewByID(id));
                    }
                    reviews = localReviews;
                    return reviews;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return reviews;
                }
            }
        }
        public MovieReview getReviewByID(int reviewId)
        {
            var review = new MovieReview();
            using (var context = new SqlServerSep6Context())
            {
                review = context.MovieReviews.Find(reviewId);
                return review;
            }
        }
    }
}
