using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();
        List<Movie> GetMovieByTitle(string title);

        Movie GetMovieById(int id);

        Movie GetMovieDetails(int id);

        void CreateMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(Movie movie);
        List<Movie> GetMostRecentMovies(int count);
        List<Movie> GetTopMovies(int count);
    }
}
