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
        public Task GetMovieBaseInfoAsync(string movieId);
    }
}
