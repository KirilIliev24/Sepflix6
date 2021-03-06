using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP6_TEST.DTO;
using SEP6_TEST.Models;

namespace SEP6_TEST.DbAccess
{
    public interface ILikedMoviesDb
    {
        public void addMovieToLiked(string username, int movieId);
        public void deleteALikedMovie(string username, int movieId);
        public Task<List<MovieDTO>> getAllLikedMovies(string username);
        public bool IsMovieInLikedlist(int id);

        public bool islikedMovieInLikedDB(int movieId, string username);
        public void addLikedMovieToList(int movieId);

        public void deleteLikedMovieFromList(int movieId);
    }
}
