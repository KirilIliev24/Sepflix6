﻿using SEP6_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DTO;
namespace SEP6_TEST.DbAccess
{
    public class WatchlistDb : IWatchListDb
    {
        MovieInfoDb MovieInfoDb = new MovieInfoDb();
        
        public List<int> movieId { get; private set; } = new List<int>();
        private List<MovieDTO> movieDTOs { get; set; } = new List<MovieDTO>();

        public void addMovieToWatchlist(string username, int movieId)
        {
            using (var context = new SqlServerSep6Context())
            {
                var watchlist = new Watchlist();
                watchlist.Username = username;
                watchlist.MovieId = movieId;
                context.Watchlists.Add(watchlist);
                context.SaveChanges();
            }
        }
        public void removeMovieFromWatchList(string username, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieDTO>> GetAllMoviesInWatchList(string username)
        {
            using (var context = new SqlServerSep6Context())
            {

                try
                {
                    movieId = await Task.Run(() => context.Watchlists.Where(n => n.Username.Equals(username)).Select(w => w.MovieId).ToList());

                    foreach (var movie in movieId)
                    {
                        movieDTOs.Add(await MovieInfoDb.getMovieByID(movie));


                    }
                    return movieDTOs;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return movieDTOs;
                }

            }
        }

        
    }
}