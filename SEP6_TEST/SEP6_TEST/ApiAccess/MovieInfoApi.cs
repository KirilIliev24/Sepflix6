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
        public PersonsBiography bio { get; private set; } = new PersonsBiography();
        public MovieInfoApi(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient();
        }

        //maybe add a clear method and a call all method
        public async Task GetAllMovieInfo(int movieId)
        {
            try
            {
                await GetMoviePlotAsync(movieId);
                await GetMovieCreditsAsync(movieId);
                await GetMovieReviewsAsync(movieId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task GetMoviePlotAsync(int movieId)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                //maybe move these keys to the app settings

                var responce = await client.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key=de4ac8654829c3ed659e8a98438c14f9&language=en-US");

                var plot = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);
                var genre = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);
                movieBaseInfo.overview = plot.overview;
                movieBaseInfo.genres = genre.genres;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task GetMoviePosterAsync(int movieId)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                //maybe move these keys to the app settings
                //client.DefaultRequestHeaders.Add("api_key", "de4ac8654829c3ed659e8a98438c14f9");

                var responce = await client.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}/images?api_key=de4ac8654829c3ed659e8a98438c14f9");

                var listOfPosterLinks = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);

                string filePath = listOfPosterLinks.posters.First().file_path;

                Poster posterLink = new Poster()
                { 
                    file_path = $"https://image.tmdb.org/t/p/w500/{filePath}"
                };
                movieBaseInfo.posters.Add(posterLink);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task GetMovieCreditsAsync(int movieId)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                //maybe move these keys to the app settings
                client.DefaultRequestHeaders.Add("api_key", "de4ac8654829c3ed659e8a98438c14f9");

                var responce = await client.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}/credits?api_key=de4ac8654829c3ed659e8a98438c14f9&language=en-US");

                var crewMembers = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);
                var castMembers = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);

                movieBaseInfo.crew = crewMembers.crew;
                movieBaseInfo.cast = castMembers.cast;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task GetMovieReviewsAsync(int movieId)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                //maybe move these keys to the app settings
                client.DefaultRequestHeaders.Add("api_key", "de4ac8654829c3ed659e8a98438c14f9");

                var responce = await client.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}/reviews?api_key=de4ac8654829c3ed659e8a98438c14f9&language=en-US");

                var results = JsonConvert.DeserializeObject<MovieBaseInfo>(responce);

                movieBaseInfo.results = results.results;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //need to move to a sepparate class
        public async Task GetPersonsBioAsync(int personId)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                //maybe move these keys to the app settings
                client.DefaultRequestHeaders.Add("api_key", "de4ac8654829c3ed659e8a98438c14f9");

                var responce = await client.GetStringAsync($"https://api.themoviedb.org/3/person/{personId}?api_key=de4ac8654829c3ed659e8a98438c14f9&language=en-US");

                var results = JsonConvert.DeserializeObject<PersonsBiography>(responce);

                if(results.deathday is null)
                {
                    results.deathday = "";
                }
                bio = results;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
