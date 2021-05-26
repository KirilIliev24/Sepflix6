using SEP6_TEST.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.ApiAccess
{
    interface IMovieAccessInfoApi
    {
        public MovieBaseInfo movieBaseInfo { get; }
        public PersonsBiography bio { get; }
        //public Poster posterLink { get; }
        public Task GetMoviePlotAsync(int movieId);
        public Task GetMoviePosterAsync(int movieId);
        public Task GetMovieCreditsAsync(int movieId);
        public Task GetMovieReviewsAsync(int movieId);
        public Task GetPersonsBioAsync(int personId);
       // public Task GetMovieGenresAsync(int movieId);
    }
}
