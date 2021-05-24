using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SEP6_TEST.ApiModels;

namespace SEP6_TEST.ApiAccess
{
    public class MovieInfoApi : IMovieAccessInfoApi
    {
        private HttpClient client;
        public MovieBaseInfo movieBaseInfo { get; private set; } = new MovieBaseInfo();

        public MovieInfoApi(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient();
        }


        public async Task GetMovieBaseInfoAsync(string movieId)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                //maybe move these keys to the app settings
                client.DefaultRequestHeaders.Add("x-rapidapi-key", "9e321c6e5cmshef2596f3bb0409dp1fa84djsn66631090335e");
                client.DefaultRequestHeaders.Add("x-rapidapi-host", "imdb8.p.rapidapi.com");

                var responce = await client.GetStringAsync($"https://imdb8.p.rapidapi.com/title/get-base?tconst={movieId}");

                movieBaseInfo = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       
        //https://imdb8.p.rapidapi.com/title/get-top-cast?tconst=tt0944947 - top cast for a movie
        //https://imdb8.p.rapidapi.com/actors/get-bio?nconst=nm0001667 - persons bio
        //https://imdb8.p.rapidapi.com/title/get-full-credits?tconst=tt0786945 - acst and crew in a movie

    }
}
