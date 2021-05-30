using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DbAccess;
using SEP6_TEST.Models;
namespace SEP6_TEST.DbAccess
{
    public class UserRatingDb : IUserRatingDb
    {
        public int rating;
        public void saveUserRating(string username, int movieId, int ratingGiven)
        {
            try
            {
                using (var context = new SqlServerSep6Context())
                {
                    
                        var userRating = new UserRating();
                        userRating.Username = username;
                        userRating.MovieId = movieId;
                        userRating.RatingGiven = ratingGiven;
                        context.Add(userRating);
                        context.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
            }
        }
        public bool hasUserVoted(string username, int movieId)
        {
            bool exists;
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    exists = context.UserRatings.Where(u=>u.Username.Equals(username)).Any(i => i.Movie.Id == movieId);
                    if (!exists)
                    {
                        return exists;
                    }
                    else
                    {
                        return exists;
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                    return true;
                }
                
            }
        }

        public int returnUserRating(string username, int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                try
                {
                    rating = context.UserRatings.Where(u => u.Username.Equals(username)).Where(i => i.MovieId == movieId).Select(r => r.RatingGiven).FirstOrDefault();

                    return rating;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                    return rating;
                }
            }
        }
    }
}
